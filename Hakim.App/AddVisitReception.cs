using Hakim.DataLayer;
using Hakim.DataLayer.Context;
using Hakim.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hakim.App
{
    public partial class AddVisitReception : Form
    {
        public int UserId = 0;
        Insurance insurance;
        HakimUnitOfWork UnitOfWork = new HakimUnitOfWork();

        public AddVisitReception()
        {
            InitializeComponent();
        }

        private void AddVisitReception_Load(object sender, EventArgs e)
        {
            cbInsurance.DataSource = UnitOfWork.Insurances.Get();
            cbInsurance.DisplayMember = "InsuranceTitle";
            cbInsurance.ValueMember = "InsuranceId";

            cbDoctor.DataSource = UnitOfWork.Doctors.Get();
            cbDoctor.DisplayMember = "DoctorTitle";
            cbDoctor.ValueMember = "DoctorId";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbInsurance_TextChanged(object sender, EventArgs e)
        {
            insurance = (Insurance)cbInsurance.SelectedItem;
            txtPrice.Text = UnitOfWork.Insurances.GetById(insurance.InsuranceId).InsurancePrice.ToString("#,0");
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            // MY WEIRD DIGIT SEPERATION SYSTEM
            // IT SEEMS TO WORK
            double valueBefore;
            if (!string.IsNullOrEmpty(txtPrice.Text) && double.TryParse(txtPrice.Text, out valueBefore) == true)
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                valueBefore = double.Parse(txtPrice.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPrice.Text = String.Format(culture, "{0:N0}", valueBefore);
                txtPrice.Select(txtPrice.Text.Length, 0);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFamily.Text != "" &&
                txtPhone.Text != "" &&
                cbInsurance.Text != "" &&
                cbDoctor.Text != "" &&
                txtPrice.Text != "")
            {
                try
                {
                    VisitReception visitReception = new VisitReception()
                    {
                        FirstName = txtName.Text,
                        LastName = txtFamily.Text,
                        PhoneNumber = txtPhone.Text,
                        Price = int.Parse(txtPrice.Text, System.Globalization.NumberStyles.AllowThousands),
                        Date = DateTime.Now,
                        UserId = this.UserId,
                        InsuranceId = insurance.InsuranceId,
                        DoctorId = ((Doctor)(cbDoctor.SelectedItem)).DoctorId
                    };
                    UnitOfWork.VisitReceptions.Insert(visitReception);
                    printRecipt.Print();
                    UnitOfWork.Save();                    
                    UnitOfWork.Dispose();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    MessageBox.Show("امکان ثبت این رکورد وجود ندارد.");
                }


            }
            else
            {
                MessageBox.Show("لطفا فیلدها را به شکل صحیح پر کنید");
            }
        }

        private void printRecipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Print printRecipt = new Print();
            printRecipt.PrintRecipt(e, txtFamily.Text, DateTime.Now,
                int.Parse(txtPrice.Text, System.Globalization.NumberStyles.AllowThousands),
                "بیمه", cbInsurance.Text, "پزشک", cbDoctor.Text);
        }
    }
}
