using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Eolia_IHM.Properties
{
    internal class EoliaUtils
    {
        // Variable relatif a la gestion des onglets 
        
        GroupBox ongletActif = null;

        // Variable relatif a la gestion du pavé numérique

        TextBox textBoxActif = null;

        // Variable relatif a la liaison série

        private static SerialPort serialPort;
        private static TextBox SerialLogBox = null;
        private static bool StartedSerial = false;

        // Variable relatif a la liaison a la BDD

        private SqlConnection SqlConnexion;
        private bool BDDConnected = false;
        private TextBox SQLLogBox = null;


        // Fonction relatif a la liaison a la BDD

        public bool BDDisConnected()
        {
            if (BDDConnected)
            {
                return true;
            }
            return false;
        }

        public async Task InitialiserConnexionSQL(string NomBaseDeDonée, string Utilisateur, string MotDePasse, string Adresse, TextBox SQLlogbox)
        {
                string connexionString = "Server=" + Adresse + ";Database=" + NomBaseDeDonée + ";Uid=" + Utilisateur + ";Pwd=" + MotDePasse + ";";

                SQLLogBox = SQLlogbox;

                SqlConnexion = new SqlConnection(connexionString);

                try
                {
                    await SqlConnexion.OpenAsync();
                    SQLLogBox.Text = "BDD OK";
                    BDDConnected = true;
                }
                catch (SqlException ex)
                {
                    SQLLogBox.Text = "Erreur : " + ex.Message;
                    SqlConnexion.Close();
                }
            
        }

        public void FermerConnexionSQL()
        {
            if (SqlConnexion != null)
            {
                SqlConnexion.Close();
                SqlConnexion.Dispose();
                SqlConnexion = null;
                BDDConnected = false;
                SQLLogBox.Text = "BDD Deconnecté";
            }
        }

        // Fonction relatif a la liaison série


        public bool SerialisConnected()
        {
            if (StartedSerial)
            {
                return true;
            }
            return false;
        }

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
                StartedSerial = false;
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
                StartedSerial = true;
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

        // Variable relatif a la gestion du pavé numérique

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


        // Fonction relatif a la gestion des onglets

        public void AfficherOnglet(GroupBox gbox)
        {
            if (ongletActif == null)
            {
                gbox.Visible = true;
                ongletActif = gbox;
            }
            else if(ongletActif == gbox)
            {
                gbox.Visible = false;
                ongletActif = null;
            }
            else
            {
                ongletActif.Visible=false;
                gbox.Visible=true;
                ongletActif = gbox;
                
            }
        
        }

        // Fonction relatif a la sauvegarde et au chargement des fichiers de configuration

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
            //le configuration Userlevel.none ca permet simplement de signifier que c'est un fichier de configuration
            return config.AppSettings.Settings[champ].Value ;

        }

    }
}
