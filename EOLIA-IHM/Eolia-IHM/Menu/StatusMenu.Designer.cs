
namespace Eolia_IHM.Menu
{
    partial class StatusMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label0 = new System.Windows.Forms.Label();
            this.labelStatutBDD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatutCamera = new System.Windows.Forms.Label();
            this.labelStatutCapteurs = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatutRegulateur = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatutVitesse = new System.Windows.Forms.Label();
            this.buttonDemarrerBDD = new System.Windows.Forms.Button();
            this.buttonDemarrerESP32 = new System.Windows.Forms.Button();
            this.buttonLiaisonRegulateur = new System.Windows.Forms.Button();
            this.buttonDemarrerToutLesServices = new System.Windows.Forms.Button();
            this.buttonArreterToutLesServices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(370, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(279, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(683, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(279, 240);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label0.Location = new System.Drawing.Point(117, 154);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(141, 18);
            this.label0.TabIndex = 3;
            this.label0.Text = "Base de Données";
            // 
            // labelStatutBDD
            // 
            this.labelStatutBDD.AutoSize = true;
            this.labelStatutBDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutBDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelStatutBDD.ForeColor = System.Drawing.Color.Red;
            this.labelStatutBDD.Location = new System.Drawing.Point(105, 210);
            this.labelStatutBDD.Name = "labelStatutBDD";
            this.labelStatutBDD.Size = new System.Drawing.Size(147, 18);
            this.labelStatutBDD.TabIndex = 4;
            this.labelStatutBDD.Text = "BDD Déconnectée";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(470, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caméra";
            // 
            // labelStatutCamera
            // 
            this.labelStatutCamera.AutoSize = true;
            this.labelStatutCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelStatutCamera.ForeColor = System.Drawing.Color.Red;
            this.labelStatutCamera.Location = new System.Drawing.Point(461, 121);
            this.labelStatutCamera.Name = "labelStatutCamera";
            this.labelStatutCamera.Size = new System.Drawing.Size(90, 18);
            this.labelStatutCamera.TabIndex = 6;
            this.labelStatutCamera.Text = "Introuvable";
            // 
            // labelStatutCapteurs
            // 
            this.labelStatutCapteurs.AutoSize = true;
            this.labelStatutCapteurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutCapteurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelStatutCapteurs.ForeColor = System.Drawing.Color.Red;
            this.labelStatutCapteurs.Location = new System.Drawing.Point(422, 219);
            this.labelStatutCapteurs.Name = "labelStatutCapteurs";
            this.labelStatutCapteurs.Size = new System.Drawing.Size(53, 18);
            this.labelStatutCapteurs.TabIndex = 8;
            this.labelStatutCapteurs.Text = "STOP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(417, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "ESP32";
            // 
            // labelStatutRegulateur
            // 
            this.labelStatutRegulateur.AutoSize = true;
            this.labelStatutRegulateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutRegulateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelStatutRegulateur.ForeColor = System.Drawing.Color.Red;
            this.labelStatutRegulateur.Location = new System.Drawing.Point(544, 219);
            this.labelStatutRegulateur.Name = "labelStatutRegulateur";
            this.labelStatutRegulateur.Size = new System.Drawing.Size(53, 18);
            this.labelStatutRegulateur.TabIndex = 10;
            this.labelStatutRegulateur.Text = "STOP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(526, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Régulateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(715, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vitesse Actuelle-Desirée";
            // 
            // labelStatutVitesse
            // 
            this.labelStatutVitesse.AutoSize = true;
            this.labelStatutVitesse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutVitesse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelStatutVitesse.Location = new System.Drawing.Point(810, 197);
            this.labelStatutVitesse.Name = "labelStatutVitesse";
            this.labelStatutVitesse.Size = new System.Drawing.Size(14, 18);
            this.labelStatutVitesse.TabIndex = 12;
            this.labelStatutVitesse.Text = "-";
            // 
            // buttonDemarrerBDD
            // 
            this.buttonDemarrerBDD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDemarrerBDD.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Bold);
            this.buttonDemarrerBDD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDemarrerBDD.Location = new System.Drawing.Point(35, 338);
            this.buttonDemarrerBDD.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDemarrerBDD.Name = "buttonDemarrerBDD";
            this.buttonDemarrerBDD.Size = new System.Drawing.Size(294, 50);
            this.buttonDemarrerBDD.TabIndex = 16;
            this.buttonDemarrerBDD.Text = "Démarrer la liaison MYSQL";
            this.buttonDemarrerBDD.UseVisualStyleBackColor = false;
            this.buttonDemarrerBDD.Click += new System.EventHandler(this.buttonEtatBDD_Click);
            // 
            // buttonDemarrerESP32
            // 
            this.buttonDemarrerESP32.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDemarrerESP32.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonDemarrerESP32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDemarrerESP32.Location = new System.Drawing.Point(370, 338);
            this.buttonDemarrerESP32.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDemarrerESP32.Name = "buttonDemarrerESP32";
            this.buttonDemarrerESP32.Size = new System.Drawing.Size(140, 50);
            this.buttonDemarrerESP32.TabIndex = 17;
            this.buttonDemarrerESP32.Text = "Démarrer liaison ESP32";
            this.buttonDemarrerESP32.UseVisualStyleBackColor = false;
            this.buttonDemarrerESP32.Click += new System.EventHandler(this.buttonDemarrerESP32_Click);
            // 
            // buttonLiaisonRegulateur
            // 
            this.buttonLiaisonRegulateur.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLiaisonRegulateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonLiaisonRegulateur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLiaisonRegulateur.Location = new System.Drawing.Point(510, 338);
            this.buttonLiaisonRegulateur.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLiaisonRegulateur.Name = "buttonLiaisonRegulateur";
            this.buttonLiaisonRegulateur.Size = new System.Drawing.Size(140, 50);
            this.buttonLiaisonRegulateur.TabIndex = 18;
            this.buttonLiaisonRegulateur.Text = "Démarrer liaison Régulateur";
            this.buttonLiaisonRegulateur.UseVisualStyleBackColor = false;
            this.buttonLiaisonRegulateur.Click += new System.EventHandler(this.buttonLiaisonRegulateur_Click);
            // 
            // buttonDemarrerToutLesServices
            // 
            this.buttonDemarrerToutLesServices.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDemarrerToutLesServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonDemarrerToutLesServices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDemarrerToutLesServices.Location = new System.Drawing.Point(683, 340);
            this.buttonDemarrerToutLesServices.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDemarrerToutLesServices.Name = "buttonDemarrerToutLesServices";
            this.buttonDemarrerToutLesServices.Size = new System.Drawing.Size(140, 50);
            this.buttonDemarrerToutLesServices.TabIndex = 19;
            this.buttonDemarrerToutLesServices.Text = "Démarrer tous les services";
            this.buttonDemarrerToutLesServices.UseVisualStyleBackColor = false;
            this.buttonDemarrerToutLesServices.Click += new System.EventHandler(this.buttonDemarrerTout_Click);
            // 
            // buttonArreterToutLesServices
            // 
            this.buttonArreterToutLesServices.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonArreterToutLesServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonArreterToutLesServices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonArreterToutLesServices.Location = new System.Drawing.Point(822, 340);
            this.buttonArreterToutLesServices.Margin = new System.Windows.Forms.Padding(0);
            this.buttonArreterToutLesServices.Name = "buttonArreterToutLesServices";
            this.buttonArreterToutLesServices.Size = new System.Drawing.Size(140, 50);
            this.buttonArreterToutLesServices.TabIndex = 20;
            this.buttonArreterToutLesServices.Text = "Arrêter tous les services";
            this.buttonArreterToutLesServices.UseVisualStyleBackColor = false;
            this.buttonArreterToutLesServices.Click += new System.EventHandler(this.buttonArreterToutLesServices_Click);
            // 
            // StatusMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.buttonArreterToutLesServices);
            this.Controls.Add(this.buttonDemarrerToutLesServices);
            this.Controls.Add(this.buttonLiaisonRegulateur);
            this.Controls.Add(this.buttonDemarrerESP32);
            this.Controls.Add(this.buttonDemarrerBDD);
            this.Controls.Add(this.labelStatutVitesse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStatutRegulateur);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelStatutCapteurs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStatutCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatutBDD);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "StatusMenu";
            this.Size = new System.Drawing.Size(1020, 417);
            this.Load += new System.EventHandler(this.StatusMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label labelStatutBDD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStatutCamera;
        private System.Windows.Forms.Label labelStatutCapteurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatutRegulateur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatutVitesse;
        private System.Windows.Forms.Button buttonDemarrerBDD;
        private System.Windows.Forms.Button buttonDemarrerESP32;
        private System.Windows.Forms.Button buttonLiaisonRegulateur;
        private System.Windows.Forms.Button buttonDemarrerToutLesServices;
        private System.Windows.Forms.Button buttonArreterToutLesServices;
    }
}
