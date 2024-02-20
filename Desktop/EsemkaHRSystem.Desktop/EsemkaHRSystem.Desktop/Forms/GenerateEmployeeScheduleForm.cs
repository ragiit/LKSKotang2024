using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class GenerateEmployeeSchedule : Form
    {
        public GenerateEmployeeSchedule()
        {
            InitializeComponent();
        }

        private void GenerateEmployeeSchedule_Load(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db  = new DataClasses1DataContext())
            {
                cbUser.DataSource = db.Users.Where(x => x.JobTitle.Level <= 5 && x.Role.Name == "User").ToList();
                cbWorkLocation.DataSource = db.WorkLocations.ToList();
                cbStartTime.DataSource = db.WorkDays.ToList();
                cbEndTime.DataSource = db.WorkDays.ToList();
                cbBreakTime.DataSource = db.WorkDays.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var schedule = new Schedule
                {
                    UserID = int.Parse(cbUser.SelectedValue.ToString()),
                    StartDate = dtStartDate.Value,
                    EndDate = dtStartDate.Value,
                    WorkDayID = int.Parse(cbStartTime.SelectedValue.ToString()),
                    WorkLocationID = int.Parse(cbWorkLocation.SelectedValue.ToString())
                };

                db.Schedules.InsertOnSubmit(schedule);
                db.SubmitChanges();

                for (DateTime date = dtStartDate.Value.Date; date <= dtEndDate.Value.Date; date = date.Date.AddDays(1))
                {
                    db.ScheduleDetails.InsertOnSubmit(new ScheduleDetail
                    {
                        ScheduleID = schedule.ID,
                        StartTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                        BreakTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                        EndTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                        BreakDuration = tbBreakTime.Text.ToInt32(),
                    });
                }
                db.SubmitChanges();

                groupBox2.ClearField();

                "Successfully".ShowInformationMessage();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.Schedules
                    .Where(x => x.UserID == int.Parse(cbUser.SelectedValue.ToString()))
                    .Select(x => new
                    {
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                LoadGrid2(((Schedule)row.Cells["x"].Value).ID);
            }
        }

        private void LoadGrid2(int Id)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            { 
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = db.ScheduleDetails
                    .Where(x => x.ScheduleID == Id)
                    .Select(x => new
                    {
                        StartTime = x.Time.TimeValue,
                        EndTime = x.Time1.TimeValue,
                        BreakTime = x.Time2.TimeValue,
                        x.BreakDuration
                    })
                    .ToList();

                dataGridView1.Columns["x"].Visible = false;
            }
        }
    }
}
