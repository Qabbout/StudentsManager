using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentsManager
{
    public partial class Form1 : Form
    {
        LinqDataContext db = new LinqDataContext();
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=.;Initial Catalog=StudentsManager;Integrated Security=True");
            
            populateLsvStudentss();
            populateLsvCourses();
            populateCourses();
            populateStudents();
            populateFilter();
            populateFullData();
            comboBox8.SelectedIndex = -1;


        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsManagerDataSet.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.studentsManagerDataSet.Course);
            // TODO: This line of code loads data into the 'studentsManagerDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentsManagerDataSet.Student);
            // TODO: This line of code loads data into the 'studentsManagerDataSet.MajorType' table. You can move, or remove it, as needed.
            this.majorTypeTableAdapter.Fill(this.studentsManagerDataSet.MajorType);

            
        }
        private void populateStudents()
        {
            listBox1.Items.Clear();
            try
            {
                conn.Open();
                string q = "Select * from Student";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Studentt a = new Studentt();
                    a.id1 = reader[0].ToString();
                    a.name1 = reader[1].ToString();
                    a.age1 = reader[2].ToString();
                    a.major1 = reader[3].ToString();
                    listBox1.Items.Add(a);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Studentt acc = new Studentt();
            acc.id1 = textBox1.Text;
            acc.name1 = textBox2.Text;
            acc.age1 = textBox3.Text;
            acc.major1 = comboBox1.SelectedValue.ToString();

            try
            {
                conn.Open();
                string q = "Insert into Student(id,name,age,major) values('" + acc.id1 + "','" + acc.name1 + "','" + acc.age1 + "','" + acc.major1 + "')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                populateStudents();
                populateLsvStudentss();
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();


                SqlCommand command = new SqlCommand("Delete from Student where id=" + textBox1.Text, conn);
                command.ExecuteNonQuery();

                ;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            populateStudents();
            populateLsvStudentss();
            
        }

        private void Textbox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Listview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listview1.SelectedItems.Count != 0)
            {
                ListViewItem l = listview1.SelectedItems[0];
                textbox4.Text = l.Text;
                textbox5.Text = l.SubItems[1].Text;
                comboBox2.SelectedValue = l.SubItems[3].Text;
            }
        }
        private void populateLsvStudentss()
        {
            listview1.Items.Clear();
            try
            {
                conn.Open();
                string q = "Select * from Student";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    string[] row = new string[4];
                    row[0] = dr[0].ToString();
                    row[1] = dr[1].ToString();
                    row[2] = dr[2].ToString();
                    row[3] = dr[3].ToString();
                    ListViewItem lvi = new ListViewItem(row);
                    listview1.Items.Add(lvi);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();


                SqlCommand command = new SqlCommand("Delete from Student where id= " + textbox4.Text, conn);
                command.ExecuteNonQuery();

                ;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            populateStudents();
            populateLsvStudentss();

            textbox4.Clear();
            textbox5.Clear();
            comboBox2.SelectedIndex = -1;

        }

        private void Button5_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string q = "update Student set name ='" + textbox5.Text + "',major='" + (int)comboBox2.SelectedValue + "' where id=" + textbox4.Text;
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

                populateStudents();
                populateLsvStudentss();
                textbox4.Clear();
                textbox5.Clear();
                comboBox2.SelectedIndex = -1;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

            Coursee acc = new Coursee();
            acc.id1= textBox6.Text;
            acc.name1 = textBox7.Text;
            acc.major1 = comboBox1.SelectedValue.ToString();

            try
            {
                conn.Open();
                string q = "Insert into Course(id,name,major) values('" + acc.id1 + "','" + acc.name1 + "','" + acc.major1 + "')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox6.Clear();
                textBox7.Clear();
                comboBox3.SelectedIndex = -1;
                populateCourses();
                populateLsvCourses();

            }
        }

        private void populateCourses()
        {
            listBox2.Items.Clear();
            try
            {
                conn.Open();
                string q = "Select * from Course";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Coursee a = new Coursee();
                    a.id1 = dr[0].ToString();
                    a.name1 = dr[1].ToString();
                    a.major1 = dr[2].ToString();
                    listBox2.Items.Add(a);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                ListViewItem l = listView2.SelectedItems[0];
                textBox8.Text = l.Text;
                textBox9.Text = l.SubItems[1].Text;
                comboBox2.SelectedValue = l.SubItems[2].Text;
            }
        }

        private void populateLsvCourses()
        {
            listView2.Items.Clear();
            try
            {
                conn.Open();
                string q = "Select * from Course";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    string[] row = new string[3];
                    row[0] = dr[0].ToString();
                    row[1] = dr[1].ToString();
                    row[2] = dr[2].ToString();
                    ListViewItem lvi = new ListViewItem(row);
                    listView2.Items.Add(lvi);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();


                SqlCommand command = new SqlCommand("Delete from Course where id= " + textBox8.Text, conn);
                command.ExecuteNonQuery();

                ;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            populateLsvCourses();
            populateCourses();
            textBox8.Clear();
            textBox9.Clear();
            comboBox4.SelectedIndex = -1;
        }

        private void Button6_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string q = "update Course set name ='" + textBox9.Text + "',major='" + (int)comboBox4.SelectedValue + "' where id=" + textBox8.Text;
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                populateLsvCourses();
                populateCourses();
                textBox8.Clear();
                textBox9.Clear();
                comboBox4.SelectedIndex = -1;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            Studentt acc = new Studentt();
            acc.signedCourse1 = (string)comboBox6.SelectedValue;
            acc.id1 = comboBox5.SelectedValue.ToString();
            try
            {
                conn.Open();
                string q = "Update Student set signedCourse='" + acc.signedCourse1+"'where id =" + acc.id1 ;
                // THIS IS WORKING BUT THE DATA GRID VIEW IS NOT REFRECHING WITHOUT CLSING THE FORM
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                populateStudents();
                populateLsvStudentss();
                populateCourses();
                populateLsvCourses();
                populateDGVStudents();



            }
        }

        private void StudentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var temp1 = studentDataGridView.SelectedCells[0].Value;
            var temp2 = studentDataGridView.SelectedCells[3].Value;
            if (temp1 != null)
                comboBox5.SelectedValue = temp1;
            if (temp2 != null)
                comboBox7.SelectedValue = temp2;
            


        }

        private void TabPage8_Click(object sender, EventArgs e)
        {

        }

       
        void populateDGVStudents()
        {
            studentDataGridView.DataSource = from Student in db.Students
                                              
                                              select Student;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            studentBindingSource2.EndEdit();
            db.SubmitChanges();
        }

        private void StudentsManagerDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        void populateFilter()
        {
            comboBox8.DataSource = from MajorType in db.MajorTypes
                                   select MajorType.majorName;



        }

        private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 0)
            {
                studentDataGridView.DataSource = from Student in db.Students
                                                 where  Student.major == "1"
                                                 select Student;
            }
            if (comboBox8.SelectedIndex == 1)
            {
                studentDataGridView.DataSource = from Student in db.Students
                                                 where Student.major == "2"
                                                 select Student;
            }
            if (comboBox8.SelectedIndex == 2)
            {
                studentDataGridView.DataSource = from Student in db.Students
                                                 where Student.major == "3"
                                                 select Student;
            }
            if(comboBox8.SelectedIndex == -1)
            {
                studentDataGridView.DataSource = from Student in db.Students
                                                
                                                 select Student;
            }

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            comboBox8.SelectedIndex = -1;
        }


        void populateFullData()
        {

            dataGridView1.DataSource = from Student in db.Students
                                       select new { Student.id, Student.name, Student.age, Student.MajorType.majorName, Student.signedCourse };

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

