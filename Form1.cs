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

namespace Corona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True");

        public int IdCitoyen;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPatientRecord();

        }

        private void GetPatientRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from AddPatient", cnx);
            DataTable dt = new DataTable();

            cnx.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            cnx.Close();

            CitoyenRecordDataGridView.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO AddPatient VALUES (@First_name , @Last_name ,@cin ,@age ,@adresse ,@pid)", cnx);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@First_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Last_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@cin", textBox3.Text);
            cmd.Parameters.AddWithValue("@age", textBox4.Text);
            cmd.Parameters.AddWithValue("@adresse", textBox5.Text);
             cmd.Parameters.AddWithValue("@pid", textBox6.Text);
          

            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();

            MessageBox.Show("New Citoyen is saved successefully", "Seved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetPatientRecord();

        }

  
    }

        
}
