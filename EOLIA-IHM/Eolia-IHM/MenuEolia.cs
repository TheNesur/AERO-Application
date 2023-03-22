using Eolia_IHM.Menu;
using Eolia_IHM.Properties;
using Eolia_IHM.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{
    public partial class MenuEolia : Form
    {
        public MenuEolia()
        {
            InitializeComponent();
            EoliaLogs.InitializeLogs();
        }

        StatusMenu statusMenu = new StatusMenu();
        MesureMenu mesureMenu = new MesureMenu();
        CameraMenu cameraMenu = new CameraMenu();
        ConfigurationMenu configurationMenu = new ConfigurationMenu();

        private const int numberMenu = 4;

        private enum MenuTypes
        {
            STATUS = 0,
            MESURE = 1,
            CAMERA = 2,
            CONFIGURATION = 3
        }

        private void chooseMenu(MenuTypes menuTypes)
        {
            switch (menuTypes)
            {
                case MenuTypes.STATUS:
                    statusMenu.Show();
                    mesureMenu.Hide();
                    cameraMenu.Hide();
                    configurationMenu.Hide();


                    buttonStatus.BackColor = Color.DarkGray;
                    buttonMesure.BackColor = Color.White;
                    buttonCamera.BackColor = Color.White;
                    buttonConfiguration.BackColor = Color.White;

                    buttonStatus.ForeColor = Color.White;
                    buttonMesure.ForeColor = Color.Black;
                    buttonCamera.ForeColor = Color.Black;
                    buttonConfiguration.ForeColor = Color.Black;

                    break;

                case MenuTypes.MESURE:
                    statusMenu.Hide();
                    mesureMenu.Show();
                    cameraMenu.Hide();
                    configurationMenu.Hide();


                    buttonStatus.BackColor = Color.White;
                    buttonMesure.BackColor = Color.DarkGray;
                    buttonCamera.BackColor = Color.White;
                    buttonConfiguration.BackColor = Color.White;

                    buttonStatus.ForeColor = Color.Black;
                    buttonMesure.ForeColor = Color.White;
                    buttonCamera.ForeColor = Color.Black;
                    buttonConfiguration.ForeColor = Color.Black;
                    break;

                case MenuTypes.CAMERA:
                    statusMenu.Hide();
                    mesureMenu.Hide();
                    cameraMenu.Show();
                    configurationMenu.Hide();


                    buttonStatus.BackColor = Color.White;
                    buttonMesure.BackColor = Color.White;
                    buttonCamera.BackColor = Color.DarkGray;
                    buttonConfiguration.BackColor = Color.White;

                    buttonStatus.ForeColor = Color.Black;
                    buttonMesure.ForeColor = Color.Black;
                    buttonCamera.ForeColor = Color.White;
                    buttonConfiguration.ForeColor = Color.Black;
                    break;

                case MenuTypes.CONFIGURATION:
                    statusMenu.Hide();
                    mesureMenu.Hide();
                    cameraMenu.Hide();
                    configurationMenu.Show();


                    buttonStatus.BackColor = Color.White;
                    buttonMesure.BackColor = Color.White;
                    buttonCamera.BackColor = Color.White;
                    buttonConfiguration.BackColor = Color.DarkGray;

                    buttonStatus.ForeColor = Color.Black;
                    buttonMesure.ForeColor = Color.Black;
                    buttonCamera.ForeColor = Color.Black;
                    buttonConfiguration.ForeColor = Color.White;
                    break;
                default:
                    break;
            }

        }


        private void MenuEolia_Load(object sender, EventArgs e)
        {
            statusMenu.Parent = panelMenu;
            mesureMenu.Parent = panelMenu;
            cameraMenu.Parent = panelMenu;
            configurationMenu.Parent = panelMenu;
            chooseMenu(MenuTypes.STATUS);


            
            if (!EoliaUtils.EoliaConfigExiste())
            {

                configurationMenu.Sauvegarder();
                MessageBox.Show("Premier lancement, veuillez configurer la BDD dans EoliaConfig.config");
                Application.Exit();

            }
            else
            {

                //EoliaLogs.InitializeLogs();
                //EoliaLogs.Write("Démarrage de l'IHM");
                configurationMenu.Recharger();
                Console.WriteLine("Eolia IHM");

            }
        }


        private void buttonStatus_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.STATUS);
        }

        private void buttonMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.LiaisonSerieCapteur())
            {
                chooseMenu(MenuTypes.MESURE);
            }
            else
            {
                EoliaUtils.MsgBoxNonBloquante("Vous ne pouvez pas acceder a la gestion des mesures si la liaison série du capteur n'est pas fonctionnelle ");
            }
            
        }

        private void buttonCamera_Click(object sender, EventArgs e)
        {
            //foreach (string port in SerialPort.GetPortNames())
            //{
            //    if (port == "/dev/video0")
            //    {
            //        chooseMenu(MenuTypes.CAMERA);
            //        return;
            //    }
            //}

            /*try
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
                    EoliaUtils.MsgBoxNonBloquante("Impossible d'accèder a la gestion de la caméra, aucune caméra n'est détecter.", "ERREUR CAMERA");
                }
                else
                {
                    chooseMenu(MenuTypes.CAMERA);
                }
            } catch (Exception ee)
            {
                EoliaUtils.MsgBoxNonBloquante("Impossible de vérifier si la caméra existe, vous n'utilisez pas la bonne version/sysème d'exploitation.", "ERREUR CAMERA");
                Console.WriteLine(ee.Message);
            }*/
            chooseMenu(MenuTypes.CAMERA);





        }

        private void buttonConfiguration_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.CONFIGURATION);
            
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            if (EoliaMes.LiaisonSerieCapteur())
            {
                if (EoliaMes.EtatTransMes())
                    EoliaMes.ArreterTransMes();
                EoliaMes.FermerLiaisonSerieCapteur();
            }

            if (EoliaReg.LiaisonSerieReg())
                EoliaReg.FermerLiaisonSerieCapteur();

            Application.Restart();
            Environment.Exit(0);
        }


    }
}
