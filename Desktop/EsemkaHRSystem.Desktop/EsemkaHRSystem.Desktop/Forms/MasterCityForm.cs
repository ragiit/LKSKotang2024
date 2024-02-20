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
using System.Xml.Linq;

namespace EsemkaHRSystem.Desktop
{
    public partial class MasterCityForm : Form
    {
        private City SelectedCity = new City();
        private List<Country> Countries = new List<Country>();

        public MasterCityForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                Countries = db.Countries.ToList();

                cbCountry.ValueMember = "Id";
                cbCountry.DisplayMember = "Name";
                cbCountry.DataSource = Countries;

                dataGridView1.DataSource = db.Cities.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower())).Select(x => new
                {
                    x.ID,
                    Country = x.Country.Name,
                    x.Name,
                    x
                }).ToList();

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["x"].Visible = false;
                dataGridView1.Columns[1].DisplayIndex = dataGridView1.ColumnCount - 1;
                dataGridView1.Columns[0].DisplayIndex = dataGridView1.ColumnCount - 2;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (e.ColumnIndex == 0)
                {
                    SelectedCity = row.Cells["x"].Value as City;
                    tbName.Text = SelectedCity.Name;
                    cbCountry.Text = Countries.FirstOrDefault(x => x.ID == SelectedCity.CountryID).Name;
                }

                if (e.ColumnIndex == 1)
                {
                    SelectedCity = row.Cells["x"].Value as City;
                    if (MessageBox.Show("Are you sure want to delete this row?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DataClasses1DataContext db = new DataClasses1DataContext())
                        {
                            db.Cities.DeleteOnSubmit(db.Cities.FirstOrDefault(x => x.ID == SelectedCity.ID));
                            db.SubmitChanges();

                            SelectedCity = new City();

                            "Deleted Successfully".ShowInformationMessage();

                            groupBox2.ClearField();

                            LoadData();
                        }
                    }
                }
            }
        }

        private void MasterCityForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.ClearField();
            SelectedCity = new City();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox2.CheckIsEmpty())
            {
                "Please insert all fields".ShowInformationMessage();
                return;
            }

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                if (SelectedCity.ID == 0)
                {
                    var existingName = db.Countries.FirstOrDefault(x => x.Name == tbName.Text);
                    if (existingName != null)
                    {
                        "City Name already exist".ShowInformationMessage();
                        return;
                    }

                    db.Cities.InsertOnSubmit(new City
                    {
                        Name = tbName.Text,
                        CountryID = int.Parse(cbCountry.SelectedValue.ToString())
                    });
                }
                else
                {
                    var existingName = db.Cities.FirstOrDefault(x => x.Name == tbName.Text && x.ID != SelectedCity.ID);
                    if (existingName != null)
                    {
                        "City Name already exist".ShowInformationMessage();
                        return;
                    }

                    existingName = db.Cities.FirstOrDefault(x => x.ID == SelectedCity.ID);
                    existingName.ID = SelectedCity.ID;
                    existingName.Name = tbName.Text;
                    existingName.CountryID = int.Parse(cbCountry.SelectedValue.ToString());
                }

                db.SubmitChanges();

                "Saved Successfully".ShowInformationMessage();

                groupBox2.ClearField();

                LoadData();
            }
        }
    }
}