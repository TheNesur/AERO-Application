using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Eolia_IHM.Properties
{
    internal class EoliaUtils
    {
        // Permet d'afficher les groupbox 
        
        GroupBox ongletActif = null;

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

        public void SauvegarderConfiguration()
        {
           

            // Création d'un fichier de configuration
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Il faudra ajouter un foreach avec un dictionnaire de string
            // pour stocker plusieurs valeurs
            config.AppSettings.Settings.Add("key", "value");
            config.AppSettings.Settings.Add("key0", "value");
            config.AppSettings.Settings.Add("key1", "value");
            config.AppSettings.Settings.Add("key2", "value");
            config.AppSettings.Settings.Add("key3", "value");

            // sauvegarde du fichier de configuration sous le nom "EoliaConfig.config"
            config.SaveAs("EoliaConfig.config", ConfigurationSaveMode.Modified);

        }

        public string LireConfiguration(string champ)
        {

            var map = new ExeConfigurationFileMap
            {
                ExeConfigFilename = "EoliaConfig.config"
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            return config.AppSettings.Settings[champ].Value ;

        }

    }
}
