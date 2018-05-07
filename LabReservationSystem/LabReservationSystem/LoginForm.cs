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
    public partial class LoginForm : Form
    {
        

        public LoginForm()
        {
            InitializeComponent();
        }
        //Will be inserted in Reservation table when Reservation is Made.
        public static int userID = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            this.Hide();
            signup.Show();
        }

        private void logInButton(object sender, EventArgs e)
        {
            string pass = "";
            SqlConnection con = new SqlConnection("Server=WINDOWS-VC8GVI7\\SQLEXPRESS;Database=LabReservation;Integrated Security=SSPI;");
            con.Open();
            SqlCommand comm = con.CreateCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "UserLogin";
            comm.Parameters.Add(new SqlParameter("email", textBox1.Text));

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                pass = reader["u_password"].ToString();
                userID = Int32.Parse(reader["u_id"].ToString());
            }
            //MessageBox.Show(userID.ToString());
            con.Close();
            
            //SHOW NEW FORM (HOME PAGE)
            if (pass.Equals(textBox2.Text))
            {
                ReservationForm RF = new ReservationForm();
                RF.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User NOT FOUND");
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
