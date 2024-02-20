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
        public MasterCityForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = db.Cities.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower())).Select(x => new
                {
                    x.ID,
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
                    cbCountry.Text = SelectedCity.Country.Name;
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
                var existingName = db.Cities.FirstOrDefault(x => x.Name == tbName.Text);

                if (SelectedCity.ID == 0 && existingName != null)
                {
                    "Country Name already exist".ShowInformationMessage();
                    return;
                }

                if (existingName != null)
                {
                    if (SelectedCity.ID != 0 && SelectedCity.Name != existingName.Name)
                    {
                        "Country Name already exist".ShowInformationMessage();
                        return;
                    }

                    existingName.ID = SelectedCity.ID;
                    existingName.CountryID = int.Parse(cbCountry.SelectedValue.ToString());
                    existingName.Name = tbName.Text;

                    "Saved Successfully".ShowInformationMessage();

                    db.SubmitChanges();

                    LoadData();
                }
                else
                {
                    db.Cities.InsertOnSubmit(new City
                    {
                        Name = tbName.Text,
                        CountryID = int.Parse(cbCountry.SelectedValue.ToString()),
                    });

                    "Saved Successfully".ShowInformationMessage();

                    db.SubmitChanges();

                    LoadData();
                }
            }
        }
    }
}
