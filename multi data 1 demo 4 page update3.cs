using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace multi_data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            panel2.Visible=true;
            panel1.Visible=false;
            panel3.Visible=false;
            panel4.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible=true ;
            panel2.Visible=false;
            panel4.Visible=false;
            panel1.Visible=false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
            //try




            //string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Admin\\Downloads\\dars daneshgah\\multi data\\multi data\\Database1.mdf\";Integrated Security=True";

            //  SqlConnection connection = new SqlConnection(connectionstring);
            //   string query = "SELECT * FROM STUDENT";
            //   connection.Open();
            //  SqlCommand cmd = new SqlCommand(query, connection);
            //  SqlDataReader reader=cmd.ExecuteReader();
            //   while(reader.Read()) 

            //  string opt = reader["id"].ToString() + "-" + reader["name"].ToString() +"-" + reader["phone"].ToString()+"-" + reader["school"].ToString()+"-" + reader["address"].ToString();
            //     comboBox1.Items.Add(opt);







            //connection.Close();
            MessageBox.Show("welcome to my  silly app ");
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            //catch(Exception ex)

            //MessageBox.Show(ex.Message);    
        
        }
        
        
            void refresh() { 
            //comboBox1.Items.Clear();
            try
            {

               

                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Admin\\Downloads\\dars daneshgah\\multi data\\multi data\\Database1.mdf\";Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionstring);
                string query = "SELECT * FROM STUDENT";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string opt = reader["id"].ToString() + "-" + reader["name"].ToString() + "-" + reader["phone"].ToString() + "-" + reader["school"].ToString() + "-" + reader["address"].ToString();
                    comboBox1.Items.Add(opt);

                }

                Refresh();




                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void page3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible=true;
            panel2.Visible=false;
            panel4.Visible=false;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible=true;
            panel3.Visible=false;   
            panel2.Visible=false;
            panel1.Visible=false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible=false;
            panel1.Visible=false;
            panel4.Visible=false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                string phone = textBox4.Text;
                string schnum = textBox3.Text;
                string address = richTextBox1.Text;
                string query = "INSERT INTO student (name,phone,school,address)VALUES " + "('" + name +"','"  + phone + "','" + schnum + "','" + address +"' )";

                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Admin\\Downloads\\dars daneshgah\\multi data\\multi data\\Database1.mdf\";Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();

                SqlCommand command = new SqlCommand(query,connection);

                if (command.ExecuteNonQuery() > 1)
                {
                    MessageBox.Show("data uploades successfuly");
                    textBox2.Text = textBox4.Text = textBox3.Text = richTextBox1.Text = "";
                    Refresh();
                }
                
                else
                {
                    MessageBox.Show("pls insert your data");
                }

                connection.Close();
             }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                
                string selct= comboBox1.SelectedItem.ToString();
                //MessageBox.Show(selct);
                string sp = selct.Split('-')[0];
                //MessageBox.Show(sp);
                string query = $"DELETE FROM STUDENT WHERE id='{sp}'";
                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Admin\\Downloads\\dars daneshgah\\multi data\\multi data\\Database1.mdf\";Integrated Security=True";
                
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                
                if (command.ExecuteNonQuery() > 1)
                {
                    MessageBox.Show("data deleted successfuly");
                    textBox2.Text = textBox4.Text = textBox3.Text = richTextBox1.Text = "";

                    Refresh();
                }
                
                connection.Close();
                
                


            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
