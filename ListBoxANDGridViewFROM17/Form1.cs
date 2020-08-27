using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBoxANDGridViewFROM17
{
    public partial class Form1 : Form
    {
        private DataTable dtcourses = new DataTable();
        private DataTable dtSelectedcourses = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCoursesTable();
            SelectedCoursesTable();

            listBox1.DataSource = dtcourses;
            listBox1.DisplayMember = "coursesName";
            listBox2.DataSource = dtSelectedcourses;
            listBox2.DisplayMember = "coursesName";
        }

        private void FillCoursesTable()
        {
            dtcourses.Columns.Add("coursesID", typeof(int));
            dtcourses.Columns.Add("coursesName");
            dtcourses.Columns.Add("coursesDuretion");


            dtcourses.Rows.Add(1, "Advance OOP", "7 months");
            dtcourses.Rows.Add(2, " OOP", "5 months");
            dtcourses.Rows.Add(3, "Formal Methods", "5 months");
            dtcourses.Rows.Add(4, " ITC", "7 months");
            dtcourses.Rows.Add(5, " SQL", "3 months");
            dtcourses.Rows.Add(6, "java", "4 months");
            dtcourses.Rows.Add(7, "web desiging", "3 months");
            dtcourses.Rows.Add(8, "Advance java", "8 months");
        }
        private void SelectedCoursesTable()
        {
            dtSelectedcourses.Columns.Add("coursesID", typeof(int));
            dtSelectedcourses.Columns.Add("coursesName");
            dtSelectedcourses.Columns.Add("coursesDuretion");


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count>0)
            {
                dtSelectedcourses.ImportRow(dtcourses.Rows[listBox1.SelectedIndex]);
                dtcourses.Rows[listBox1.SelectedIndex].Delete();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                dtcourses.ImportRow(dtSelectedcourses.Rows[listBox2.SelectedIndex]);
                dtSelectedcourses.Rows[listBox2.SelectedIndex].Delete();
            }
        }

        private void btn_AddAll_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                int count = dtcourses.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    dtSelectedcourses.ImportRow(dtcourses.Rows[listBox1.SelectedIndex]);
                    dtcourses.Rows[listBox1.SelectedIndex].Delete();
                }
            }
        }

        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                int count = dtSelectedcourses.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    dtcourses.ImportRow(dtSelectedcourses.Rows[listBox2.SelectedIndex]);
                    dtSelectedcourses.Rows[listBox2.SelectedIndex].Delete();
                }
            }
        }

        private void btn_Finalize_Click(object sender, EventArgs e)
        {
         DialogResult dr=  MessageBox.Show("Are you sure you want to finalize the courses", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                dataGridView1.DataSource = dtSelectedcourses;

                dataGridView1.Enabled = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                

                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Width = 500;
            }
            else
            {
                MessageBox.Show("Please select atleast one course.",  "Information  message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
    }
}
