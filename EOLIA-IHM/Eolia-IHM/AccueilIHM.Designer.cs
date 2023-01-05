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
            this.EOLIATitre = new System.Windows.Forms.Label();
            this.BoutonLancer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EOLIATitre
            // 
            this.EOLIATitre.AutoSize = true;
            this.EOLIATitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.6F);
            this.EOLIATitre.Location = new System.Drawing.Point(493, 40);
            this.EOLIATitre.Name = "EOLIATitre";
            this.EOLIATitre.Size = new System.Drawing.Size(149, 51);
            this.EOLIATitre.TabIndex = 1;
            this.EOLIATitre.Text = "EOLIA";
            // 
            // BoutonLancer
            // 
            this.BoutonLancer.Location = new System.Drawing.Point(349, 154);
            this.BoutonLancer.Name = "BoutonLancer";
            this.BoutonLancer.Size = new System.Drawing.Size(391, 162);
            this.BoutonLancer.TabIndex = 0;
            this.BoutonLancer.Text = "Démarrer l\'application";
            this.BoutonLancer.UseVisualStyleBackColor = true;
            this.BoutonLancer.Click += new System.EventHandler(this.BoutonLancer_Click);
            // 
            // AccueilIHM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.ControlBox = false;
            this.Controls.Add(this.EOLIATitre);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EOLIATitre;
        private System.Windows.Forms.Button BoutonLancer;
    }
}

