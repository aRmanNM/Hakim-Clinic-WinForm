using Hakim.DataLayer;
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
    public partial class Login : Form
    {
        public int UserId = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                using (HakimUnitOfWork unitOfWork = new HakimUnitOfWork())
                {
                    User user = unitOfWork.Users.GetUserByName(txtUserName.Text);
                    if (user != null && user.UserPassword == txtPassword.Text)
                    {
                        UserId = user.UserId;
                        this.DialogResult = DialogResult.OK;                        
                    }
                    else
                    {
                        MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد.");
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا فیلد های مربوط را تکمیل بفرمایید.");
            }
        }
    }
}
