using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        StudentDB st = new StudentDB();
        DataTable dtStudent;

        public Form1()
        {
            InitializeComponent();
        }

        private void getAllStudents()
        {
            dtStudent = st.GetStudentList();
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            txtClass.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dtStudent, "ID");
            txtName.DataBindings.Add("Text", dtStudent, "Name");
            txtAge.DataBindings.Add("Text", dtStudent, "Age");
            txtClass.DataBindings.Add("Text", dtStudent, "Class");

            dgvStudentList.DataSource = dtStudent;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(txtID.Text);
            string Name = txtName.Text;
            int Age = Int32.Parse(txtAge.Text);
            string Class = txtClass.Text;

            Students stu = new Students
            {
                ID = ID,
                Name = Name,
                Age = Age,
                Class = Class
            };
            bool r = st.Add(stu);
            if(r == true)
            {
                MessageBox.Show("add successful!!");
            }
            else
            {
                MessageBox.Show("add fail !!");
            }
            getAllStudents();
        }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getAllStudents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(txtID.Text);
            string Name = txtName.Text;
            int Age = Int32.Parse(txtAge.Text);
            string Class = txtClass.Text;

            Students stu = new Students
            {
                ID = ID,
                Name = Name,
                Age = Age,
                Class = Class
            };
            bool r = st.Update(stu);

            if(r == true)
            {
                MessageBox.Show("Update sucessfully!");
            }
            else
            {
                MessageBox.Show("Fail!!");
            }
            getAllStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(txtID.Text);

            bool r = st.Delete(ID);

            if (r == true)
            {
                MessageBox.Show("Delete sucessfully!");
            }
            else
            {
                MessageBox.Show("fail!");
            }
            getAllStudents();
        }
    }
}
