using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Space_Solutions__Pvt.__Ltd_Esoft_Unit_04_Project_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpassword.Text;

            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Login success","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Form2 colonist = new Form2();
                this.Hide();
                colonist.Show();

            }
            else if(username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
