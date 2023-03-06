using Eolia_IHM.Properties;
using Eolia_IHM.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eolia_IHM.Utils.EoliaCam;

namespace Eolia_IHM.Menu
{
    public partial class CameraMenu : UserControl
    {
        //private EoliaCam cameraEolia = new EoliaCam();
        private String directoryVideo = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/VIDEO";
        private String directoryImage = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/IMG";
        private String directoryIcon = "ICON";
        private bool bigScreenActived = false;

        private bool savePictureAvecMesure = false;

        //private static Mutex mtx;



        //this.pictureBoxBigScreen.Click += new System.EventHandler(this.pictureBoxBigScreen_Click);



        public CameraMenu()
        {
            InitializeComponent();
        }

        private void CameraMenu_Load(object sender, EventArgs e)
        {
            labelAucuneImageTrouvee.Visible = false;
            pictureBoxBigScreen.Visible = false;
            reloadDirectoryImage();
        }


        private void buttonRemiseAZeroDuFiltre_Click(object sender, EventArgs e)
        {

            comboBoxFiltreImageJour.ResetText();
            comboBoxFiltreImageMois.ResetText();
            comboBoxFiltreImageAnnee.ResetText();

            comboBoxFiltreImageHeure.ResetText();
            comboBoxFiltreImageMinute.ResetText();
            comboBoxFiltreImageSeconde.ResetText();


            reloadDirectoryImage();

        }

        // Evenement des comboBox si ils changent
        private void comboBoxFiltreImageReload(object sender, EventArgs e)
        {
            reloadDirectoryImage();
        }

        private void activeBigScreen(object sender, EventArgs e)
        {
            if (!bigScreenActived)
            {
                PictureBox pictureBox = (PictureBox)sender;
                pictureBoxBigScreen.Image = pictureBox.Image;
                pictureBoxBigScreen.Visible = true;
                flowLayoutPanelDossierImage.Visible = false;
                bigScreenActived = true;
            }
            else
            {
                pictureBoxBigScreen.Visible = false;
                flowLayoutPanelDossierImage.Visible = true;
                bigScreenActived = false;
            }
        }


        private bool iconIsExist(String nameIcon)
        {
            if (File.Exists($"{directoryIcon}/{nameIcon}")) return true;
            else return false;
        }

