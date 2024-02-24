using EsemkaHRSystem.Desktop.DataContext;
using EsemkaHRSystem.Desktop.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MyScheduleForm : Form
    {
        public MyScheduleForm()
        {
            InitializeComponent();
        }

        private void MyScheduleForm_Load(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.Schedules
                    .Where(x => x.UserID == Helper.UserLogin.ID)
                    .Select(x => new
                    {
                        Employee = x.User.FullName,
                        x.StartDate,
                        x.EndDate,
                        WorkLocation = x.WorkLocation.Name,
                        WorkDay = x.WorkDay.Name,
                        x
                    })
                    .ToList();

                dataGridView1.Columns["x"].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                LoadGrid2((Schedule)row.Cells["x"].Value);
            }
        }

        private void LoadGrid2(Schedule value)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var details = db.ScheduleDetails.Where(x => x.ScheduleID == value.ID).OrderBy(x => x.Date).ToList();

                flowLayoutPanel1.Controls.Clear();

                foreach (var item in details)
                {
                    flowLayoutPanel1.Controls.Add(new MyScheduleUserConrol(item));
                }
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    control.Size = new Size(flowLayoutPanel1.Width - control.Margin.Horizontal,
                                            control.Height);
                }
            }
        }
    }
}