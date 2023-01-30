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
            textBox1.Text += "Mesure reçu avec Portance = 5 | Trainee = 10.";
            textBox1.Text += "\r\nCapteurs tarer...";
            textBox1.Text += "\r\nMesure reçu avec Portance = 0 | Trainee = 10.";
            textBox1.Text += "\r\nMesure reçu avec Portance = 51 | Trainee = 75.";
            textBox1.Text += "\r\nMesure reçu avec Portance = 145 | Trainee = 85.";
            textBox1.Text += "\r\nSession sauvegarder...";
            textBox1.Text += "\r\nEnregistrement des données lancer...";
            textBox1.Text += "\r\nMesure reçu avec Portance = 145 | Trainee = 85.";
            textBox1.Text += "\r\nMesure reçu avec Portance = 51 | Trainee = 75.";
            textBox1.Text += "\r\nArrêt de l'enregistrement des donées.";
            textBox1.Text += "\r\nSession sauvegarder...";
        }

    }
}
