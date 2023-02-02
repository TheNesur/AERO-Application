using Eolia_IHM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM.Menu
{
    public partial class StatusMenu : UserControl
    {
        public StatusMenu()
        {
            InitializeComponent();
        }

        private bool bddDemarrer = false;
        private bool esp32Demarrer = false;
        private bool liaisonRegulateurDemarrer = false;

        private void StatusMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonDemarrerESP32_Click(object sender, EventArgs e)
        {
            
            if (EoliaMes.LiaisonSerieCapteur())
            {
                EoliaMes.FermerLiaisonSerieCapteur();
                if (!EoliaMes.LiaisonSerieCapteur())
                {
                    buttonDemarrerESP32.Text = "Démarrée liaison série";
                    esp32Demarrer = false;
                }
            }
            else
            {
                EoliaMes.InitialiserLiaisonSerieCapteur(ConfigurationMenu.PortSerieCapteur, labelStatutCapteurs);
                if (EoliaMes.LiaisonSerieCapteur())
                {
                    buttonDemarrerESP32.Text = "Arrêtée liaison série";
                    esp32Demarrer = true;
                }
            }
        }

        private void buttonEtatBDD_Click(object sender, EventArgs e)
        {
            if (!EoliaSQL.BDDisConnected())
            {
                EoliaSQL.InitialiserConnexionSQL(ConfigurationMenu.NomBDD,
                ConfigurationMenu.UsernameBDD,
                ConfigurationMenu.PasswordBDD,
                ConfigurationMenu.AdresseBDD,
                labelStatutBDD, buttonDemarrerBDD);
                bddDemarrer = true;

            }
            else
            {
                EoliaSQL.FermerConnexionSQL();
                bddDemarrer = false;
            }
        }

        private void buttonDemarrerTout_Click(object sender, EventArgs e)
        {
            if (!bddDemarrer) buttonDemarrerBDD.PerformClick();
            if (!esp32Demarrer) buttonDemarrerESP32.PerformClick();
            if (!liaisonRegulateurDemarrer) buttonLiaisonRegulateur.PerformClick();
        }

        private void buttonArreterToutLesServices_Click(object sender, EventArgs e)
        {
            if (bddDemarrer) buttonDemarrerBDD.PerformClick();
            if (esp32Demarrer) buttonDemarrerESP32.PerformClick();
            if (liaisonRegulateurDemarrer) buttonLiaisonRegulateur.PerformClick();

        }

        private void buttonLiaisonRegulateur_Click(object sender, EventArgs e)
        {

        }
    }
}
