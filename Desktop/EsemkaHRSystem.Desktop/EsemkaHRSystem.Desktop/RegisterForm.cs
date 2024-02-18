using System;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            dateTimePickerDateOfBirth.MaxDate = DateTime.Now;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().ShowDialog();
        }
    }
}