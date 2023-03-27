
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
            this.pictureBoxBigScreen = new System.Windows.Forms.PictureBox();
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
            this.buttonActualiserDossier = new System.Windows.Forms.Button();
            this.checkBoxDisplayMesureInImage = new System.Windows.Forms.CheckBox();
            this.groupBoxDossierVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetourCamera)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAucuneImageTrouvee
            // 
            this.labelAucuneImageTrouvee.AutoSize = true;
            this.labelAucuneImageTrouvee.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.labelAucuneImageTrouvee.Location = new System.Drawing.Point(60, 180);
            this.labelAucuneImageTrouvee.Name = "labelAucuneImageTrouvee";
            this.labelAucuneImageTrouvee.Size = new System.Drawing.Size(268, 30);
            this.labelAucuneImageTrouvee.TabIndex = 0;
            this.labelAucuneImageTrouvee.Text = "Aucune image trouvée";
            // 
            // groupBoxDossierVideo
            // 
            this.groupBoxDossierVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.groupBoxDossierVideo.Controls.Add(this.pictureBoxBigScreen);
            this.groupBoxDossierVideo.Controls.Add(this.labelAucuneImageTrouvee);
            this.groupBoxDossierVideo.Controls.Add(this.flowLayoutPanelDossierImage);
            this.groupBoxDossierVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxDossierVideo.Location = new System.Drawing.Point(572, 17);
            this.groupBoxDossierVideo.Name = "groupBoxDossierVideo";
            this.groupBoxDossierVideo.Size = new System.Drawing.Size(429, 397);
            this.groupBoxDossierVideo.TabIndex = 20;
            this.groupBoxDossierVideo.TabStop = false;
            this.groupBoxDossierVideo.Text = "Dossier Image";
            // 
            // pictureBoxBigScreen
            // 
            this.pictureBoxBigScreen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBigScreen.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBigScreen.Image")));
            this.pictureBoxBigScreen.Location = new System.Drawing.Point(5, 0);
            this.pictureBoxBigScreen.Name = "pictureBoxBigScreen";
            this.pictureBoxBigScreen.Size = new System.Drawing.Size(418, 400);
            this.pictureBoxBigScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBigScreen.TabIndex = 4;
            this.pictureBoxBigScreen.TabStop = false;
            this.pictureBoxBigScreen.Click += new System.EventHandler(this.activeBigScreen);
            // 
            // flowLayoutPanelDossierImage
            // 
            this.flowLayoutPanelDossierImage.AutoScroll = true;
            this.flowLayoutPanelDossierImage.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowLayoutPanelDossierImage.Location = new System.Drawing.Point(1, 26);
            this.flowLayoutPanelDossierImage.Name = "flowLayoutPanelDossierImage";
            this.flowLayoutPanelDossierImage.Size = new System.Drawing.Size(428, 342);
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
            this.buttonLancerEnregistrementVideo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLancerEnregistrementVideo.BackgroundImage")));
            this.buttonLancerEnregistrementVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLancerEnregistrementVideo.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonLancerEnregistrementVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLancerEnregistrementVideo.Location = new System.Drawing.Point(123, 284);
            this.buttonLancerEnregistrementVideo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLancerEnregistrementVideo.Name = "buttonLancerEnregistrementVideo";
            this.buttonLancerEnregistrementVideo.Size = new System.Drawing.Size(80, 80);
            this.buttonLancerEnregistrementVideo.TabIndex = 23;
            this.buttonLancerEnregistrementVideo.UseVisualStyleBackColor = false;
            this.buttonLancerEnregistrementVideo.Click += new System.EventHandler(this.buttonLancerEnregistrementVideo_Click);
            // 
            // buttonActiverRetourCamera
            // 
            this.buttonActiverRetourCamera.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonActiverRetourCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonActiverRetourCamera.BackgroundImage")));
            this.buttonActiverRetourCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonActiverRetourCamera.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonActiverRetourCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonActiverRetourCamera.Location = new System.Drawing.Point(22, 284);
            this.buttonActiverRetourCamera.Margin = new System.Windows.Forms.Padding(0);
            this.buttonActiverRetourCamera.Name = "buttonActiverRetourCamera";
            this.buttonActiverRetourCamera.Size = new System.Drawing.Size(80, 80);
            this.buttonActiverRetourCamera.TabIndex = 22;
            this.buttonActiverRetourCamera.UseVisualStyleBackColor = false;
            this.buttonActiverRetourCamera.Click += new System.EventHandler(this.buttonActiverRetourCamera_Click);
            // 
            // buttonRemiseAZeroDuFiltre
            // 
            this.buttonRemiseAZeroDuFiltre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemiseAZeroDuFiltre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemiseAZeroDuFiltre.BackgroundImage")));
            this.buttonRemiseAZeroDuFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemiseAZeroDuFiltre.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRemiseAZeroDuFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonRemiseAZeroDuFiltre.Location = new System.Drawing.Point(357, 284);
            this.buttonRemiseAZeroDuFiltre.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRemiseAZeroDuFiltre.Name = "buttonRemiseAZeroDuFiltre";
            this.buttonRemiseAZeroDuFiltre.Size = new System.Drawing.Size(80, 80);
            this.buttonRemiseAZeroDuFiltre.TabIndex = 25;
            this.buttonRemiseAZeroDuFiltre.UseVisualStyleBackColor = false;
            this.buttonRemiseAZeroDuFiltre.Click += new System.EventHandler(this.buttonRemiseAZeroDuFiltre_Click);
            // 
            // buttonPrendrePhoto
            // 
            this.buttonPrendrePhoto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPrendrePhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrendrePhoto.BackgroundImage")));
            this.buttonPrendrePhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPrendrePhoto.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonPrendrePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonPrendrePhoto.Location = new System.Drawing.Point(222, 284);
            this.buttonPrendrePhoto.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrendrePhoto.Name = "buttonPrendrePhoto";
            this.buttonPrendrePhoto.Size = new System.Drawing.Size(80, 80);
            this.buttonPrendrePhoto.TabIndex = 24;
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
            this.comboBoxFiltreImageJour.Location = new System.Drawing.Point(102, 25);
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
            this.comboBoxFiltreImageHeure.Location = new System.Drawing.Point(102, 143);
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
            this.comboBoxFiltreImageMois.Location = new System.Drawing.Point(102, 59);
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
            this.comboBoxFiltreImageMinute.Location = new System.Drawing.Point(103, 177);
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
            this.comboBoxFiltreImageAnnee.Location = new System.Drawing.Point(102, 93);
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
            // buttonActualiserDossier
            // 
            this.buttonActualiserDossier.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonActualiserDossier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonActualiserDossier.BackgroundImage")));
            this.buttonActualiserDossier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonActualiserDossier.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonActualiserDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.buttonActualiserDossier.Location = new System.Drawing.Point(452, 284);
            this.buttonActualiserDossier.Margin = new System.Windows.Forms.Padding(0);
            this.buttonActualiserDossier.Name = "buttonActualiserDossier";
            this.buttonActualiserDossier.Size = new System.Drawing.Size(80, 80);
            this.buttonActualiserDossier.TabIndex = 26;
            this.buttonActualiserDossier.UseVisualStyleBackColor = false;
            this.buttonActualiserDossier.Click += new System.EventHandler(this.buttonActualiserDossier_Click);
            // 
            // checkBoxDisplayMesureInImage
            // 
            this.checkBoxDisplayMesureInImage.AutoSize = true;
            this.checkBoxDisplayMesureInImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.checkBoxDisplayMesureInImage.Checked = true;
            this.checkBoxDisplayMesureInImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayMesureInImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisplayMesureInImage.Location = new System.Drawing.Point(22, 375);
            this.checkBoxDisplayMesureInImage.Name = "checkBoxDisplayMesureInImage";
            this.checkBoxDisplayMesureInImage.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.checkBoxDisplayMesureInImage.Size = new System.Drawing.Size(344, 29);
            this.checkBoxDisplayMesureInImage.TabIndex = 27;
            this.checkBoxDisplayMesureInImage.Text = "Afficher les mesures sur l\'image";
            this.checkBoxDisplayMesureInImage.UseVisualStyleBackColor = false;
            this.checkBoxDisplayMesureInImage.CheckedChanged += new System.EventHandler(this.checkBoxDisplayMesureInImage_CheckedChanged);
            // 
            // CameraMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.checkBoxDisplayMesureInImage);
            this.Controls.Add(this.buttonActualiserDossier);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetourCamera)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxDossierVideo;
        private System.Windows.Forms.PictureBox pictureBoxRetourCamera;
        private System.Windows.Forms.Button buttonLancerEnregistrementVideo;
        private System.Windows.Forms.Button buttonActiverRetourCamera;
        private System.Windows.Forms.Button buttonRemiseAZeroDuFiltre;
        private System.Windows.Forms.Button buttonPrendrePhoto;
        private System.Windows.Forms.Label labelAucuneImageTrouvee;
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
        private System.Windows.Forms.PictureBox pictureBoxBigScreen;
        private System.Windows.Forms.Button buttonActualiserDossier;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDossierImage;
        private System.Windows.Forms.CheckBox checkBoxDisplayMesureInImage;
    }
}
