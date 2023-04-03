using Eolia_IHM.Properties;
using Eolia_IHM.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private String directoryIcon = AppDomain.CurrentDomain.BaseDirectory + "/ICON/";

        //private bool cameraConnected = false;


        private bool iconIsExist(String nameIcon)
        {
            if (File.Exists($"{directoryIcon}/{nameIcon}")) return true;
            else return false;
        }

        private void StatusMenu_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
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

                        if (iconIsExist("camera-erreur.png"))
                            pictureBoxCameraCapture.Image = Image.FromFile(directoryIcon + "/camera-erreur.png");

                    }
                    else
                    {

                        if (iconIsExist("camera-on.png"))
                            pictureBoxCameraCapture.Image = Image.FromFile(directoryIcon + "/camera-on.png");

                    }
                }
                catch (Exception ee)
                {

                    if (iconIsExist("camera-off.png"))
                        pictureBoxCameraCapture.Image = Image.FromFile(directoryIcon + "/camera-off.png");

                    Console.WriteLine(ee.Message);
                }
            }
            else
            {
                if (iconIsExist("camera-off.png"))
                    pictureBoxCameraCapture.Image = Image.FromFile(directoryIcon + "/camera-off.png");
            }
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
            if (EoliaReg.LiaisonSerieReg())
            {
                EoliaReg.FermerLiaisonSerieCapteur();
                if (!EoliaReg.LiaisonSerieReg()) { 
                    buttonLiaisonRegulateur.Text = "Démarrer liaison régulateur";
                    liaisonRegulateurDemarrer = false;
                }
            }
            else
            {
                EoliaReg.InitialiserLiaisonSerieCapteur(ConfigurationMenu.PortSerieRegulateur, labelStatutRegulateur);
                if (EoliaReg.LiaisonSerieReg())
                {
                    buttonLiaisonRegulateur.Text = "Arrêter liaison régulateur";
                    liaisonRegulateurDemarrer = true;
                }
            }

        }
    }
}
