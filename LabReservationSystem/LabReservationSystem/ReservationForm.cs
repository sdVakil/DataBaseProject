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
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        //Retieved From DataBase, Reservation Table
        DateTime dateTime;
        int time = 0;
        int device = 0;
       
        private Boolean checkReservation()
        {
            {
                string dateForm = dateTimePicker1.Value.ToShortDateString();
                SqlConnection con = new SqlConnection("Server=WINDOWS-VC8GVI7\\SQLEXPRESS;Database=LabReservation;Integrated Security=SSPI;");
                con.Open();
                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "checkReservation";
                comm.Parameters.Add(new SqlParameter("date", dateTimePicker1.Value.ToShortDateString()));
                comm.Parameters.Add(new SqlParameter("time", comboBox1.SelectedIndex + 1));
                comm.Parameters.Add(new SqlParameter("device", comboBox2.SelectedIndex + 1));

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    dateTime = Convert.ToDateTime(reader["r_date"].ToString());
                    time = int.Parse(reader["t_id"].ToString());
                    device = int.Parse(reader["d_id"].ToString());
                }

                if (dateTime.ToShortDateString().Equals(dateForm) &&
                    time == comboBox1.SelectedIndex + 1 &&
                    device == comboBox2.SelectedIndex + 1)
                {
                    //MessageBox.Show("ALREADY RESERVED");
                    return false;
                }
                else
                {
                    //createReservation(dateTime, time, device);
                    //MessageBox.Show("SLOT Requested, Waiting for Admin Apporoval");
                    return true;
                }
            }
            
        }


        private void makeReservation()
        {
            Boolean CR =  checkReservation();
            if (CR == true)
            {
                SqlConnection con = new SqlConnection("Server=WINDOWS-VC8GVI7\\SQLEXPRESS;Database=LabReservation;Integrated Security=SSPI;");
                con.Open();
                SqlCommand comm = con.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "insert_Reservation";
                comm.Parameters.Add(new SqlParameter("date", dateTimePicker1.Value.ToShortDateString()));
                comm.Parameters.Add(new SqlParameter("u_id", LoginForm.userID));
                comm.Parameters.Add(new SqlParameter("t_id", comboBox1.SelectedIndex+1));
                comm.Parameters.Add(new SqlParameter("d_id", comboBox2.SelectedIndex + 1));
                
                comm.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Already Reserved!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makeReservation();
        }
    }
}