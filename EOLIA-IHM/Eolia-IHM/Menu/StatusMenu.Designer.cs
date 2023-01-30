
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
            this.labelStatutBDD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatutCamera = new System.Windows.Forms.Label();
            this.labelStatutCapteurs = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatutRegulateur = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStatutVitesse = new System.Windows.Forms.Label();
            this.buttonEtatBDD = new System.Windows.Forms.Button();
            this.buttonDemarrerESP32 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(117, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Base de Donnée";
            // 
            // labelStatutBDD
            // 
            this.labelStatutBDD.AutoSize = true;
            this.labelStatutBDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutBDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatutBDD.ForeColor = System.Drawing.Color.Red;
            this.labelStatutBDD.Location = new System.Drawing.Point(138, 214);
            this.labelStatutBDD.Name = "labelStatutBDD";
            this.labelStatutBDD.Size = new System.Drawing.Size(68, 25);
            this.labelStatutBDD.TabIndex = 4;
            this.labelStatutBDD.Text = "STOP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(470, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caméra";
            // 
            // labelStatutCamera
            // 
            this.labelStatutCamera.AutoSize = true;
            this.labelStatutCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelStatutCamera.ForeColor = System.Drawing.Color.Red;
            this.labelStatutCamera.Location = new System.Drawing.Point(461, 121);
            this.labelStatutCamera.Name = "labelStatutCamera";
            this.labelStatutCamera.Size = new System.Drawing.Size(102, 24);
            this.labelStatutCamera.TabIndex = 6;
            this.labelStatutCamera.Text = "Introuvable";
            // 
            // labelStatutCapteurs
            // 
            this.labelStatutCapteurs.AutoSize = true;
            this.labelStatutCapteurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutCapteurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelStatutCapteurs.ForeColor = System.Drawing.Color.Red;
            this.labelStatutCapteurs.Location = new System.Drawing.Point(415, 219);
            this.labelStatutCapteurs.Name = "labelStatutCapteurs";
            this.labelStatutCapteurs.Size = new System.Drawing.Size(61, 24);
            this.labelStatutCapteurs.TabIndex = 8;
            this.labelStatutCapteurs.Text = "STOP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(410, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "ESP32";
            // 
            // labelStatutRegulateur
            // 
            this.labelStatutRegulateur.AutoSize = true;
            this.labelStatutRegulateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutRegulateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelStatutRegulateur.ForeColor = System.Drawing.Color.Red;
            this.labelStatutRegulateur.Location = new System.Drawing.Point(526, 219);
            this.labelStatutRegulateur.Name = "labelStatutRegulateur";
            this.labelStatutRegulateur.Size = new System.Drawing.Size(61, 24);
            this.labelStatutRegulateur.TabIndex = 10;
            this.labelStatutRegulateur.Text = "STOP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(526, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Régulateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(735, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vitesse Actuel-Desirée";
            // 
            // labelStatutVitesse
            // 
            this.labelStatutVitesse.AutoSize = true;
            this.labelStatutVitesse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.labelStatutVitesse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelStatutVitesse.Location = new System.Drawing.Point(826, 197);
            this.labelStatutVitesse.Name = "labelStatutVitesse";
            this.labelStatutVitesse.Size = new System.Drawing.Size(16, 24);
            this.labelStatutVitesse.TabIndex = 12;
            this.labelStatutVitesse.Text = "-";
            // 
            // buttonEtatBDD
            // 
            this.buttonEtatBDD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEtatBDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEtatBDD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEtatBDD.Location = new System.Drawing.Point(50, 338);
            this.buttonEtatBDD.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEtatBDD.Name = "buttonEtatBDD";
            this.buttonEtatBDD.Size = new System.Drawing.Size(279, 50);
            this.buttonEtatBDD.TabIndex = 16;
            this.buttonEtatBDD.Text = "Démarrer la BDD";
            this.buttonEtatBDD.UseVisualStyleBackColor = false;
            this.buttonEtatBDD.Click += new System.EventHandler(this.buttonEtatBDD_Click);
            // 
            // buttonDemarrerESP32
            // 
            this.buttonDemarrerESP32.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDemarrerESP32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(510, 338);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 50);
            this.button3.TabIndex = 18;
            this.button3.Text = "Démarrer liaison Régulateur";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(683, 340);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(279, 50);
            this.button4.TabIndex = 19;
            this.button4.Text = "Démarrer liaison Régulateur";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // StatusMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonDemarrerESP32);
            this.Controls.Add(this.buttonEtatBDD);
            this.Controls.Add(this.labelStatutVitesse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStatutRegulateur);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelStatutCapteurs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStatutCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatutBDD);
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
        private System.Windows.Forms.Label labelStatutBDD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStatutCamera;
        private System.Windows.Forms.Label labelStatutCapteurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatutRegulateur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatutVitesse;
        private System.Windows.Forms.Button buttonEtatBDD;
        private System.Windows.Forms.Button buttonDemarrerESP32;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
