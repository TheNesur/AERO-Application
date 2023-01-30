
namespace Eolia_IHM
{
    partial class MenuEolia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEolia));
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.buttonConfiguration = new System.Windows.Forms.Button();
            this.buttonCamera = new System.Windows.Forms.Button();
            this.buttonMesure = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonQuitter.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonQuitter.Location = new System.Drawing.Point(818, 128);
            this.buttonQuitter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(204, 50);
            this.buttonQuitter.TabIndex = 15;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = false;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // buttonConfiguration
            // 
            this.buttonConfiguration.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConfiguration.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfiguration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonConfiguration.Location = new System.Drawing.Point(614, 128);
            this.buttonConfiguration.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfiguration.Name = "buttonConfiguration";
            this.buttonConfiguration.Size = new System.Drawing.Size(204, 50);
            this.buttonConfiguration.TabIndex = 14;
            this.buttonConfiguration.Text = "Configuration";
            this.buttonConfiguration.UseVisualStyleBackColor = false;
            this.buttonConfiguration.Click += new System.EventHandler(this.buttonConfiguration_Click);
            // 
            // buttonCamera
            // 
            this.buttonCamera.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCamera.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCamera.Location = new System.Drawing.Point(410, 128);
            this.buttonCamera.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCamera.Name = "buttonCamera";
            this.buttonCamera.Size = new System.Drawing.Size(204, 50);
            this.buttonCamera.TabIndex = 13;
            this.buttonCamera.Text = "Camera";
            this.buttonCamera.UseVisualStyleBackColor = false;
            this.buttonCamera.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // buttonMesure
            // 
            this.buttonMesure.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMesure.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMesure.Location = new System.Drawing.Point(206, 128);
            this.buttonMesure.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMesure.Name = "buttonMesure";
            this.buttonMesure.Size = new System.Drawing.Size(204, 50);
            this.buttonMesure.TabIndex = 12;
            this.buttonMesure.Text = "Mesure";
            this.buttonMesure.UseVisualStyleBackColor = false;
            this.buttonMesure.Click += new System.EventHandler(this.buttonMesure_Click);
            // 
            // buttonStatus
            // 
            this.buttonStatus.BackColor = System.Drawing.Color.DarkGray;
            this.buttonStatus.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonStatus.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStatus.Location = new System.Drawing.Point(2, 128);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(204, 50);
            this.buttonStatus.TabIndex = 11;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = false;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Location = new System.Drawing.Point(2, 181);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1020, 417);
            this.panelMenu.TabIndex = 16;
            // 
            // MenuEolia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonConfiguration);
            this.Controls.Add(this.buttonCamera);
            this.Controls.Add(this.buttonMesure);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuEolia";
            this.Text = "MenuEolia";
            this.Load += new System.EventHandler(this.MenuEolia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.Button buttonConfiguration;
        private System.Windows.Forms.Button buttonCamera;
        private System.Windows.Forms.Button buttonMesure;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
    }
}