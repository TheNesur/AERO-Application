
namespace Eolia_IHM.Menu
{
    partial class CameraMenu
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraMenu));
            this.labelAucuneImageTrouvee = new System.Windows.Forms.Label();
            this.groupBoxDossierVideo = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelDossierImage = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxRetourCamera = new System.Windows.Forms.PictureBox();
            this.buttonLancerEnregistrementVideo = new System.Windows.Forms.Button();
            this.buttonActiverRetourCamera = new System.Windows.Forms.Button();
            this.buttonRemiseAZeroDuFiltre = new System.Windows.Forms.Button();
            this.buttonPrendrePhoto = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxFiltreImageJour = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltreImageHeure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFiltreImageMois = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltreImageMinute = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFiltreImageAnnee = new System.Windows.Forms.ComboBox();
            this.comboBoxFiltreImageSeconde = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDossierVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetourCamera)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAucuneImageTrouvee
            // 
            this.labelAucuneImageTrouvee.AutoSize = true;
            this.labelAucuneImageTrouvee.Font = new System.Drawing.Font("Montserrat ExtraBold", 19F);
            this.labelAucuneImageTrouvee.Location = new System.Drawing.Point(60, 180);
            this.labelAucuneImageTrouvee.Name = "labelAucuneImageTrouvee";
            this.labelAucuneImageTrouvee.Size = new System.Drawing.Size(333, 36);
            this.labelAucuneImageTrouvee.TabIndex = 0;
            this.labelAucuneImageTrouvee.Text = "Aucune image trouvée";
            // 
            // groupBoxDossierVideo
            // 
            this.groupBoxDossierVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.groupBoxDossierVideo.Controls.Add(this.labelAucuneImageTrouvee);
            this.groupBoxDossierVideo.Controls.Add(this.flowLayoutPanelDossierImage);
            this.groupBoxDossierVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxDossierVideo.Location = new System.Drawing.Point(572, 17);
            this.groupBoxDossierVideo.Name = "groupBoxDossierVideo";
            this.groupBoxDossierVideo.Size = new System.Drawing.Size(429, 383);
            this.groupBoxDossierVideo.TabIndex = 20;
            this.groupBoxDossierVideo.TabStop = false;
            this.groupBoxDossierVideo.Text = "Dossier Image";
            // 
            // flowLayoutPanelDossierImage
            // 
            this.flowLayoutPanelDossierImage.AutoScroll = true;
            this.flowLayoutPanelDossierImage.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowLayoutPanelDossierImage.Location = new System.Drawing.Point(1, 26);
            this.flowLayoutPanelDossierImage.Name = "flowLayoutPanelDossierImage";
            this.flowLayoutPanelDossierImage.Size = new System.Drawing.Size(428, 357);
            this.flowLayoutPanelDossierImage.TabIndex = 3;
            // 
            // pictureBoxRetourCamera
            // 
            this.pictureBoxRetourCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.pictureBoxRetourCamera.ErrorImage = null;
            this.pictureBoxRetourCamera.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRetourCamera.Image")));
            this.pictureBoxRetourCamera.Location = new System.Drawing.Point(22, 17);
            this.pictureBoxRetourCamera.Name = "pictureBoxRetourCamera";
            this.pictureBoxRetourCamera.Size = new System.Drawing.Size(280, 256);
            this.pictureBoxRetourCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRetourCamera.TabIndex = 21;
            this.pictureBoxRetourCamera.TabStop = false;
            // 
            // buttonLancerEnregistrementVideo
            // 
            this.buttonLancerEnregistrementVideo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLancerEnregistrementVideo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonLancerEnregistrementVideo.Font = new System.Drawing.Font("Montserrat ExtraBold", 10F);
            this.buttonLancerEnregistrementVideo.Location = new System.Drawing.Point(22, 350);
            this.buttonLancerEnregistrementVideo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLancerEnregistrementVideo.Name = "buttonLancerEnregistrementVideo";
            this.buttonLancerEnregistrementVideo.Size = new System.Drawing.Size(257, 50);
            this.buttonLancerEnregistrementVideo.TabIndex = 23;
            this.buttonLancerEnregistrementVideo.Text = "Lancer l\'enregistrement vidéo";
            this.buttonLancerEnregistrementVideo.UseVisualStyleBackColor = false;
            this.buttonLancerEnregistrementVideo.Click += new System.EventHandler(this.buttonLancerEnregistrementVideo_Click);
            // 
            // buttonActiverRetourCamera
            // 
            this.buttonActiverRetourCamera.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonActiverRetourCamera.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonActiverRetourCamera.Font = new System.Drawing.Font("Montserrat ExtraBold", 13F);
            this.buttonActiverRetourCamera.Location = new System.Drawing.Point(22, 290);
            this.buttonActiverRetourCamera.Margin = new System.Windows.Forms.Padding(0);
            this.buttonActiverRetourCamera.Name = "buttonActiverRetourCamera";
            this.buttonActiverRetourCamera.Size = new System.Drawing.Size(257, 50);
            this.buttonActiverRetourCamera.TabIndex = 22;
            this.buttonActiverRetourCamera.Text = "Activée la caméra";
            this.buttonActiverRetourCamera.UseVisualStyleBackColor = false;
            this.buttonActiverRetourCamera.Click += new System.EventHandler(this.buttonActiverRetourCamera_Click);
            // 
            // buttonRemiseAZeroDuFiltre
            // 
            this.buttonRemiseAZeroDuFiltre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemiseAZeroDuFiltre.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonRemiseAZeroDuFiltre.Font = new System.Drawing.Font("Montserrat ExtraBold", 13F);
            this.buttonRemiseAZeroDuFiltre.Location = new System.Drawing.Point(287, 350);
            this.buttonRemiseAZeroDuFiltre.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRemiseAZeroDuFiltre.Name = "buttonRemiseAZeroDuFiltre";
            this.buttonRemiseAZeroDuFiltre.Size = new System.Drawing.Size(257, 50);
            this.buttonRemiseAZeroDuFiltre.TabIndex = 25;
            this.buttonRemiseAZeroDuFiltre.Text = "Remise a zéro du filtre";
            this.buttonRemiseAZeroDuFiltre.UseVisualStyleBackColor = false;
            this.buttonRemiseAZeroDuFiltre.Click += new System.EventHandler(this.buttonRemiseAZeroDuFiltre_Click);
            // 
            // buttonPrendrePhoto
            // 
            this.buttonPrendrePhoto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPrendrePhoto.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonPrendrePhoto.Font = new System.Drawing.Font("Montserrat ExtraBold", 13F);
            this.buttonPrendrePhoto.Location = new System.Drawing.Point(287, 290);
            this.buttonPrendrePhoto.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrendrePhoto.Name = "buttonPrendrePhoto";
            this.buttonPrendrePhoto.Size = new System.Drawing.Size(257, 50);
            this.buttonPrendrePhoto.TabIndex = 24;
            this.buttonPrendrePhoto.Text = "Prendre Photo";
            this.buttonPrendrePhoto.UseVisualStyleBackColor = false;
            this.buttonPrendrePhoto.Click += new System.EventHandler(this.buttonPrendrePhoto_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Jour :";
            // 
            // comboBoxFiltreImageJour
            // 
            this.comboBoxFiltreImageJour.FormattingEnabled = true;
            this.comboBoxFiltreImageJour.IntegralHeight = false;
            this.comboBoxFiltreImageJour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBoxFiltreImageJour.Location = new System.Drawing.Point(71, 25);
            this.comboBoxFiltreImageJour.MaxDropDownItems = 10;
            this.comboBoxFiltreImageJour.Name = "comboBoxFiltreImageJour";
            this.comboBoxFiltreImageJour.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageJour.TabIndex = 3;
            this.comboBoxFiltreImageJour.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // comboBoxFiltreImageHeure
            // 
            this.comboBoxFiltreImageHeure.FormattingEnabled = true;
            this.comboBoxFiltreImageHeure.IntegralHeight = false;
            this.comboBoxFiltreImageHeure.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.comboBoxFiltreImageHeure.Location = new System.Drawing.Point(85, 143);
            this.comboBoxFiltreImageHeure.MaxDropDownItems = 10;
            this.comboBoxFiltreImageHeure.Name = "comboBoxFiltreImageHeure";
            this.comboBoxFiltreImageHeure.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageHeure.TabIndex = 3;
            this.comboBoxFiltreImageHeure.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mois :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Minute :";
            // 
            // comboBoxFiltreImageMois
            // 
            this.comboBoxFiltreImageMois.FormattingEnabled = true;
            this.comboBoxFiltreImageMois.IntegralHeight = false;
            this.comboBoxFiltreImageMois.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comboBoxFiltreImageMois.Location = new System.Drawing.Point(71, 59);
            this.comboBoxFiltreImageMois.MaxDropDownItems = 10;
            this.comboBoxFiltreImageMois.Name = "comboBoxFiltreImageMois";
            this.comboBoxFiltreImageMois.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageMois.TabIndex = 5;
            this.comboBoxFiltreImageMois.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // comboBoxFiltreImageMinute
            // 
            this.comboBoxFiltreImageMinute.FormattingEnabled = true;
            this.comboBoxFiltreImageMinute.IntegralHeight = false;
            this.comboBoxFiltreImageMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60\t"});
            this.comboBoxFiltreImageMinute.Location = new System.Drawing.Point(86, 177);
            this.comboBoxFiltreImageMinute.MaxDropDownItems = 10;
            this.comboBoxFiltreImageMinute.Name = "comboBoxFiltreImageMinute";
            this.comboBoxFiltreImageMinute.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageMinute.TabIndex = 5;
            this.comboBoxFiltreImageMinute.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Année :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seconde :";
            // 
            // comboBoxFiltreImageAnnee
            // 
            this.comboBoxFiltreImageAnnee.FormattingEnabled = true;
            this.comboBoxFiltreImageAnnee.IntegralHeight = false;
            this.comboBoxFiltreImageAnnee.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024"});
            this.comboBoxFiltreImageAnnee.Location = new System.Drawing.Point(85, 93);
            this.comboBoxFiltreImageAnnee.MaxDropDownItems = 10;
            this.comboBoxFiltreImageAnnee.Name = "comboBoxFiltreImageAnnee";
            this.comboBoxFiltreImageAnnee.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageAnnee.TabIndex = 7;
            this.comboBoxFiltreImageAnnee.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // comboBoxFiltreImageSeconde
            // 
            this.comboBoxFiltreImageSeconde.FormattingEnabled = true;
            this.comboBoxFiltreImageSeconde.IntegralHeight = false;
            this.comboBoxFiltreImageSeconde.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.comboBoxFiltreImageSeconde.Location = new System.Drawing.Point(102, 211);
            this.comboBoxFiltreImageSeconde.MaxDropDownItems = 10;
            this.comboBoxFiltreImageSeconde.Name = "comboBoxFiltreImageSeconde";
            this.comboBoxFiltreImageSeconde.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltreImageSeconde.TabIndex = 7;
            this.comboBoxFiltreImageSeconde.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltreImageReload);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageSeconde);
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageAnnee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageMinute);
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageMois);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageHeure);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxFiltreImageJour);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(309, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 256);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètre du Filtre d\'image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Heure :";
            // 
            // CameraMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRemiseAZeroDuFiltre);
            this.Controls.Add(this.buttonPrendrePhoto);
            this.Controls.Add(this.buttonLancerEnregistrementVideo);
            this.Controls.Add(this.buttonActiverRetourCamera);
            this.Controls.Add(this.pictureBoxRetourCamera);
            this.Controls.Add(this.groupBoxDossierVideo);
            this.Name = "CameraMenu";
            this.Size = new System.Drawing.Size(1020, 417);
            this.Load += new System.EventHandler(this.CameraMenu_Load);
            this.groupBoxDossierVideo.ResumeLayout(false);
            this.groupBoxDossierVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetourCamera)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxDossierVideo;
        private System.Windows.Forms.PictureBox pictureBoxRetourCamera;
        private System.Windows.Forms.Button buttonLancerEnregistrementVideo;
        private System.Windows.Forms.Button buttonActiverRetourCamera;
        private System.Windows.Forms.Button buttonRemiseAZeroDuFiltre;
        private System.Windows.Forms.Button buttonPrendrePhoto;
        private System.Windows.Forms.Label labelAucuneImageTrouvee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDossierImage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageJour;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageHeure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageMois;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageMinute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageAnnee;
        private System.Windows.Forms.ComboBox comboBoxFiltreImageSeconde;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}
