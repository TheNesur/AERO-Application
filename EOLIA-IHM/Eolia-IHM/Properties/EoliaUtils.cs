using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;
using System.IO;

namespace Eolia_IHM.Properties
{
    internal class EoliaUtils
    {
        // Permet d'afficher les groupbox 
        
        GroupBox ongletActif = null;
        TextBox textBoxActif = null;
        private static TextBox SerialLogBox = null;
        private static SerialPort serialPort;


        public void AfficherPortSerie(ComboBox cmbBox)
        {
            
            cmbBox.Items.Clear();
            
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbBox.Items.Add(port);
            }


        }

        public static void FermerLiaisonSerie(string portChoisit)
        {
            if (serialPort.PortName == portChoisit)
            {
                // fermer le port série
                serialPort.Close();
                SerialLogBox.Text = "Liaison Série -> Arrèté";
            }
        }
        
        public static void InitialiserLiaisonSerie(string portChoisit, TextBox logTextBox)
        {
            SerialLogBox = logTextBox;

            if (SerialPort.GetPortNames().Contains(portChoisit))
            {
                serialPort = new SerialPort(portChoisit);
                // param liaison série
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;

                // définir les événements qui seront gérés de manière asynchrone
                serialPort.DataReceived += DesQueDonneesRecu;
                serialPort.ErrorReceived += DesQueErreurRecu;
                serialPort.Open();
                SerialLogBox.Text = "Liaison Série -> Démarrée";
            }
            else
            {
                SerialLogBox.Text = "Liaison Série -> Port Existant pas";
            }
           
            
        }

        private static void DesQueDonneesRecu(object sender, SerialDataReceivedEventArgs e)
        {
            // récupérer l'objet SerialPort qui a déclenché l'événement
            SerialPort serialPort = (SerialPort)sender;

            // lire les données reçues
            string data = serialPort.ReadExisting();

            // donnée a traité sur data
        }

        private static void DesQueErreurRecu(object sender, SerialErrorReceivedEventArgs e)
        {
            
            SerialPort serialPort = (SerialPort)sender;
            serialPort.Close();
            SerialLogBox.Text = "Liaison Série -> Arrêtée";
            // erreur reçu
        }


        public void TextBoxActif(TextBox txtbox)
        {
            textBoxActif = txtbox;
        }

        public void PaveNumerique(int x) // x = caractère a entré dans la textbox
        {                                // 10 = . / 11 = del
            if(textBoxActif!= null) {
                if (x == 10)
                {
                    textBoxActif.Text = textBoxActif.Text + ".";
                }
                else if (x == 11)
                {
                    if(textBoxActif.Text.Length > 0)
                        textBoxActif.Text = textBoxActif.Text.Remove(textBoxActif.TextLength - 1);
                }
                else
                {
                    textBoxActif.Text = textBoxActif.Text + x.ToString();
                }

                textBoxActif.Focus();
            }
        }

        public void AfficherOnglet(GroupBox gbox)
        {
            if (ongletActif == null)
            {
                gbox.Visible = true;
                ongletActif = gbox;
            }
            else
            {
                ongletActif.Visible=false;
                gbox.Visible=true;
                ongletActif = gbox;
                
            }
        
        }

        public void SauvegarderConfiguration(IDictionary<string, string> ListeValeurASauvegarder)
        {
           

            // Création d'un fichier de configuration
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Il faudra ajouter un foreach avec un dictionnaire de string
            // pour stocker plusieurs valeurs
            foreach(KeyValuePair<string, string> entry in ListeValeurASauvegarder)
            {
                config.AppSettings.Settings.Add(entry.Key, entry.Value);
            }
            

            // sauvegarde du fichier de configuration sous le nom "EoliaConfig.config"
            config.SaveAs("EoliaConfig.config", ConfigurationSaveMode.Modified);

        }


        // Renvoi la valeur du champ "champ" du XML sous forme d'un String
        public string LireConfiguration(string champ)
        {
            //permet de spécifier le chemin d'accès du fichier de configuration
            var map = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "EoliaConfig.config"
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            //le configuration Userlever.none ca permet simplement de signifier que c'est un fichier de configuration
            return config.AppSettings.Settings[champ].Value ;

        }

    }
}
