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

        private Mutex mutex;

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

        public static int SavePicture(String folder, bool saveMesureInImage = false)
        {
            return 0;
        }



        /*-----------------------------------------------*/
        /*-                   SAVE VIDEO                -*/
        /*-----------------------------------------------*/

        public static int StartSaveVideo(String folder)
        {
            return 1;
        }

        public static int StopSaveVideo()
        {
            return 0;
        }

        public static bool CameraExist()
        {
            return false;
        }
    }
}
