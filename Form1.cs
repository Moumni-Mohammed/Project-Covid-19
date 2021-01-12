using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace covidManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataSet1.AddPatient'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.addPatientTableAdapter.Fill(this.dataSet1.AddPatient);
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string First_Name = txtFname.Text;
                string Last_Name = txtLname.Text;
                string cin = txtCin.Text;
                int Age = Convert.ToInt32(txtAge.Text);
                string Adresse = txtAdresse.Text;
                int pid = Convert.ToInt32(txtPid.Text);


                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = "Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;

                cmd.CommandText = "insert into AddPatient values ('" + First_Name + "', '" + Last_Name + "', '" + cin + "' , '" + Age + "', '" + Adresse + "', '" + pid + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                DA.Fill(DS);
            }
            catch (Exception)

            {
                MessageBox.Show("something wrong , please verify ! ");
            }

            MessageBox.Show("Data saved successfully");

            txtFname.Clear();
            txtLname.Clear();
            txtCin.Clear();
            txtAge.Clear();
            txtAdresse.Clear();
            txtPid.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                int pid = Convert.ToInt32(textBox1.Text);

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = "Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;

                cmd.CommandText = "Select * from AddPatient where pid = " + pid + " ";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                DA.Fill(DS);
                dataGridView2.DataSource = DS.Tables[0];
            }
        }

        private void btnStatusProgress_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;



        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox2.Text);
                string TestPcr = comboBoxTest.Text;

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = "Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;

                cmd.CommandText = "insert into Test values ('" + pid + "', '" + TestPcr + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


            }
            catch (Exception)
            {
                MessageBox.Show("something wrong , please verify ! ");
            }

            MessageBox.Show("Data saved successfully");

            textBox2.Clear();
            comboBoxTest.ResetText();
           
        }

        private void btnSaveStatu_Click(object sender, EventArgs e)
        {

            try
            {
                int pid = Convert.ToInt32(textBox3.Text);
                string Statu = comboBoxStatu.Text;

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = "Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;

                cmd.CommandText = "insert into Etat values ('" + pid + "', '" + Statu + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

            }
            catch (Exception)
            {
               MessageBox.Show("something wrong , please verify ! ");
            }

            MessageBox.Show("Data saved successfully");

            textBox3.Clear();
            comboBoxStatu.ResetText();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
           

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = "Data Source=DESKTOP-S86SJHL;Initial Catalog=Corona;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;

            cmd.CommandText = "Select First_Name, Last_Name, cin, Age, Adresse , TestPcr, Statu from AddPatient, Test, Etat where AddPatient.pid=Test.pid and AddPatient.pid=Etat.pid ; ";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);
            dataGridView3.DataSource = DS.Tables[0];

        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView3.Rows)
            {
                string Statu = Convert.ToString(row.Cells[6].Value);
                string TestPcr = Convert.ToString(row.Cells[5].Value);

                if (TestPcr == "Positive"  &&  Statu == "Recover")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (TestPcr == "Positive" && Statu == "Dead")
                {
                    row.DefaultCellStyle.BackColor = Color.Coral;
                }

            }
        }

      
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
