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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eolia_IHM.Utils.EoliaCam;

namespace Eolia_IHM.Menu
{
    public partial class CameraMenu : UserControl
    {
        //private EoliaCam cameraEolia = new EoliaCam();
        private String directoryVideo = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/VIDEO/";
        private String directoryImage = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/IMG/";
        private String directoryIcon = AppDomain.CurrentDomain.BaseDirectory + "/ICON/";
        private bool bigScreenActived = false;

        private bool savePictureAvecMesure = true;


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

                if (Directory.GetFiles(directoryImage).Length == 0) {labelAucuneImageTrouvee.Invoke(new Action(() => labelAucuneImageTrouvee.Visible = true)); flowLayoutPanelDossierImage.Controls.Clear(); return 0; }
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


                            string[] comboBoxFiltreDay = null;
                            string[] comboBoxFiltreMonth = null;
                            string[] comboBoxFiltreYears = null;
                            string[] comboBoxFiltreHour = null;
                            string[] comboBoxFiltreMinute = null;
                            string[] comboBoxFiltreSecond = null;

                            bool existedDay = false;
                            bool existedMonth = false;
                            bool existedYears = false;
                            bool existedHour = false;
                            bool existedMinute = false;
                            bool existedSecond = false;

                            //String comboBoxFiltreJour = null;
                            //comboBoxFiltreImageJour.Invoke(new Action(() => Convert.ToString(comboBoxFiltreImageJour.SelectedItem))));
                            comboBoxFiltreImageJour.Invoke((MethodInvoker)delegate { comboBoxFiltreDay = comboBoxFiltreImageJour.Items.Cast<string>().ToArray(); });
                            comboBoxFiltreImageMois.Invoke((MethodInvoker)delegate { comboBoxFiltreMonth = comboBoxFiltreImageMois.Items.Cast<string>().ToArray(); });
                            comboBoxFiltreImageAnnee.Invoke((MethodInvoker)delegate { comboBoxFiltreYears = comboBoxFiltreImageAnnee.Items.Cast<string>().ToArray(); });

                            comboBoxFiltreImageHeure.Invoke((MethodInvoker)delegate { comboBoxFiltreHour = comboBoxFiltreImageHeure.Items.Cast<string>().ToArray(); });
                            comboBoxFiltreImageMinute.Invoke((MethodInvoker)delegate { comboBoxFiltreMinute = comboBoxFiltreImageMinute.Items.Cast<string>().ToArray(); });
                            comboBoxFiltreImageSeconde.Invoke((MethodInvoker)delegate { comboBoxFiltreSecond = comboBoxFiltreImageSeconde.Items.Cast<string>().ToArray(); });

                            foreach (string item in comboBoxFiltreDay) { if (item.ToString() == day) { existedDay = true;} }
                            foreach (string item in comboBoxFiltreMonth) { if (item.ToString() == month) { existedMonth = true; } }
                            foreach (string item in comboBoxFiltreYears) { if (item.ToString() == years) { existedYears = true; } }
                            foreach (string item in comboBoxFiltreHour) { if (item.ToString() == hour) { existedHour = true; } }
                            foreach (string item in comboBoxFiltreMinute) { if (item.ToString() == minute) { existedMinute = true; } }
                            foreach (string item in comboBoxFiltreSecond) { if (item.ToString() == second) { existedSecond = true; } }



                            //EoliaLogs.Write(item.Length + "/" + comboBoxFiltreYears.Length + " : " + item, EoliaLogs.Types.DEBUG, "FILTRE");

                            //EoliaLogs.Write(comboBoxFiltreJour.Length + " : " + comboBoxFiltreJour.ToString(), EoliaLogs.Types.DEBUG, "FILTRE");

                            if (!existedDay) comboBoxFiltreImageJour.Invoke(new Action(() => comboBoxFiltreImageJour.Items.Add(day)));
                            if (!existedMonth) comboBoxFiltreImageMois.Invoke(new Action(() => comboBoxFiltreImageMois.Items.Add(month)));
                            if (!existedYears) comboBoxFiltreImageAnnee.Invoke(new Action(() => comboBoxFiltreImageAnnee.Items.Add(years)));
                            if (!existedHour) comboBoxFiltreImageHeure.Invoke(new Action(() => comboBoxFiltreImageHeure.Items.Add(hour)));
                            if (!existedMinute) comboBoxFiltreImageMinute.Invoke(new Action(() => comboBoxFiltreImageMinute.Items.Add(minute)));
                            if (!existedSecond) comboBoxFiltreImageSeconde.Invoke(new Action(() => comboBoxFiltreImageSeconde.Items.Add(second)));

                            comboBoxFiltreImageJour.Invoke(new Action(() => comboBoxFiltreImageJour.Sorted = true));
                            comboBoxFiltreImageMois.Invoke(new Action(() => comboBoxFiltreImageMois.Sorted = true));
                            comboBoxFiltreImageAnnee.Invoke(new Action(() => comboBoxFiltreImageAnnee.Sorted = true));
                            comboBoxFiltreImageHeure.Invoke(new Action(() => comboBoxFiltreImageHeure.Sorted = true));
                            comboBoxFiltreImageMinute.Invoke(new Action(() => comboBoxFiltreImageMinute.Sorted = true));
                            comboBoxFiltreImageSeconde.Invoke(new Action(() => comboBoxFiltreImageSeconde.Sorted = true));

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

