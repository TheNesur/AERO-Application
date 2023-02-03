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

                    RegulateurLiaisonSerie.Open();
                    CapeurlLogBox.Text = "Liaison Série -> Démarrée";
                    EoliaLogs.Write("Liaison série démarée", EoliaLogs.Types.SERIAL);
                    LireSerie = true;
                    readThread = new Task(Lire);
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
          écrire requête de donné demande 
            1 octet         1 octet      2 octet                   1 octet         2 octet 
            add esclave     fonction     Adresse frist mot         nb de mot       crc16
            XXXX XXXX       XXXX XXXX    XXXX XXXX|XXXX XXXX       XXXX XXXX       XXXX XXXX | XXXX XXXX
            0000 0001       0000 0011    0011 0001 0000 0000       0000 0100       0100 1010   1111 0101    
              0     1       0       3       3  1    0   0           0   4           4     A     F     5
         */   
       private static void messageDemandeInfo(byte[] message )
        {
            byte AdresseEsclave;
            byte Fonction;
            switch (Fonction){ // change selon la valeur de la variable fonction 
                case 0x03 |0x04:{
                    byte[2] AdressePremiersMot;
                    byte[2] NbMot;
                    message =new byte [8] ;   
                    Array.Copy (AdresseEsclave,0,message,0);
                    Array.Copy (Fonction,0,message,1 );
                    Array.Copy (AdressePremiersMot,0,message,2);
                    Array.Copy (NbMot,0,message,4);
                    AjoutCRCEnvoie(CRC(message));
                }
                break;
                case 0x06:{
                    byte[2] AdresseDuMot;
                    byte[2] ValeurDuMot;
                    message =new byte [8] ;  
                    Array.Copy (AdresseEsclave,0,message,0);
                    Array.Copy (Fonction,0,message,1 );
                    Array.Copy (AdressePremiersMot,0,message,2);
                    Array.Copy (NbMot,0,message,4);
                    AjoutCRCEnvoie(CRC(message));   
                }
                break;
            }
        }
        
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
                            VerifierCRCRecu(message);
                            
                            else
                            {
                                switch(message[2]<0x80){
                                    case 0x83 |0x84 : CapeurlLogBox.text ="il y a eu une erreur dans la lecture ";
                                    break;
                                    case 0x86 : CapeurlLogBox.text ="il y a eu une erreur dans l'écriture du mot ";
                                    break;
                                    case 0x90 : CapeurlLogBox.text ="il y a eu une erreur dans l'écriture des mots ";
                                    break;
                                }
                            }
                        }
                       //Verifi la Commande message);
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
