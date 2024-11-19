using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog_3_Project_alpha_v0._1
{
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
        }

        public void Bookings_Load(object sender, EventArgs e)
        {
            int no;

            lblBookingDate.Text = DateTime.Now.ToShortDateString();
            dtpStartDate.MinDate = DateTime.Now;

            for (int i = 0; i < 26; i++)
            {

            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drBookings, drBookingsDerts;
            int bookingNo;

            int noRows = Prog_3_Project_alpha_v0.Tables["Bookings"].Rows.Count;



            if (lstPatient.SelectedIndex == -1)
                MessageBox.Show("Please select a Patient", "Patient");
            else if (lstStaff.SelectedIndex == -1)
                MessageBox.Show("Please select Staff", "Staff");
            else if (lvwBooking.Items.Count == 0)
                MessageBox.Show("Please add a patient/staff to the booking", "Booking Details");
        }






        private void AddPatient_Click(object sender, EventArgs e)
        {
            bool ok = true;
            bool exists = false;


            if (lstPatient.SelectedIndex == -1)
                MessageBox.Show("Please select a Patient", "Patient");
            else if (lstTreatment.SelectedIndex == -1)
                MessageBox.Show("Please select Treatment", "Treatment");
            else if (lstStaff.SelectedIndex == -1)
                MessageBox.Show("Please select Staff", "Staff");

            else
            {
                foreach (ListViewItem item in lvwBooking.Items)
                {
                    if (item.SubItems[1].Text == 1stPatient.Text || item.SubItems[2].Text == 1stStaff)
                    {
                        MessageBox.Show("")
                            }
                }
            }



        }





        private void DeletePatient_Click(object sender, EventArgs e)
        {
            if(lvwBooking.SelectedItems.Count ! = 0)
            {
                var item = lvwBooking.SelectedItems[0];
                lvwBooking.Items.Delete(item);
            }

        }

        private void ClearPatient()
        {
            lstPatient.SelectedIndex = -1;

            lblPat0.Text = "";
            lblPat1.Text = "";
            lblPat2.Text = "";
            lblPat3.Text = "";
            lblPat4.Text = "";
            lblPat5.Text = "";
        }
    }
}
