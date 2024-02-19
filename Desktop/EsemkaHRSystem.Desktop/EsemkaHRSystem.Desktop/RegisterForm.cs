using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class RegisterForm : Form
    {
        private List<City> Cities = new List<City>();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            dateTimePickerDateOfBirth.MaxDate = DateTime.Now;
            dateJoindate.MaxDate = DateTime.Now;

            LoadData();
        }

        private void LoadData()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
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
                cbDepartment.ValueMember = "Id";
                cbDepartment.DisplayMember = "Name";
                cbCity.ValueMember = "Id";
                cbCity.DisplayMember = "Name";

                cbCountry.DataSource = countries;
                cbCitizen.DataSource = citizenship;
                cbCountry.DataSource = countries;
                cbJobTitle.DataSource = jobTitles;
                cbDepartment.DataSource = departments;

                cbCity.DataSource = Cities.Where(x => x.CountryID == int.Parse(cbCountry.SelectedValue.ToString())).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (groupBox1.CheckIsEmpty() || groupBox2.CheckIsEmpty())
                {
                    return;
                }

                Hide();
                new LoginForm().ShowDialog();
            }
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCity.DataSource = Cities.Where(x => x.CountryID == int.Parse(cbCountry.SelectedValue.ToString())).ToList();
        }

        private void tbIdCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeypressGlobal();
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeypressGlobal();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name and display it in the picture box
                string selectedImage = openFileDialog.FileName;
                pictureBox1.Image = new System.Drawing.Bitmap(selectedImage);
            }
        }
    }
}