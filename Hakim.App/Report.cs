using Hakim.DataLayer;
using Hakim.DataLayer.Context;
using Hakim.Utilities;
using LinqKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hakim.App
{
    public partial class Report : Form
    {
        public int UserId = 0;
        public int TotalPrice = 0;                
        HakimUnitOfWork UnitOfWork = new HakimUnitOfWork();

        public Report()
        {
            InitializeComponent();
        }        

        private void Report_Load(object sender, EventArgs e)
        {
            User user = UnitOfWork.Users.GetById(UserId);
            lblCurrentUser.Text += user.UserName;
            lblTotalPrice.Text += TotalPrice;
            txtDate.Text = DateTime.Now.ToShamsi();

            cbReport.Items.Add("پذیرش");
            List <ServiceGroup> rs = UnitOfWork.ServiceGroups.Get().ToList();
            foreach (var item in rs)
            {
                cbReport.Items.Add(item.ServiceGroupTitle.ToString());
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbReport_TextChanged(object sender, EventArgs e)
        {
            if (cbReport.Text == "پذیرش")
            {
                cbFilter1.Enabled = true;
                lblFilter1.Text = "پزشک:";
                cbFilter1.DataSource = UnitOfWork.Doctors.Get();
                cbFilter1.DisplayMember = "DoctorTitle";
                cbFilter1.SelectedItem = null;

                cbFilter2.Enabled = true;
                lblFilter2.Text = "بیمه:";
                cbFilter2.DataSource = UnitOfWork.Insurances.Get();
                cbFilter2.DisplayMember = "InsuranceTitle";
                cbFilter2.SelectedItem = null;
            }
            else
            {
                lblFilter1.Text = "فیلتر یک:";                                
                cbFilter1.SelectedItem = null;
                cbFilter1.Enabled = false;

                lblFilter2.Text = "فیلتر دو:";                
                cbFilter2.SelectedItem = null;
                cbFilter2.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            dgReport.Rows.Clear();
            dgReport.Columns.Clear();            

            if (cbReport.Text == "پذیرش")
            {
                var predicate = PredicateBuilder.New<VisitReception>();

                if (txtDate.Text != "" && txtDate.MaskCompleted == true)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime dt = DateTime.ParseExact(txtDate.Text, "yyyy/MM/dd", provider);
                    dt = ShamsiDate.ToMiladi(dt);

                    predicate.And(i => i.Date.Day == dt.Day && i.Date.Month == dt.Month && i.Date.Year == dt.Year);
                }

                if (cbFilter1.Text != "")
                {
                    predicate.And(i => i.Doctor.DoctorTitle == cbFilter1.Text);
                }

                if (cbFilter2.Text != "")
                {
                    predicate.And(i => i.Insurance.InsuranceTitle == cbFilter2.Text);
                }

                List<VisitReception> visitReceptions = new List<VisitReception>();
                visitReceptions = UnitOfWork.VisitReceptions.GetWithPredicate(predicate).ToList();

                dgReport.AutoGenerateColumns = false;

                dgReport.Columns.Add("VisitReceptionId", "شماره");
                dgReport.Columns.Add("DoctorTitle", "پزشک");
                dgReport.Columns.Add("InsuranceTitle", "بیمه");
                dgReport.Columns.Add("Price", "مبلغ");

                foreach (var item in visitReceptions)
                {
                    dgReport.Rows.Add(item.VisitReceptionId, item.Doctor.DoctorTitle,
                        item.Insurance.InsuranceTitle, item.Price);
                }
            }
            else
            {
                var predicate = PredicateBuilder.New<ServiceReception>();

                if (txtDate.Text != "" && txtDate.MaskCompleted == true)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime dt = DateTime.ParseExact(txtDate.Text, "yyyy/MM/dd", provider);
                    dt = ShamsiDate.ToMiladi(dt);

                    predicate.And(i => i.Date.Day == dt.Day && i.Date.Month == dt.Month && i.Date.Year == dt.Year);
                }

                predicate.And(i => i.ServiceGroup.ServiceGroupTitle == cbReport.Text);
                
                List<ServiceReception> serviceReceptions = new List<ServiceReception>();
                serviceReceptions = UnitOfWork.ServiceReceptions.Get(predicate).ToList();

                dgReport.AutoGenerateColumns = false;

                dgReport.Columns.Add("ServiceReceptionId", "شماره");
                dgReport.Columns.Add("ServiceTitle", "خدمت");                
                dgReport.Columns.Add("Price", "مبلغ");

                foreach (var item in serviceReceptions)
                {
                    dgReport.Rows.Add(item.ServiceReceptionId, item.Service.ServiceTitle,item.Price);
                }
            }
            
            TotalPrice = 0;
            foreach (DataGridViewRow item in dgReport.Rows)
            {
                TotalPrice += int.Parse(item.Cells["Price"].Value.ToString());
            }            
            lblTotalPrice.Text = "مجموع:  " + TotalPrice.ToString("#,0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgReport.Rows.Clear();
            dgReport.Columns.Clear();

            cbFilter1.SelectedItem = null;
            cbFilter2.SelectedItem = null;
            cbReport.SelectedItem = null;

            txtDate.Text = DateTime.Now.ToShamsi();

            lblTotalPrice.Text = "مجموع:  " + 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
