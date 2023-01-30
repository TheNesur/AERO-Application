using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{
    internal class EoliaSQL
    {

        // Variable relatif a la liaison a la BDD

        private static MySqlConnection SqlConnexion = null;
        private static bool BDDConnected = false;
        private static Label SQLLogBox = null;
        private static Button SwitchBouton = null;



        // Fonction relatif a la liaison a la BDD

        public static bool BDDisConnected()
        {
            if (BDDConnected)
            {
                return true;
            }
            return false;
        }

        public static void InitialiserConnexionSQL(string NomBaseDeDonée, string Utilisateur, string MotDePasse, string Adresse, Label SQLState, Button BoutonStartSQL)
        {
            string connexionString = "Server=" + Adresse + ";Database=" + NomBaseDeDonée + ";Uid=" + Utilisateur + ";Pwd=" + MotDePasse + ";";
            //string connexionString = "Data Source=" + Adresse + ",3306;Initial Catalog = " + NomBaseDeDonée + "; User ID = " + Utilisateur + "; Password = " + MotDePasse;
            SQLLogBox = SQLState;

            BoutonStartSQL.Enabled = false;
            SwitchBouton = BoutonStartSQL;
            SqlConnexion = new MySqlConnection(connexionString);
            Task.Run(() =>
            {
                try
                {
                    SqlConnexion.Open();
                    // SQLLogBox.Text = "BDD OK";
                    SQLLogBox.Invoke(new Action(() => SQLLogBox.Text = "BDD OK"));
                    BoutonStartSQL.Invoke(new Action(() => BoutonStartSQL.Enabled = true));
                    BoutonStartSQL.Invoke(new Action(() => BoutonStartSQL.Text = "Arreter la connexion MYSQL"));
                    EoliaLogs.Write("Connecté a la BDD MYSQL", EoliaLogs.Types.MYSQL);
                    BDDConnected = true;
                }
                catch (MySqlException ex)
                {
                    //    SQLLogBox.Text = "Erreur : " + ex.Message;
                    EoliaLogs.Write("Echec lors de la connexion a la BDD MYSQL ("+ex+")", EoliaLogs.Types.MYSQL);
                    SQLLogBox.Invoke(new Action(() => SQLLogBox.Text = "Erreur "));
                    BoutonStartSQL.Invoke(new Action(() => BoutonStartSQL.Enabled = true));
                    
                    SqlConnexion.Close();
                    SqlConnexion = null;
                }
            });

        }

        public static void FermerConnexionSQL()
        {
            if (SqlConnexion != null)
            {
                SqlConnexion.Close();
                SqlConnexion.Dispose();
                SqlConnexion = null;
                BDDConnected = false;
                SQLLogBox.Text = "BDD Deconnecté";
                SwitchBouton.Text = "Démarrer la liaison MYSQL";
            }
        }

        public static async Task<int> ExecuterRequeteSansReponse(string requete)
        {
            if (SqlConnexion != null)
            {
                MySqlCommand command = new MySqlCommand(requete, SqlConnexion);
                int LigneAffecte = await command.ExecuteNonQueryAsync();
                return LigneAffecte;
            }
            return 0;
        }

    }
}
