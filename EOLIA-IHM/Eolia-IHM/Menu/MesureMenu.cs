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
    public partial class MesureMenu : UserControl
    {
        public MesureMenu()
        {
            InitializeComponent();

            if (!EoliaCam.CameraExist())
            {
                multimediaParam.Enabled = false;
            }

        }

        private void buttonLancerTransmissionMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.EtatTransMes())
            {
                buttonLancerTransmissionMesure.Text = "Demarrer transmission mesure";
                EoliaMes.ArreterTransMes();
            }
            else
            {
                buttonLancerTransmissionMesure.Text = "Arrêter transmission mesure";
                EoliaMes.InitialiserTransMes(textBoxLogMesure, labelMesurePortance, labelMesureTrainee, ConfigurationMenu.FREQUENCEMES, ConfigurationMenu.EQGVOLTPORTANCE, ConfigurationMenu.EQGVOLTTRAINEE);
            }
        }

        private void buttonLancerEnregistrementMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.EnregistrementMes(labelValeurMoyenneTrainee,labelValeurMoyennePortance,labelNomSession,labelNombreMesure,labelEtatSession, photoParam.Checked,videoParam.Checked))
            {
                if (EoliaCam.CameraExist())
                {
                    multimediaParam.Enabled = true;
                    multimediaParam.BackColor = Color.FromArgb(204,204,204);
                    buttonSauvegarderSessionEnCours.Enabled = true;
                    buttonSauvegarderSessionEnCours.BackColor = Color.White;

                }
                buttonLancerEnregistrementMesure.Text = "Demarrer enregistrement mesure";
            }
            else
            {
                multimediaParam.Enabled = false;
                multimediaParam.BackColor = Color.FromArgb(150,150,150);
                buttonSauvegarderSessionEnCours.Enabled = false;
                buttonSauvegarderSessionEnCours.BackColor = Color.Gray;
                buttonLancerEnregistrementMesure.Text = "Arrêter enregistrement mesure";
            }
        }

        private async void buttonSauvegarderSessionEnCours_Click(object sender, EventArgs e)
        {
            buttonSauvegarderSessionEnCours.Enabled = false;

            if (EoliaSQL.BDDisConnected())
            {
                if (EoliaMes.SessionMesureDispo())
                {
                    string Requete = "INSERT INTO sessionmesure (idSession, nomMesure, dateMesure, czMesure, cxMesure, rhoMesure, sMesure, fMesure, photoMesure, videoMesure) VALUES(NULL, '" + labelNomSession.Text + "', NULL, '"+ConfigurationMenu.CZ+"', '"+ConfigurationMenu.CX+"', '"+ConfigurationMenu.rho+"', '"+ConfigurationMenu.S+"', '"+ ConfigurationMenu.FREQUENCEMES + "', '" + EoliaMes.ObtenirRepPhoto() + "', '" + EoliaMes.ObtenirRepVideo() + "'); SELECT LAST_INSERT_ID();";
                    //   string Requete = "INSERT INTO `Mesure` (`idMesure`, `MesurePortance`, `MesureTrainee`, `NomMesure`) VALUES (NULL, '" + EoliaMes.PortancePretPourEnvoi() + "', '" + EoliaMes.TraineePretPourEnvoi() + "', '" + labelNomSession.Text + "');";
                    int ResultRequete = await EoliaSQL.ExecuterRequeteAvecReponse(Requete);
                    int idSession = ResultRequete;


                    if (ResultRequete != -1)
                    {
                        Requete = "INSERT INTO `mesure` (`idMesure`, `portanceMesure`, `traineeMesure`, `vitesseMesure`, `idSession`) VALUES " + EoliaMes.RequeteMesurePrete(ResultRequete) + ";";
                        ResultRequete = await EoliaSQL.ExecuterRequeteSansReponse(Requete);
                        if (ResultRequete != -1)
                        {
                            EoliaUtils.MsgBoxNonBloquante("Transmission de la session numéro " + idSession + " bien effectuée.");
                            EoliaMes.ReinitialiserSession();
                        }
                        else
                        {
                            EoliaUtils.MsgBoxNonBloquante("Echec de la transmission");
                        }

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
            buttonSauvegarderSessionEnCours.Enabled = true;
        }

        private void buttonTarerCapteurs_Click(object sender, EventArgs e)
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
    }
}
