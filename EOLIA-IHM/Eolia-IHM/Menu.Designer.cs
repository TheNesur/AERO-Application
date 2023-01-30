
namespace Eolia_IHM
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonStatus = new System.Windows.Forms.Button();
            this.buttonMesure = new System.Windows.Forms.Button();
            this.buttonCamera = new System.Windows.Forms.Button();
            this.buttonConfiguration = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStatus
            // 
            this.buttonStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonStatus.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonStatus.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatus.Location = new System.Drawing.Point(2, 130);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(204, 50);
            this.buttonStatus.TabIndex = 5;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = false;
            this.buttonStatus.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMesure
            // 
            this.buttonMesure.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMesure.Location = new System.Drawing.Point(206, 130);
            this.buttonMesure.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMesure.Name = "buttonMesure";
            this.buttonMesure.Size = new System.Drawing.Size(204, 50);
            this.buttonMesure.TabIndex = 6;
            this.buttonMesure.Text = "Mesure";
            this.buttonMesure.UseVisualStyleBackColor = true;
            this.buttonMesure.Click += new System.EventHandler(this.buttonMesure_Click);
            // 
            // buttonCamera
            // 
            this.buttonCamera.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCamera.Location = new System.Drawing.Point(410, 130);
            this.buttonCamera.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCamera.Name = "buttonCamera";
            this.buttonCamera.Size = new System.Drawing.Size(204, 50);
            this.buttonCamera.TabIndex = 7;
            this.buttonCamera.Text = "Camera";
            this.buttonCamera.UseVisualStyleBackColor = true;
            this.buttonCamera.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // buttonConfiguration
            // 
            this.buttonConfiguration.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfiguration.Location = new System.Drawing.Point(614, 130);
            this.buttonConfiguration.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfiguration.Name = "buttonConfiguration";
            this.buttonConfiguration.Size = new System.Drawing.Size(204, 50);
            this.buttonConfiguration.TabIndex = 8;
            this.buttonConfiguration.Text = "Configuration";
            this.buttonConfiguration.UseVisualStyleBackColor = true;
            this.buttonConfiguration.Click += new System.EventHandler(this.buttonConfiguration_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.Location = new System.Drawing.Point(818, 130);
            this.buttonQuitter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(204, 50);
            this.buttonQuitter.TabIndex = 9;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonConfiguration);
            this.Controls.Add(this.buttonCamera);
            this.Controls.Add(this.buttonMesure);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Button buttonMesure;
        private System.Windows.Forms.Button buttonCamera;
        private System.Windows.Forms.Button buttonConfiguration;
        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}