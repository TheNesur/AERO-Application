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
    public partial class MesureMenu : UserControl
    {
        public MesureMenu()
        {
            InitializeComponent();

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
                EoliaMes.InitialiserTransMes(textBoxLogMesure, labelMesurePortance, labelMesureTrainee, EoliaUtils.LireConfiguration("NOMBREMESUREPARSECONDE"));
            }
        }

        private void buttonLancerEnregistrementMesure_Click(object sender, EventArgs e)
        {
            if (EoliaMes.EnregistrementMes(labelValeurMoyenneTrainee,labelValeurMoyennePortance,labelNomSession,labelNombreMesure,labelEtatSession))
            {
                buttonLancerEnregistrementMesure.Text = "Demarrer enregistrement mesure";
            }
            else
            {
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
                    string Requete = "INSERT INTO `Mesure` (`idMesure`, `MesurePortance`, `MesureTrainee`, `NomMesure`) VALUES (NULL, '" + EoliaMes.PortancePretPourEnvoi() + "', '" + EoliaMes.TraineePretPourEnvoi() + "', '" + labelNomSession.Text + "');";
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
