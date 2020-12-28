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


        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-S86SJHL;Initial Catalog=Covid;Integrated Security=True");

        public int IdCitoyen;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCitoyenRecord();

        }

        private void GetCitoyenRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from Citoyen", cnx);
            DataTable dt = new DataTable();

            cnx.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            cnx.Close();

            CitoyenRecordDataGridView.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO Citoyen VALUES (@cin , @nom ,@prenom ,@age ,@location ,@aMaladieChronique ,@aSymptomesGrave)", cnx);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cin", textBox1.Text);
            cmd.Parameters.AddWithValue("@nom", textBox2.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox3.Text);
            cmd.Parameters.AddWithValue("@age", textBox4.Text);
            cmd.Parameters.AddWithValue("@location", textBox5.Text);
            if (radioButton2.Checked)
                cmd.Parameters.AddWithValue("@AmaladieChro", "oui");
            else if (radioButton1.Checked)
                cmd.Parameters.AddWithValue("@AmaladieChro", "non");

            else if (radioButton3.Checked)
                cmd.Parameters.AddWithValue("@AsympGrave", "oui");
            else if (radioButton4.Checked)
                cmd.Parameters.AddWithValue("@AsympGrave", "non");

            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();

            MessageBox.Show("New Citoyen is saved successefully", "Seved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GetCitoyenRecord();

        }

  
    }

        
}
