using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Eolia_IHM.Properties;

namespace Eolia_IHM
{
    public static class EoliaLogs
    {
        // Emplacement du fichier de logs
        //private static String nameFileLogs = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.eolia\\logs";
        private static String nameFileLogs = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB") + "/logs";
        private static int numberFile = 0;
        private static Mutex _mutex = new Mutex();

        // Une enumération pour définir la tâche
        public enum Types
        {
            DEBUG = 0,
            ERROR = 1,
            MYSQL = 2,
            CONTROLLER = 3,
            CAMERA = 4,
            SITE = 5,
            SERIAL = 6,
            LOGS = 88,
            OTHER = 99

        }

        // Vérifier si le dossier ou ce trouve les logs existe, sinon le crée
        private static void FolderExist()
        {
            try
            {
                if (!Directory.Exists(nameFileLogs))
                {
                    // Crée le dossier logs
                    System.IO.Directory.CreateDirectory(nameFileLogs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
            

        // Initialise le dossier et le fichier de log
        public static void InitializeLogs()
        {
            _mutex = new Mutex();
            _mutex.WaitOne();
            try
            {
                FolderExist();

                String folderFile = nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") ;
                bool fileLogsExist = File.Exists(folderFile + "_" + numberFile + ".log");

                if (fileLogsExist)
                {
                    for (int i = 0; File.Exists(folderFile + "_" + i + ".log"); i++)
                    {
                        numberFile++;
                    }
                }

                File.AppendAllText(folderFile + "_" + numberFile + ".log", DateTime.Now.ToString("[HH:mm:ss] [") + Types.LOGS + "] Initialisation des logs...");
                Console.WriteLine("Fichier logs crée: " + folderFile + "_" + numberFile + ".log");

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        // Fonction de d'arrêt de lecture dans le fichier actuelle de log.
        public static void FinishLogs()
        {
            _mutex.WaitOne();
            try
            {
                FolderExist();
                File.AppendAllText(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", DateTime.Now.ToString("[HH:mm:ss] [") + Types.LOGS + "] Stopping...\n\n\n\n");

            }
            catch (Exception e)
            {
                Console.Write("Exception: " + e.Message);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        // Fonction de lecture demandant le nombre de ligne a lire ou par défaut est définuir sur une ligne
        public static string[] Read(int nbrLigne = 1)
        {
            _mutex.WaitOne();
            try
            {
                String folderFile = nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log";
                if (!File.Exists(folderFile)) return null;

                StreamReader fileReader = new StreamReader(folderFile);
                String line = fileReader.ReadLine();

                List<String> fileLines = new List<string>();
                for (int i = 0; line != null && i < nbrLigne; i++)
                {
                    fileLines.Add(line);
                    line = fileReader.ReadLine();
                }
                fileReader.Close();
                return fileLines.ToArray();
            }
            catch (Exception e)
            {
                Console.Write("Exception: " + e.Message);
                return null;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        // Fonction d'écriture dans le fichier logs, demander le texte a enregristrer et le type de logs via un enum
        public static bool Write(string args, Types type = Types.OTHER, String other = null)
        {
            _mutex.WaitOne();
            try
            {
                if (other == null)
                    File.AppendAllText(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", DateTime.Now.ToString("[HH:mm:ss] [") + type + "] " + args + "\n");
                else File.AppendAllText(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", DateTime.Now.ToString("[HH:mm:ss] [") + type + "] [" + other + "]" + args + "\n");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}
