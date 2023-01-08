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
                textBoxAdresseMYSQL.Text = "A MODIFIER";
                textBoxUsernameMYSQL.Text = "A MODIFIER";
                textBoxMotdepasseMYSQL.Text = "A MODIFIER";
                textBoxNomBDDMYSQL.Text = "A MODIFIER";
                Sauvegarder();
                MessageBox.Show("Premier lancement, veuillez configurer la BDD dans EoliaConfig.config");
                Application.Exit();

            }
            else
            {

                Recharger();
            }
        }

        public void Recharger()
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
            if (EoliaFnct.EtatTransMes())
            {
                EoliaFnct.ArreterTransMes();
            }
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
            if (EoliaFnct.SerialisConnected()) {
                EoliaFnct.AfficherOnglet(GroupBoxMesure);
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas acceder a la gestion des mesures si la liaison série n'est pas fonctionnelle ");
            }
        }

        private void BoutonOngletConfig_Click(object sender, EventArgs e)
        {
            if (EoliaFnct.BDDisConnected() || EoliaFnct.SerialisConnected())
            {
                MessageBox.Show("Vous ne pouvez pas modifier la configuration, si un ou plusieurs services sont lancés");
            }
            else
            {
                EoliaFnct.AfficherOnglet(GroupBoxConfig);
                EoliaFnct.AfficherPortSerie(ComboxBoxChoixPortSerie);
            }

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
            EoliaFnct.InitialiserLiaisonSerie(ComboxBoxChoixPortSerie.Text, textBoxEtatLiaisonSerie);
            if (EoliaFnct.SerialisConnected())
            {
                buttonArreterLiaisonSerie.Enabled = true;
                buttonDemarrerLiaisonSerie.Enabled = false;
            }

        }

        private void buttonArreterLiaisonSerie_Click(object sender, EventArgs e)
        {
            EoliaFnct.FermerLiaisonSerie(ComboxBoxChoixPortSerie.Text);

            buttonArreterLiaisonSerie.Enabled = false;
            buttonDemarrerLiaisonSerie.Enabled = true;

        }

        private async void buttonDemarrerLiaisonBDD_Click(object sender, EventArgs e)
        {
            buttonDemarrerLiaisonBDD.Enabled = false;
            await EoliaFnct.InitialiserConnexionSQL(textBoxNomBDDMYSQL.Text,
                                            textBoxUsernameMYSQL.Text,
                                            textBoxMotdepasseMYSQL.Text,
                                            textBoxAdresseMYSQL.Text,
                                            textBoxEtatLiaisonBDD);
            if (EoliaFnct.BDDisConnected())
                buttonArreterLiaisonBDD.Enabled = true;
            else
                buttonDemarrerLiaisonBDD.Enabled = true;

        }

        private void buttonArreterLiaisonBDD_Click(object sender, EventArgs e)
        {
            EoliaFnct.FermerConnexionSQL();
            if (!EoliaFnct.BDDisConnected())
            {
                buttonDemarrerLiaisonBDD.Enabled = true;
                buttonArreterLiaisonBDD.Enabled = false;
            }

        }

        private void BoutonRecharger_Click(object sender, EventArgs e)
        {
            Recharger();
        }

        private void buttonSwitchTransmissionMesure_Click(object sender, EventArgs e)
        {
            if (EoliaFnct.EtatTransMes())
            {
                buttonSwitchTransmissionMesure.Text = "Demarrer transmission mesure";
                EoliaFnct.ArreterTransMes();
            }
            else
            {
                buttonSwitchTransmissionMesure.Text = "Arrêter transmission mesure";
                EoliaFnct.InitialiserTransMes(labelMsgMesure, labelMesPortance, labelMesTainee);
            }
        }

        private void buttonSwitchEnregistrementMesure_Click(object sender, EventArgs e)
        {
            if (EoliaFnct.EnregistrementMes(labelSessionMesureMoyTrainee, labelSessionMesureMoyPort, labelNomMesureSession, labelNombreMesureSession, labelSessionMesureEtat))
            {
                buttonSwitchEnregistrementMesure.Text = "Demarrer enregistrement mesure";
            }
            else
            {
                buttonSwitchEnregistrementMesure.Text = "Arrêter enregistrement mesure";
            }
        }

        private void buttonTarCapteurs_Click(object sender, EventArgs e)
        {
            if (EoliaFnct.EtatTransMes())
            {
                EoliaFnct.TarerCapteur();
            }
            else
            {
                EoliaFnct.MsgBoxNonBloquante("Vous devez établir une transmission avant de tarer");
            }
        }

        private async void buttonSauvegarderSession_Click(object sender, EventArgs e)
        {
            buttonSauvegarderSession.Enabled = false;
            if (EoliaFnct.BDDisConnected())
            {
                if (EoliaFnct.SessionMesureDispo())
                {
                    string Requete = "INSERT INTO `Mesure` (`idMesure`, `MesurePortance`, `MesureTrainee`, `NomMesure`) VALUES (NULL, '" + labelSessionMesureMoyPort.Text + "', '" + labelSessionMesureMoyTrainee.Text + "', '" + labelNomMesureSession.Text + "');";
                    int ResultRequete = await EoliaFnct.ExecuterRequeteSansReponse(Requete);
                    if (ResultRequete != 0)
                    {
                        EoliaFnct.MsgBoxNonBloquante("Données envoyées avec Succés");
                    }
                    else
                    {
                        EoliaFnct.MsgBoxNonBloquante("Echec de la transmission");
                    }
                }
                else
                {
                    EoliaFnct.MsgBoxNonBloquante("La session de mesure est inexistante ou vide");
                }
            }
            else
            {
                EoliaFnct.MsgBoxNonBloquante("Non connecté a la BDD, Transmission impossible");
            }
            buttonSauvegarderSession.Enabled = true;
    
        }
    }
}