        private int reloadDirectoryImage()
        {
            if (Directory.Exists(directoryImage))
            {

                if (Directory.GetFiles(directoryImage).Length == 0) {labelAucuneImageTrouvee.Invoke(new Action(() => labelAucuneImageTrouvee.Visible = true));; return 0; }
                else { labelAucuneImageTrouvee.Invoke(new Action(() => labelAucuneImageTrouvee.Visible = false));  }

                int er = 0;
                try
                {
                    String[] nameFileImage = Directory.GetFiles(directoryImage);
                    
                    flowLayoutPanelDossierImage.Invoke(new Action(() => flowLayoutPanelDossierImage.Controls.Clear()));
                    int numberAllImage = 0;
                    Task.Run(() =>
                    {
                        EoliaLogs.Write($"Nombre d'image : {Directory.GetFiles(directoryImage).Length}");
                        for (int i = 0; i < Directory.GetFiles(directoryImage).Length; i++)
                        {
                            er = 2;

                            String fileTMP = nameFileImage[i].Substring(nameFileImage[i].IndexOf('[') + 1);
                            String[] nameFileEdited = fileTMP.Split('-');

                            String day = nameFileEdited[0].ToString();
                            String month = nameFileEdited[1].ToString();
                            String years = nameFileEdited[2].ToString();

                            String hour = nameFileEdited[4].ToString();
                            String minute = nameFileEdited[5].ToString();
                            String second = nameFileEdited[6].ToString().Split(']')[0];

                            er = 3;

                            //comboBoxFiltreImageJour.Invoke(new Action(() => BoutonStartSQL.Enabled = true));
                            //EoliaLogs.Write($"Vérification des comboBox", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");
                            //comboBoxFiltreImageJour.Invoke(new Action(() => comboBoxFiltreImageJour.Text.Length.C));

                            int lenghtImageJour = 0,
                            lenghtImageMois = 0,
                            lenghtImageAnnee = 0, 
                            lenghtImageHeure = 0,
                            lenghtImageMinute = 0,
                            lenghtImageSeconde = 0;

                            comboBoxFiltreImageJour.Invoke((MethodInvoker)delegate { lenghtImageJour = comboBoxFiltreImageJour.Text.Length; });
                            comboBoxFiltreImageMois.Invoke((MethodInvoker)delegate { lenghtImageMois = comboBoxFiltreImageMois.Text.Length; });
                            comboBoxFiltreImageAnnee.Invoke((MethodInvoker)delegate { lenghtImageAnnee = comboBoxFiltreImageAnnee.Text.Length; });

                            comboBoxFiltreImageHeure.Invoke((MethodInvoker)delegate { lenghtImageHeure = comboBoxFiltreImageHeure.Text.Length; });
                            comboBoxFiltreImageMinute.Invoke((MethodInvoker)delegate { lenghtImageMinute = comboBoxFiltreImageMinute.Text.Length; });
                            comboBoxFiltreImageSeconde.Invoke((MethodInvoker)delegate { lenghtImageSeconde = comboBoxFiltreImageSeconde.Text.Length; });


                            String filtreImageJour = null,
                            filtreImageMois = null,
                            filtreImageAnnee = null,
                            filtreImageHeure = null,
                            filtreImageMinute = null,
                            filtreImageSeconde = null;

                            comboBoxFiltreImageJour.Invoke((MethodInvoker)delegate { filtreImageJour = comboBoxFiltreImageJour.Text; });
                            comboBoxFiltreImageMois.Invoke((MethodInvoker)delegate { filtreImageMois = comboBoxFiltreImageMois.Text; });
                            comboBoxFiltreImageAnnee.Invoke((MethodInvoker)delegate { filtreImageAnnee = comboBoxFiltreImageAnnee.Text; });

                            comboBoxFiltreImageHeure.Invoke((MethodInvoker)delegate { filtreImageHeure = comboBoxFiltreImageHeure.Text; });
                            comboBoxFiltreImageMinute.Invoke((MethodInvoker)delegate { filtreImageMinute = comboBoxFiltreImageMinute.Text; });
                            comboBoxFiltreImageSeconde.Invoke((MethodInvoker)delegate { filtreImageSeconde = comboBoxFiltreImageSeconde.Text; });

                            
                            if (lenghtImageJour != 0 && day != filtreImageJour) continue;
                            if (lenghtImageMois != 0 && month != filtreImageMois) continue;
                            if (lenghtImageAnnee != 0 && years != filtreImageAnnee) continue;

                            if (lenghtImageHeure != 0 && hour != filtreImageHeure) continue;
                            if (lenghtImageMinute != 0 && minute != filtreImageMinute) continue;
                            if (lenghtImageSeconde != 0 && second != filtreImageSeconde) continue;

                            //EoliaLogs.Write(day + " | " + month + " | " + years + " || " + hour + " | " + minute + " | " + second + " > " + nameFileImage[i] + " | " + i, , EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");
                            er = 4;

                            PictureBox pictureBox = new PictureBox();
                            //EoliaLogs.Write($"Check 1", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");

                            pictureBox.Size = new Size(130, 130);
                            pictureBox.Image = Image.FromFile(nameFileImage[i]);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            //EoliaLogs.Write($"Check 2", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");

                            flowLayoutPanelDossierImage.Invoke(new Action(() => pictureBox.Parent = flowLayoutPanelDossierImage));
                            //pictureBox.Parent = flowLayoutPanelDossierImage;

                            //EoliaLogs.Write($"Check 3", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");
                            //pictureBox.Invoke(new Action(() => pictureBox.Click += new System.EventHandler(this.activeBigScreen)));

                            pictureBox.Click += new System.EventHandler(this.activeBigScreen);
                            //EoliaLogs.Write($"Check 4", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");

                            er = 5;
                            numberAllImage++;
                            //EoliaLogs.Write($"Image {i} = {nameFileImage[i]}:{pictureBox.ToString()} - TT:{numberAllImage}|{Directory.GetFiles(directoryImage).Length}", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");
                        }
                        if (numberAllImage == 0) labelAucuneImageTrouvee.Invoke(new Action(() => labelAucuneImageTrouvee.Visible = true));
                    });
                    return er;
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                    return -1;
                }

                //});

                //return er;
            }
            else
            {
                Directory.CreateDirectory(directoryImage);
                labelAucuneImageTrouvee.Visible = true;
                return 0;
            }
        }


