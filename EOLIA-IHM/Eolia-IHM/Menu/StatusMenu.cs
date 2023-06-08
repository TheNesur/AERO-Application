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


        private void CheckIsActived()
        {
            if (bddDemarrer && esp32Demarrer && liaisonRegulateurDemarrer)
            {
                buttonDemarrerToutLesServices.Enabled = false;
                buttonDemarrerToutLesServices.BackColor = Color.FromArgb(204, 204, 204);

                buttonArreterToutLesServices.Enabled = true;
                buttonArreterToutLesServices.BackColor = Color.White;
            }
            else
            {
                buttonDemarrerToutLesServices.Enabled = true;
                buttonDemarrerToutLesServices.BackColor = Color.White;

                buttonArreterToutLesServices.Enabled = false;
                buttonArreterToutLesServices.BackColor = Color.FromArgb(204, 204, 204);
            }
        }

        //private bool cameraConnected = false;


        private bool iconIsExist(String nameIcon)
        {
            if (File.Exists($"{directoryIcon}/{nameIcon}")) return true;
            else return false;
        }

        private void StatusMenu_Load(object sender, EventArgs e)
        {

            buttonArreterToutLesServices.Enabled = false;
            buttonArreterToutLesServices.BackColor = Color.FromArgb(204, 204, 204);

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
                    CheckIsActived();
                }
            }
            else
            {
                EoliaMes.InitialiserLiaisonSerieCapteur(ConfigurationMenu.PortSerieCapteur, labelStatutCapteurs);
                if (EoliaMes.LiaisonSerieCapteur())
                {
                    buttonDemarrerESP32.Text = "Arrêtée liaison série";
                    esp32Demarrer = true;
                    CheckIsActived();
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
                CheckIsActived();

            }
            else
            {
                EoliaSQL.FermerConnexionSQL();
                bddDemarrer = false;
                CheckIsActived();
            }
        }

        private void buttonDemarrerTout_Click(object sender, EventArgs e)
        {
            if (!bddDemarrer) buttonDemarrerBDD.PerformClick();
            if (!esp32Demarrer) buttonDemarrerESP32.PerformClick();
            if (!liaisonRegulateurDemarrer) buttonLiaisonRegulateur.PerformClick();
            CheckIsActived();
        }

        private void buttonArreterToutLesServices_Click(object sender, EventArgs e)
        {
            if (bddDemarrer) buttonDemarrerBDD.PerformClick();
            if (esp32Demarrer) buttonDemarrerESP32.PerformClick();
            if (liaisonRegulateurDemarrer) buttonLiaisonRegulateur.PerformClick();
            CheckIsActived();

        }

        private void buttonLiaisonRegulateur_Click(object sender, EventArgs e)
        {
            if (EoliaReg.LiaisonSerieReg())
            {
                EoliaReg.FermerLiaisonSerieCapteur();
                if (!EoliaReg.LiaisonSerieReg()) { 
                    buttonLiaisonRegulateur.Text = "Démarrer liaison régulateur";
                    liaisonRegulateurDemarrer = false;
                    CheckIsActived();
                }
            }
            else
            {
                EoliaReg.InitialiserLiaisonSerieCapteur(ConfigurationMenu.PortSerieRegulateur, labelStatutRegulateur);
                if (EoliaReg.LiaisonSerieReg())
                {
                    buttonLiaisonRegulateur.Text = "Arrêter liaison régulateur";
                    liaisonRegulateurDemarrer = true;
                    CheckIsActived();
                }
            }

        }
    }
}
