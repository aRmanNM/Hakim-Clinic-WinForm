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
    public partial class ChangePassword : Form
    {
        public int UserId = 0;
        public User user;
        HakimUnitOfWork UnitOfWork = new HakimUnitOfWork();

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Enabled = false;

            user = UnitOfWork.Users.GetById(UserId);
            txtUserName.Text = user.UserName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text == user.UserPassword &&
                txtNewPassword.Text != "" &&
                txtNewPassword.Text == txtNewPasswordRepeated.Text)
            {
                try
                {
                    user.UserPassword = txtNewPassword.Text;
                    UnitOfWork.Users.Update(user);
                    UnitOfWork.Save();
                    UnitOfWork.Dispose();
                    MessageBox.Show("رمز عبور جدید با موفقیت ذخیره شد.");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    MessageBox.Show("عملیات با خطا مواجه شد.");
                }                                
            }
            else
            {
                MessageBox.Show("فیلدها به درستی تکمیل نشده اند.");
            }
        }
    }
}
