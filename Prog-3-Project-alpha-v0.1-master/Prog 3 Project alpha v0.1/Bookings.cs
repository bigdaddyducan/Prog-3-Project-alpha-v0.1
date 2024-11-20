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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (1stStaff.Items.Count! = 0)
                    {
                pnlBooking.Enabled = true;
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (1stTreatment.Items.Count! = 0)
                    {
                dsProg_3_Project_alpha_v0.Tables["Patient"].Clear();

                cmdTreatmentDetails.Parameters[""].value = 1stTreatment.SelectedValue;

                daStaff.Fill(dsProg_3_Project_alpha_v0, "Staff");


                1stStaff.DataSource = Prog_3_Project_alpha_v0.Tables[""];
                1stStaff.DisplayMember = "";
                1stStaff.ValueMember = "";

                1stStaff.SelectedIndex = -1;
            }
        }

        private void fillListboxPatients(String str)
        {
            cmdPatientsDetails.Parameters["@Letter"].Value = str + "%";

            daPatients.Fill(dsProg_3_Project_alpha_v0, "Patient");

            1stPatient.DataSource = dsProg_3_Project_alpha_v0.Tables["Patient"];
            1stPatient.DisplayMember = "name";
            1stPatient.ValueMember = "PatientNo";
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String title = "";

            dsProg_3_Project_alpha_v0.Tables["Patient"].Clear();

            cmdPatientDetails.Parameters["@CustNo"].Value = lstPatients.SelectedValue;

            daPatients.Fill(dsProg_3_Project_alpha_v0, "Patients");

            1stPatients.DataSource = dsProg_3_Project_alpha_v0.Tables["Patient"];
            1stPatient.DisplayMember = "name";
            1stPatient.Valuemember = "breedNo";

            1stPatient.SelectedIndex = -1;

            drPatient = dsProg_3_Project_alpha_v0.Tables["Patient"].Rows.Find(1stPatient.SelectedValue);

            if (drPatient["Title"].ToString() == "Mr")
                title = "Mr";
            if (drPatient["Title"].ToString() == "Mrs")
                title = "Mrs";
            if (drPatient["Title"].ToString() == "Miss")
                title = "Miss";
            if (drPatient["Title"].ToString() == "Ms")
                title = "Ms";

            lblPat0.Text = drPatient["PatientNo"].ToString();
            lblPat1.Text = title + " " + drPatient["Forename"].ToString() + " " + drPatient["Surname"].ToString();
            lblPat2.Text = drPatient["Street"].ToString();
            lblPat3.Text = drPatient["Town"].ToString();
            lblPat4.Text = drPatient["County"].ToString();
            lblPat5.Text = drPatient["Postcode"].ToString();
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
            else
            {
                drBookings = Prog_3_Project_alpha_v0.Tables["Booking"].NewRow();

                drBookings["BookingNo"] = bookingNo;
                Bookings["PatientNo"] = int.Parse(lblPat0.Text);
                Bookings["dateBooked"] = DateTime.Parse(lblBookingDate.Text.Trim());
                Bookings["dateStart"] = DateTime.Parse(dtpStartDate.Text.Trime());

                dsProg_3_Project_alpha_v0.Tables["Booking"].Rows.Add(drBooking);
                daBooking.Update(dsProg_3_Project_alpha_v0, "Booking");

                foreach (ListViewItem item in lvwBooking.Items)
                {
                    drBookingsDets = dsProg_3_Project_alpha_v0.Tables["BookingDetail"].NewRow();
                    drBookingsDets["bookingNo"] = drBookings["bookingNo"];
                    drBookingsDets["Treatment"] = int.Parse(item.SubItems[0].Text);
                    drBookingsDets["Staff"] = int.Parse(item.SubItems[2].Text);
                    dsProg_3_Project_alpha_v0.Tables["BookingDetail"].Rows.Add(drBookingsDets);
                    drBookingsDets.Update(dsProg_3_Project_alpha_v0, "BookingDetail");

                }

                MessageBox.Show("Booking No: " + drBookings["bookingNo"].ToString() + " added to system");

                pnlBooking.Enabled = false;

            }
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
                        MessageBox.Show("Patient or Staff already selected for this booking.", "Booking");
                        exists = true;
                        break;
                    }
                }

                if (!exits)
                {
                    DateTime start = DateTime.Parse(dtpStartDate.Text.Trim());
                    foreach (DataRow dr in Prog_3_Project_alpha_v0._1.Tables["BookedStaff"].Rows)
                    {
                        DateTime bookedDate = DateTime.Parse(dr["dateStart"].ToString());

                        if (start >= bookedDate && start <= bookedDate.AddDays(int.Parse(cmbNoOfDays.Text)))
                        {
                            if ((dr["PatientNo"] == 1stPatient.SelectedValue) || (dr[].ToString() == 1stPatient.Text))
                                {
                                MessageBox.Show("Either the selected patient or staff is already included in a booking for this date range. Please re-select.", "Booking");
                                ok = false;
                            }
                            if (!ok)
                                break;
                        }
                    }
                    if (ok)
                    {
                        foreach (DataRow dr in Prog_3_Project_alpha_v0.Tables[""].Rows)
                        {
                            if (dr[""].ToString() == 1stPatient.Text)
                                    {
                                ListViewItem item = new ListViewItem(dr["patientno"].ToString());
                                item.SubItems.Add(dr[""].ToString());
                                item.SubItems.Add(1stTreatment.Text);
                                lvwBooking.Items.Add(item);
                                break;
                            }
                        }
                    }
                }
            }

        }



        private void DeletePatient_Click(object sender, EventArgs e)
        {
            if (lvwBooking.SelectedItems.Count! = 0)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
