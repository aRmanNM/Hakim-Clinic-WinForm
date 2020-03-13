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
    public partial class AddServiceReception : Form
    {
        public int UserId = 0;
        Service service;
        HakimUnitOfWork UnitOfWork = new HakimUnitOfWork();

        public AddServiceReception()
        {
            InitializeComponent();
        }

        private void AddServiceReception_Load(object sender, EventArgs e)
        {
            cbService.DataSource = UnitOfWork.Services.Get();
            cbService.DisplayMember = "ServiceTitle";
            cbService.ValueMember = "ServiceId";
            // cbService.SelectedItem = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbService_TextChanged(object sender, EventArgs e)
        {
            service = (Service)cbService.SelectedItem;
            txtPrice.Text = UnitOfWork.Services.GetById(service.ServiceId).ServicePrice.ToString("#,0");
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
                cbService.Text != "" &&
                txtPrice.Text != "")
            {
                //try
                //{
                    ServiceReception serviceReception = new ServiceReception()
                    {
                        FirstName = txtName.Text,
                        LastName = txtFamily.Text,
                        PhoneNumber = txtPhone.Text,
                        Price = int.Parse(txtPrice.Text, System.Globalization.NumberStyles.AllowThousands),
                        Date = DateTime.Now,
                        UserId = this.UserId,
                        ServiceId = service.ServiceId,
                        ServiceGroupId = service.ServiceGroupId
                    };
                    UnitOfWork.ServiceReceptions.Insert(serviceReception);
                    printRecipt.Print();
                    UnitOfWork.Save();                    
                    UnitOfWork.Dispose();
                    this.DialogResult = DialogResult.OK;
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("امکان ثبت این رکورد وجود ندارد.");
                //}
                

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
                "خدمت:", cbService.Text);
        }
    }
}
