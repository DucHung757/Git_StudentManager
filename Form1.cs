using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_2_StudentManager
{
    public partial class Form1 : Form
    {
        List<Student> studens = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
        public class Student
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string ID { get; set; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student()
            {
                Name = txtName.Text,
                Gender = cboGender.Text,

            };
            studens.Add(s);
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = studens;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int index = dgvStudents.CurrentRow.Index;
                studens[index].Name = txtName.Text;
                studens[index].Gender = cboGender.Text;
                studens[index].ID = txtID.Text;
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studens;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int index = dgvStudents.CurrentRow.Index;
                studens.RemoveAt(index);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studens;
            }
        }

        private void ttnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text.ToLower();
            var result = studens.FindAll(s=>s.Name.ToLower().Contains(keyword));
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = result;
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboGender.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtID.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            cboGender.Text = "";
        }
    }
}
