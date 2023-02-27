namespace Eolia_IHM
{
    partial class AccueilIHM
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccueilIHM));
            this.BoutonLancer = new System.Windows.Forms.Button();
            this.buttonFermerProgramme = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BoutonLancer
            // 
            this.BoutonLancer.BackColor = System.Drawing.Color.White;
            this.BoutonLancer.Font = new System.Drawing.Font("Montserrat ExtraBold", 35F);
            this.BoutonLancer.Location = new System.Drawing.Point(200, 230);
            this.BoutonLancer.Name = "BoutonLancer";
            this.BoutonLancer.Size = new System.Drawing.Size(600, 150);
            this.BoutonLancer.TabIndex = 0;
            this.BoutonLancer.Text = "DEMARRER L\'APPLICATION";
            this.BoutonLancer.UseVisualStyleBackColor = false;
            this.BoutonLancer.Click += new System.EventHandler(this.BoutonLancer_Click);
            // 
            // buttonFermerProgramme
            // 
            this.buttonFermerProgramme.BackColor = System.Drawing.Color.White;
            this.buttonFermerProgramme.Font = new System.Drawing.Font("Montserrat ExtraBold", 17F);
            this.buttonFermerProgramme.Location = new System.Drawing.Point(364, 397);
            this.buttonFermerProgramme.Name = "buttonFermerProgramme";
            this.buttonFermerProgramme.Size = new System.Drawing.Size(300, 100);
            this.buttonFermerProgramme.TabIndex = 2;
            this.buttonFermerProgramme.Text = "Fermer le programme";
            this.buttonFermerProgramme.UseVisualStyleBackColor = false;
            this.buttonFermerProgramme.Click += new System.EventHandler(this.buttonFermerProgramme_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(271, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // AccueilIHM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None; // bloque mono
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonFermerProgramme);
            this.Controls.Add(this.BoutonLancer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "AccueilIHM";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accueil IHM";
            this.Load += new System.EventHandler(this.AccueilIHM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BoutonLancer;
        private System.Windows.Forms.Button buttonFermerProgramme;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

