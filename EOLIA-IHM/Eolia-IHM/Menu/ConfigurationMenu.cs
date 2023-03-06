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
using System.Windows.Forms.VisualStyles;

namespace Eolia_IHM.Menu
{
    public partial class ConfigurationMenu : UserControl
    {
        public static TextBox textBox;

        public static string PortSerieCapteur;
        public static string PortSerieRegulateur;
        public static string FrequenceMesure;
        public static string AdresseBDD;
        public static string NomBDD;
        public static string UsernameBDD;
        public static string PasswordBDD;
        public static string FREQUENCEMES;
        public static string EQGVOLTTRAINEE;
        public static string EQGVOLTPORTANCE;
        public static Label labelNomBDD;


        public ConfigurationMenu()
        {
            InitializeComponent();
        }

        private void ConfigurationMenu_Load(object sender, EventArgs e)
        {
            Recharger();
            buttonConfiguration.PerformClick();
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
            PortSerieRegulateur = comboBoxPortRegulateur.Text;

            textBoxNbMesureSec.Text = EoliaUtils.LireConfiguration("FREQUENCEMESURE");
            FREQUENCEMES = textBoxNbMesureSec.Text;

            textBoxGVoltPortance.Text = EoliaUtils.LireConfiguration("EQUIVALENCEVOLTPORTANCE");
            EQGVOLTPORTANCE = textBoxGVoltPortance.Text;

            textBoxGVoltTrainee.Text = EoliaUtils.LireConfiguration("EQUIVALENCEVOLTTRAINEE");
            EQGVOLTTRAINEE = textBoxGVoltPortance.Text;

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
            ListeValeurASauvegarder.Add("FREQUENCEMESURE", textBoxNbMesureSec.Text);
            ListeValeurASauvegarder.Add("EQUIVALENCEVOLTPORTANCE", textBoxGVoltPortance.Text);
            ListeValeurASauvegarder.Add("EQUIVALENCEVOLTTRAINEE", textBoxGVoltTrainee.Text);

            EoliaUtils.SauvegarderConfiguration(ListeValeurASauvegarder);
        }

        private void buttonSauvegarderConfig_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }

        private void comboBoxPortRegulateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPortRegulateur.SelectedIndex != -1)
            {
                comboBoxPortCapteur.Items.Remove(comboBoxPortRegulateur.SelectedItem);

            }
        }

        private void comboBoxPortCapteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPortCapteur.SelectedIndex != -1)
            {
                comboBoxPortRegulateur.Items.Remove(comboBoxPortCapteur.SelectedItem);

            }
        }


        private void comboBoxPortCapteur_Click(object sender, EventArgs e)
        {
            EoliaUtils.AfficherPortSerie((ComboBox)sender);
        }

        private void comboBoxPortRegulateur_Click(object sender, EventArgs e)
        {
            EoliaUtils.AfficherPortSerie((ComboBox)sender);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void ChoixFormat(object sender ,EventArgs e)
        {

        }
        private void textBoxGVoltTrainee_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void textBoxS_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

    }
}
