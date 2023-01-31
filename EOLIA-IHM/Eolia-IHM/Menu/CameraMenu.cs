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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Eolia_IHM.Utils.EoliaCam;

namespace Eolia_IHM.Menu
{
    public partial class CameraMenu : UserControl
    {
        private EoliaCam cameraEolia = new EoliaCam();
        private String directoryVideo = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/VIDEO";
        private String directoryImage = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/IMG";



        public CameraMenu()
        {
            InitializeComponent();
            labelAucuneImageTrouvee.Visible = false;
        }

        private void CameraMenu_Load(object sender, EventArgs e)
        {
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

        private void comboBoxFiltreImageReload(object sender, EventArgs e)
        {
            reloadDirectoryImage();
        }


        private bool reloadDirectoryImage()
        {
            if (Directory.Exists(directoryImage))
            {

                if (Directory.GetFiles(directoryImage).Length == 0) { labelAucuneImageTrouvee.Visible = true; return true; }
                //Task.Run(() =>
                //{
                    String[] nameFileImage = Directory.GetFiles(directoryImage);
                    //if (Directory.GetFiles(directoryImage).Length == 0) { labelAucuneImageTrouvee.Visible = true; return; }
                    flowLayoutPanelDossierImage.Controls.Clear();
                    for (int i = 0; i < Directory.GetFiles(directoryImage).Length; i++)
                    {
                        String fileTMP = nameFileImage[i].Substring(nameFileImage[i].IndexOf('[') + 1);
                        String[] nameFileEdited = fileTMP.Split('-');

                        String day = nameFileEdited[0].ToString();
                        String month = nameFileEdited[1].ToString();
                        String years = nameFileEdited[2].ToString();

                        String hour = nameFileEdited[4].ToString();
                        String minute = nameFileEdited[5].ToString();
                        String second = nameFileEdited[6].ToString().Split(']')[0];


                        //comboBoxFiltreImageJour.Invoke(new Action(() => BoutonStartSQL.Enabled = true));


                        if (comboBoxFiltreImageJour.Text.Length != 0 && day != comboBoxFiltreImageJour.Text) continue;
                        if (comboBoxFiltreImageMois.Text.Length != 0 && month != comboBoxFiltreImageMois.Text) continue;
                        if (comboBoxFiltreImageAnnee.Text.Length != 0 && years != comboBoxFiltreImageAnnee.Text) continue;

                        if (comboBoxFiltreImageHeure.Text.Length != 0 && hour != comboBoxFiltreImageHeure.Text) continue;
                        if (comboBoxFiltreImageMinute.Text.Length != 0 && minute != comboBoxFiltreImageMinute.Text) continue;
                        if (comboBoxFiltreImageSeconde.Text.Length != 0 && second != comboBoxFiltreImageSeconde.Text) continue;
                        labelAucuneImageTrouvee.Visible = false;
                        //Console.WriteLine(day + " | " + month + " | " + years + " || " + hour + " | " + minute + " | " + second + " | ");

                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Size = new Size(130, 130);
                        pictureBox.Image = Image.FromFile(nameFileImage[i]);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Parent = flowLayoutPanelDossierImage;
                    }
                    if (flowLayoutPanelDossierImage.Controls.Count == 0) labelAucuneImageTrouvee.Visible = true;
                //});
                

            }
            else
            {
                Directory.CreateDirectory(directoryImage);
                labelAucuneImageTrouvee.Visible = true;
                return true;
            }
            return false;
        }


        private void buttonActiverRetourCamera_Click(object sender, EventArgs e)
        {
            int er;
            if (!cameraEolia.CaptureIsStart())
            {
                if (cameraEolia.IsStream()) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer une capture d'image, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = cameraEolia.StartDisplayImage(pictureBoxRetourCamera);
                buttonActiverRetourCamera.Text = "Activée la camera";
            }
            else
            {
                if (cameraEolia.GetTypesCapture() != CameraTypes.IMAGECAPTURE) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer  une capture d'image, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = cameraEolia.StopDisplayImage();
                buttonActiverRetourCamera.Text = "Désactiver la camera";

            }
            if (er != 0) EoliaLogs.Write("Erreur lancement capture d'image: " + er, EoliaLogs.Types.CAMERA);
        }

        private void buttonPrendrePhoto_Click(object sender, EventArgs e)
        {
            cameraEolia.SavePicture(directoryImage, 0, 0);
        }

        private void buttonLancerEnregistrementVideo_Click(object sender, EventArgs e)
        {
            int er;
            if (!cameraEolia.CaptureIsStart())
            {
                if (cameraEolia.IsStream()) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer une l'enregistrement de video, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = cameraEolia.StartSaveVideo(directoryVideo);
                buttonLancerEnregistrementVideo.Text = "Arrêter l'enregistrement vidéo";
            }
            else
            {
                if (cameraEolia.GetTypesCapture() != CameraTypes.VIDEOSAVE) { EoliaUtils.MsgBoxNonBloquante("Impossible de lancer l'enregistrement de video, une capture est déjà en cours, veuiller l'arrêter en premier.", "Erreur : Impossible d'accèder au flux"); return; }
                er = cameraEolia.StopSaveVideo();
                buttonLancerEnregistrementVideo.Text = "Lancer l'enregistrement vidéo";

            }
            if (er != 0) EoliaLogs.Write("Erreur lancement de l'enregistrement video : " + er, EoliaLogs.Types.CAMERA);
        }

    }
}
