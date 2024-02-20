using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static bool IsMdiChildFormOpen(Form mdiParent, Type childFormType)
        {
            foreach (Form form in mdiParent.MdiChildren)
            {
                if (form.GetType() == childFormType)
                {
                    return true;
                }
            }
            return false;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuSecondItem.Text.Equals("My Schedule"))
            {
                if (!IsMdiChildFormOpen(this, typeof(MyScheduleForm)))
                {
                    new MyScheduleForm
                    {
                        MdiParent = this
                    }.Show();
                }
            }
            else
            {
                if (!IsMdiChildFormOpen(this, typeof(GenerateEmployeeSchedule)))
                {
                    new GenerateEmployeeSchedule
                    {
                        MdiParent = this
                    }.Show();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Helper.UserLogin == null)
                return;

            if (Helper.UserLogin.Role.Name.Equals("User") && Helper.UserLogin.JobTitle.Level <= 5)
            {
                masterToolStripMenuItem.Visible = false;
                menuSecondItem.Text = "My Schedule";
            }
            else
            {
                toolStripMenuItem1.Visible = false;
            }
        }

        private void masterEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsMdiChildFormOpen(this, typeof(MasterEmployeeForm)))
            {
                new MasterEmployeeForm
                {
                    MdiParent = this
                }.Show();
            }
        }

        private void masterJobPositionAndJobTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsMdiChildFormOpen(this, typeof(MasterJobForm)))
            {
                new MasterJobForm
                {
                    MdiParent = this
                }.Show();
            }
        }

        private void masterCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsMdiChildFormOpen(this, typeof(MasterCountryForm)))
            {
                new MasterCountryForm
                {
                    MdiParent = this
                }.Show();
            }
        }

        private void masterCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsMdiChildFormOpen(this, typeof(MasterCityForm)))
            {
                new MasterCityForm
                {
                    MdiParent = this
                }.Show();
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            Helper.UserLogin = new User();
            new LoginForm().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!IsMdiChildFormOpen(this, typeof(MyProfileForm)))
            {
                new MyProfileForm
                {
                    MdiParent = this
                }.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}