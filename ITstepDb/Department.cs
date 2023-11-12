using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITstepDb
{
    public partial class DepartmentForm : Form
    {
        private Department department;
        public DepartmentForm()
        {
            InitializeComponent();
        }

        public DepartmentForm(Department department)
        {
            InitializeComponent();
            this.department = department;
            nameTextBox.Text = department.Name;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            department = new Department();
            department.Name = nameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        public Department GetDepartment()
        {
            return department;
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
