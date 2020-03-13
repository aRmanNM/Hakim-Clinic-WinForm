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
    public partial class Reception : Form
    {
        public int UserId = 0;
        public DateTime dt = DateTime.Now;
        public User user;
        HakimUnitOfWork unitOfWork = new HakimUnitOfWork();


        public Reception()
        {
            InitializeComponent();
        }

        private void Reception_Load(object sender, EventArgs e)
        {
            dgService.AutoGenerateColumns = false;            
            dgVisit.AutoGenerateColumns = false;

            RefreshGrids();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void RefreshGrids()
        {
            List<ServiceReception> serviceRecepetions = new List<ServiceReception>();
            List<VisitReception> visitRecepetions = new List<VisitReception>();

            user = unitOfWork.Users.GetById(UserId);
            lblCurrentUser.Text = "کاربر سیستم: " + user.UserName;
            lblDate.Text = dt.ToShamsi();
            
            // REGENERATE SERVICES
            dgService.Rows.Clear();
            serviceRecepetions.AddRange(unitOfWork.ServiceReceptions.Get(n => n.UserId == UserId &&
                    n.Date.Day == dt.Day && n.Date.Month == dt.Month && n.Date.Year == dt.Year));            
            foreach (var item in serviceRecepetions)
            {
                dgService.Rows.Add(item.ServiceReceptionId, item.FirstName, item.LastName,
                                   item.PhoneNumber, item.Service.ServiceTitle,
                                   item.Date.ToShamsi(), item.Price.ToString("#,0"));
            }

            // REGENERATE VISITS
            dgVisit.Rows.Clear();
            visitRecepetions.AddRange(unitOfWork.VisitReceptions.Get(n => n.UserId == UserId &&
                   n.Date.Day == dt.Day && n.Date.Month == dt.Month && n.Date.Year == dt.Year));
            foreach (var item in visitRecepetions)
            {
                dgVisit.Rows.Add(item.VisitReceptionId, item.FirstName, item.LastName,
                                 item.PhoneNumber, item.Date.ToShamsi(), item.Insurance.InsuranceTitle,
                                 item.Doctor.DoctorTitle, item.Price.ToString("#,0"));
            }



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            if (tabReception.SelectedTab == tabService)
            {
                AddServiceReception addServiceReceptionForm = new AddServiceReception();
                addServiceReceptionForm.UserId = this.UserId;
                addServiceReceptionForm.ShowDialog();
                if (addServiceReceptionForm.DialogResult == DialogResult.OK)
                {
                    RefreshGrids();
                }
            }
            if (tabReception.SelectedTab == tabVisit)
            {
                AddVisitReception addVisitReceptionForm = new AddVisitReception();
                addVisitReceptionForm.UserId = this.UserId;
                addVisitReceptionForm.ShowDialog();
                if (addVisitReceptionForm.DialogResult == DialogResult.OK)
                {
                    RefreshGrids();
                }
            }
        }
    }
}
