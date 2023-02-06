using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Eolia_IHM.Properties;
using Iot.Device.Media;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Eolia_IHM.Utils
{
    class EoliaCam
    {
        //private bool isStartCapture;
        private PictureBox pictureBox = null;
        private String folderVideo;


        private List<byte[]> tabVideo;
        FileStream fileStreamVideo = null;


        private bool streamStart;
        private bool captureIsStart; // Un flux est actuellement capturer = true
        private CameraTypes typeCapture;



        private VideoConnectionSettings settings = null;
        private VideoDevice device = null;
        private CancellationTokenSource tokenSource = null;

        public enum CameraTypes
        {
            IMAGECAPTURE = 0,
            IMAGESAVE = 1,
            VIDEOSAVE = 2,
            NOTCAPTURE = 99
        }



        public EoliaCam()
        {
            // J'initialise capture


            streamStart = false;
            captureIsStart = false;
            typeCapture = CameraTypes.NOTCAPTURE;
            tabVideo = new List<byte[]>();

            //EoliaLogs.Write("Initialisation de la capture d'images...", EoliaLogs.Types.CAMERA);
            //settings = new VideoConnectionSettings(busId: 0, captureSize: (640, 480), pixelFormat: Iot.Device.Media.PixelFormat.JPEG);
            //device = VideoDevice.Create(settings);
            //tokenSource = new CancellationTokenSource();
            //device.NewImageBufferReady += NewImageBufferReadyEventHandler;

        }
        /*-----------------------------------------------*/
        /*-                    Utils                    -*/
        /*-----------------------------------------------*/
        private Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mstream = new MemoryStream();
            byte[] pData = blob;
            mstream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mstream, false);
            return bm;
        }

        private bool initializeCamera(Iot.Device.Media.PixelFormat format)
        {
            EoliaLogs.Write("Initialisation de la caméra...", EoliaLogs.Types.CAMERA, "CAMERA");
            settings = new VideoConnectionSettings(busId: 0, captureSize: (640, 480), pixelFormat: format);
            device = VideoDevice.Create(settings);
            tokenSource = new CancellationTokenSource();

            device.NewImageBufferReady += NewImageBufferReadyEventHandler;
            device.StartCaptureContinuous();
            if (device != null && tokenSource != null) return true;
            return false;
        }

        private bool checkInitializeCamera()
        {
            if (device == null) return false;
            if (tokenSource == null) return false;
            //if (device.IsCapturing != true) return false;
            return true;
        }

        private void destructCamera()
        {
            EoliaLogs.Write("Destruction de la caméra...", EoliaLogs.Types.CAMERA, "CAMERA");
            if (!tokenSource.IsCancellationRequested) tokenSource.Cancel();
            if (device.IsCapturing) device.StopCaptureContinuous();
            if (tokenSource != null) tokenSource.Dispose();
            if (device != null) device.Dispose();
        }



        /*-----------------------------------------------*/
        /*-            Récupération d'image             -*/
        /*-----------------------------------------------*/
        void NewImageBufferReadyEventHandler(object sender, NewImageBufferReadyEventArgs newImageBufferReadyEventArgs)
        {
            int er = -1;
            try
            {
                if (streamStart && captureIsStart)
                {
                    if (pictureBox != null && (typeCapture == CameraTypes.IMAGECAPTURE || typeCapture == CameraTypes.IMAGESAVE)) { er = 1; pictureBox.Image = ByteToImage(newImageBufferReadyEventArgs.ImageBuffer); }
                    if (typeCapture == CameraTypes.VIDEOSAVE) { er = 2; EoliaLogs.Write("Mémoire actuelle : " + GC.GetTotalMemory(false) + " / " + GC.MaxGeneration); tabVideo.Add(newImageBufferReadyEventArgs.ImageBuffer); }
                    
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                EoliaLogs.Write("Impossible de récupérer l'image de la caméra. er:" + er, EoliaLogs.Types.CAMERA);

            }
        }

        public bool IsStream() { return streamStart; }
        public bool CaptureIsStart() { return captureIsStart; }
        public CameraTypes GetTypesCapture() { return typeCapture; }
        //public CameraTypes GetStateCameraType() { return isStateCameraType; }



        /*-----------------------------------------------*/
        /*-                 CAPTURE IMAGE               -*/
        /*-----------------------------------------------*/

        public int StartDisplayImage(PictureBox picture)
        {
            // rajouter un check ici                 typeCapture = CameraTypes.NOTCAPTURE;
            if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de la capture d'image " , EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");
                if (picture == null) return 1;
                pictureBox = picture;

                streamStart = true;
                captureIsStart = true;
                typeCapture = CameraTypes.IMAGECAPTURE;

                if (initializeCamera(Iot.Device.Media.PixelFormat.JPEG) != true) return 2;
                EoliaLogs.Write("Initialisation terminer", EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");

                //checkInitializeCamera();
                EoliaLogs.Write("Capture en cours...", EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");

                new Thread(() => { device.CaptureContinuous(tokenSource.Token); }).Start();

                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible de lancer l'affichage des images.", EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");
                return -1;
            }
        }

        public int StopDisplayImage()
        {
            if (typeCapture != CameraTypes.IMAGECAPTURE || captureIsStart != true) return 1;
            try
            {
                destructCamera();
                captureIsStart = false;
                streamStart = false;
                typeCapture = CameraTypes.NOTCAPTURE;
                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible d'arrêter l'affichage des images.", EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");

                return -1;
            }
        }



        /*-----------------------------------------------*/
        /*-                   SAVE IMAGE                -*/
        /*-----------------------------------------------*/

        public int SavePicture(String folder, float portance = -1, float trainee = -1, bool saveMesureInImage = false)
        {
            //if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement d'une image ", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                //streamStart = true;
                //typeCapture = CameraTypes.IMAGESAVE;
                String nameCapture = DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + "PORTANCE " + portance + " TRAINEE " + trainee + ".jpg";
                if (initializeCamera(Iot.Device.Media.PixelFormat.JPEG) != true) return 2;
                if ((portance != -1 && portance !=-1 ) || saveMesureInImage == false)
                {
                    device.Capture(folder + "/" + nameCapture);
                }
                else
                {
                    Image imageNPT = ByteToImage(device.Capture());
                    Bitmap bitmapNPT = new Bitmap(imageNPT.Width, imageNPT.Height);
                    using (Graphics g = Graphics.FromImage(imageNPT))
                    {
                        g.DrawImage(imageNPT, 0, 0, imageNPT.Width, imageNPT.Height);
                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.White, new PointF(10, imageNPT.Height - 50));
                    }
                    imageNPT.Save($"{folder}/{nameCapture}-{imageNPT.Height}");
                }

                destructCamera();
                //streamStart = false;
                //typeCapture = CameraTypes.NOTCAPTURE;
                EoliaLogs.Write("Capture enregistrer de l'image dans " + folder + "/" + DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + "PORTANCE " + portance + " TRAINEE " + trainee + ".jpg", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");


                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible d'enregistrer l'image.", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");
                return -1;
            }
        }



        /*-----------------------------------------------*/
        /*-                   SAVE VIDEO                -*/
        /*-----------------------------------------------*/

        public int StartSaveVideo(String folder)
        {
            if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement de la vidéo ", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                streamStart = true;
                captureIsStart = true;
                folderVideo = folder;
                typeCapture = CameraTypes.VIDEOSAVE;

                if (initializeCamera(Iot.Device.Media.PixelFormat.H264) != true) return 2;

                EoliaLogs.Write("Initialisation terminer", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                //checkInitializeCamera();
                EoliaLogs.Write("Capture en cours...", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                new Thread(() => { device.CaptureContinuous(tokenSource.Token); }).Start();


                //EoliaLogs.Write("Capture enregistrer de la vidéo dans " + folder + "/" + DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + ".H264", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible d'enregistrer la vidéo.", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return -1;
            }
        }

        public int StopSaveVideo()
        {
            if (typeCapture != CameraTypes.VIDEOSAVE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement de la vidéo ", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                if (!Directory.Exists(folderVideo)) Directory.CreateDirectory(folderVideo);


                destructCamera();
                fileStreamVideo = File.Create(folderVideo + "/" + DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + ".H264");
                //Task.Run(() =>
                //{

                EoliaLogs.Write("Enregistrement des bits en cours...", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");

                for (int i = 0; i < tabVideo.Count; i++)
                {
                    fileStreamVideo.Write(tabVideo[i], 0, tabVideo[i].Length);

                    EoliaLogs.Write($"{i} : " + tabVideo[i], EoliaLogs.Types.CAMERA, "VIDEO");
                }

                tabVideo.Clear();
                //});

                //checkInitializeCamera();

                streamStart = false;
                captureIsStart = false;
                typeCapture = CameraTypes.NOTCAPTURE;

                EoliaLogs.Write("Capture enregistrer de la vidéo dans " + folderVideo + "/" + DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + ".H264", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible d'enregistrer la vidéo.", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return -1;
            }
        }
    }
}
