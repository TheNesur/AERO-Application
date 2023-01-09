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
        
        public IHM()
        {
            InitializeComponent();
            if (!File.Exists("EoliaConfig.config"))
            {
                
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
            textBoxAdresseMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLADRESS");
            textBoxUsernameMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLUSERNAME");
            textBoxMotdepasseMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLPASSWORD");
            textBoxNomBDDMYSQL.Text = EoliaUtils.LireConfiguration("MYSQLDBNAME");
            ComboxBoxChoixPortSerieCapteur.Text = EoliaUtils.LireConfiguration("PORTSERIECAPTEUR");
            textBoxNbMesureSec.Text = EoliaUtils.LireConfiguration("NOMBREMESUREPARSECONDE");
            textBoxCZ.Text = EoliaUtils.LireConfiguration("CZ");
            textBoxCX.Text = EoliaUtils.LireConfiguration("CX");
            textBoxS.Text = EoliaUtils.LireConfiguration("S");
            textBoxV.Text = EoliaUtils.LireConfiguration("V");
            textBoxp.Text = EoliaUtils.LireConfiguration("RHO"); 
        }
        public void Sauvegarder()
        {
            IDictionary<string, string> ListeValeurASauvegarder = new Dictionary<string, string>();
            ListeValeurASauvegarder.Add("MYSQLADRESS", textBoxAdresseMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLUSERNAME", textBoxUsernameMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLPASSWORD", textBoxMotdepasseMYSQL.Text);
            ListeValeurASauvegarder.Add("MYSQLDBNAME", textBoxNomBDDMYSQL.Text);
            ListeValeurASauvegarder.Add("PORTSERIECAPTEUR", ComboxBoxChoixPortSerieCapteur.Text);
            ListeValeurASauvegarder.Add("NOMBREMESUREPARSECONDE", textBoxNbMesureSec.Text);
            ListeValeurASauvegarder.Add("CZ", textBoxCZ.Text);
            ListeValeurASauvegarder.Add("CX", textBoxCX.Text);
            ListeValeurASauvegarder.Add("S", textBoxS.Text);
            ListeValeurASauvegarder.Add("V", textBoxV.Text);
            ListeValeurASauvegarder.Add("RHO", textBoxp.Text);
            EoliaUtils.SauvegarderConfiguration(ListeValeurASauvegarder);
        }

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            if (EoliaMes.EtatTransMes())
            {
                EoliaMes.ArreterTransMes();
            }
            Application.Exit();
        }

        private void IHM_Load(object sender, EventArgs e)
        {

        }

        private void BoutonOngletEtat_Click(object sender, EventArgs e)
        {
            EoliaUtils.AfficherOnglet(GroupBoxEtat);
        }

        private void BoutonOngletMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.LiaisonSerieCapteur()) {
                EoliaUtils.AfficherOnglet(GroupBoxMesure);
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas acceder a la gestion des mesures si la liaison série du capteur n'est pas fonctionnelle ");
            }
        }

        private void BoutonOngletConfig_Click(object sender, EventArgs e)
        {
            if (EoliaSQL.BDDisConnected() || EoliaMes.LiaisonSerieCapteur())
            {
                MessageBox.Show("Vous ne pouvez pas modifier la configuration, si un ou plusieurs services sont lancés");
            }
            else
            {
                EoliaUtils.AfficherOnglet(GroupBoxConfig);
                EoliaUtils.AfficherPortSerie(ComboxBoxChoixPortSerieCapteur);
            }

        }

        private void BoutonSauvegarde_Click(object sender, EventArgs e)
        {
            Sauvegarder();
        }

        private void textBoxCX_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxCX);
        }

        private void textBoxCZ_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxCZ);
        }

        private void textBoxp_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxp);
        }

        private void textBoxV_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxV);
        }

        private void textBoxS_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxS);
        }

        private void BoutonNumpad1_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(1);
        }

        private void BoutonNumpad2_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(2);
        }

        private void BoutonNumpad3_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(3);
        }

        private void BoutonNumpad4_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(4);
        }

        private void BoutonNumpad5_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(5);
        }

        private void BoutonNumpad6_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(6);
        }

        private void BoutonNumpad7_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(7);
        }

        private void BoutonNumpad8_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(8);
        }

        private void BoutonNumpad9_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(9);
        }

        private void BoutonNumpadDot_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(10);
        }

        private void BoutonNumpadDel_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(11);
        }

        private void BoutonNumpad0_Click(object sender, EventArgs e)
        {
            EoliaUtils.PaveNumerique(0);
        }

        private void BoutonRechargerPortSerie_Click(object sender, EventArgs e)
        {
            EoliaUtils.AfficherPortSerie(ComboxBoxChoixPortSerieCapteur);
        }

        private void buttonDemarrerLiaisonSerie_Click(object sender, EventArgs e)
        {
            EoliaMes.InitialiserLiaisonSerieCapteur(ComboxBoxChoixPortSerieCapteur.Text, textBoxEtatLiaisonSerie);
            if (EoliaMes.LiaisonSerieCapteur())
            {
                buttonArreterLiaisonSerie.Enabled = true;
                buttonDemarrerLiaisonSerie.Enabled = false;
            }

        }

        private void buttonArreterLiaisonSerie_Click(object sender, EventArgs e)
        {
            EoliaMes.FermerLiaisonSerieCapteur();

            buttonArreterLiaisonSerie.Enabled = false;
            buttonDemarrerLiaisonSerie.Enabled = true;

        }

        private void buttonDemarrerLiaisonBDD_Click(object sender, EventArgs e)
        {
          //buttonDemarrerLiaisonBDD.Enabled = false;
            EoliaSQL.InitialiserConnexionSQL(textBoxNomBDDMYSQL.Text,
                                            textBoxUsernameMYSQL.Text,
                                            textBoxMotdepasseMYSQL.Text,
                                            textBoxAdresseMYSQL.Text,
                                            textBoxEtatLiaisonBDD,
                                            buttonDemarrerLiaisonBDD,
                                            buttonArreterLiaisonBDD);
        /*    if (EoliaFnct.BDDisConnected())
                buttonArreterLiaisonBDD.Enabled = true;
            else
                buttonDemarrerLiaisonBDD.Enabled = true; */

        }

        private void buttonArreterLiaisonBDD_Click(object sender, EventArgs e)
        {
            EoliaSQL.FermerConnexionSQL();
            if (!EoliaSQL.BDDisConnected())
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
            if (EoliaMes.EtatTransMes())
            {
                buttonSwitchTransmissionMesure.Text = "Demarrer transmission mesure";
                EoliaMes.ArreterTransMes();
            }
            else
            {
                buttonSwitchTransmissionMesure.Text = "Arrêter transmission mesure";
                EoliaMes.InitialiserTransMes(labelMsgMesure, labelMesPortance, labelMesTainee, textBoxNbMesureSec);
            }
        }

        private void buttonSwitchEnregistrementMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.EnregistrementMes(labelSessionMesureMoyTrainee, labelSessionMesureMoyPort, labelNomMesureSession, labelNombreMesureSession, labelSessionMesureEtat))
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
            if (EoliaMes.EtatTransMes())
            {
                EoliaMes.TarerCapteur();
            }
            else
            {
                EoliaUtils.MsgBoxNonBloquante("Vous devez établir une transmission avant de tarer");
            }
        }

        private async void buttonSauvegarderSession_Click(object sender, EventArgs e)
        {
            buttonSauvegarderSession.Enabled = false;
            if (EoliaSQL.BDDisConnected())
            {
                if (EoliaMes.SessionMesureDispo())
                {
                    string Requete = "INSERT INTO `Mesure` (`idMesure`, `MesurePortance`, `MesureTrainee`, `NomMesure`) VALUES (NULL, '" + labelSessionMesureMoyPort.Text + "', '" + labelSessionMesureMoyTrainee.Text + "', '" + labelNomMesureSession.Text + "');";
                    int ResultRequete = await EoliaSQL.ExecuterRequeteSansReponse(Requete);
                    if (ResultRequete != 0)
                    {
                        EoliaUtils.MsgBoxNonBloquante("Données envoyées avec Succés");
                    }
                    else
                    {
                        EoliaUtils.MsgBoxNonBloquante("Echec de la transmission");
                    }
                }
                else
                {
                    EoliaUtils.MsgBoxNonBloquante("La session de mesure est inexistante ou vide");
                }
            }
            else
            {
                EoliaUtils.MsgBoxNonBloquante("Non connecté a la BDD, Transmission impossible");
            }
            buttonSauvegarderSession.Enabled = true;
    
        }

        private void textBoxNbMesureSec_Click(object sender, EventArgs e)
        {
            EoliaUtils.TextBoxActif(textBoxNbMesureSec);
        }
    }
}
