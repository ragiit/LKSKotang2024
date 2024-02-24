using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MasterEmployeeForm : Form
    {
        private User SelectedUser = new User();
        private List<EmployeeStatuse> EmployeeStatuses = new List<EmployeeStatuse>();
        private List<Department> Departments = new List<Department>();

        public MasterEmployeeForm()
        {
            InitializeComponent();
        }

        //using (DataClasses1DataContext db = new DataClasses1DataContext())
        //    {
        //    }
        private void tbIdCardNumber_TextChanged(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                LoadData();
            }
        }

        private void MasterEmployeeForm_Load(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                EmployeeStatuses = db.EmployeeStatuses.ToList();
                Departments = db.Departments.ToList();

                cbEmployeeStatus.ValueMember = "Id";
                cbEmployeeStatus.DisplayMember = "Name";
                cbDepartment.ValueMember = "Id";
                cbDepartment.DisplayMember = "Name";

                cbEmployeeStatus.DataSource = EmployeeStatuses;
                cbDepartment.DataSource = Departments;
            }

            LoadData();
        }

        private void LoadData()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = db.Users
                    .Where(x => x.Role.Name.Equals("User") && x.JobTitle.Level <= 5 && x.FullName.Contains(tbSearch.Text))
                    .Select(x => new
                    {
                        x.ID,
                        x.FullName,
                        Status = x.EmployeeStatuse.Name,
                        Department = x.Department.Name,
                        JobTitle = x.JobTitle.Name,
                        JoinDate = x.JoinDate,
                        RegistrationDate = x.JoinDate,
                        StartDate = x.JoinDate,
                        EndDate = x.JoinDate,
                        Salary = x.SALARY,
                        x.Active,
                        Photo = Helper.PathBaseUrlImage + x.Photo,
                        x,
                    }).ToList();

                dataGridView1.Columns["JoinDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dataGridView1.Columns["Photo"].Visible = false;
                dataGridView1.Columns["RegistrationDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dataGridView1.Columns["StartDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dataGridView1.Columns["EndDate"].DefaultCellStyle.Format = "dd MMM yyyy";

                //dataGridView2.DataSource = db.Users
                //  .Where(x => x.Role.Name.Equals("User") && x.JobTitle.Level <= 5 && x.FullName.Contains(tbSearch.Text))
                //  .Select(x => new
                //  {
                //      x.ID,
                //      x.FullName,
                //      Status = x.EmployeeStatuse.Name,
                //      Department = x.Department.Name,
                //      JobTitle = x.JobTitle.Name,
                //      JoinDate = x.JoinDate,
                //      RegistrationDate = x.JoinDate,
                //      StartDate = x.JoinDate,
                //      EndDate = x.JoinDate,
                //      Salary = x.SALARY,
                //      x.Active,
                //      x.Photo,
                //      x,
                //  }).ToList();

                dataGridView1.Columns["Photo"].Visible = false;
                dataGridView1.Columns["x"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns[1].DisplayIndex = dataGridView1.Columns.Count - 1;

                //foreach (DataGridViewRow item in dataGridView2.Rows)
                //{
                //    if (!string.IsNullOrWhiteSpace(item.Cells["Photo"].Value.ToString()))
                //    {
                //        //var path = $@"{Helper.PathBaseUrlImage}{item.Cells["Photo"].Value}";
                //        var path = @"D:\GithubRepo\LKSKotang2024\Desktop\EsemkaHRSystem.Desktop\EsemkaHRSystem.Desktop\Images\RobloxScreenShot20240101_205643673.png";
                //        Bitmap bm = new Bitmap($@"{path}");
                //        //bm = new Bitmap(bm, 50, 50);
                //        item.Cells[0].Value = bm;
                //    }
                //}

                //foreach (DataGridViewRow item in dataGridView1.Rows)
                //{
                //    if (!string.IsNullOrWhiteSpace(item.Cells["Photo"].Value.ToString()))
                //    {
                //        //var path = $@"{Helper.PathBaseUrlImage}{item.Cells["Photo"].Value}";
                //        var path = $@"{item.Cells["Photo"].Value}";
                //        //var path = @"D:\GithubRepo\LKSKotang2024\Desktop\EsemkaHRSystem.Desktop\EsemkaHRSystem.Desktop\Images\RobloxScreenShot20240101_205643673.png";
                //        //Bitmap bm = new Bitmap($@"{item.Cells["Photo"].Value.ToString()}");
                //        //Bitmap bm = new Bitmap(Image.FromFile(item.Cells["Photo"].Value.ToString()));
                //        //bm = new Bitmap(bm, 50, 50);
                //        //item.Cells[PhotoGrid.Name].Value = File.ReadAllBytes(item.Cells["Photo"].Value.ToString());
                //        //item.Cells[PhotoGrid.Name] = new DataGridViewImageCell { Value = bm };
                //        //DataGridViewImageCell cell = new DataGridViewImageCell();
                //        //cell.Value = Image.FromFile(path);
                //        //item.Cells[PhotoGrid.Index] = cell;
                //        //item.Cells[PhotoGrid.Name].Value = File.ReadAllBytes(item.Cells["Photo"].Value.ToString());

                //        using (Bitmap bm = new Bitmap(path))
                //        {
                //            DataGridViewImageCell cell = new DataGridViewImageCell();
                //            cell.Value = bm;
                //            item.Cells[PhotoGrid.Index] = cell;
                //        }
                //    }
                //}
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow r = dataGridView1.Rows[e.RowIndex];

                    if (e.ColumnIndex == 1)
                    {
                        SelectedUser = r.Cells["x"].Value as User;
                        tbSalary.Text = SelectedUser.SALARY.ToString();
                        cbEmployeeStatus.Text = EmployeeStatuses.FirstOrDefault(x => x.ID == SelectedUser.EmployeeStatusID)?.Name;
                        cbDepartment.Text = Departments.FirstOrDefault(x => x.ID == SelectedUser.DepartmentID)?.Name;
                        tbName.Text = SelectedUser.FullName;
                        dtStartDate.Value = SelectedUser.StatusStartDate.GetValueOrDefault();
                        dtEndDate.Value = SelectedUser.StatusEndDate.GetValueOrDefault();
                        checkBox1.Checked = SelectedUser.Active;
                    }
                }
            }
            catch { }
        }

        private void tbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeypressGlobal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedUser = new User();
            groupBox2.ClearField();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedUser.ID == 0)
            {
                "Please select the User".ShowInformationMessage();
                return;
            }

            if (groupBox2.CheckIsEmpty())
            {
                "Field can't be Empty".ShowInformationMessage();
                return;
            }

            if (dtStartDate.Value.Date > dtEndDate.Value.Date)
            {
                "Invalid Start Date".ShowInformationMessage();
                return;
            }

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.ID == SelectedUser.ID);

                if (user == null)
                    return;

                user.SALARY = Convert.ToDecimal(tbSalary.Text);
                user.EmployeeStatusID = int.Parse(cbEmployeeStatus.SelectedValue.ToString());
                user.DepartmentID = int.Parse(cbDepartment.SelectedValue.ToString());
                user.StatusStartDate = dtStartDate.Value;
                user.StatusEndDate = dtEndDate.Value;
                user.Active = checkBox1.Checked;

                db.SubmitChanges();

                "Successfully Updated the User!".ShowInformationMessage();

                SelectedUser = new User();

                groupBox2.ClearField();

                LoadData();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (!string.IsNullOrWhiteSpace(item.Cells["Photo"].Value.ToString()))
                {
                    Bitmap bm = new Bitmap($@"{item.Cells["Photo"].Value.ToString()}");
                    //bm = new Bitmap(bm, 50, 50);
                    item.Cells[0].Value = bm;
                }

                if (!Convert.ToBoolean(item.Cells["Active"].Value))
                {
                    item.DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
        }
    }
}