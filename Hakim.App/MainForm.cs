using Hakim.DataLayer.Context;
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
    public partial class MainForm : Form
    {
        public int UserId = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        public void LoginProcess()
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();

            if (loginForm.DialogResult == DialogResult.OK)
            {
                this.Show();
                this.UserId = loginForm.UserId;
                loginForm.Dispose();
                using (HakimUnitOfWork unitOfWork = new HakimUnitOfWork())
                {
                    lblCurrentUser.Text = "کاربر سیستم: " + 
                        unitOfWork.Users.GetById(this.UserId).UserName;
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePasswordForm = new ChangePassword();
            changePasswordForm.UserId = this.UserId;
            changePasswordForm.ShowDialog();

            if (changePasswordForm.DialogResult == DialogResult.OK)
            {
                this.Show();
                changePasswordForm.Dispose();
            }
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reception receptionForm = new Reception();
            receptionForm.UserId = this.UserId;
            receptionForm.ShowDialog();
            if (receptionForm.DialogResult == DialogResult.OK)
            {
                this.Show();
                receptionForm.Dispose();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report reportForm = new Report();
            reportForm.UserId = this.UserId;
            reportForm.ShowDialog();
            if (reportForm.DialogResult == DialogResult.OK)
            {
                this.Show();
                reportForm.Dispose();
            }
        }
    }
}
