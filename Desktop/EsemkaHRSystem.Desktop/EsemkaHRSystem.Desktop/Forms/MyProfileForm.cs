using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MyProfileForm : Form
    {
        private string PhotoName = "";
        private string FileName = "";
        private List<City> Cities = new List<City>();

        public MyProfileForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (groupBox1.CheckIsEmpty())
                {
                    "Please insert all field".ShowInformationMessage();
                    return;
                }

                var user = db.Users.FirstOrDefault(x => x.ID == Helper.UserLogin.ID);
                if (user != null)
                {
                    user.CountryID = int.Parse(cbCountry.SelectedValue.ToString());
                    user.CityID = int.Parse(cbCity.SelectedValue.ToString());
                    user.Username = tbUsername.Text;
                    user.Password = tbPassword.Text;
                    user.Email = tbEmail.Text;
                    user.FullName = tbFullName.Text;
                    user.IDCardNumber = tbIdCardNumber.Text;
                    user.CivilStatus = cbCivil.Text;
                    user.Religion = cbReligion.Text;
                    user.Gender = cbGender.Text;
                    user.Address = tbAddress.Text;
                    user.Phone = tbPhone.Text;
                    user.Photo = string.IsNullOrWhiteSpace(PhotoName) ? null : PhotoName;

                    "Successfully Updated".ShowInformationMessage();
                    db.SubmitChanges();
                }

                var savePath = Helper.PathBaseUrlImage + PhotoName;

                try
                {
                    Bitmap bitmap = new Bitmap(FileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                    bitmap.Save(savePath);
                }
                catch { }
            }
        }

        private void MyProfileForm_Load(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (Helper.UserLogin == null)
                    return;

                var genders = new string[2]
                {
                    "Male",
                    "Female"
                };
                cbGender.DataSource = genders;

                var civilStatus = new string[2]
                {
                    "Single",
                    "Married"
                };
                cbCivil.DataSource = civilStatus;

                var religions = new string[6]
                {
                    "Islam",
                    "Kristen",
                    "Katolik",
                    "Hindu",
                    "Buddha",
                    "Konghucu",
                };
                cbReligion.DataSource = religions;

                var citizenship = db.Countries.ToList();
                var status = db.EmployeeStatuses.ToList();
                var countries = db.Countries.ToList();
                var jobTitles = db.JobTitles.Where(x => x.Level <= 5).ToList();
                var departments = db.Departments.ToList();
                Cities = db.Cities.ToList();

                cbCountry.ValueMember = "Id";
                cbCountry.DisplayMember = "Name";
                cbCitizen.ValueMember = "Id";
                cbCitizen.DisplayMember = "Name";
                cbJobTitle.ValueMember = "Id";
                cbJobTitle.DisplayMember = "Name";
                cbCity.ValueMember = "Id";
                cbCity.DisplayMember = "Name";
                cbStatus.ValueMember = "Id";
                cbStatus.DisplayMember = "Name";
                cbDepartment.ValueMember = "Id";
                cbDepartment.DisplayMember = "Name";

                cbDepartment.DataSource = departments;
                cbCountry.DataSource = countries;
                cbCitizen.DataSource = citizenship;
                cbCountry.DataSource = countries;
                cbJobTitle.DataSource = jobTitles;
                cbStatus.DataSource = status;

                cbCity.DataSource = Cities.Where(x => x.CountryID == int.Parse(cbCountry.SelectedValue.ToString())).ToList();

                var user = db.Users.FirstOrDefault(x => x.ID == Helper.UserLogin.ID);
                tbUsername.Text = user.Username;
                tbPassword.Text = user.Password;
                tbEmail.Text = user.Email;
                tbPhone.Text = user.Phone;
                tbFullName.Text = user.FullName;
                tbIdCardNumber.Text = user.ID.ToString();
                cbGender.Text = user.Gender;
                cbReligion.Text = user.Religion;
                dateTimePickerDateOfBirth.Value = user.DateOfBirth;
                tbAddress.Text = user.Address;
                tbPhone.Text = user.Phone;
                cbCivil.Text = user.CivilStatus;
                cbCitizen.Text = countries.FirstOrDefault(x => x.ID == user.CountryID).Name;
                cbCountry.Text = Cities.FirstOrDefault(x => x.ID == user.CountryID).Country.Name;
                cbCity.Text = Cities.FirstOrDefault(x => x.ID == user.CityID).Name;

                tbSalary.Text = user.SALARY.ToString();
                cbDepartment.Text = departments.FirstOrDefault(x => x.ID == user.DepartmentID).Name;
                cbJobTitle.Text = jobTitles.FirstOrDefault(x => x.ID == user.JobTitleID).Name;
                cbStatus.Text = status.FirstOrDefault(x => x.ID == user.EmployeeStatusID).Name;
                dtStartDate.Value = user.StatusStartDate.Value;
                dtEndDate.Value = user.StatusEndDate.Value;

                if (!string.IsNullOrWhiteSpace(user.Photo))
                {
                    pictureBox1.Image = Image.FromFile(Helper.PathBaseUrlImage + user.Photo);   
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImage = openFileDialog.FileName;
                PhotoName = openFileDialog.SafeFileName;
                FileName = openFileDialog.FileName;

                pictureBox1.Image = new System.Drawing.Bitmap(selectedImage);
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCity.DataSource = Cities.Where(x => x.CountryID == int.Parse(cbCountry.SelectedValue.ToString())).ToList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}