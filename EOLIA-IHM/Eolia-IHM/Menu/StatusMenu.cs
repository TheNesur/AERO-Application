using Eolia_IHM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        //private bool cameraConnected = false;

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
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "vcgencmd",
                        Arguments = "get_camera",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (output.Contains("detected=0"))
                {
                    labelStatutCamera.Text = "Introuvable";
                    labelStatutCamera.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    labelStatutCamera.Text = "Connectée";
                    labelStatutCamera.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ee)
            {
                labelStatutCamera.Text = "Introuvable";
                labelStatutCamera.ForeColor = System.Drawing.Color.Green; 
                Console.WriteLine(ee.Message);
            }
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
