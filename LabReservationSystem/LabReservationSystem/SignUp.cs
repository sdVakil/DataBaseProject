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

namespace LabReservationSystem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int id = 2;
        private void createUser(object sender, EventArgs e)
        {
            id++;
            SqlConnection con = new SqlConnection("Server=WINDOWS-VC8GVI7\\SQLEXPRESS;Database=LabReservation;Integrated Security=SSPI;");
            con.Open();
            SqlCommand comm = con.CreateCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "insert_SignUp";
            comm.Parameters.Add(new SqlParameter("name", textBox1.Text));
            comm.Parameters.Add(new SqlParameter("regID", textBox2.Text));
            comm.Parameters.Add(new SqlParameter("email", textBox3.Text));
            comm.Parameters.Add(new SqlParameter("pass", textBox5.Text));
            comm.Parameters.Add(new SqlParameter("contact", textBox4.Text));
            comm.Parameters.Add(new SqlParameter("program", comboBox1.SelectedItem));
            comm.Parameters.Add(new SqlParameter("semester", comboBox2.SelectedItem));

            comm.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Inserted");
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

