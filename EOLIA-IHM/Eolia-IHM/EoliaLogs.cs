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
        private static Mutex _mutex;

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
            // Protége l'accer au fichier logs a l'aide d'un mutex
            _mutex = new Mutex();
            _mutex.WaitOne();
            try
            {
                FolderExist();

                // Vérifie si un fichier logs du même jour existe, si il existe pas je l'initialise à 0 et j'incrémente ma variable
                bool fileLogsExist = File.Exists(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_0.log");
               // Console.WriteLine("fileLogsExist : " + fileLogsExist + "  > Exists : " + (nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_0.log"));

                if (fileLogsExist)
                {
                 //   Console.WriteLine("FileLogsExiste : " + fileLogsExist);
                    for (int i = 0; File.Exists(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + i + ".log"); i++, fileLogsExist = File.Exists(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + i + ".log"))
                    {
                        numberFile++;
                    }
                    
                }

                // J'ouvre le fichier de log en écriture
                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);
                fileWriter.WriteLine(DateTime.Now.ToString("[HH:mm:ss] [") + Types.LOGS + "] Initialisation des logs...");
                fileWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                // J'enleve le mutex dans finally pour mettre que en cas de d'erreur il retir a tout les coups de mutex
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
                // J'ouvre le fichier de log en écriture
                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);
                fileWriter.WriteLine(DateTime.Now.ToString("[HH:mm:ss] [") + Types.LOGS + "] Stopping...\n\n\n\n");
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

        // Fonction de lecture demandant le nombre de ligne a lire ou par défaut est définuir sur une ligne
        public static string[] Read(int nbrLigne = 1)
        {
            _mutex.WaitOne();
            try
            {
                // J'ouvre le fichier de log en lecture
                StreamReader fileReader = new StreamReader(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log");
                // Je prend la première ligne du fichier
                String line = fileReader.ReadLine();
                // Et je la sauvegarde dans une Liste dynamique
                List<String> fileLines = new List<string>();
                // Je fait une boucle tant que le fichier n'est pas vide et que le nombre de ligne a lire n'est pas atteint
                for (int i = 0; line != null && i < nbrLigne; i++)
                {
                    // J'ajoute ma ligne de log a mon tableau
                    fileLines.Add(line);
                    // Et je prépare ma prochaine ligne
                    line = fileReader.ReadLine();
                }
                fileReader.Close();
                // Je ferme le fichier et je retourne mon tableau contenant les logs demander
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
            // En cas d'erreur je retourne null
            return null;
        }

        // Fonction d'écriture dans le fichier logs, demander le texte a enregristrer et le type de logs via un enum
        public static void Write(string args, Types type)
        {
            _mutex.WaitOne();
            try
            {
                StreamWriter fileWriter = new StreamWriter(nameFileLogs + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + numberFile + ".log", true);

                fileWriter.Write(DateTime.Now.ToString("[HH:mm:ss] [") + type + "] " + args + "\n");
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
