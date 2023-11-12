using System.Data.Entity;
using System.Windows.Forms;

namespace ITstepDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tabControl1.TabPages.Add(new TabPage("Departments"));
            tabControl1.TabPages.Add(new TabPage("Forms"));
            tabControl1.TabPages.Add(new TabPage("Groups"));
            tabControl1.TabPages.Add(new TabPage("Students"));
            tabControl1.TabPages[0].Controls.Add(new DepartmentsForm());
            tabControl1.TabPages[1].Controls.Add(new FormsForm());
            tabControl1.TabPages[2].Controls.Add(new GroupsForm());
            tabControl1.TabPages[3].Controls.Add(new StudentsForm());
        }
        public class MyContext : DbContext
        {
            public DbSet<Department> Departments { get; set; }
            public DbSet<Form> Forms { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Student> Students { get; set; }
        }
    }
}