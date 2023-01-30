using Eolia_IHM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM.Menu
{
    public partial class ConfigurationMenu : UserControl
    {
        public static TextBox textBox;

        public static string PortSerieCapteur;
        public static string FrequenceMesure;
        public static string AdresseBDD;
        public static string NomBDD;
        public static string UsernameBDD;
        public static string PasswordBDD;


        public ConfigurationMenu()
        {
            InitializeComponent();
        }

        private void ConfigurationMenu_Load(object sender, EventArgs e)
        {

        }


        private void BoutonNumpad_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            EoliaUtils.PaveNumerique(btn.Text);

        }

        private void textBoxPad_Click(object sender, EventArgs e)
        {
           // textBox = (TextBox)sender;
            
            EoliaUtils.TextBoxActif((TextBox)sender);
            
        }


        private void buttonConfiguration_Click(object sender, EventArgs e)
        {
            EoliaUtils.AfficherPortSerie(comboBoxPortCapteur);
            EoliaUtils.AfficherPortSerie(comboBoxPortRegulateur);
        }

        private void buttonRechargerConfiguration_Click(object sender, EventArgs e)
        {
            Recharger();
        }

        public void Recharger()
        {
            labelAdresseMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLADRESS");
            AdresseBDD = labelAdresseMYSQL.Text;
            labelUsernameMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLUSERNAME");
            UsernameBDD = labelUsernameMYSQL.Text;
            labelMDPMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLPASSWORD");
            PasswordBDD = labelMDPMYSQL.Text;
            labelNomBDDMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLDBNAME");
            NomBDD = labelNomBDDMYSQL.Text;
            labelRepetoire.Text = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB");
            comboBoxPortCapteur.Text = EoliaUtils.LireConfiguration("PORTSERIECAPTEUR");
            PortSerieCapteur = comboBoxPortCapteur.Text;
            comboBoxPortRegulateur.Text = EoliaUtils.LireConfiguration("PORTSERIEREGULATEUR");
            textBoxNbMesureSec.Text = EoliaUtils.LireConfiguration("NOMBREMESUREPARSECONDE");
        }
        public void Sauvegarder()
        {
            IDictionary<string, string> ListeValeurASauvegarder = new Dictionary<string, string>();
            ListeValeurASauvegarder.Add("MYSQLADRESS", labelAdresseMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLUSERNAME", labelUsernameMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLPASSWORD", labelMDPMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLDBNAME", labelNomBDDMYSQL.Text);
            ListeValeurASauvegarder.Add("REPERTOIRESITEWEB", labelRepetoire.Text);

            ListeValeurASauvegarder.Add("PORTSERIECAPTEUR", comboBoxPortCapteur.Text);
            ListeValeurASauvegarder.Add("PORTSERIEREGULATEUR", comboBoxPortRegulateur.Text);

            ListeValeurASauvegarder.Add("NOMBREMESUREPARSECONDE", textBoxNbMesureSec.Text);

            EoliaUtils.SauvegarderConfiguration(ListeValeurASauvegarder);
        }

        private void buttonSauvegarderConfig_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }
    }
}
