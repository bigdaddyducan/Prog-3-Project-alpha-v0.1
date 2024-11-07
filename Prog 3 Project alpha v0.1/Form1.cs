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
        private void Pic_Box_Add_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Pic_Box_Add, "Add");
        }

        private void Pic_Box_Edit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Pic_Box_Edit, "Edit");
        }

        private void Pic_Box_Delete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Pic_Box_Delete, "Delete");
        }
    }
}
