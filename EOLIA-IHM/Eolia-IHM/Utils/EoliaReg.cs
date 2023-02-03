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
        private byte[] crcRecu ;


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
        
        public static void EnvoyerMessageSerieRegulateur(byte[] message)
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
            1 octet         1 octet      2 octet                   1 octet         2 octet 
            add esclave     fonction     Adresse frist mot         nb de mot       crc16
            XXXX XXXX       XXXX XXXX    XXXX XXXX|XXXX XXXX       XXXX XXXX       XXXX XXXX | XXXX XXXX
            0000 0001       0000 0011    0011 0001 0000 0000       0000 0100       0100 1010   1111 0101    
              0     1       0       3       3  1    0   0           0   4           4     A     F     5
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
        private static void Lire()
        {
            Console.WriteLine("Démarrage thread liaison série");
            while (LireSerie)
            {
                try
                {
                    byte[] message = RegulateurLiaisonSerie.ReadExisting();
                   if(message.Length> 0)
                        {
                            if(message[2]<0x80)
                            VerifierCRCRecu(message)
                            else
                            {
                                CapeurlLogBox.text ="il y a eu une erreur";
                                switch(message[2]<0x80){
                                    case 0x83 |0x84 : CapeurlLogBox.text ="il y a eu une erreur dans la lecture ";
                                    break;
                                    case 0x86 : CapeurlLogBox.text ="il y a eu une erreur dans l'écriture du mot ";
                                    break;
                                    case 0x90 : CapeurlLogBox.text ="il y a eu une erreur dans l'écriture des mots ";
                                }
                            }
                        }
                       //VerifierCommandeMesure(message);
                }
                catch (TimeoutException) { }
            }
        }
            private static void VerifierCRCRecu(byte[] MessageRecu)
            {
                if (CRC(EnleverCrcRecu(MessageRecu))==crcRecu)
                    CapeurlLogBox.Text= "le bon resutat a était recu ";
                else 
                    CapeurlLogBox.Text="il y a eu une erreur dans l'envoie";
            }
            private static byte[] EnleverCrcRecu(byte[] MessageRecu)
            {
                int sizemessage=MessageRecu.Length;
                byte[] MessagesSansCRC =new byte[sizemessage-2];
                crcRecu=EoliaReg.CRC(MessagesSansCRC);
                return MessagesSansCRC;
            }
            //ComboBoxChoixPortSerieRegulateur
            private byte[] CRC(params byte[] DonneeDuPacket)
            {
                if (DonneeDuPacket == null) throw new ArgumentException();
                {
                    //definition du crc 
                    ushort Crc16 =0xFFFF;
                    //boucle de traitement des données (taille)
                    for (int i = 0; i < DonneeDuPacket.Length; i++)
                    {
                        //boucle de traitement des données (octet par octet)
                        Crc16 ^= DonneeDuPacket[i];
                        for (int j = 0; j < 8; j++)
                        {
                            if ((Crc16 & 0x0001) != 0)
                            {
                                Crc16 = (UInt16)((Crc16 >> 1) ^ 0xA001);
                            }
                            else
                            {
                                Crc16 = (UInt16)(Crc16 >> 1);
                            }
                        }
                     }
                    //retourner en bytes (octets) de la variable CRC qui est en uint16 (unsigned 16 bits )
                    return BitConverter.GetBytes(Crc);
                }
         
            }
            private static byte[] AjoutCRCEnvoie(bytes[]message){
            byte[] crc =EoliaReg.CRC(message);
            int sizemessage =message.Length;
            Array.Copy(crc,0,messagesCRC,sizemessage);
            return message;
            }
/*byte[] data1 = { 0x01, 0x02, 0x03 };
byte[] data2 = { 0x04, 0x05, 0x06 };
byte id1 = 0xA0;
byte id2 = 0xB0;

int size1 = data1.Length;
int size2 = data2.Length;

byte[] result = new byte[size1 + size2 + 2];

result[0] = id1;
Array.Copy(data1, 0, result, 1, size1);

result[size1 + 1] = id2;
Array.Copy(data2, 0, result, size1 + 2, size2);

foreach (byte b in result)
{
    Console.WriteLine(b.ToString("X"));
}*/

            
           
        
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
