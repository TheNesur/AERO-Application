
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatusBDD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatusCamera = new System.Windows.Forms.Label();
            this.labelStatusCapteurs = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatusRegulateurs = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatusVitesse = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F);
            this.label1.Location = new System.Drawing.Point(117, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Base de Donnée";
            // 
            // labelStatusBDD
            // 
            this.labelStatusBDD.AutoSize = true;
            this.labelStatusBDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatusBDD.Font = new System.Drawing.Font("Montserrat SemiBold", 12F);
            this.labelStatusBDD.ForeColor = System.Drawing.Color.Green;
            this.labelStatusBDD.Location = new System.Drawing.Point(138, 214);
            this.labelStatusBDD.Name = "labelStatusBDD";
            this.labelStatusBDD.Size = new System.Drawing.Size(100, 22);
            this.labelStatusBDD.TabIndex = 4;
            this.labelStatusBDD.Text = "Connectée";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.label2.Location = new System.Drawing.Point(470, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caméra";
            // 
            // labelStatusCamera
            // 
            this.labelStatusCamera.AutoSize = true;
            this.labelStatusCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatusCamera.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.labelStatusCamera.ForeColor = System.Drawing.Color.Red;
            this.labelStatusCamera.Location = new System.Drawing.Point(451, 125);
            this.labelStatusCamera.Name = "labelStatusCamera";
            this.labelStatusCamera.Size = new System.Drawing.Size(112, 21);
            this.labelStatusCamera.TabIndex = 6;
            this.labelStatusCamera.Text = "Déconnectée";
            // 
            // labelStatusCapteurs
            // 
            this.labelStatusCapteurs.AutoSize = true;
            this.labelStatusCapteurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatusCapteurs.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.labelStatusCapteurs.ForeColor = System.Drawing.Color.Green;
            this.labelStatusCapteurs.Location = new System.Drawing.Point(399, 219);
            this.labelStatusCapteurs.Name = "labelStatusCapteurs";
            this.labelStatusCapteurs.Size = new System.Drawing.Size(93, 21);
            this.labelStatusCapteurs.TabIndex = 8;
            this.labelStatusCapteurs.Text = "Connectée";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label5.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.label5.Location = new System.Drawing.Point(410, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Capteur";
            // 
            // labelStatusRegulateurs
            // 
            this.labelStatusRegulateurs.AutoSize = true;
            this.labelStatusRegulateurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatusRegulateurs.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.labelStatusRegulateurs.ForeColor = System.Drawing.Color.Green;
            this.labelStatusRegulateurs.Location = new System.Drawing.Point(526, 219);
            this.labelStatusRegulateurs.Name = "labelStatusRegulateurs";
            this.labelStatusRegulateurs.Size = new System.Drawing.Size(93, 21);
            this.labelStatusRegulateurs.TabIndex = 10;
            this.labelStatusRegulateurs.Text = "Connectée";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label7.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.label7.Location = new System.Drawing.Point(526, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Régulateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.label3.Location = new System.Drawing.Point(735, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vitesse Actuel/Desirée";
            // 
            // labelStatusVitesse
            // 
            this.labelStatusVitesse.AutoSize = true;
            this.labelStatusVitesse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatusVitesse.Font = new System.Drawing.Font("Montserrat SemiBold", 11F);
            this.labelStatusVitesse.Location = new System.Drawing.Point(756, 197);
            this.labelStatusVitesse.Name = "labelStatusVitesse";
            this.labelStatusVitesse.Size = new System.Drawing.Size(139, 21);
            this.labelStatusVitesse.TabIndex = 12;
            this.labelStatusVitesse.Text = "10km/h / 12km/h";
            // 
            // StatusMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelStatusVitesse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStatusRegulateurs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelStatusCapteurs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStatusCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatusBDD);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatusBDD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStatusCamera;
        private System.Windows.Forms.Label labelStatusCapteurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatusRegulateurs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatusVitesse;
    }
}
