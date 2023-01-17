using Eolia_IHM.Properties;
using MySql.Data.MySqlClient;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{


    internal class EoliaMes
    {

        // Variable relatif a la liaison série

        private static volatile bool LireSerie = false;
        private static SerialPort CapteurLiaisonSerie = null;
        private static TextBox CapeurlLogBox = null;
        private static Task readThread = null;
        private static string cmdBuff = "";
        private static string nxtcmdBuff = "";

        // Variable relatif a la gestion ges mesures

        private static List<float> ListeMesureTrainee = null;
        private static List<float> ListeMesurePortance = null;
        private static bool EnregistreMesure = false;
        private static Label LabelMesTrainee = null;
        private static Label LabelMesPortance = null;
        private static Label ReponseCMDMesure = null;
        private static bool TransmissionMesure = false;
        private static Label LabelValMoyenneTrainee = null;
        private static Label LabelValMoyennePortance = null;
        private static Label LabelNombreDeMesure = null;
        private static Label LabelNomSessionMesure = null;
        private static string NomSessionMesure = null;
        private static Label LabelEtatSession = null;



        // Fonction relatif a la gestion des mesures

        public static void InitialiserTransMes(Label RepMsg, Label LabelMesPort, Label LabelMesTra, TextBox nbMesureSec)
        {
            LabelMesTrainee = LabelMesTra;
            LabelMesPortance = LabelMesPort;
            ReponseCMDMesure = RepMsg;
            TransmissionMesure = true;
            ReponseCMDMesure.Text = "Les mesures reçues seront afichées au dessus";
            EnvoyerMessageSerieCapteur("START " + nbMesureSec.Text);

        }

        public static void TarerCapteur()
        {
            EnvoyerMessageSerieCapteur("TARAGE");
        }

        public static bool EtatTransMes()
        {
            if (TransmissionMesure)
            {
                return true;
            }
            return false;
        }

        public static bool SessionMesureDispo()
        {
            if (EnregistreMesure)
            {
                EoliaUtils.MsgBoxNonBloquante("Vous ne pouvez pas enregistrer la session tant que les mesures sont en cours");
                return false;
            }
            if (ListeMesurePortance != null)
            {
                if (ListeMesurePortance.Count() > 0)
                    return true;
            }
            return false;
        }


        public static bool EnregistrementMes(Label labelValMoyenneTrainee, Label labelValMoyennePortance, Label labelNomSessionMesure, Label labelNombreDeMesure, Label labelEtatSession)
        {
            if (!EnregistreMesure)
            {
                ListeMesureTrainee = null;
                ListeMesurePortance = null;
                ListeMesurePortance = new List<float>();
                ListeMesureTrainee = new List<float>();
                LabelNomSessionMesure = labelNomSessionMesure;
                LabelNombreDeMesure = labelNombreDeMesure;
                LabelValMoyennePortance = labelValMoyennePortance;
                LabelValMoyenneTrainee = labelValMoyenneTrainee;
                LabelEtatSession = labelEtatSession;


                NomSessionMesure = DateTime.Now.ToString("MM/dd/yyyy_HH:mm:ss");

                LabelEtatSession.Text = "Oui";
                LabelNomSessionMesure.Text = NomSessionMesure;
                LabelValMoyennePortance.Text = "0";
                LabelValMoyenneTrainee.Text = "0";
                LabelNombreDeMesure.Text = "0";
                EnregistreMesure = true;
                return false;
            }

            EnregistreMesure = false;
            LabelEtatSession.Text = "Non";
            return true;
        }

        public static void ArreterTransMes()
        {
            EnvoyerMessageSerieCapteur("STOP");

            ReponseCMDMesure.Text = "Transmission des mesures arrêtés";

            LabelMesTrainee = null;
            LabelMesPortance = null;
            ReponseCMDMesure = null;


            TransmissionMesure = false;


        }

        public static void VerifierCommandeMesure(string command)
        {
             if (!TransmissionMesure)
                    return;

            cmdBuff = cmdBuff + nxtcmdBuff;
            cmdBuff = cmdBuff + command;
            if (cmdBuff.IndexOf("\r\n") != -1)
            {
                command = cmdBuff;

                cmdBuff = cmdBuff.Substring(0, cmdBuff.IndexOf("\r\n") + 2);
                nxtcmdBuff = cmdBuff.Substring(cmdBuff.IndexOf("\r\n") + 2);

                
            }
            else
            {
                return;
            }


            bool CommandeAvecMessage;
            string[] words = cmdBuff.Split(' ');
            if (words.Length < 1)
            {
                cmdBuff = "";
                return;
            }

            // On vérifie que le premier mot de la commande est "PORTANCE" et que le troisième mot est "TRAINEE" et que le quatrième mot est "MSG"
            if (words[0] == "MSG")
            {
                CommandeAvecMessage = true;
            }
            else if (words[0] == "PORTANCE" && words[2] == "TRAINEE")
            {
                CommandeAvecMessage = false;
               
            }
            else
            {
                cmdBuff = "";
                return;
            }



            if (CommandeAvecMessage)
            {
                // On fusion tous les mots qui suivent dans une chaîne de caractères
                string message = "";
                for (int i = 1; i < words.Length; i++)
                {
                    message += words[i] + " ";
                }

                // On enleve l'espace en fin de chaîne
                message = message.TrimEnd();



                ReponseCMDMesure.Invoke(new Action(() => ReponseCMDMesure.Text = message));
            }
            else
            {
                float portance, trainee;
                if (!float.TryParse(words[1], out portance) || !float.TryParse(words[3], out trainee))
                {
                    cmdBuff = "";
                    return;
                }
                if (EnregistreMesure)
                {
                    ListeMesureTrainee.Add(trainee);
                    ListeMesurePortance.Add(portance);

                    LabelValMoyenneTrainee.Invoke(new Action(() => LabelValMoyenneTrainee.Text = ListeMesureTrainee.Average().ToString()));
                    LabelValMoyennePortance.Invoke(new Action(() => LabelValMoyennePortance.Text = ListeMesurePortance.Average().ToString()));
                    LabelNombreDeMesure.Invoke(new Action(() => LabelNombreDeMesure.Text = ListeMesurePortance.Count().ToString()));

                }

                LabelMesTrainee.Invoke(new Action(() => LabelMesTrainee.Text = words[1]));
                LabelMesPortance.Invoke(new Action(() => LabelMesPortance.Text = words[3]));
                
            }




            cmdBuff = "";

        }


        // Fonction relatif a la liaison série du capteur


        public static bool LiaisonSerieCapteur()
        {
            if (CapteurLiaisonSerie != null)
            {
                return true;
            }
            return false;
        }



        public static void FermerLiaisonSerieCapteur()
        {

            // fermer le port série
            LireSerie = false;
            
            readThread = null;
            CapteurLiaisonSerie.Close();
            CapteurLiaisonSerie = null;
            CapeurlLogBox.Text = "Liaison Série -> Arrèté";
           


        }

        public static void InitialiserLiaisonSerieCapteur(string portChoisit, TextBox logTextBox)
        {
            CapeurlLogBox = logTextBox;

            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                try
                {
                    CapteurLiaisonSerie = new SerialPort(portChoisit);

                    // param liaison série
                    CapteurLiaisonSerie.BaudRate = 9600;
                    CapteurLiaisonSerie.Parity = Parity.None;
                    CapteurLiaisonSerie.StopBits = StopBits.One;
                    CapteurLiaisonSerie.DataBits = 8;
                    CapteurLiaisonSerie.Handshake = Handshake.None;

                    // définir les événements qui seront gérés de manière asynchrone
                    //  CapteurLiaisonSerie.DataReceived += DesQueDonneesRecuCapteur;
                    //  CapteurLiaisonSerie.ErrorReceived += DesQueErreurRecuCapteur;
                    

                    CapteurLiaisonSerie.Open();
                    CapeurlLogBox.Text = "Liaison Série -> Démarrée";
                    EoliaLogs.Write("Liaison série démarée", EoliaLogs.Types.SERIAL);
                    LireSerie = true;
                    readThread = new Task(Read);
                    readThread.Start();

                }
                catch (IOException ex)
                {
                    CapeurlLogBox.Text = "Liaison Série -> " + ex;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }
                catch (UnauthorizedAccessException ex)
                {
                    CapeurlLogBox.Text = "Liaison Série -> Acces refusé ("+ex+")";
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }
                catch (ArgumentException ex)
                {
                    CapeurlLogBox.Text = "Liaison Série -> " + ex;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }

            }
            else
            {
                CapeurlLogBox.Text = "Liaison Série -> Port Existant pas";
            }


        }

        public static void EnvoyerMessageSerieCapteur(string message)
        {
            if (CapteurLiaisonSerie != null && CapteurLiaisonSerie.IsOpen)
            {
                // Envoi du message
                CapteurLiaisonSerie.Write(message);
            }
        }


        /* private static void DesQueDonneesRecuCapteur(object port, SerialDataReceivedEventArgs e)
        {
            // récupérer l'objet SerialPort qui a déclenché l'événement
            SerialPort portSerie = (SerialPort)port;

            // lire les données reçues
            string data = portSerie.ReadExisting();

            // donnée a traité sur data
            VerifierCommandeMesure(data);
        } */

        private static void Read()
        {
            Console.WriteLine("Démarrage thread liaison série");
            while (LireSerie)
            {
                try
                {
                    string message = CapteurLiaisonSerie.ReadExisting();
                    if(message.Length> 0)
                        VerifierCommandeMesure(message);
                }
                catch (TimeoutException) { }
            }
        }

        private static void DesQueErreurRecuCapteur(object port, SerialErrorReceivedEventArgs e)
        {

            SerialPort portSerie = (SerialPort)port;
            portSerie.Close();
            CapeurlLogBox.Text = "Liaison Série -> Arrêtée";
            EoliaLogs.Write("Liaison série terminée ", EoliaLogs.Types.SERIAL);
            // erreur reçu
        }


    }
}
