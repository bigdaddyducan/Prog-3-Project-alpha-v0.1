using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog_3_Project_alpha_v0._1
{
    public partial class Staff_Form : Form
    {
        public Staff_Form()
        {
            InitializeComponent();
        }


        private void Pic_Box_Display_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Pic_Box_Display, "Display");
        }

        private void Staff_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
