using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Drawing.Text;

namespace Prog_3_Project_alpha_v0._1
{
    public partial class StaffForm : Form
    {
        SqlDataAdapter daCustomer;
        DataSet dsInTheDogHouse = new DataSet();
        SqlCommandBuilder cmdBCustomer;
        DataRow drCustomer;
        String connStr, sqlCustomer;
        int selectedTab = 0;
        bool custSelected = false;
        int custNoSelected = 0;

        public StaffForm()
        {
            InitializeComponent();
        }
        private void StaffForm_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .;Initial Catalog = InTheDogHouse;Integrated Security = true";

            sqlCustomer = @"select * from Customer";
            daCustomer = new SqlDataAdapter(sqlCustomer, connStr);
            cmdBCustomer = new SqlCommandBuilder(daCustomer);
            daCustomer.FillSchema(dsInTheDogHouse, SchemaType.Source, "Customer");
            daCustomer.Fill(dsInTheDogHouse, "Customer");

            DGV1.DataSource = dsInTheDogHouse.Tables["Customer"];

            //dgv resizeing
            DGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            TabCon.SelectedIndex = 1;
            TabCon.SelectedIndex = 0;
        }
        private void btn_AddAdd_Click(object sender, EventArgs e)
        {
            StaffId StaffID = new StaffId();
            bool ok = true;
            errP.Clear();

            try
            {
                StaffID.StaffID = Convert.ToInt32(lbl_AddStaffIDChange.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lbl_AddStaffIDChange, MyEx.toString());
            }

            try
            {
                StaffID.Surname = txt_AddSurname.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddSurname, MyEx.toString());
            }

