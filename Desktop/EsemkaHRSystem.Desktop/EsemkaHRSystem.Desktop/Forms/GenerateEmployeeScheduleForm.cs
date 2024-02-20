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
            dtStartDate.MinDate = DateTime.Now;
            dtEndDate.MinDate = DateTime.Now;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                cbUser.DataSource = db.Users.Where(x => x.JobTitle.Level <= 5 && x.Role.Name == "User" && x.Active && x.JoinDate.Date >= DateTime.Now.Date).ToList();
                cbWorkLocation.DataSource = db.WorkLocations.ToList();
                cbStartTime.DataSource = db.Times.ToList();
                cbEndTime.DataSource = db.Times.ToList();
                cbBreakTime.DataSource = db.Times.ToList();
                cbWorkDay.DataSource = db.WorkDays.ToList();
            }

            LoadGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (groupBox2.CheckIsEmpty())
                {
                    "Field can't be Empty".ShowInformationMessage();
                    return;
                }

                var schedule = new Schedule
                {
                    UserID = int.Parse(cbUser.SelectedValue.ToString()),
                    StartDate = dtStartDate.Value,
                    EndDate = dtEndDate.Value,
                    WorkDayID = int.Parse(cbWorkDay.SelectedValue.ToString()),
                    WorkLocationID = int.Parse(cbWorkLocation.SelectedValue.ToString())
                };

                db.Schedules.InsertOnSubmit(schedule);
                db.SubmitChanges();

                var fullDay = new List<string>()
                {
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday",
                    "Saturday",
                    "Sunday"
                };

                var weekend = new List<string>()
                {
                    "Saturday",
                    "Sunday"
                };

                var workDay = new List<string>()
                {
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday",
                };

                for (DateTime date = dtStartDate.Value.Date; date <= dtEndDate.Value.Date; date = date.Date.AddDays(1))
                {
                    if (cbWorkDay.Text.Contains("Fullday"))
                    {
                        if (fullDay.Contains(date.DayOfWeek.ToString()))
                        {
                            db.ScheduleDetails.InsertOnSubmit(new ScheduleDetail
                            {
                                Date = date,
                                ScheduleID = schedule.ID,
                                StartTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                EndTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakDuration = tbBreakTime.Text.ToInt32(),
                            });
                        }
                        continue;
                    }

                    if (cbWorkDay.Text.Contains("Weekend"))
                    {
                        if (weekend.Contains(date.DayOfWeek.ToString()))
                        {
                            db.ScheduleDetails.InsertOnSubmit(new ScheduleDetail
                            {
                                Date = date,
                                ScheduleID = schedule.ID,
                                StartTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                EndTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakDuration = tbBreakTime.Text.ToInt32(),
                            });
                        }
                        continue;
                    }

                    if (cbWorkDay.Text.Contains("Workday"))
                    {
                        if (workDay.Contains(date.DayOfWeek.ToString()))
                        {
                            db.ScheduleDetails.InsertOnSubmit(new ScheduleDetail
                            {
                                Date = date,
                                ScheduleID = schedule.ID,
                                StartTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                EndTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                                BreakDuration = tbBreakTime.Text.ToInt32(),
                            });
                        }
                        continue;
                    }

                    if (date.DayOfWeek.ToString() == cbWorkDay.Text)
                    {
                        db.ScheduleDetails.InsertOnSubmit(new ScheduleDetail
                        {
                            Date = date,
                            ScheduleID = schedule.ID,
                            StartTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                            BreakTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                            EndTimeId = int.Parse(cbStartTime.SelectedValue.ToString()),
                            BreakDuration = tbBreakTime.Text.ToInt32(),
                        });
                    }
                }
                db.SubmitChanges();

                groupBox2.ClearField();

                "Successfully".ShowInformationMessage();

                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = db.Schedules
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
                dataGridView1.Columns[0].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                LoadGrid2(((Schedule)row.Cells["x"].Value).ID);

                if (e.ColumnIndex == 0)
                {
                    var schedule = row.Cells["x"].Value as Schedule;
                    if (MessageBox.Show("Are you sure want to delete this row?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DataClasses1DataContext db = new DataClasses1DataContext())
                        {
                            db.Schedules.DeleteOnSubmit(db.Schedules.FirstOrDefault(x => x.ID == schedule.ID));
                            db.ScheduleDetails.DeleteAllOnSubmit(db.ScheduleDetails.Where(x => x.ScheduleID == schedule.ID));

                            db.SubmitChanges();

                            "Deleted Successfully".ShowInformationMessage();

                            groupBox2.ClearField();

                            LoadGrid();
                        }
                    }
                }
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
                        x.Date,
                        StartTime = x.Time.TimeValue,
                        EndTime = x.Time1.TimeValue,
                        BreakTime = x.Time2.TimeValue,
                        x.BreakDuration
                    })
                    .ToList();

                dataGridView2.Columns["BreakDuration"].HeaderText = "Break Duration (Minutes)";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void tbBreakTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeypressGlobal();
        }

        private void S(object sender, EventArgs e)
        {
        }
    }
}