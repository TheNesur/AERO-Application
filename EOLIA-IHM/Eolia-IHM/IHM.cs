using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{
    public partial class IHM : Form
    {
        public int lol;
        public IHM()
        {
            InitializeComponent();
        }

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IHM_Load(object sender, EventArgs e)
        {

        }
    }
}
