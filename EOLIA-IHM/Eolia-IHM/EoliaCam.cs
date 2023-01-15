using Emgu.CV;
using Emgu.CV.Structure;
using Eolia_IHM.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Eolia_IHM.Utils
{
    class EoliaCam
    {
        private bool isStream;
        private Capture capture;
        private PictureBox pictureBox;
        private int numberFileExist;

        // récupére l'image de la pictureBox pour donner par Start() à celle de l'objet
        private void streaming(object sender, System.EventArgs e)
        {
            // Je récupère l'image que produit la caméra puis la convertie sous un format de la bibliothèque EmguCV
            var img = capture.QueryFrame().ToImage<Bgr, byte>();
            // Convertie de "Emgu.CV.Image<Bgr, byte>" à "System.Drawing.Bitmap" qui proviens de .NET Framework
            var bmp = img.Bitmap;
            // Je change l'image obtenue à l'image que contient la picturebox
            pictureBox.Image = bmp;
        }

        public EoliaCam()
        {
            // J'initialise capture
            capture = new Capture();
            isStream = false;
        }

        // Renvoie l'état du stream
        public bool getStreaming() { return isStream; }


        // Lance l'envoie des images de la cam a la PictureBox si elle est pas encore en cours
        public bool Start(PictureBox picture)
        {
            try
            {
                if (!isStream)
                {
                    pictureBox = picture;
                    // Lance une tâche en arrière plan
                    Application.Idle += streaming;
                    isStream = true;

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool Stop()
        {
            try
            {
                if (isStream)
                {
                    isStream = false;
                    Application.Idle -= streaming;

                    capture.Stop();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool SavePicture(PictureBox picture, String folder, float portance = 0, float trainee = 0)
        {
            picture.Image = pictureBox.Image;
            if (!Directory.Exists(folder)) System.IO.Directory.CreateDirectory(folder);
            String fileName = folder + "/" + DateTime.Now.ToString("[dd-MM-yyyy HH-mm-ss]") + " PORTANCE " + portance + " TRAINEE " + trainee + " - " + numberFileExist + ".jpg";

            // Une sécuriter en cas ou la fonction Save ne gère pas le nombre de requête 
            try
            {
                if (File.Exists(fileName)) numberFileExist++;
                else numberFileExist = 0;

                fileName = folder + "/" + DateTime.Now.ToString("[dd-MM-yyyy HH-mm-ss]") + " PORTANCE " + portance + " TRAINEE " + trainee + " - " + numberFileExist + ".jpg";

                picture.Image.Save(fileName, ImageFormat.Jpeg);
                
                //Ajout d'une meta donnee en dev
                /*String fileName = folder + "/" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".jpg";
                using (Image image = Image.FromFile(fileName))
                {
                    PropertyItem descriptionProperty = image.PropertyItems[0];
                    descriptionProperty.Id = 0x0320; // ID pour la description
                    descriptionProperty.Type = 2; // type unicode
                    descriptionProperty.Value = Encoding.Unicode.GetBytes("Bonjour");
                    descriptionProperty.Len = descriptionProperty.Value.Length;
                    image.SetPropertyItem(descriptionProperty);

                    image.Save(fileName, ImageFormat.Jpeg);
                }*/
            }
            catch (Exception e)
            {
                SavePicture(picture, folder, portance, trainee);
                Console.WriteLine(e.Message);
            }

            if (File.Exists(fileName)) return true;
            else return false;
        }
    }
}
