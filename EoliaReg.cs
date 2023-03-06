using Eolia_IHM.Properties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using OpenTK.Graphics.OpenGL;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eolia_IHM.Menu;
using Iot.Device.Ip5306;

namespace Eolia_IHM
{


    internal class EoliaReg
    {
       

        // Variable relatif a la liaison série

        private static volatile bool LireSerie = false;
        private static SerialPort RegulateurLiaisonSerie = null;
        private static Label ReguleurlLogBox = null;
        private static Task readThread = null;
        private static Task readThreadInfini = null
        private static byte[] MessageEcoute = [0x01, 0x03, 0x00, 0x2A, 0x04 ,0x07, 0x27];
        private static byte[] crcRecu= new byte[1];

        // variable relatif a la communication au Régulateur 
        private Label labelVitesse = null;
        private static Button RecevoireBouton =null;
        private static Button EnvoieBouton=null ;

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            if (EoliaReg.LiaisonSerieRegulateur())
            {
                EoliaReg.FermerLiaisonSerieRegulateur();
            }
            Application.Restart();
            Environment.Exit(0);
        }

       


        public static bool LiaisonSerieRegulateur()
        {
            if (RegulateurLiaisonSerie != null)
            {
                return true;
            }
            return false;
        }

        public static void InitialiserLiaisonSerieRegulateur(string portChoisit, Label logTextBoxregu)
        {
            ReguleurlLogBox = logTextBoxregu;
            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                try
                {
                    RegulateurLiaisonSerie = new SerialPort(portChoisit);

                    // paramètres de la liaison série
                    RegulateurLiaisonSerie.BaudRate = 9600;
                    RegulateurLiaisonSerie.Parity = Parity.None;
                    RegulateurLiaisonSerie.StopBits = StopBits.One;
                    RegulateurLiaisonSerie.DataBits = 8;
                    RegulateurLiaisonSerie.Handshake = Handshake.None;

                    RegulateurLiaisonSerie.Open();
                    ReguleurlLogBox.Text = "Liaison Série -> Démarrée";
                    ReguleurlLogBox.ForeColor = System.Drawing.Color.Green;
                    EoliaLogs.Write("Démarée", EoliaLogs.Types.SERIAL);
                    EoliaLogs.Write("Liaison série démarée", EoliaLogs.Types.SERIAL);
                    LireSerie = true;
                  
                    readThread = new Task(Lire);
                    readThread.Start();
                    Task.run(() =>
                    {
                        while (SerialPort.GetPortNames().Contains(portChoisit))
                        {
                            RegulateurLiaisonSerie.Write(MessageEcoute);
                            readThreadInfini = new Task(Lire);
                            if (LireSerie == false)
                                break;
                            else
                                Thread.Sleep(1000); //attent 1000 milliseconde ou 1 seconde pour reprendre la boucle while 
                        }
                    });
                    }
                catch (IOException ex)
                {
                    ReguleurlLogBox.Text = "Liaison Série 1 -> " + ex;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    RegulateurLiaisonSerie = null;

                }
                catch (UnauthorizedAccessException ex)
                {
                    ReguleurlLogBox.Text = "Liaison Série 2-> Acces refusé (" + ex + ")";
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    RegulateurLiaisonSerie = null;
                }
                catch (ArgumentException ex)
                {
                    ReguleurlLogBox.Text = "Liaison Série3 -> " + ex;
                    EoliaLogs.Write("Liaison série echec " + ex, EoliaLogs.Types.SERIAL);
                    RegulateurLiaisonSerie = null;
                }

            }
            else
            { 
                ReguleurlLogBox.Text = "pb port ";
            }

        }
        

        public  void EnvoyerMessageSerieRegulateur(byte[] message)
        {
            if (RegulateurLiaisonSerie != null && RegulateurLiaisonSerie.IsOpen)
            {
                
                string messageString= ToString(messagePrépa(message))
                // Envoi du message
                RegulateurLiaisonSerie.Write(getstring);
            }
        }

        /*
          écrire requête de donné demande 
            1 octet         1 octet      2 octet                   2 octet         2 octet 
            add esclave     fonction     Adresse frist mot         nb de mot       crc16
            XXXX XXXX       XXXX XXXX    XXXX XXXX|XXXX XXXX       XXXX XXXX       XXXX XXXX | XXXX XXXX
            0000 0001       0000 0011    0011 0001 0000 0000       0000 0100       0100 1010   1111 0101    
              0     1       0       3       3  1    0   0           0   4           4     A     F     5
         */
     
        private  byte messagePrépa(byte[] message,byte fonction )
        {
            byte AdresseEsclave=0x01;
            ushort AdressePremiersMot = 0x002A;
            byte[] AdresseMot = BitConverter.GetBytes(AdressePremiersMot);
            byte[] NbMot= new byte[1];
            message = new byte[8];
            message[0] = AdresseEsclave;
            message[1] = 0x06;
            Array.Copy(AdresseMot,0, message, 2,2);
            Array.Copy(NbMot,0, message, 4,2);
            return AjoutCRCEnvoie(message);        
        }
        //boucle d'écoute infini 
    private static void Lire()
        {
            Console.WriteLine("Démarrage thread liaison série");
            while (LireSerie)
            {
                try
                {
                    string messageString = RegulateurLiaisonSerie.ReadExisting();
                    byte[] messageoctet = Convert.ToByte( messageString);
                    if (messageoctet.Length > 0)
                    {
                        
                        if (messageoctet[2] < 0x80)

                            VerifierCRCRecu(messageoctet);

                        else
                        {
                            ReguleurlLogBox.Text = "il y a une erreur ";
                        }
                    }
                    //Verifi la Commande message);
                }
                catch (TimeoutException) { 
            }
        }
       
        
        private static void VerifierCRCRecu(byte[] MessageRecu)
        {
            Array.Copy(MessageRecu, MessageRecu.Length - 2, crcRecu, 0, 2);
            byte[] MessageSansCRC = EnleverCrcRecu(MessageRecu);
            if (CRC(MessageSansCRC) == crcRecu)
                ReguleurlLogBox.Text = "le bon resutat a était recu ";
            else
                ReguleurlLogBox.Text = "il y a eu une erreur dans l'envoie";
        }
        private static byte[] EnleverCrcRecu(byte[] MessageRecu)
        {
            int sizemessage = MessageRecu.Length;
            byte[] MessagesSansCRC = new byte[sizemessage - 2];
           
            return MessagesSansCRC;
        }
        //ComboBoxChoixPortSerieRegulateur
        private static byte[] CRC( byte[] DonneeDuPacket)
        {
            if (DonneeDuPacket == null) throw new ArgumentException();
            {
                //definition du crc 
                ushort Crc16 = 0xFFFF;
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
                return BitConverter.GetBytes(Crc16);
            }

        }

        private  byte[] AjoutCRCEnvoie(byte[] message)
        {
            byte[] crc = CRC(message);
            int sizemessage = message.Length;
            Array.Copy(crc, 0, message, sizemessage+1,2);
            return message;
        }

        public static void FermerLiaisonSerieRegulateur()
        {

            // fermer le port série
            LireSerie = false;

            readThread = null;
            RegulateurLiaisonSerie.Close();
            RegulateurLiaisonSerie = null;
            ReguleurlLogBox.Text = "Liaison Série -> Arrèté";
        }

        private void DesQueErreurRecuRegulateur(object port, SerialErrorReceivedEventArgs e)
        {
            SerialPort portSerie = (SerialPort)port;
            portSerie.Close();
            ReguleurlLogBox.Text = "Liaison Série -> Arrêtée";
            EoliaLogs.Write("Liaison série terminée ", EoliaLogs.Types.SERIAL);
            // erreur reçu
        }
    }
}
