using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MyScheduleForm
            {
                MdiParent = this
            }.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            masterToolStripMenuItem.Visible = false;
            menuSecondItem.Text = "My Schedule";
        }

        private void masterEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterEmployeeForm
            {
                MdiParent = this
            }.Show();
        }

        private void masterJobPositionAndJobTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterJobPositionAndJobTitleForm
            {
                MdiParent = this
            }.Show();
        }

        private void masterCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterCountryForm
            {
                MdiParent = this
            }.Show();
        }

        private void masterCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MasterCityForm
            {
                MdiParent = this
            }.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new MyProfileForm
            {
                MdiParent = this
            }.Show();
        }
    }
}