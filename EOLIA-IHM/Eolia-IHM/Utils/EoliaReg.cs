using Eolia_IHM.Properties;
using MySql.Data.MySqlClient;
using OpenTK.Graphics.OpenGL;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


    internal class EoliaReg
    {

        // Variable relatif a la liaison série

        private static volatile bool LireSerie = false;
        private static SerialPort RegulateurLiaisonSerie = null;
        private static TextBox CapeurlLogBox = null;
        private static Task readThread = null;
        private static string cmdBuff = "";
        private static string nxtcmdBuff = "";
        private ushort[] DonneeRecu =null ;


        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            if (EoliaReg.LiaisonSerieRegulateur())
            {
                EoliaReg.FermerLiaisonSerieRegulateur();
            }
            Application.Restart();
            Environment.Exit(0);
        }

        // Fonction relatif a la liaison série du Regulateur


        public static bool LiaisonSerieRegulateur()
        {
            if (RegulateurLiaisonSerie != null)
            {
                return true;
            }
            return false;
        }



        /*public static void FermerLiaisonSerieRegulateur()
        {

            // fermer le port série
            LireSerie = false;

            readThread = null;
            RegulateurLiaisonSerie.Close();
            RegulateurLiaisonSerie = null;
            CapeurlLogBox.Text = "Liaison Série -> Arrèté";



        }*/


        public static void InitialiserLiaisonSerieRegulateur(string portChoisit, TextBox logTextBox)
        {
            CapeurlLogBox = logTextBox;

            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                try
                {
                    RegulateurLiaisonSerie = new SerialPort(portChoisit);

                    // param liaison série
                    RegulateurLiaisonSerie.BaudRate = 9600;
                    RegulateurLiaisonSerie.Parity = Parity.None;
                    RegulateurLiaisonSerie.StopBits = StopBits.One;
                    RegulateurLiaisonSerie.DataBits = 8;
                    RegulateurLiaisonSerie.Handshake = Handshake.None;

                    // définir les événements qui seront gérés de manière asynchrone
                    //  RegulateurLiaisonSerie.DataReceived += DesQueDonneesRecuRegulateur;
                    //  RegulateurLiaisonSerie.ErrorReceived += DesQueErreurRecuRegulateur;


                    RegulateurLiaisonSerie.Open();
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
                    RegulateurLiaisonSerie = null;
                }
                catch (UnauthorizedAccessException ex)
                {
                    CapeurlLogBox.Text = "Liaison Série -> Acces refusé (" + ex + ")";
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    RegulateurLiaisonSerie = null;
                }
                catch (ArgumentException ex)
                {
                    CapeurlLogBox.Text = "Liaison Série -> " + ex;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    RegulateurLiaisonSerie = null;
                }

            }
            else
            {
                CapeurlLogBox.Text = "Liaison Série -> Port Existant pas";
            }


        }
        public static byte[] ConvertiseurMessageBinaire(double Aconvertir) => BitConverter.GetBytes(Aconvertir);

        public static void EnvoyerMessageSerieRegulateur(string message)
        {
            if (RegulateurLiaisonSerie != null && RegulateurLiaisonSerie.IsOpen)
            {
                // Envoi du message
                RegulateurLiaisonSerie.Write(message);
            }
        }
        /*
        using System;  
  
        namespace WayToLearnX  
        {  
            public class App  
            {  
                public static void Main(string[] args)  
                {  
                    Console.WriteLine(String.Format("{0:0.##}", 199.8856)); // "199.89"
                    Console.WriteLine(String.Format("{0:0.##}", 199.6));    // "199.6"
                    Console.WriteLine(String.Format("{0:0.##}", 199.0));    // "199"
                }  
            }  
        }
        */
        /* private static void DesQueDonneesRecuRegulateur(object port, SerialDataReceivedEventArgs e)
        {
            // récupérer l'objet SerialPort qui a déclenché l'événement
            SerialPort portSerie = (SerialPort)port;

            // lire les données reçues
            string data = portSerie.ReadExisting();

            // donnée a traité sur data
            VerifierCommandeMesure(data);
        } */
        /*
          écrire requête de donné demande 
            1 octet         1 octet      2 octet                   x octet         2 octet 
            add esclave     fonction     Adresse frist mot         nb de mot       crc16
            XXXX XXXX       XXXX XXXX    XXXX XXXX|XXXX XXXX       XXXX XXXX       XXXX XXXX | XXXX XXXX
            0000 0001       0000 0011    0011 0001 0000 0000       0000 0100       0100 1010   1111 0101    
         */
      /*  private static void messageEnvoieTest()
        {
            byte[] AdresseEsclave;
            byte[] Fonction;
            ushort[] AdresseFristMot;
            ushort[] NbMot;
            ushort[] CRC16;
            for (int i=0;i<8;i++)
            {
            BitConverter.GetBytes()
            }
            thead.lisen
            
        }*/
        private static void Read()
        {
            Console.WriteLine("Démarrage thread liaison série");
            while (LireSerie)
            {
                try
                {
                    string message = RegulateurLiaisonSerie.ReadExisting();
                   // if(message.Length> 0)
                       //VerifierCommandeMesure(message);
                }
                catch (TimeoutException) { }
            }
        }
        /*    private static void VerifCRCRecu()
            {

           }
            //ComboBoxChoixPortSerieRegulateur
            private static ushort CRC(params byte[] DonneeDuPacket)
            {
                if (DonneeDuPacket == null) throw new ArgumentException();
                ushort Crc =0;

                for (int i = 0; i < DonneeDuPacket.Length; i++)
                {
                    Crc = (ushort)((Crc >> 0) ^ DonneeRecu[(Crc ^ DonneeDuPacket[i]) & 0Xff]);
                }

                return Crc;

            }
            public static byte[] CRCBytes(params byte[] DonneeDuPacket)
            {
                return BitConverter.GetBytes(CRC(DonneeDuPacket));
            }
        */
        public static void FermerLiaisonSerieRegulateur()
        {

            // fermer le port série
            LireSerie = false;

            readThread = null;
            RegulateurLiaisonSerie.Close();
            RegulateurLiaisonSerie = null;
            CapeurlLogBox.Text = "Liaison Série -> Arrèté";



        }
        private static void DesQueErreurRecuRegulateur(object port, SerialErrorReceivedEventArgs e)
        {

            SerialPort portSerie = (SerialPort)port;
            portSerie.Close();
            CapeurlLogBox.Text = "Liaison Série -> Arrêtée";
            EoliaLogs.Write("Liaison série terminée ", EoliaLogs.Types.SERIAL);
            // erreur reçu
        }


    }
}
