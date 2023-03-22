using Eolia_IHM.Menu;
using Eolia_IHM.Properties;
using Eolia_IHM.Utils;
using MySql.Data.MySqlClient;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
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
        private static Label CapteurlLogBox = null;
        private static Task readThread = null;
        private static string cmdBuff = "";
        private static string nxtcmdBuff = "";

        // Variable relatif a la gestion ges mesures

        private static List<float> ListeMesureTrainee = null;
        private static List<float> ListeMesurePortance = null;
        private static List<float> ListeVitesse = null;

        private static bool EnregistreMesure = false;
        private static Label LabelMesTrainee = null;
        private static Label LabelMesPortance = null;
        private static TextBox ReponseCMDMesure = null;
        private static bool TransmissionMesure = false;
        private static Label LabelValMoyenneTrainee = null;
        private static Label LabelValMoyennePortance = null;
        private static Label LabelNombreDeMesure = null;
        private static Label LabelNomSessionMesure = null;
        private static bool SauveVitesse;
        private static string NomSessionMesure = null;
        private static Label LabelEtatSession = null;
        private static bool photo = false;
        private static bool video = false;
        private static string RepEnregistrement = null;

        private static String directoryVideo = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/VIDEO/";
        private static String directoryImage = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/IMG/";

        // Fonction relatif a la gestion des mesures

        public static void InitialiserTransMes(TextBox RepMsg, Label LabelMesPort, Label LabelMesTra, string FMES, string EQGVOLTPORTANCE, string EQGVOLTTRAINEE)
        {
            LabelMesTrainee = LabelMesTra;
            LabelMesPortance = LabelMesPort;
            ReponseCMDMesure = RepMsg;
            TransmissionMesure = true;
            ReponseCMDMesure.AppendText( "Envoi de la requete a l'ESP32 sur le port "+ CapteurLiaisonSerie.PortName +"\r\n\r\n");
            EnvoyerMessageSerieCapteur("START " + FMES + " EQGVOLTPORTANCE " + EQGVOLTPORTANCE + " EQGVOLTTRAINEE " + EQGVOLTTRAINEE);

        }

        public static string PortancePretPourEnvoi()
        {
            string PortanceFormate = ""; // Initialise une chaine de caractere vide
            if (SessionMesureDispo()) // Vérifie que une session n'est pas en cours    
            {                         // d'enregistrement et qu'il y a bien des mesures
                for(int i = 0; i < ListeMesurePortance.Count(); i++)
                { // Traite l'ensemble de la liste
                    PortanceFormate= PortanceFormate + ListeMesurePortance[i].ToString();
                    if(ListeMesurePortance.Count()-1 != i) 
                    {
                        PortanceFormate = PortanceFormate + ";"; // sépare les mesures par des ";" sauf 
                    }                                            //la dernière qui n'est pas suivie de ";"
                }                                                  
                return PortanceFormate.Replace(",", "."); // Le Replace est simplement une sécurité pour 
            }                                             // être sure que les "." ne sont pas des "," 
            else
            {
                return "";
            }
        }

        public static string ObtenirPortance()
        {
            if(LabelMesPortance != null)
                return LabelMesPortance.Text;
            return "";
        }



        public static string ObtenirTrainee()
        {
            if (LabelMesPortance != null)
                return LabelMesTrainee.Text;
            return "";
        }

        public static string ObtenirRepPhoto()
        {

            if (photo)
            {
                return RepEnregistrement;
            }
            return "NULL";
        }

        public static string ObtenirRepVideo()
        {
            if (video)
            {
                return RepEnregistrement;
            }
            return "NULL";
        }

        public static string TraineePretPourEnvoi()
        {
            string TraineeFormate = "";
            if (SessionMesureDispo())
            {

                return TraineeFormate.Replace(",", "."); ;
            }
            else
            {
                return "";
            }
        }

        public static string RequeteMesurePrete(int idSession)
        {
            string MesureFormate = "";
          //  if (SessionMesureDispo())
           // {
                for (int i = 0; i < ListeMesureTrainee.Count(); i++)
                {
                    MesureFormate = MesureFormate + "(NULL,'" + ListeMesurePortance[i].ToString().Replace(",", ".") + "','" + ListeMesureTrainee[i].ToString().Replace(",", ".") + "','0','" + idSession + "')";
                    if (ListeMesureTrainee.Count() - 1 != i)
                    {
                        MesureFormate = MesureFormate + ",";
                    }
                }
                return MesureFormate;
          //  }
         //   return "";
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

        public static void ReinitialiserSession()
        {
            ListeMesurePortance = null;
            ListeMesureTrainee = null;
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


        public static bool EnregistrementMes(Label labelValMoyenneTrainee, Label labelValMoyennePortance, Label labelNomSessionMesure, Label labelNombreDeMesure, Label labelEtatSession, bool prendrePhoto, bool prendreVideo, bool prendreVitesse)
        {
            if (!EnregistreMesure)
            {
                ListeMesureTrainee = null;
                ListeMesurePortance = null;
                ListeMesurePortance = new List<float>();
                ListeMesureTrainee = new List<float>();
                ListeVitesse= new List<float>();

                LabelNomSessionMesure = labelNomSessionMesure;
                LabelNombreDeMesure = labelNombreDeMesure;
                LabelValMoyennePortance = labelValMoyennePortance;
                LabelValMoyenneTrainee = labelValMoyenneTrainee;
                LabelEtatSession = labelEtatSession;


                RepEnregistrement = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                if (prendreVideo)
                {
                    video = true;
                    // RepEnregistrement
                    EoliaCam.StartSaveVideo(directoryVideo + RepEnregistrement);
                }
                else {                 
                    photo = prendrePhoto;
                }

                SauveVitesse = prendreVitesse;



                NomSessionMesure = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");

                LabelEtatSession.Text = "Session lancée";
                LabelNomSessionMesure.Text = NomSessionMesure;
                LabelValMoyennePortance.Text = "0";
                LabelValMoyenneTrainee.Text = "0";
                LabelNombreDeMesure.Text = "0";
                EnregistreMesure = true;
                EoliaLogs.Write("Enregistrement mesure démarée", EoliaLogs.Types.SERIAL);
                return false;
                
            }

            if (prendreVideo)
                EoliaCam.StopSaveVideo();
            EoliaLogs.Write("Enregistrement mesure arrêtée", EoliaLogs.Types.SERIAL);
            EnregistreMesure = false;
            LabelEtatSession.Text = "Session arrêtée";
            return true;
        }

        public static void ArreterTransMes()
        {
            EnvoyerMessageSerieCapteur("STOP");
            EoliaLogs.Write("Transmission mesure arrêtée", EoliaLogs.Types.SERIAL);
            ReponseCMDMesure.AppendText( "Transmission des mesures arrêtés\r\n\r\n");

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
            cmdBuff.Replace("\r\n", String.Empty);
            EoliaLogs.Write("Commande liaison série capteur reçue " + cmdBuff, EoliaLogs.Types.SERIAL);
            bool CommandeAvecMessage; // sera mise a true si la commande contient un message
            string[] words = cmdBuff.Split(' ');
            if (words.Length < 1) // découpe les arguments de la commande
            {                     // pour l'exploiter ensuite
                cmdBuff = "";
                return;
            }

            // Vérifie la commande
            if (words[0] == "MSG")
            {
                CommandeAvecMessage = true;
            }
            else if (words[0] == "PORTANCE" && words[2] == "TRAINEE")
            {
                CommandeAvecMessage = false;
            }
            else // si aucune des conditions précédentes commande non existante
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



                ReponseCMDMesure.Invoke(new Action(() => ReponseCMDMesure.AppendText( message+ "`\r\n\r\n")));
            }
            else
            {
                float portance, trainee;
                string strPort = words[1];
                string strTra = words[3];
                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!float.TryParse(strPort, NumberStyles.Float, culture, out portance) || !float.TryParse(strTra, NumberStyles.Float, culture, out trainee))
                {
                    cmdBuff = "";
                    return;
                }

                    LabelMesTrainee.Invoke(new Action(() => LabelMesTrainee.Text = trainee.ToString()));
                    LabelMesPortance.Invoke(new Action(() => LabelMesPortance.Text = portance.ToString()));
                
                if (EnregistreMesure)
                {
                    ListeMesureTrainee.Add(trainee);
                    ListeMesurePortance.Add(portance);

                    LabelValMoyenneTrainee.Invoke(new Action(() => LabelValMoyenneTrainee.Text = ListeMesureTrainee.Average().ToString()));
                    LabelValMoyennePortance.Invoke(new Action(() => LabelValMoyennePortance.Text = ListeMesurePortance.Average().ToString()));
                    LabelNombreDeMesure.Invoke(new Action(() => LabelNombreDeMesure.Text = ListeMesurePortance.Count().ToString()));

                    if (photo)
                        EoliaCam.SavePicture(directoryImage + RepEnregistrement, true);
                    if (SauveVitesse)
                        ListeVitesse.Add(EoliaReg.obtenirVitesse());



                }


                
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
            CapteurlLogBox.Text = "Arrèté";
            CapteurlLogBox.ForeColor = System.Drawing.Color.Red;
            EoliaLogs.Write("Liaison série ESP32 arrêtée", EoliaLogs.Types.SERIAL);


        }

        public static void InitialiserLiaisonSerieCapteur(string portChoisit, Label logTextBox)
        {
            CapteurlLogBox = logTextBox;

            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                try
                {
                    CapteurLiaisonSerie = new SerialPort(portChoisit)
                    {
                        // param liaison série
                        BaudRate = 9600,
                        Parity = Parity.None,
                        StopBits = StopBits.One,
                        DataBits = 8,
                        Handshake = Handshake.None
                    };

                    CapteurLiaisonSerie.Open();
                    CapteurlLogBox.Text = " Démarrée";
                    CapteurlLogBox.ForeColor = System.Drawing.Color.Green;
                    EoliaLogs.Write("Liaison série ESP32 démarrée", EoliaLogs.Types.SERIAL);
                    LireSerie = true;
                    readThread = new Task(Read);
                    readThread.Start();

                }
                catch (IOException ex)
                {
                    CapteurlLogBox.Text = "Arret " ;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }
                catch (UnauthorizedAccessException ex)
                {
                    CapteurlLogBox.Text = "Acces refusé ";
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }
                catch (ArgumentException ex)
                {
                    CapteurlLogBox.Text = "Erreur";
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    CapteurLiaisonSerie = null;
                }

            }
            else
            {
                CapteurlLogBox.Text = "Pb port";
                CapteurlLogBox.ForeColor = System.Drawing.Color.Red;
            }


        }

        public static void EnvoyerMessageSerieCapteur(string message)
        {
            if (CapteurLiaisonSerie != null && CapteurLiaisonSerie.IsOpen)
            {
                // Envoi du message
                CapteurLiaisonSerie.Write(message + " /r/n");
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
            while (LireSerie) // condition de sortie
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
            CapteurlLogBox.Text = "Arrêtée";
            CapteurlLogBox.ForeColor = System.Drawing.Color.Red;
            EoliaLogs.Write("Liaison série terminée ", EoliaLogs.Types.SERIAL);
            // erreur reçu
        }


    }
}
