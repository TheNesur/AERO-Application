using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Eolia_IHM
{
    public static class LogsIHM
    {
        // Emplacement du fichier de logs
        //private static String nameFileLogs = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.eolia\\logs";
        private static String nameFileLogs = "logs";
        private static int numberFile = 0;
        private static Mutex _mutex;

        public enum Types
        {
            // A completer et mitiger sur cette idée
            DEBUG = 0,
            ERROR = 1,
            MYSQL = 2,
            CONTROLLER = 3,
            CAMERA = 4,
            SITE = 5,
            LOGS = 88,
            OTHER = 99

        }


        private static void FolderExist()
        {
            try
            {
                if (!Directory.Exists(nameFileLogs))
                {
                    // Crée le dossier si jamais il n'hésite pas
                    System.IO.Directory.CreateDirectory(nameFileLogs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
            

        
        public static void InitializeLogs()
        {
            _mutex = new Mutex();
            _mutex.WaitOne();
            try
            {
                FolderExist();

                // Ajouter une vérification pour savoir si il existe deja un fichier logs de aujourd'hui
                if (File.Exists(DateTime.Now.ToString("dd-MM-yyyy") + "_0")) numberFile++;


                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);
                fileWriter.WriteLine(DateTime.Now.ToString("[hh:mm:ss] [") + Types.LOGS + "] Initialisation des logs...");
                fileWriter.Close();
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

        public static void DestructLogsIHM()
        {
            _mutex.WaitOne();
            try
            {
                FolderExist();
                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);
                fileWriter.WriteLine(DateTime.Now.ToString("[hh:mm:ss] [") + Types.LOGS + "] Stopping...\n\n\n\n");
                fileWriter.Close();
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


        public static string[] Read(int nbrLigne = 1)
        {
            _mutex.WaitOne();
            try
            {
                StreamReader fileReader = new StreamReader(nameFileLogs + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log");
                // Je prend la première ligne
                String line = fileReader.ReadLine();
                List<String> fileLines = new List<string>();
                // Je regarde le fichier n'est pas vide
                for (int i = 0; line != null && i < nbrLigne; i++)
                {
                    fileLines.Add(line);
                    Console.WriteLine("Debug : " + line);
                    line = fileReader.ReadLine();
                }
                fileReader.Close();
                return fileLines.ToArray();
            }
            catch (Exception e)
            {
                Console.Write("Exception: " + e.Message);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
            return null;
        }

        public static void Write(string args, Types type)
        {
            _mutex.WaitOne();
            try
            {
                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "\\" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);

                fileWriter.Write(DateTime.Now.ToString("[hh:mm:ss] [") + type + "] " + args + "\n");
                fileWriter.Close();
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

    }
}
