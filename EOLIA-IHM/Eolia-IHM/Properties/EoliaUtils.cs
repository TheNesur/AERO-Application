using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Eolia_IHM.Properties
{
    internal class EoliaUtils
    {
        // Variable relatif a la gestion des onglets 
        
        GroupBox ongletActif = null;

        // Variable relatif a la gestion du pavé numérique

        TextBox textBoxActif = null;

        // Variable relatif a la liaison série

        private  SerialPort serialPort = null;
        private  TextBox SerialLogBox = null;
       

        // Variable relatif a la liaison a la BDD

        private MySqlConnection SqlConnexion = null;
        private bool BDDConnected = false;
        private TextBox SQLLogBox = null;


        // Variable relatif a la gestion ges mesures

        private List<float> ListeMesureTrainee = null;
        private List<float> ListeMesurePortance = null;
        private bool EnregistreMesure = false;
        private Label LabelMesTrainee = null;
        private Label LabelMesPortance = null;
        private Label ReponseCMDMesure = null;
        private bool TransmissionMesure = false;

        // Fonction relatif a la gestion des mesures

        public void InitialiserTransMes(Label RepMsg, Label LabelMesPort, Label LabelMesTra)
        {
            LabelMesTrainee = LabelMesTra;
            LabelMesPortance = LabelMesPort;
            ReponseCMDMesure = RepMsg;
            TransmissionMesure = true;
            ReponseCMDMesure.Text = "Les mesures reçues seront afichées au dessus";
            EnvoyerMessageSerie("START");

        }

        public void TarerCapteur()
        {
            EnvoyerMessageSerie("TARAGE");
        }

        public bool EtatTransMes()
        {
            if(TransmissionMesure)
            {
                return true;
            }
            return false;
        }

        public bool EnregistrementMes()
        {
            if(!EnregistreMesure)
            {
                EnregistreMesure = true;
                return false ;
            }
            EnregistreMesure = false;
            return true;
        }

        public void ArreterTransMes()
        {
            EnvoyerMessageSerie("STOP");

            ReponseCMDMesure.Text = "Transmission des mesures arrêtés";

            LabelMesTrainee = null;
            LabelMesPortance = null;
            ReponseCMDMesure = null;


            TransmissionMesure = false;
            

        }

        public void VerifierCommandeMesure(string command)
        {
            if (!TransmissionMesure)
                return;

            bool CommandeAvecMessage;
            string[] words = command.Split(' ');
            if (words.Length < 3)
            {
                return;
            }

            // On vérifie que le premier mot de la commande est "PORTANCE" et que le troisième mot est "TRAINEE" et que le quatrième mot est "MSG"
            if (words.Length > 4)
            {
                CommandeAvecMessage = true;
            }else if (words[0] == "PORTANCE" && words[2] == "TRAINEE")
            {
                CommandeAvecMessage = false;
            }
            else
            {
                return;
            }

                
                float portance, trainee;
            if (!float.TryParse(words[1], out portance) || !float.TryParse(words[3], out trainee))
            {
                return;
            }
            if (CommandeAvecMessage)
            {
                // On fusion tous les mots qui suivent dans une chaîne de caractères
                string message = "";
                for (int i = 5; i < words.Length; i++)
                {
                    message += words[i] + " ";
                }

                // On enleve l'espace en fin de chaîne
                message = message.TrimEnd();

                ReponseCMDMesure.Text = message;
            }

            if (EnregistreMesure) {
                ListeMesureTrainee.Add(trainee);
                ListeMesurePortance.Add(portance);
            }


            LabelMesTrainee.Invoke(new Action(() => LabelMesTrainee.Text = words[1]));
            LabelMesPortance.Invoke(new Action(() => LabelMesPortance.Text = words[3]));

        }


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
                //string connexionString = "Data Source=" + Adresse + ",3306;Initial Catalog = " + NomBaseDeDonée + "; User ID = " + Utilisateur + "; Password = " + MotDePasse;
                SQLLogBox = SQLlogbox;

                SqlConnexion = new MySqlConnection(connexionString);

                try
                {
                    await SqlConnexion.OpenAsync();
                    SQLLogBox.Text = "BDD OK";
                    BDDConnected = true;
                }
                catch (MySqlException ex)
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

        public async Task<int> ExecuterRequeteSansReponse(string requete)
        {
            if (SqlConnexion != null)
            {
                MySqlCommand command = new MySqlCommand(requete, SqlConnexion);
                int LigneAffecte = await command.ExecuteNonQueryAsync();
                return LigneAffecte;
            }
            return 0;
        }


        // Fonction relatif a la liaison série


        public bool SerialisConnected()
        {
            if (serialPort != null)
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

        public  void FermerLiaisonSerie(string portChoisit)
        {
            if (serialPort.PortName == portChoisit)
            {
                // fermer le port série
                serialPort.Close();
                serialPort = null;
                SerialLogBox.Text = "Liaison Série -> Arrèté";
                
            }
        }
        
        public void InitialiserLiaisonSerie(string portChoisit, TextBox logTextBox)
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

        void EnvoyerMessageSerie(string message)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                // Envoi du message
                serialPort.Write(message);
            }
        }


        private void DesQueDonneesRecu(object port, SerialDataReceivedEventArgs e)
        {
            // récupérer l'objet SerialPort qui a déclenché l'événement
            SerialPort portSerie = (SerialPort)port;

            // lire les données reçues
            string data = portSerie.ReadExisting();

            // donnée a traité sur data
            VerifierCommandeMesure(data);
        }

        private void DesQueErreurRecu(object port, SerialErrorReceivedEventArgs e)
        {
            
            SerialPort portSerie = (SerialPort)port;
            portSerie.Close();
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
