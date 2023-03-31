using Eolia_IHM.Properties;
using Eolia_IHM.Utils;
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
        public static string PortSerieRegulateur;
        public static string FrequenceMesure;
        public static string AdresseBDD;
        public static string NomBDD;
        public static string UsernameBDD;
        public static string PasswordBDD;
        public static string FREQUENCEMES;
        public static string EQGVOLTTRAINEE;
        public static string EQGVOLTPORTANCE;
        public static string ECHELLEJAUGEPORTANCE;
        public static string ECHELLEJAUGETRAINEE;
        public static string CZ;
        public static string CX;
        public static string rho;
        public static string S; 
        public static Label labelNomBDD;


        public ConfigurationMenu()
        {
            InitializeComponent();
        }

        private void ConfigurationMenu_Load(object sender, EventArgs e)
        {
            if(EoliaUtils.EoliaConfigExiste())
                Recharger();
            buttonConfiguration.PerformClick();
            //panelGoCalib.BackColor = Color.FromArgb(150, 150, 150);
            panelGoCalib.BackColor = Color.Gray;
            buttoncalibrerportance.BackColor = Color.FromArgb(204, 204, 204);
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

            textBoxGVoltPortance.Text = EoliaUtils.LireConfiguration("VALEURMAXPORTANCE");
            EQGVOLTPORTANCE = textBoxGVoltPortance.Text;

            textBoxGVoltTrainee.Text = EoliaUtils.LireConfiguration("VALEURMAXTRAINEE");
            EQGVOLTTRAINEE = textBoxGVoltPortance.Text;

            textBoxCx.Text = EoliaUtils.LireConfiguration("CX");
            CX = textBoxCx.Text;


            textBoxCz.Text = EoliaUtils.LireConfiguration("CZ");
            CZ = textBoxCz.Text;

            textBoxRho.Text = EoliaUtils.LireConfiguration("RHO");
            rho = textBoxRho.Text;

            textBoxS.Text = EoliaUtils.LireConfiguration("SURFACEALAIR");
            S = textBoxS.Text;

            ECHELLEJAUGEPORTANCE = EoliaUtils.LireConfiguration("ECHELLEJAUGEPORTANCE");
            textBoxEchellePortance.Text = ECHELLEJAUGEPORTANCE;


            ECHELLEJAUGETRAINEE = EoliaUtils.LireConfiguration("ECHELLEJAUGETRAINEE");
            textBoxEchelleTrainee.Text = ECHELLEJAUGETRAINEE;


            EoliaLogs.Write("Configuration chargée", EoliaLogs.Types.OTHER);
        }
        public void Sauvegarder()
        {
            IDictionary<string, string> ListeValeurASauvegarder = new Dictionary<string, string>
            {
                { "MYSQLADRESS", labelAdresseMYSQL.Text },
                { "MYSQLUSERNAME", labelUsernameMYSQL.Text },
                { "MYSQLPASSWORD", labelMDPMYSQL.Text },
                { "MYSQLDBNAME", labelNomBDDMYSQL.Text },
                { "REPERTOIRESITEWEB", labelRepetoire.Text },
                { "PORTSERIECAPTEUR", comboBoxPortCapteur.Text },
                { "PORTSERIEREGULATEUR", comboBoxPortRegulateur.Text },
                { "FREQUENCEMESURE", textBoxNbMesureSec.Text },
                { "VALEURMAXPORTANCE", textBoxGVoltPortance.Text },
                { "VALEURMAXTRAINEE", textBoxGVoltTrainee.Text },
                { "CX", textBoxCx.Text },
                { "CZ", textBoxCz.Text },
                { "RHO", textBoxRho.Text },
                { "SURFACEALAIR", textBoxS.Text },
                { "ECHELLEJAUGEPORTANCE", ECHELLEJAUGEPORTANCE },
                { "ECHELLEJAUGETRAINEE", ECHELLEJAUGETRAINEE }
            };

            EoliaLogs.Write("Nouvelle configuration enregistrée", EoliaLogs.Types.OTHER);
            PortSerieCapteur = comboBoxPortCapteur.Text;
            PortSerieRegulateur = comboBoxPortRegulateur.Text;
            FREQUENCEMES = textBoxNbMesureSec.Text;
            EQGVOLTPORTANCE = textBoxGVoltPortance.Text;
            EQGVOLTTRAINEE = textBoxGVoltPortance.Text;
            CX = textBoxCx.Text;
            CZ = textBoxCz.Text;
            rho = textBoxRho.Text;
            S = textBoxS.Text;

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

        private void ConfigurationMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (EoliaMes.LiaisonSerieCapteur())
            {
                groupBoxConfigJauges.Enabled = true;
            }
            else
            {
                groupBoxConfigJauges.Enabled = false;
            }
        }



        private async void buttoncalibrerportance_Click(object sender, EventArgs e)
        {
            EoliaMes.EnvoyerMessageSerieCapteur("RAWPORTANCE");

            int delaiMaximum = 5000; // Temps d'attente maximum en millisecondes
            int delaiEcoule = 0; // Temps écoulé depuis le début de l'attente en millisecondes

            while (float.IsNaN(EoliaMes.CalibrationPortance))
            {
                await Task.Delay(100);
                delaiEcoule += 100;

                if (delaiEcoule >= delaiMaximum)
                {
                    // Si le délai maximum est écoulé et que la valeur de CalibrationPortance n'a pas été définie, affiche un message d'erreur.
                    EoliaUtils.MsgBoxNonBloquante("Délai maximum d'attente dépassé. La calibration de portance a échoué.");
                    return;
                }
            }


                // Sinon, affiche la valeur de CalibrationPortance dans la zone de texte.
                textBoxEchellePortance.Text = EoliaMes.CalibrationPortance.ToString().Replace(",", ".");
            

            // Réinitialise CalibrationPortance.
            EoliaMes.CalibrationPortance = float.NaN;
        }


        private async void buttoncalibrertrainee_Click(object sender, EventArgs e)
        {
            EoliaMes.EnvoyerMessageSerieCapteur("RAWTRAINEE");

            int delaiMaximum = 5000; // Temps d'attente maximum en millisecondes
            int delaiEcoule = 0; // Temps écoulé depuis le début de l'attente en millisecondes

            while (float.IsNaN(EoliaMes.CalibrationTrainee) && delaiEcoule < delaiMaximum)
            {
                await Task.Delay(100);
                delaiEcoule += 100;
            }

            if (delaiEcoule >= delaiMaximum)
            {
                
                EoliaUtils.MsgBoxNonBloquante("Délai maximum d'attente dépassé. La calibration de portance a échoué.");
            }
            else
            {
          
                textBoxEchelleTrainee.Text = EoliaMes.CalibrationTrainee.ToString().Replace(",", ".");
            }

            // Réinitialise CalibrationPortance.
            EoliaMes.CalibrationTrainee = float.NaN;
        }

        private async void buttonSTARTGOCALIB_Click(object sender, EventArgs e)
        {
            
            if (!panelGoCalib.Enabled) {
                buttonSTARTGOCALIB.Enabled = false;
                EoliaMes.EnvoyerMessageSerieCapteur("GOCALIB");
                int delaiMaximum = 5000; // Temps d'attente maximum en millisecondes
                int delaiEcoule = 0; // Temps écoulé depuis le début de l'attente en millisecondes

                while (EoliaMes.GoCalib != true)
                {
                    await Task.Delay(100);
                    delaiEcoule += 100;
                    if (delaiEcoule >= delaiMaximum)
                    {
                        buttonSTARTGOCALIB.Text = "Demarrer";
                        EoliaUtils.MsgBoxNonBloquante("Délai maximum d'attente dépassé. La calibration a échoué.");
                        return;
                    }
                }



                panelGoCalib.Enabled = true;
                EoliaMes.GoCalib = false;
                buttonSTARTGOCALIB.Text = "Terminer";
                panelGoCalib.BackColor = Color.FromArgb(204, 204, 204);
                buttoncalibrerportance.BackColor = Color.White;

            }
            else
            {
                ConfigurationMenu.ECHELLEJAUGEPORTANCE = textBoxEchellePortance.Text;
                ConfigurationMenu.ECHELLEJAUGETRAINEE = textBoxEchelleTrainee.Text;
                Sauvegarder();
                buttonSTARTGOCALIB.Text = "Demarrer";
                panelGoCalib.Enabled = false;
                panelGoCalib.BackColor = Color.Gray;
                buttoncalibrerportance.BackColor = Color.FromArgb(204, 204, 204);
            }

        }
    }
}
