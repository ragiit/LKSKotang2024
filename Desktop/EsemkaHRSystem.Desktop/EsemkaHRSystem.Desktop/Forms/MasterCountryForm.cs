using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public partial class MasterCountryForm : Form
    {
        private Country SelectedCountry = new Country();

        public MasterCountryForm()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = db.Countries.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower()) || x.Code.ToLower().Contains(tbSearch.Text.ToLower())).Select(x => new
                {
                    x.ID,
                    x.Name,
                    x.Code,
                    x
                }).ToList();

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["x"].Visible = false;
                dataGridView1.Columns[1].DisplayIndex = dataGridView1.ColumnCount - 1;
                dataGridView1.Columns[0].DisplayIndex = dataGridView1.ColumnCount - 2;
            }
        }

        private void MasterCountryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (e.ColumnIndex == 0)
                {
                    SelectedCountry = row.Cells["x"].Value as Country;
                    tbName.Text = SelectedCountry.Name;
                    tbCode.Text = SelectedCountry.Code;
                }

                if (e.ColumnIndex == 1)
                {
                    SelectedCountry = row.Cells["x"].Value as Country;
                    if (MessageBox.Show("Are you sure want to delete this row?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (DataClasses1DataContext db = new DataClasses1DataContext())
                        {
                            db.Countries.DeleteOnSubmit(db.Countries.FirstOrDefault(x => x.ID == SelectedCountry.ID));
                            db.SubmitChanges();

                            SelectedCountry = new Country();

                            "Deleted Successfully".ShowInformationMessage();

                            groupBox2.ClearField();

                            LoadData();
                        }
                    }
                }
            }
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
                if (SelectedCountry.ID == 0)
                {
                    var existingName = db.Countries.FirstOrDefault(x => x.Name == tbName.Text);
                    if (existingName != null)
                    {
                        "Country Name already exist".ShowInformationMessage();
                        return;
                    }

                    db.Countries.InsertOnSubmit(new Country
                    {
                        Name = tbName.Text,
                        Code = tbCode.Text
                    });
                }
                else
                {
                    var existingName = db.Countries.FirstOrDefault(x => x.Name == tbName.Text && x.ID != SelectedCountry.ID);
                    if (existingName != null)
                    {
                        "Country Name already exist".ShowInformationMessage();
                        return;
                    }

                    existingName = db.Countries.FirstOrDefault(x => x.ID == SelectedCountry.ID);
                    existingName.ID = SelectedCountry.ID;
                    existingName.Name = tbName.Text;
                    existingName.Code = tbCode.Text;
                }

                db.SubmitChanges();

                "Saved Successfully".ShowInformationMessage();

                groupBox2.ClearField();

                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.ClearField();
            SelectedCountry = new Country();
        }
    }
}