using EsemkaHRSystem.Desktop.DataContext;
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
    public partial class MasterJobForm : Form
    {
        private JobTitle SelectedJobTitle = new JobTitle();
        private JobPosition SelectedJobPosition = new JobPosition();

        private List<JobTitle> JobTitles = new List<JobTitle>();

        public MasterJobForm()
        {
            InitializeComponent();
        }

        private void MasterJobForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = null;

                JobTitles = db.JobTitles.ToList();

                var jobPositions = db.JobPositions.ToList();

                dataGridView1.DataSource = jobPositions.Select(x => new
                {
                    x.ID,
                    x.Name,
                    x
                }).ToList(); ;

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["x"].Visible = false;

                SelectedJobPosition = jobPositions.FirstOrDefault();

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = JobTitles.Where(x => x.PositionID == SelectedJobPosition.ID)
                    .Select(x => new
                    {
                        x.ID,
                        x.Name,
                        x.Level,
                        JobPosition = x.JobPosition.Name,
                        x
                    }).ToList();

                try
                {
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView2.Columns["x"].Visible = false;
                    dataGridView2.Columns[1].DisplayIndex = dataGridView2.ColumnCount - 1;
                    dataGridView2.Columns[0].DisplayIndex = dataGridView2.ColumnCount - 2;
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedJobTitle = new JobTitle();
            SelectedJobPosition = new JobPosition();
            groupBox3.ClearField();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    SelectedJobPosition = row.Cells["x"].Value as JobPosition;

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = JobTitles.Where(x => x.PositionID == SelectedJobPosition.ID)
                        .Select(x => new
                        {
                            x.ID,
                            x.Name,
                            x.Level,
                            JobPosition = x.JobPosition.Name,
                            x
                        }).ToList();
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView2.Columns["x"].Visible = false;
                    dataGridView2.Columns[1].DisplayIndex = dataGridView2.ColumnCount - 1;
                    dataGridView2.Columns[0].DisplayIndex = dataGridView2.ColumnCount - 2;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                    if (e.ColumnIndex == 0)
                    {
                        SelectedJobTitle = row.Cells["x"].Value as JobTitle;
                        tbName.Text = SelectedJobTitle.Name;
                        numericUpDown1.Value = SelectedJobTitle.Level;
                    }

                    if (e.ColumnIndex == 1)
                    {
                        SelectedJobTitle = row.Cells["x"].Value as JobTitle;
                        if (MessageBox.Show("Are you sure want to delete this row?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (DataClasses1DataContext db = new DataClasses1DataContext())
                            {
                                db.JobTitles.DeleteOnSubmit(db.JobTitles.FirstOrDefault(x => x.ID == SelectedJobTitle.ID));
                                db.SubmitChanges();

                                SelectedJobTitle = new JobTitle();

                                groupBox3.ClearField();

                                "Deleted Successfully".ShowInformationMessage();

                                LoadData();
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error when deleted the data. \n" + ee.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox3.CheckIsEmpty())
            {
                "Please insert the Name and Level field".ShowInformationMessage();
                return;
            }

            if (SelectedJobPosition.ID == 0)
            {
                "Please select the Job Position".ShowInformationMessage();
                return;
            }

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (SelectedJobTitle.ID == 0)
                {
                    var existingName = db.JobTitles.FirstOrDefault(x => x.Name == tbName.Text);
                    if (existingName != null)
                    {
                        "Name already exist".ShowInformationMessage();
                        return;
                    }

                    db.JobTitles.InsertOnSubmit(new JobTitle
                    {
                        Name = tbName.Text,
                        Level = numericUpDown1.Value.ToInt32(),
                        PositionID = SelectedJobPosition.ID
                    });
                }
                else
                {
                    var existingName = db.JobTitles.FirstOrDefault(x => x.Name == tbName.Text && x.ID != SelectedJobTitle.ID);
                    if (existingName != null)
                    {
                        "Name already exist".ShowInformationMessage();
                        return;
                    }

                    existingName = db.JobTitles.FirstOrDefault(x => x.ID == SelectedJobTitle.ID);
                    existingName.ID = SelectedJobTitle.ID;
                    existingName.Name = tbName.Text;
                    existingName.Level = numericUpDown1.Value.ToInt32();
                }

                db.SubmitChanges();

                "Saved Successfully".ShowInformationMessage();

                groupBox3.ClearField();

                LoadData();
            }
        }
    }
}