namespace Eolia_IHM
{
    partial class IHM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EOLIATitre = new System.Windows.Forms.Label();
            this.ConteneurOngletBouton = new System.Windows.Forms.Panel();
            this.BoutonOngletEtat = new System.Windows.Forms.Button();
            this.BoutonOngletMesure = new System.Windows.Forms.Button();
            this.BoutonOngletConfig = new System.Windows.Forms.Button();
            this.BoutonQuitter = new System.Windows.Forms.Button();
            this.ConteneurOngletBouton.SuspendLayout();
            this.SuspendLayout();
            // 
            // EOLIATitre
            // 
            this.EOLIATitre.AutoSize = true;
            this.EOLIATitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.6F);
            this.EOLIATitre.Location = new System.Drawing.Point(436, 9);
            this.EOLIATitre.Name = "EOLIATitre";
            this.EOLIATitre.Size = new System.Drawing.Size(149, 51);
            this.EOLIATitre.TabIndex = 2;
            this.EOLIATitre.Text = "EOLIA";
            // 
            // ConteneurOngletBouton
            // 
            this.ConteneurOngletBouton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ConteneurOngletBouton.Controls.Add(this.BoutonQuitter);
            this.ConteneurOngletBouton.Controls.Add(this.BoutonOngletConfig);
            this.ConteneurOngletBouton.Controls.Add(this.BoutonOngletMesure);
            this.ConteneurOngletBouton.Controls.Add(this.BoutonOngletEtat);
            this.ConteneurOngletBouton.Location = new System.Drawing.Point(12, 63);
            this.ConteneurOngletBouton.Name = "ConteneurOngletBouton";
            this.ConteneurOngletBouton.Size = new System.Drawing.Size(1000, 59);
            this.ConteneurOngletBouton.TabIndex = 3;
            // 
            // BoutonOngletEtat
            // 
            this.BoutonOngletEtat.Location = new System.Drawing.Point(3, 3);
            this.BoutonOngletEtat.Name = "BoutonOngletEtat";
            this.BoutonOngletEtat.Size = new System.Drawing.Size(164, 53);
            this.BoutonOngletEtat.TabIndex = 0;
            this.BoutonOngletEtat.Text = "Etat";
            this.BoutonOngletEtat.UseVisualStyleBackColor = true;
            // 
            // BoutonOngletMesure
            // 
            this.BoutonOngletMesure.Location = new System.Drawing.Point(169, 3);
            this.BoutonOngletMesure.Name = "BoutonOngletMesure";
            this.BoutonOngletMesure.Size = new System.Drawing.Size(164, 53);
            this.BoutonOngletMesure.TabIndex = 1;
            this.BoutonOngletMesure.Text = "Mesure";
            this.BoutonOngletMesure.UseVisualStyleBackColor = true;
            // 
            // BoutonOngletConfig
            // 
            this.BoutonOngletConfig.Location = new System.Drawing.Point(335, 3);
            this.BoutonOngletConfig.Name = "BoutonOngletConfig";
            this.BoutonOngletConfig.Size = new System.Drawing.Size(164, 53);
            this.BoutonOngletConfig.TabIndex = 2;
            this.BoutonOngletConfig.Text = "Configuration";
            this.BoutonOngletConfig.UseVisualStyleBackColor = true;
            // 
            // BoutonQuitter
            // 
            this.BoutonQuitter.Location = new System.Drawing.Point(872, 3);
            this.BoutonQuitter.Name = "BoutonQuitter";
            this.BoutonQuitter.Size = new System.Drawing.Size(125, 53);
            this.BoutonQuitter.TabIndex = 3;
            this.BoutonQuitter.Text = "Quitter";
            this.BoutonQuitter.UseVisualStyleBackColor = true;
            this.BoutonQuitter.Click += new System.EventHandler(this.BoutonQuitter_Click);
            // 
            // IHM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.ConteneurOngletBouton);
            this.Controls.Add(this.EOLIATitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "IHM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IHM";
            this.Load += new System.EventHandler(this.IHM_Load);
            this.ConteneurOngletBouton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EOLIATitre;
        private System.Windows.Forms.Panel ConteneurOngletBouton;
        private System.Windows.Forms.Button BoutonQuitter;
        private System.Windows.Forms.Button BoutonOngletConfig;
        private System.Windows.Forms.Button BoutonOngletMesure;
        private System.Windows.Forms.Button BoutonOngletEtat;
    }
}