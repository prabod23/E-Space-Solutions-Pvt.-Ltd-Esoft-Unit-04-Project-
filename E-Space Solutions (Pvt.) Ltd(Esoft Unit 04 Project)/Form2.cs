using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace E_Space_Solutions__Pvt.__Ltd_Esoft_Unit_04_Project_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=E_Space_Solutions;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            displaydata();
        }
        public void displaydata()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select MarsColonizationID,FirstName,MiddleName,Surname,DateOfBirth,Qualification,Age,EarthAddress,Gender,ContactNo,CivilStatus,NoOf_Family_Members as FamilyMembers  from Colonist ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void textboxclear()
        {
            id.Text = "No";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0 || textBox5.TextLength == 0 || textBox6.TextLength == 0 || textBox7.TextLength == 0 || textBox8.TextLength == 0)
            {
                MessageBox.Show("Please Enter All Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
               
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Colonist values(@FirstName,@MiddleName,@Surname,@DateOfBirth,@Qualification,@Age,@EarthAddress,@Gender,@ContactNo,@CivilStatus,@NoOf_Family_Members)", conn);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@MiddleName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Surname", textBox3.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Qualification", textBox4.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@EarthAddress", textBox6.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@ContactNo", textBox7.Text);
                cmd.Parameters.AddWithValue("@CivilStatus", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@NoOf_Family_Members", int.Parse(textBox8.Text));
                cmd.ExecuteNonQuery();

                conn.Close();

                textboxclear();
                MessageBox.Show("Registed", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                displaydata();
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Colonist set FirstName= '"+textBox1.Text+"',MiddleName= '"+textBox2.Text+"',Surname='"+textBox3.Text+"',DateOfBirth='"+dateTimePicker1.Text+"',Qualification='"+textBox4.Text+"',Age='"+int.Parse(textBox5.Text)+"',EarthAddress= '"+textBox6.Text+"',Gender= '"+comboBox1.Text+"',ContactNo= '"+int.Parse(textBox7.Text)+"',CivilStatus='"+comboBox2.Text+"',NoOf_Family_Members= '"+int.Parse(textBox8.Text)+"' where MarsColonizationID ='"+int.Parse(id.Text)+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            MessageBox.Show("record Updated succesfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id.Text = "No";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Colonist where MarsColonizationID = '"+id.Text+"' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            MessageBox.Show("record Deleted succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id.Text = "No";
        }
    }
}
