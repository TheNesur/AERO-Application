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
        public ConfigurationMenu()
        {
            InitializeComponent();
        }

        private void ConfigurationMenu_Load(object sender, EventArgs e)
        {

        }


        private void BoutonNumpad_Click(object sender, EventArgs e)
        {
            if (textBox == null) return;
            Button btn = (Button)sender;
            if (textBox.Text.Contains(".") && btn.Text.Contains(".")) return;
            textBox.Text += btn.Text;

        }

        private void textBoxPad_Click(object sender, EventArgs e)
        {
            textBox = (TextBox)sender;
            //EoliaUtils.TextBoxActif((TextBox)sender);
            
        }
        private void BoutonNumpadSupp_Click(object sender, EventArgs e)
        {
            if (textBox == null) return;
            if (textBox.Text.Length == 0) return;
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
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
            labelUsernameMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLUSERNAME");
            labelMDPMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLPASSWORD");
            labelNomBDDMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLDBNAME");
            labelRepetoire.Text = EoliaUtils.LireConfiguration("REPERTOIRESITEWEB");
            comboBoxPortCapteur.Text = EoliaUtils.LireConfiguration("PORTSERIECAPTEUR");
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
            ListeValeurASauvegarder.Add("PORTSERIEREGULATEUR", comboBoxPortCapteur.Text);

            ListeValeurASauvegarder.Add("NOMBREMESUREPARSECONDE", textBoxNbMesureSec.Text);

            EoliaUtils.SauvegarderConfiguration(ListeValeurASauvegarder);
        }

        private void buttonSauvegarderConfig_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }
    }
}
