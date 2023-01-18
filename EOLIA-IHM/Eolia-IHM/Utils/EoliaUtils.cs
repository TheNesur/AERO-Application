using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Eolia_IHM.Properties
{
    internal class EoliaUtils
    {
        // Variable relatif a la gestion des onglets 
        
        static GroupBox ongletActif = null;

        // Variable relatif a la gestion du pavé numérique

        static TextBox textBoxActif = null;






        // Variable relatif a la gestion du pavé numérique

        public static void TextBoxActif(TextBox txtbox)
        {
            textBoxActif = txtbox;
        }

        public static void PaveNumerique(int x) // x = caractère a entré dans la textbox
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

        public static void AfficherOnglet(GroupBox gbox)
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

        public static void SauvegarderConfiguration(IDictionary<string, string> ListeValeurASauvegarder)
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
            config.SaveAs("config/EoliaConfig.config", ConfigurationSaveMode.Modified);

        }


        // Renvoi la valeur du champ "champ" du XML sous forme d'un String
        public static string LireConfiguration(string champ)
        {
            //permet de spécifier le chemin d'accès du fichier de configuration
            var map = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "config/EoliaConfig.config"
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            //le configuration Userlevel.none ca permet simplement de signifier que c'est un fichier de configuration
            return config.AppSettings.Settings[champ].Value ;

        }


        // Fonction utilitaire

        public static void AfficherPortSerie(ComboBox cmbBox)
        {

            cmbBox.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbBox.Items.Add(port);
            }


        }

        public static bool EoliaConfigExiste()
        {
            if (File.Exists("config/EoliaConfig.config"))
            {
                return true;
            }
            return false;
        }

        public static void MsgBoxNonBloquante(string Msg)
        {
            Task.Run(() => { MessageBox.Show(Msg); });
        
        }

    }
}
