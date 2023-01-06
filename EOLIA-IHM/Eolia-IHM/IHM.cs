using Eolia_IHM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{
    public partial class IHM : Form
    {
        EoliaUtils EoliaFnct = new EoliaUtils(); // Instance de la classe EoliaUtils 
        public IHM()
        {
            InitializeComponent();
            if (!File.Exists("EoliaConfig.config"))
            {
                /*
                IDictionary<string, string> ListeValeurASauvegarder = new Dictionary<string, string>();
                
                ListeValeurASauvegarder.Add("MYSQLADRESS", "A CONFIGURER");
                ListeValeurASauvegarder.Add("MYSQLUSERNAME", "A CONFIGURER");
                ListeValeurASauvegarder.Add("MYSQLPASSWORD", "A CONFIGURER");
                ListeValeurASauvegarder.Add("MYSQLDBNAME", "A CONFIGURER");
                ListeValeurASauvegarder.Add("SERIALPORT", "");
                ListeValeurASauvegarder.Add("CZ", "");
                ListeValeurASauvegarder.Add("CX","");
                ListeValeurASauvegarder.Add("S","");
                ListeValeurASauvegarder.Add("V", "");
                ListeValeurASauvegarder.Add("RHO", "");
                EoliaFnct.SauvegarderConfiguration(ListeValeurASauvegarder); */
                textBoxAdresseMYSQL.Text = "A COMPLETER";
                textBoxUsernameMYSQL.Text = "A COMPLETER";
                textBoxMotdepasseMYSQL.Text = "A COMPLETER";
                textBoxNomBDDMYSQL.Text = "A COMPLETER";
                Sauvegarder();
                MessageBox.Show("Premier lancement, veuillez configurer la BDD dans EoliaConfig.config");
                Application.Exit();

            }
            else
            {
                
                textBoxAdresseMYSQL.Text = EoliaFnct.LireConfiguration("MYSQLADRESS");
                textBoxUsernameMYSQL.Text = EoliaFnct.LireConfiguration("MYSQLUSERNAME");
                textBoxMotdepasseMYSQL.Text = EoliaFnct.LireConfiguration("MYSQLPASSWORD");
                textBoxNomBDDMYSQL.Text = EoliaFnct.LireConfiguration("MYSQLDBNAME");
                ComboxBoxChoixPortSerie.Text = EoliaFnct.LireConfiguration("SERIALPORT");
                textBoxCZ.Text = EoliaFnct.LireConfiguration("CZ");
                textBoxCX.Text = EoliaFnct.LireConfiguration("CX");
                textBoxS.Text = EoliaFnct.LireConfiguration("S");
                textBoxV.Text = EoliaFnct.LireConfiguration("V");
                textBoxp.Text = EoliaFnct.LireConfiguration("RHO");
            }
        }

        public void Sauvegarder()
        {
            IDictionary<string, string> ListeValeurASauvegarder = new Dictionary<string, string>();
            ListeValeurASauvegarder.Add("MYSQLADRESS", textBoxAdresseMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLUSERNAME", textBoxUsernameMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLPASSWORD", textBoxMotdepasseMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLDBNAME", textBoxNomBDDMYSQL.Text);
            ListeValeurASauvegarder.Add("SERIALPORT", ComboxBoxChoixPortSerie.Text);
            ListeValeurASauvegarder.Add("CZ", textBoxCZ.Text);
            ListeValeurASauvegarder.Add("CX", textBoxCX.Text);
            ListeValeurASauvegarder.Add("S", textBoxS.Text);
            ListeValeurASauvegarder.Add("V", textBoxV.Text);
            ListeValeurASauvegarder.Add("RHO", textBoxp.Text);
            EoliaFnct.SauvegarderConfiguration(ListeValeurASauvegarder);
        }

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IHM_Load(object sender, EventArgs e)
        {

        }

        private void BoutonOngletEtat_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxEtat);
        }

        private void BoutonOngletMesure_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxMesure);
        }

        private void BoutonOngletConfig_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxConfig);
        }

        private void BoutonSauvegarde_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }

        private void textBoxCX_Click(object sender, EventArgs e)
        {
            EoliaFnct.TextBoxActif(textBoxCX);
        }

        private void textBoxCZ_Click(object sender, EventArgs e)
        {
            EoliaFnct.TextBoxActif(textBoxCZ);
        }

        private void textBoxp_Click(object sender, EventArgs e)
        {
            EoliaFnct.TextBoxActif(textBoxp);
        }

        private void textBoxV_Click(object sender, EventArgs e)
        {
            EoliaFnct.TextBoxActif(textBoxV);
        }

        private void textBoxS_Click(object sender, EventArgs e)
        {
            EoliaFnct.TextBoxActif(textBoxS);
        }

        private void BoutonNumpad1_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(1);
        }

        private void BoutonNumpad2_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(2);
        }

        private void BoutonNumpad3_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(3);
        }

        private void BoutonNumpad4_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(4);
        }

        private void BoutonNumpad5_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(5);
        }

        private void BoutonNumpad6_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(6);
        }

        private void BoutonNumpad7_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(7);
        }

        private void BoutonNumpad8_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(8);
        }

        private void BoutonNumpad9_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(9);
        }

        private void BoutonNumpadDot_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(10);
        }

        private void BoutonNumpadDel_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(11);
        }

        private void BoutonNumpad0_Click(object sender, EventArgs e)
        {
            EoliaFnct.PaveNumerique(0);
        }

        private void BoutonRechargerPortSerie_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherPortSerie(ComboxBoxChoixPortSerie);
        }

        private void buttonDemarrerLiaisonSerie_Click(object sender, EventArgs e)
        {
            EoliaUtils.InitialiserLiaisonSerie(ComboxBoxChoixPortSerie.Text, textBoxEtatLiaisonSerie);
        }

        private void buttonArreterLiaisonSerie_Click(object sender, EventArgs e)
        {
            EoliaUtils.FermerLiaisonSerie(ComboxBoxChoixPortSerie.Text);
        }

        private void buttonDemarrerLiaisonBDD_Click(object sender, EventArgs e)
        {
            EoliaFnct.InitialiserConnexionSQL(textBoxNomBDDMYSQL.Text, 
                                            textBoxUsernameMYSQL.Text,
                                            textBoxMotdepasseMYSQL.Text,
                                            textBoxAdresseMYSQL.Text, 
                                            textBoxEtatLiaisonBDD);

        }
    }
}
