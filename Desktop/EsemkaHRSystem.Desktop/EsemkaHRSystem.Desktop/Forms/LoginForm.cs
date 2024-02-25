using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new RegisterForm().ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (string.IsNullOrWhiteSpace(tbUsrname.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    "Please insert Username & Password!".ShowInformationMessage();
                    return;
                }

                var user = db.Users.FirstOrDefault(x => (x.Username == tbUsrname.Text || x.Email == tbUsrname.Text) && x.Password == Helper.GetSHA256Hash(tbPassword.Text));
                if (user == null)
                {
                    "Please correct the error and try again".ShowInformationMessage();
                    return;
                }

                if (user.JoinDate.Date > DateTime.Now.Date)
                {
                    $"Your account is not yet active. Your account will be activated on {user.JoinDate.Date:dd MMM yyyy}. Please wait until then to log in".ShowInformationMessage();
                    return;
                }

                if (!user.Active)
                {
                    "Your account is not active. For more information, please contact the Admin or the HR".ShowInformationMessage();
                    return;
                }

                Helper.UserLogin = user;

                Hide();
                new MainForm().ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbUsrname.Text = "admin";
            tbPassword.Text = "123";
        }
    }
}