                            pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.activeBigScreen);
                            //pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveMouseInFlowLayout);
                            //pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownMouseInFlowLayout);
                            //pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpMouseInFlowLayout);
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
                else EoliaLogs.Write("Bouton start retour cam introuvable !!! : " + directoryIcon, EoliaLogs.Types.CAMERA);
                if (File.Exists("ICON/buttonStopBig.png")) EoliaLogs.Write("OUIIIIIIIIIIII", EoliaLogs.Types.CAMERA);


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
                    
                    var task = Task.Run(() => {

                        Image imageCapture = EoliaCam.SavePicture(directoryImage, true);
                        if (imageCapture == null) return;
                        PictureBox pictureBox = new PictureBox();
                        //EoliaLogs.Write($"Check 1", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");

                        pictureBox.Size = new Size(130, 130);
                        pictureBox.Image = EoliaCam.SavePicture(directoryImage, true);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        //EoliaLogs.Write($"Check 2", EoliaLogs.Types.CAMERA, "FOLDER-IMAGE");
                        flowLayoutPanelDossierImage.Invoke(new Action(() => pictureBox.Parent = flowLayoutPanelDossierImage));
                        labelAucuneImageTrouvee.Invoke(new Action(() => labelAucuneImageTrouvee.Visible = false));
                    });
                    task.Wait();

                    //reloadDirectoryImage();
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
                er = EoliaCam.StartSaveVideo(directoryVideo);
                //buttonLancerEnregistrementVideo.Text = "Arrêter l'enregistrement vidéo";
                buttonPrendrePhoto.Enabled = false;
                buttonPrendrePhoto.BackColor = Color.Gray;
                if (iconIsExist("buttonStopRecBig.png"))
                    buttonLancerEnregistrementVideo.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStopRecBig.png");
            }
            else
            {
                if (EoliaCam.GetTypesCapture() != CameraTypes.VIDEOSAVE) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer l'enregistrement de video, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = EoliaCam.StopSaveVideo();
                //buttonLancerEnregistrementVideo.Text = "Lancer l'enregistrement vidéo";
                buttonPrendrePhoto.Enabled = true;
                buttonPrendrePhoto.BackColor = Color.White;
                if (iconIsExist("buttonStartRecBig.png"))
                    buttonLancerEnregistrementVideo.BackgroundImage = Image.FromFile(directoryIcon + "/buttonStartRecBig.png");

            }
            if (er != 0) EoliaLogs.Write("Erreur lancement de l'enregistrement video : " + er, EoliaLogs.Types.CAMERA);
        }

        private void checkBoxDisplayMesureInImage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisplayMesureInImage.Checked) savePictureAvecMesure = true;
            else savePictureAvecMesure = false;
        }

        private int posMouse;
        private bool mouseDown = false;
        private void DownMouseInFlowLayout(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Down FlowPanel X : " + flowLayoutPanelDossierImage.Height
            //    + " | Y : " + flowLayoutPanelDossierImage.AutoScrollPosition.Y + " | pos souris : " + Control.MousePosition.Y);
            posMouse = Control.MousePosition.Y;
            mouseDown = true;
        }

        private void UpMouseInFlowLayout(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Up FlowPanel X : " + flowLayoutPanelDossierImage.AutoScrollPosition.X
            //    + " | Y : " + flowLayoutPanelDossierImage.AutoScrollPosition.Y + " | pos souris : " + Control.MousePosition.Y + " = " + (Control.MousePosition.Y - posMouse));
            mouseDown = false;



        }
        private void MoveMouseInFlowLayout(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Console.WriteLine(
                    "MouseMove : flowY = " + flowLayoutPanelDossierImage.AutoScrollPosition.Y
                    + " | MouseY = " + Control.MousePosition.Y
                    + " | posMouse = " + posMouse
                    + " | NewPosFlowY-5 = " + (flowLayoutPanelDossierImage.AutoScrollPosition.Y - 5)
                    + " | NewPosFlowY+5 = " + (flowLayoutPanelDossierImage.AutoScrollPosition.Y + 5)
                    );

                int newPosition = 0;

                if (Control.MousePosition.Y < posMouse)
                {
                    newPosition = Math.Abs(flowLayoutPanelDossierImage.AutoScrollPosition.Y) + 20;
                    flowLayoutPanelDossierImage.AutoScrollPosition = new Point(
                        flowLayoutPanelDossierImage.AutoScrollPosition.X,
                        newPosition
                    );

                    //Console.WriteLine("PLUS : " + nouvellePosisition);
                } else if (Control.MousePosition.Y > posMouse)
                {
                    newPosition = Math.Abs(flowLayoutPanelDossierImage.AutoScrollPosition.Y) - 20;
                    flowLayoutPanelDossierImage.AutoScrollPosition = new Point(
                        flowLayoutPanelDossierImage.AutoScrollPosition.X,
                        newPosition
                    );
                    //Console.WriteLine("MOINS : " + nouvellePosisition);
                }

                posMouse = Control.MousePosition.Y;
            }
        }

        private void deleteAllImages(object sender, EventArgs e)
        {
            foreach(string fileName in Directory.GetFiles(directoryImage))
            {
                File.Delete(fileName);
                //Console.WriteLine("File is = " + fileName);
            }
            EoliaLogs.Write("Toutes les images capturés manuellement ont étaient supprimé.");
            reloadDirectoryImage();
        }
    }
}