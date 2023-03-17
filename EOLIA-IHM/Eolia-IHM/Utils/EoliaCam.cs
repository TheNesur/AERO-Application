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
        private static bool Initialized = false;
        private static PictureBox pictureBox = null;
        private static String folderIMG = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/IMG/";
        private static String folderVIDEO = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/VIDEO/";


        private static List<byte[]> tabVideo;
        static FileStream fileStreamVideo = null;

        private static String nameFileVideo = null;
        private static DriveInfo driveInfo = new DriveInfo("/");


        private static byte countImageVideo = 0;

        private static bool streamStart;
        private static bool captureIsStart; // Un flux est actuellement capturer = true
        //private static bool saveMesureInImageForVideo = false;
        private static CameraTypes typeCapture = CameraTypes.NOTCAPTURE;



        private static VideoConnectionSettings settings = null;
        private static VideoDevice device = null;
        private static CancellationTokenSource tokenSource = null;


        //private static Mutex mutex;

        public enum CameraTypes
        {
            IMAGECAPTURE = 0,
            IMAGESAVE = 1,
            VIDEOSAVE = 2,
            NOTCAPTURE = 99
        }

        /*-----------------------------------------------*/
        /*-                    Utils                    -*/
        /*-----------------------------------------------*/
        private static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mstream = new MemoryStream();
            byte[] pData = blob;
            mstream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mstream, false);
            return bm;
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static bool initializeCamera(Iot.Device.Media.PixelFormat format, bool initializeCapture = true)
        {
            try
            {
                EoliaLogs.Write("Initialisation de la caméra...", EoliaLogs.Types.CAMERA, "MEMOIRE");

                if (initializeCapture)
                {
                    streamStart = false;
                    captureIsStart = false;
                    typeCapture = CameraTypes.NOTCAPTURE;
                    tabVideo = new List<byte[]>();
                    //saveMesureInImageForVideo = false;
                }

                settings = new VideoConnectionSettings(busId: 0, captureSize: (640, 480), pixelFormat: format);
                device = VideoDevice.Create(settings);
                tokenSource = new CancellationTokenSource();

                device.NewImageBufferReady += NewImageBufferReadyEventHandler;
                device.StartCaptureContinuous();

                if (device != null && tokenSource != null) { 
                    Initialized = true; 
                    EoliaLogs.Write("Initialisation de la caméra sans erreur.", EoliaLogs.Types.CAMERA, "MEMOIRE");
                    return true; 
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return false;
        }


        private static bool checkInitializeCamera(Iot.Device.Media.PixelFormat format)
        {
            if (Initialized) return true;
            else if (initializeCamera(format)) return true;
            else return false;
        }


        private static void destructCamera()
        {
            EoliaLogs.Write("Restitution de la mémoire louée par la caméra en cours...", EoliaLogs.Types.CAMERA, "MEMOIRE");
            if (!tokenSource.IsCancellationRequested) tokenSource.Cancel();
            if (device.IsCapturing) device.StopCaptureContinuous();
            if (tokenSource != null) tokenSource.Dispose();
            if (device != null) device.Dispose();
            EoliaLogs.Write("Restitution de la mémoire effectuée sans erreur.", EoliaLogs.Types.CAMERA, "MEMOIRE");
        }

        public static bool CameraExist()
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "vcgencmd",
                        Arguments = "get_camera",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (output.Contains("detected=0"))
                {
                    return false;
                }
                else
                {
                    return true;

                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
        }


        /*-----------------------------------------------*/
        /*-            Récupération d'image             -*/
        /*-----------------------------------------------*/
        static void NewImageBufferReadyEventHandler(object sender, NewImageBufferReadyEventArgs newImageBufferReadyEventArgs)
        {
            int er = -1;
            try
            {
                if (driveInfo.AvailableFreeSpace <= 1000000000)  // 1Go 
                { 
                    EoliaLogs.Write("Stockage insuffisant", EoliaLogs.Types.ERROR); 
                    EoliaUtils.MsgBoxNonBloquante("Stockage insuffisant, arrêt de la capture"); 
                    destructCamera();  
                    return; 
                }
                if (streamStart && captureIsStart)
                {
                    if (pictureBox != null && (typeCapture == CameraTypes.IMAGECAPTURE || typeCapture == CameraTypes.IMAGESAVE)) { er = 1; pictureBox.Image = ByteToImage(newImageBufferReadyEventArgs.ImageBuffer); }
                    if (typeCapture == CameraTypes.VIDEOSAVE) { 
                        er = 2; 
                        if (countImageVideo == 9)
                        {
                            fileStreamVideo.Close();
                            fileStreamVideo = File.Open(nameFileVideo, FileMode.Append);
                            for (int i = 0; i < tabVideo.Count; i++)
                            {
                                fileStreamVideo.Write(tabVideo[i], 0, tabVideo[i].Length);

                                EoliaLogs.Write($"{i} : " + tabVideo[i].Length, EoliaLogs.Types.CAMERA, "VIDEO");
                            }
                            fileStreamVideo.Close();


                            tabVideo.Clear();
                            countImageVideo = 0;
                        }
                        er = 3;
                        /*
                        if (saveMesureInImageForVideo)
                        {
                            er = 5;

                            Image imageNPT = ByteToImage(newImageBufferReadyEventArgs.ImageBuffer);
                            er = 6;
                            if (imageNPT != null)
                                EoliaLogs.Write("Image is not null ");
                            EoliaLogs.Write("Image object : " + imageNPT);

                            EoliaLogs.Write("Image Width : " + imageNPT.Width + " | Image Height : " + imageNPT.Height);

                            Console.WriteLine("Image Width : " + imageNPT.Width + " | Image Height : " + imageNPT.Height);
                            Bitmap bitmapNPT = new Bitmap(imageNPT.Width, imageNPT.Height);
                            er = 7;
                            using (Graphics g = Graphics.FromImage(imageNPT))
                            {
                                String portance = null, trainee = null;
                                if (EoliaMes.ObtenirPortance() == null) portance = "0";
                                else portance = EoliaMes.ObtenirPortance();

                                if (EoliaMes.ObtenirTrainee() == null) trainee = "0";
                                else trainee = EoliaMes.ObtenirTrainee();
                                er = 8;
                                g.DrawImage(imageNPT, 0, 0, imageNPT.Width, imageNPT.Height);
                                Brush colorBorder = Brushes.Black;
                                Brush colorText = Brushes.White;
                                //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(8, imageNPT.Height - 52));
                                //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(12, imageNPT.Height - 48));
                                //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(12, imageNPT.Height - 50));

                                portance = portance.Replace('\n', ' ');
                                portance = portance.Replace('\r', ' ');
                                g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(10, imageNPT.Height - 48));
                                g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(10, imageNPT.Height - 52));
                                g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(12, imageNPT.Height - 50));
                                g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(8, imageNPT.Height - 50));
                                g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorText, new PointF(10, imageNPT.Height - 50));
                                er = 9;
                            }
                            er = 10;

                            tabVideo.Add(ImageToByte(imageNPT));
                        }
                         else
                        {
                            er = 12;
                        */
                            tabVideo.Add(newImageBufferReadyEventArgs.ImageBuffer);

                        //}                            er = 14;

                        countImageVideo++;
                        EoliaLogs.Write("Mémoire actuelle : " + GC.GetTotalMemory(false) + " / " + GC.MaxGeneration + " || TabVideo : " + tabVideo.Count + "/" + countImageVideo); 
                        
                    }
                    
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                EoliaLogs.Write("Impossible de récupérer l'image de la caméra. er:" + er, EoliaLogs.Types.CAMERA);

            }
        }

        public static bool IsStream() { return streamStart; }               //     A modifier
        public static bool CaptureIsStart() { return captureIsStart; }      //     A modifier
        public static CameraTypes GetTypesCapture() { return typeCapture; } //     A modifier



        /*-----------------------------------------------*/
        /*-                 CAPTURE IMAGE               -*/
        /*-----------------------------------------------*/

        public static int StartDisplayImage(PictureBox picture)
        {
            // rajouter un check ici                 typeCapture = CameraTypes.NOTCAPTURE;
            if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de la capture d'image " , EoliaLogs.Types.CAMERA, "DISPLAY-IMAGE");
                if (picture == null) return 1;
                pictureBox = picture;


                if (initializeCamera(Iot.Device.Media.PixelFormat.JPEG) != true) return 2;

                streamStart = true;
                captureIsStart = true;
                typeCapture = CameraTypes.IMAGECAPTURE;
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

        public static int StopDisplayImage()
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

        public static int SavePicture(String folder = null, bool saveMesureInImage = false, String portance = null, String trainee = null)
        {
            //if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            if (typeCapture == CameraTypes.VIDEOSAVE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement d'une image ", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");
                if (folder == null) folder = folderIMG;

                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                //String nameCapture = DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + "PORTANCE " + portance + " TRAINEE " + trainee + ".jpg";
                if (initializeCamera(Iot.Device.Media.PixelFormat.JPEG, false) != true) return 2;

                if (portance == null && portance == null)
                {
                    if (EoliaMes.ObtenirPortance() == null) portance = "0";
                    else portance = EoliaMes.ObtenirPortance();

                    if (EoliaMes.ObtenirTrainee() == null) trainee = "0";
                    else trainee = EoliaMes.ObtenirTrainee();
                }
                String nameCapture = DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss] ") + "PORTANCE " + portance + " TRAINEE " + trainee + ".jpg";

                if (saveMesureInImage == false)
                {
                    device.Capture(folder + "/" + nameCapture);
                    EoliaLogs.Write("Capture de l'image sans la mesure", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");

                }
                else
                {
                    Image imageNPT = ByteToImage(device.Capture());
                    Bitmap bitmapNPT = new Bitmap(imageNPT.Width, imageNPT.Height);
                    using (Graphics g = Graphics.FromImage(imageNPT))
                    {
                        g.DrawImage(imageNPT, 0, 0, imageNPT.Width, imageNPT.Height);
                        Brush colorBorder = Brushes.Black;
                        Brush colorText = Brushes.White;
                        //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(8, imageNPT.Height - 52));
                        //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(12, imageNPT.Height - 48));
                        //g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(12, imageNPT.Height - 50));

                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(10, imageNPT.Height - 48));
                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(10, imageNPT.Height - 52));
                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(12, imageNPT.Height - 50));
                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorBorder, new PointF(8, imageNPT.Height - 50));
                        g.DrawString($"PORTANCE : {portance} | TRAINEE : {trainee}", new Font("Arial", 20, FontStyle.Bold), colorText, new PointF(10, imageNPT.Height - 50));

                    }
                    imageNPT.Save($"{folder}/{nameCapture}");
                    EoliaLogs.Write("Capture de l'image avec la mesure", EoliaLogs.Types.CAMERA, "SAVE-IMAGE");

                }
                //destructCamera();
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

        public static int StartSaveVideo(String FolderVideo = null)
        {
            if (typeCapture != CameraTypes.NOTCAPTURE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement de la vidéo ", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                //if (folder == null) folder = folderVIDEO;
                //if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                if (initializeCamera(Iot.Device.Media.PixelFormat.H264) != true) return 2;

                streamStart = true;
                captureIsStart = true;
                //saveMesureInImageForVideo = saveMesureInImage;
                typeCapture = CameraTypes.VIDEOSAVE;
                //saveMesureInImageForVideo = saveMesureInVideo;

                EoliaLogs.Write("Initialisation terminer", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                //checkInitializeCamera();

                nameFileVideo = DateTime.Now.ToString("[dd-MM-yyyy--HH-mm-ss]") + ".H264";

                if (FolderVideo == null)
                {
                    if (!Directory.Exists(folderVIDEO)) Directory.CreateDirectory(folderVIDEO);
                    nameFileVideo = folderVIDEO + "/" + nameFileVideo;
                } else
                {
                    if (!Directory.Exists(FolderVideo)) Directory.CreateDirectory(FolderVideo);
                    nameFileVideo = FolderVideo + "/" + nameFileVideo;
                }
                Console.WriteLine("Lien video : " + nameFileVideo);
                fileStreamVideo = File.Create(nameFileVideo);
                fileStreamVideo.Close();


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

        public static int StopSaveVideo()
        {
            var er = -1;
            if (typeCapture != CameraTypes.VIDEOSAVE) return 10;
            try
            {
                EoliaLogs.Write("Lancement de l'enregristrement de la vidéo ", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                //if (!Directory.Exists(FolderVideo)) Directory.CreateDirectory(FolderVideo);

                er = 1;
                destructCamera();
                er = 2;

                // Vérifier si le nom FileStartVideo fini par .H264

                //Task.Run(() =>
                //{

                EoliaLogs.Write("Enregistrement des bits en cours...", EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                fileStreamVideo = File.Open(nameFileVideo, FileMode.Append);
                er = 3;
                for (int i = 0; i < tabVideo.Count; i++)
                {
                    er = 4;
                    fileStreamVideo.Write(tabVideo[i], 0, tabVideo[i].Length);
                    er = 5;
                    EoliaLogs.Write($"{i} : " + tabVideo[i].Length, EoliaLogs.Types.CAMERA, "VIDEO");
                }
                fileStreamVideo.Close();
                fileStreamVideo.Dispose();
                er = 6;
                tabVideo.Clear();
                er = 7;
                EoliaLogs.Write("Mémoire actuelle : " + GC.GetTotalMemory(false) + " / " + GC.MaxGeneration + " || TabVideo : " + tabVideo.Count);
                //});

                //checkInitializeCamera();

                streamStart = false;
                captureIsStart = false;
                //saveMesureInImageForVideo = false;
                typeCapture = CameraTypes.NOTCAPTURE;
                er = 0;

                EoliaLogs.Write("Capture enregistrer de la vidéo dans " + nameFileVideo + " : zqdqzdqz : " + er, EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                EoliaLogs.Write("Impossible d'enregistrer la vidéo." + " : zqdqzdqz : " + er, EoliaLogs.Types.CAMERA, "SAVE-VIDEO");
                return -1;
            }
        }
    }
}
