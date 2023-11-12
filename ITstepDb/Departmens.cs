using System;
using System.Linq;
using System.Windows.Forms;

namespace ITstepDb
{
    public partial class DepartmentsForm : Form
    {
        public DepartmentsForm()
        {
            InitializeComponent();
            using (var db = new MyContext())
            {
                departmentsDataGridView.DataSource = db.Departments.ToList();
            }
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            using (var db = new MyContext())
            {
                departmentsDataGridView.DataSource = db.Departments.ToList();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var form = new DepartmentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var db = new MyContext())
                    {
                        db.Departments.Add(form.GetDepartment());
                        db.SaveChanges();
                    }

                    PopulateGrid();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (departmentsDataGridView.SelectedRows.Count == 0)
                return;

            var id = (int)departmentsDataGridView.SelectedRows[0].Cells["Id"].Value;

            using (var db = new MyContext())
            {
                var department = db.Departments.FirstOrDefault(d => d.Id == id);

                if (department != null)
                {
                    using (var form = new DepartmentForm(department))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            db.Entry(department).CurrentValues.SetValues(form.GetDepartment());
                            db.SaveChanges();
                        }
                    }
                }
            }

            PopulateGrid();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (departmentsDataGridView.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Confirm delete?", "Delete",
                               MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var id = (int)departmentsDataGridView.SelectedRows[0].Cells["Id"].Value;

                using (var db = new MyContext())
                {
                    var department = db.Departments.FirstOrDefault(d => d.Id == id);

                    if (department != null)
                    {
                        db.Departments.Remove(department);
                        db.SaveChanges();
                    }
                }

                PopulateGrid();
            }
        }
    }
}