            try
            {
                StaffID.Forename = txt_AddForename.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddForename, MyEx.toString());
            }

            try
            {
                StaffID.Street = txt_AddStreet.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddStreet, MyEx.toString());
            }

            try
            {
                StaffID.Town = txt_AddTown.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddTown, MyEx.toString());
            }

            try
            {
                StaffID.County = txt_AddCounty.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddCounty, MyEx.toString());
            }

            try
            {
                StaffID.Postcode = txt_AddPostcode.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddPostcode, MyEx.toString());
            }

            try
            {
                StaffID.TelNo = txt_AddTelephone.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txt_AddTelephone, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drCustomer = dsInTheDogHouse.Tables["Customer"].NewRow();
                    drCustomer["StaffID"] = StaffID.StaffID;
                    drCustomer["Forename"] = StaffID.Forename;
                    drCustomer["Surname"] = StaffID.Surname;
                    drCustomer["Street"] = StaffID.Street;
                    drCustomer["Town"] = StaffID.Town;
                    drCustomer["County"] = StaffID.County;
                    drCustomer["Postcode"] = StaffID.Postcode;
                    drCustomer["TelNo"] = StaffID.TelNo;

                    dsInTheDogHouse.Tables["Customer"].Rows.Add(drCustomer);
                    daCustomer.Update(dsInTheDogHouse, "Customer");

                    MessageBox.Show("Customer Added");

                    if (MessageBox.Show("Do you wish to add another customer?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsInTheDogHouse.Tables["Customer"].Rows.Count);
                    }
                    else
                    {
                        TabCon.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        void clearAddForm()
        {
            txt_AddForename.Clear();
            txt_AddSurname.Clear();
            txt_AddStreet.Clear();
            txt_AddTown.Clear();
            txt_AddCounty.Clear();
            txt_AddPostcode.Clear();
            txt_AddTelephone.Clear();
        }
        private void getNumber(int noRows)
        {
            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows[noRows - 1];
            lbl_AddStaffIDChange.Text = (int.Parse(drCustomer["StaffID"].ToString()) + 1).ToString();
        }
        private void TabCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = TabCon.SelectedIndex;

            TabCon.TabPages[TabCon.SelectedIndex].Focus();
            TabCon.TabPages[TabCon.SelectedIndex].CausesValidation = true;

            switch (TabCon.SelectedIndex)
            {
                case 0://Display tab selected
                    {
                        dsInTheDogHouse.Tables["Customer"].Clear();
                        daCustomer.Fill(dsInTheDogHouse, "Customer");

                        break;
                    }
                case 1://add tab selected
                    {
                        int noRows = dsInTheDogHouse.Tables["Customer"].Rows.Count;
                        if (noRows == 0)
                        {
                            lbl_AddStaffIDChange.Text = "10000";
                        }
                        else
                        {
                            getNumber(noRows);
                        }
                        errP.Clear();
                        clearAddForm();
                        break;
                    }
                case 2://Edit tab selected
                    {
                        if (custNoSelected == 0)
                        {
                            TabCon.SelectedIndex = 0;
                            break;
                        }
                        else
                        {
                            lbl_EditStaffIDChange.Text = custNoSelected.ToString();
                            drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(lbl_EditStaffIDChange.Text);

                            Txt_EditForename.Text = drCustomer["Forename"].ToString();
                            txt_EditSurname.Text = drCustomer["Surname"].ToString();
                            txt_EditStreet.Text = drCustomer["Street"].ToString();
                            txt_EditTown.Text = drCustomer["Town"].ToString();
                            txt_EditCounty.Text = drCustomer["County"].ToString();
                            txt_EditPostcode.Text = drCustomer["Postcode"].ToString();
                            txt_EditTelphone.Text = drCustomer["TelNo"].ToString();

                            break;
                        }
                    }
            }
        }

        void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (DGV1.SelectedRows.Count == 0)
            {
                custSelected = false;
                custNoSelected = 0;
            }
            else if (DGV1.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected = Convert.ToInt32(DGV1.SelectedRows[0].Cells[0].Value);
            }
        }
        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (custSelected == false && custNoSelected == 0)
            {
                TabCon.SelectedIndex = 0;
                MessageBox.Show("PLease select a customer to edit");
                custSelected = false;
                custNoSelected = 0;
            }
            else if (DGV1.SelectedRows.Count == 1)
            {
                custSelected = true;
                custNoSelected = Convert.ToInt32(DGV1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            TabCon.TabPages[0].CausesValidation = true;
            TabCon.TabPages[0].Validating += new CancelEventHandler(AddTabValidate);

            TabCon.TabPages[2].CausesValidation = true;
            TabCon.TabPages[2].Validating += new CancelEventHandler(EditTabValidate);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (lbl_EditEdit.Text == "Edit")
            {
                Txt_EditForename.Enabled = true;
                txt_AddSurname.Enabled = true;
                txt_EditStreet.Enabled = true;
                txt_EditTown.Enabled = true;
                txt_EditCounty.Enabled = true;
                txt_EditPostcode.Enabled = true;
                txt_EditTelphone.Enabled = true;

                lbl_EditEdit.Text = "Save";
            }
            else
            {
                StaffId StaffID = new StaffId();
                bool ok = true;
                errP.Clear();
                try
                {
                    StaffID.StaffID = Convert.ToInt32(lbl_EditStaffIDChange.Text.Trim());//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lbl_EditStaffIDChange, MyEx.toString());
                }
                try
                {
                    StaffID.Title = cbx_EditTitle.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cbx_EditTitle, MyEx.toString());
                }
                try
                {
                    StaffID.Surname = txt_EditSurname.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditSurname, MyEx.toString());
                }
                try
                {
                    StaffID.Forename = Txt_EditForename.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(Txt_EditForename, MyEx.toString());
                }
                try
                {
                    StaffID.Street = txt_EditStreet.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditStreet, MyEx.toString());
                }
                try
                {
                    StaffID.Town = txt_EditTown.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditTown, MyEx.toString());
                }
                try
                {
                    StaffID.County = txt_EditCounty.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditCounty, MyEx.toString());
                }
                try
                {
                    StaffID.Postcode = txt_EditPostcode.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditPostcode, MyEx.toString());
                }
                try
                {
                    StaffID.TelNo = txt_EditTelphone.Text.Trim();//passd to Customer class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txt_EditTelphone, MyEx.toString());
                }
                try
                {
                    if (ok)
                    {
                        drCustomer.BeginEdit();

                        drCustomer["StaffID"] = StaffID.StaffID;
                        drCustomer["Forename"] = StaffID.Forename;
                        drCustomer["Surname"] = StaffID.Surname;
                        drCustomer["Street"] = StaffID.Street;
                        drCustomer["Town"] = StaffID.Town;
                        drCustomer["County"] = StaffID.County;
                        drCustomer["Postcode"] = StaffID.Postcode;
                        drCustomer["TelNo"] = StaffID.TelNo;

                        drCustomer.EndEdit();
                        daCustomer.Update(dsInTheDogHouse, "Customer");

                        MessageBox.Show("Staff Details Updated", "Customer");

                        Txt_EditForename.Enabled = false;
                        txt_EditSurname.Enabled = false;
                        txt_EditStreet.Enabled = false;
                        txt_AddTown.Enabled = false;
                        txt_EditCounty.Enabled = false;
                        txt_EditPostcode.Enabled = false;
                        txt_EditTelphone.Enabled = false;
                        lbl_EditEdit.Text = "Edit";
                        TabCon.SelectedIndex = 0;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("" + Ex.TargetSite + "" + Ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Display_Delete_Click(object sender, EventArgs e)
        {
            //if(lstCustomers.SelectedIndices.Count ==0)
            if (DGV1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Staff member from the list.", "Select Staff");
            }
            else
            {
                drCustomer = dsInTheDogHouse.Tables["Customer"].Rows.Find(DGV1.SelectedRows[0].Cells[0].Value);

                string tempName = drCustomer["Forename"].ToString() + " " + drCustomer["Surname"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + " details?", "AddCustomer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drCustomer.Delete();
                    daCustomer.Update(dsInTheDogHouse, "Customer");
                }
            }
        }
        private void btn_AddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition od Customer No: " + lbl_AddStaffIDChange.Text + "?", "Add Customer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                TabCon.SelectedIndex = 0;
            }
        }
        private void btn_Display_Add_Click(object sender, EventArgs e)
        {
            TabCon.SelectedIndex = 1;
        }

        private void btn_Display_Edit_Click(object sender, EventArgs e)
        {
            TabCon.SelectedIndex = 2;
        }

        private void btn_EditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Staff ID: " + lbl_EditStaffIDChange.Text + "?", "Edit Staff", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                TabCon.SelectedIndex = 0;
            }
        }
    }
}