        private void buttonActiverRetourCamera_Click(object sender, EventArgs e)
        {
            int er;
            if (!EoliaCam.CaptureIsStart())
            {
                if (EoliaCam.IsStream()) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer une capture d'image, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = EoliaCam.StartDisplayImage(pictureBoxRetourCamera);
                //buttonActiverRetourCamera.Text = "Activée la camera";
                if (iconIsExist("buttonStopBig.png"))
                    buttonActiverRetourCamera.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStopBig.png");
            }
            else
            {
                if (EoliaCam.GetTypesCapture() != CameraTypes.IMAGECAPTURE) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer  une capture d'image, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = EoliaCam.StopDisplayImage();
                //buttonActiverRetourCamera.Text = "Désactiver la camera";
                if (iconIsExist("buttonStartBig.png"))
                    buttonActiverRetourCamera.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartBig.png");

            }
            if (er != 0) EoliaLogs.Write("Erreur lancement capture d'image: " + er, EoliaLogs.Types.CAMERA);
        }

        private void buttonPrendrePhoto_Click(object sender, EventArgs e)
        {
            if (iconIsExist("buttonStopScreenshotBig.png"))
                buttonPrendrePhoto.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStopScreenshotBig.png");
            if (savePictureAvecMesure)
            {
                Task.Run(() =>
                {
                    
                    var task = Task.Run(() => { EoliaCam.SavePicture(directoryImage, true); });
                    task.Wait();

                    reloadDirectoryImage();
                    if (iconIsExist("buttonStartScreenshotBig.png"))
                        buttonPrendrePhoto.Invoke((MethodInvoker)delegate { buttonPrendrePhoto.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartScreenshotBig.png"); });
                    //buttonPrendrePhoto.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartScreenshotBig.png");
                });
            }
            else
            {
                Task.Run(() =>
                {
                    var task = Task.Run(() => { EoliaCam.SavePicture(directoryImage, false); });
                    task.Wait();

                    reloadDirectoryImage();
                    if (iconIsExist("buttonStartScreenshotBig.png"))
                        buttonPrendrePhoto.Invoke((MethodInvoker)delegate { buttonPrendrePhoto.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartScreenshotBig.png"); });
                    //buttonPrendrePhoto.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartScreenshotBig.png");
                });

            }


        }

        private void buttonLancerEnregistrementVideo_Click(object sender, EventArgs e)
        {
            int er;
            if (!EoliaCam.CaptureIsStart())
            {
                if (EoliaCam.IsStream()) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer une l'enregistrement de video, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = EoliaCam.StartSaveVideo();
                //buttonLancerEnregistrementVideo.Text = "Arrêter l'enregistrement vidéo";
                if (iconIsExist("buttonStopRecBig.png"))
                    buttonLancerEnregistrementVideo.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStopRecBig.png");
            }
            else
            {
                if (EoliaCam.GetTypesCapture() != CameraTypes.VIDEOSAVE) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer l'enregistrement de video, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = EoliaCam.StopSaveVideo(directoryVideo);
                //buttonLancerEnregistrementVideo.Text = "Lancer l'enregistrement vidéo";
                if (iconIsExist("buttonStartRecBig.png"))
                    buttonLancerEnregistrementVideo.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartRecBig.png");

            }
            if (er != 0) EoliaLogs.Write("Erreur lancement de l'enregistrement video : " + er, EoliaLogs.Types.CAMERA);
        }

        private void buttonActualiserDossier_Click(object sender, EventArgs e)
        {
            if (iconIsExist("buttonStopReloadFileBig.png"))
                buttonActualiserDossier.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStopReloadFileBig.png");
            reloadDirectoryImage();
            if (iconIsExist("buttonStartReloadFileBig.png"))
                buttonActualiserDossier.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartReloadFileBig.png");
        }

        private void checkBoxDisplayMesureInImage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayMesureInImage.Checked) savePictureAvecMesure = true;
            else savePictureAvecMesure = false;
        }
    }
}