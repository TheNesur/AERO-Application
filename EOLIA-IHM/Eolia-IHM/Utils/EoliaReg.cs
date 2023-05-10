using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM.Utils
{
    internal class EoliaReg
    {

        private static float MaxValue = 20;
        private static volatile float vitesse = float.NaN;
        private static volatile float vitessedesir = float.NaN;
        private static volatile float vitesseaenvoyer = float.NaN;
        private static volatile bool updateform = false;

        static object serialPortLock = new object();



        private static Label loglabel;
        private static TextBox logtxtbox;
        private static SerialPort serialPort = null;

        static float ConvertByteArrayToFloat(byte[] bytes, int startIndex)
        {
            byte[] temp = new byte[4];

            for (int i = 0; i < 4; i++)
                temp[i] = bytes[i + startIndex];

            Array.Reverse(temp, 2, 2);
            Array.Reverse(temp);
            Array.Reverse(temp, 2, 2);

            uint bits = (uint)(temp[0] << 24 | temp[1] << 16 | temp[2] << 8 | temp[3]);
            float resultat = BitConverter.ToSingle(BitConverter.GetBytes(bits), 0);
            return resultat;
        }
        static byte[] ConvertFloatToByteArray(float toconvert)
        {
            byte[] temp = BitConverter.GetBytes(toconvert);

            Array.Reverse(temp, 2, 2);
            Array.Reverse(temp);
            Array.Reverse(temp, 2, 2);

            return temp;
        }
        public static bool ModBusVerifErreur(byte[] modbusFrame)
        {
            //// Vérifier que la trame Modbus est au moins de la longueur minimale
            //if (modbusFrame.Length < 5)
            //{
            //    throw new Exception("La trame modbus reçu n'est pas une trame valide ");
            //}

            //// Vérifier que la fonction Modbus est une fonction d'erreur
            //if ((modbusFrame[1] & 0x80) == 0x80)
            //{
            //    throw new Exception("L'esclave a renvoyé une erreur");
            //}

            return false;
        }
        static byte[] ModBusLireRegistre(byte esclave, ushort adressedebut, ushort quantité)
        {
            lock (serialPortLock)
            {
                // Configuration de la requête Modbus
                byte slaveAddress = esclave;  // Adresse esclave du Jumo dtron 304
                byte functionCode = 3;  // Code de fonction pour lire des registres
                ushort startingAddress = adressedebut;  // Adresse de début pour la lecture des registres
                ushort quantity = quantité;  // Nombre de registres à lire
                byte[] requestWithoutCRC = new byte[] { slaveAddress, functionCode, (byte)(startingAddress >> 8), (byte)(startingAddress & 0xFF), (byte)(quantity >> 8), (byte)(quantity & 0xFF) };

                // Calcul du CRC pour la requête Modbus
                ushort crc = CalculateCRC(requestWithoutCRC);
                byte[] requestWithCRC = new byte[requestWithoutCRC.Length + 2];
                Array.Copy(requestWithoutCRC, requestWithCRC, requestWithoutCRC.Length);
                requestWithCRC[requestWithoutCRC.Length] = (byte)(crc & 0xFF);
                requestWithCRC[requestWithoutCRC.Length + 1] = (byte)(crc >> 8);

                // Envoi de la requête Modbus avec CRC

                //Console.WriteLine("Envoi de la requete vitesse, attente de recevoir " + requestWithCRC.Length);

                serialPort.Write(requestWithCRC, 0, requestWithCRC.Length);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //while (serialPort.BytesToRead <= requestWithCRC.Length && stopWatch.ElapsedMilliseconds < 1000);



                // Lecture de la réponse Modbus
                byte[] response = new byte[5 + 2 * quantity];  // Taille de la réponse en fonction du nombre de registres demandés

                while (serialPort.BytesToRead <= requestWithCRC.Length)
                {
                    Task.Delay(10);
                    if (stopWatch.ElapsedMilliseconds > 1000) throw new Exception("La trame n'as pas été reçue dans les délais");
                }

                serialPort.Read(response, 0, response.Length);

                byte[] reponseSansCRC = new byte[response.Length - 2];
                Array.Copy(response, reponseSansCRC, response.Length - 2);

                ushort crcrecu = BitConverter.ToUInt16(response, response.Length - 2);
                ushort crctheorique = CalculateCRC(reponseSansCRC);
                if (crcrecu == crctheorique && !ModBusVerifErreur(response))
                    return response;
                else
                    throw new Exception("La trame reçue contient une erreur");
            }
        }
        static bool ModBusEcrireFloat(byte esclave, ushort adressedebut, float valeur)
        {
            lock (serialPortLock)
            {
                // Configuration de la requête Modbus
                byte slaveAddress = esclave;  // Adresse esclave du Jumo dtron 304
                byte functionCode = 0x10;  // Code de fonction pour lire des registres
                ushort startingAddress = adressedebut;  // Adresse de début pour la lecture des registres
                ushort quantity = 2;  // Nombre de registres à écrire
                byte nboctet = 4;
                byte[] data = ConvertFloatToByteArray(valeur);
                byte[] requestWithoutCRC = new byte[] { slaveAddress, functionCode, (byte)(startingAddress >> 8), (byte)(startingAddress & 0xFF), (byte)(quantity >> 8), (byte)(quantity & 0xFF), nboctet, data[3], data[2], data[1], data[0] };


                // Calcul du CRC pour la requête Modbus
                ushort crc = CalculateCRC(requestWithoutCRC);
                byte[] requestWithCRC = new byte[requestWithoutCRC.Length + 2];
                Array.Copy(requestWithoutCRC, requestWithCRC, requestWithoutCRC.Length);
                requestWithCRC[requestWithoutCRC.Length] = (byte)(crc & 0xFF);
                requestWithCRC[requestWithoutCRC.Length + 1] = (byte)(crc >> 8);

                // Envoi de la requête Modbus avec CRC

                //Console.WriteLine("Envoi de la requete vitesse, attente de recevoir " + requestWithCRC.Length);
                // Console.WriteLine(ConvertByteArrayToFloat(requestWithCRC, requestWithCRC.Length - 6));
                serialPort.Write(requestWithCRC, 0, requestWithCRC.Length);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //while (serialPort.BytesToRead <= requestWithCRC.Length && stopWatch.ElapsedMilliseconds < 1000);



                // Lecture de la réponse Modbus
                byte[] response = new byte[8];  // Taille de la réponse 

                while (serialPort.BytesToRead < 8)
                {
                    Task.Delay(10);
                    if (stopWatch.ElapsedMilliseconds > 1000)
                    {
                        serialPort.Read(response, 0, serialPort.BytesToRead);
                        throw new Exception("La trame n'as pas été reçue dans les délais et " + serialPort.BytesToRead + " octets reçus");

                    }
                }

                serialPort.Read(response, 0, response.Length);

                byte[] reponseSansCRC = new byte[response.Length - 2];
                Array.Copy(response, reponseSansCRC, response.Length - 2);

                ushort crcrecu = BitConverter.ToUInt16(response, response.Length - 2);
                ushort crctheorique = CalculateCRC(reponseSansCRC);
                if (crcrecu == crctheorique && !ModBusVerifErreur(response) && response[5] == quantity)
                    return true;
                else
                    throw new Exception("La trame reçue contient une erreur");

            }
        }
        static float ObtenirVitesse()
        {
            float vitesse = 0;
            try
            {
                byte[] reponse = ModBusLireRegistre(1, 0x28, 0x2);
                vitesse = ConvertByteArrayToFloat(reponse, reponse.Length - 6);
                majUI(float.NaN, vitesse);
            }
            catch
            {
                vitesse = 0;
            }

            return vitesse;
        }
        static float ObtenirConsigne()
        {
            float consigne = 0;
            try
            {
                byte[] reponse = ModBusLireRegistre(1, 0x3100, 0x2);
                consigne = ConvertByteArrayToFloat(reponse, reponse.Length - 6);
                majUI(consigne, float.NaN);
            }
            catch
            {
                consigne = 0;
            }

            return consigne;
        }
        public static bool ParamVitesse(float vitesse)
        {
            if(ModBusEcrireFloat(0x1, 0x3100, vitesse))
            {
                vitessedesir = vitesse;
                return true;
            }
            else
            {
                return false;
            }

        }
        public static float obtenirVitesse()
        {
            if (vitesse != float.NaN)
                return vitesse * MaxValue / 100;
            return 0;
        }
        public static float obtenirVitesseVoulue()
        {
            if (vitessedesir != float.NaN)
                return vitessedesir;
            return float.NaN;
        }

        public static float obtenirVitesseVoulueRaw()
        {
            if (vitessedesir != float.NaN)
                return vitessedesir;
            return float.NaN;
        }
        static void majUI(float vdesir, float v)
        {
            /*if (v != float.NaN)
                vitesse = v;
            if (vdesir != float.NaN)
                vitessedesir = vdesir;

            if (updateform)
            {
                if (v != float.NaN)
                    ;
                if (vdesir != float.NaN)
                    ;
                updateform = false;
            }*/ // Semble inutile mais on peut garder ......
        }


        static ushort CalculateCRC(byte[] data)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < data.Length; i++)
            {
                crc ^= (ushort)data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) == 1)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc;
        }

        public static void SaveLogBox(TextBox txt)
        {
            logtxtbox = txt;
        }

        public static void InitialiserLiaisonSerieCapteur(string portChoisit, Label logLabel, TextBox logTxtBox = null)
        {
            loglabel = logLabel;
            logtxtbox = logTxtBox;

            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                try
                {
                    serialPort = new SerialPort(portChoisit, 9600, Parity.None, 8, StopBits.One);
                    serialPort.Open();

                    loglabel.Text = " Démarrée";
                    loglabel.ForeColor = System.Drawing.Color.Green;
                    EoliaLogs.Write("Liaison série Régulateur démarrée régulateur", EoliaLogs.Types.SERIAL);

                }
                catch (IOException ex)
                {
                    loglabel.Text = "Arret ";
                    EoliaLogs.Write("Liaison série echec régulateur" + ex, EoliaLogs.Types.SERIAL);
                    serialPort = null;
                }
                catch (UnauthorizedAccessException ex)
                {
                    loglabel.Text = "Acces refusé ";
                    EoliaLogs.Write("Liaison série echec régulateur" + ex, EoliaLogs.Types.SERIAL);
                    serialPort = null;
                }
                catch (ArgumentException ex)
                {
                    loglabel.Text = "Erreur";
                    EoliaLogs.Write("Liaison série echec régulateur" + ex, EoliaLogs.Types.SERIAL);
                    serialPort = null;
                }

            }
            else
            {
                loglabel.Text = "Pb port";
                loglabel.ForeColor = System.Drawing.Color.Red;
            }


        }

        public static bool LiaisonSerieReg()
        {
            if (serialPort != null)
            {
                return true;
            }
            return false;
        }
        public static async Task<bool> ParamVitesseAsync(float vitesse)
        {
            return await Task.Run(() => ParamVitesse(vitesse));
        }

        

        public static float readVitesse()
        { 
                return vitesse = ObtenirConsigne();
        }
        public static async Task<float> readVitesseAsync()
        {
            return await Task.Run(() => ObtenirConsigne());
        }

        public static void AutoReloadAll(int ms, Label Vitesse, Label Consigne)
        {
            updateform = true;
            Task.Run(() => {
                while (updateform)
                {
                    
                    try
                    {
                        float _vitesse = ObtenirVitesse();
                        Vitesse.Invoke(new Action(() => Vitesse.Text = (Math.Round(_vitesse * MaxValue / 100,2)-3.99).ToString()));
                        vitesse = _vitesse;
                        float _consigne = ObtenirConsigne();
                        vitessedesir = _consigne;
                        
                        Consigne.Invoke(new Action(() => Consigne.Text = (Math.Round(_consigne,2)).ToString()));
                    }
                    catch (Exception e)
                    {
                        if (logtxtbox != null) logtxtbox.Invoke(new Action(() => logtxtbox.AppendText("[Reg]" + e.Message + "`\r\n\r\n")));
                    }
                    /* Vitesse.text = vitesse; */
                    //Console.WriteLine(vitesse);
                    Thread.Sleep(ms);
                }
            });
        }

        





        public static void FermerLiaisonSerieCapteur()
        {

            // fermer le port série
            stopReloadVitese();

            serialPort.Close();
            serialPort = null;
            loglabel.Text = "Arrèté";
            loglabel.ForeColor = System.Drawing.Color.Red;
            EoliaLogs.Write("Liaison série Régulateur arrêtée", EoliaLogs.Types.SERIAL);


        }

        public static void stopReloadVitese()
        {
            updateform = false;
        }

    }
}
