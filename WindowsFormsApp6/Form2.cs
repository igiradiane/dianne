using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp6
{
    public partial class Form2 :Form
    {
        private string connectionstring;
        private MySqlConnection Connection;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connectionstring = "server=localhost;database=hosteldb;uid=root;pwd=iraduddkk;";
               Connection = new MySqlConnection(connectionstring);
            Connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usernametext = textBox1.Text;
            var passwordtext = textBox2.Text;
            var selectcommand = new MySqlCommand();
            selectcommand.CommandText = "select *from user where username=@username and password=@password";
            selectcommand.Parameters.AddWithValue("@username", usernametext);
            selectcommand.Parameters.AddWithValue("@password", passwordtext);
            selectcommand.Connection = Connection;
            MySqlDataReader datareader = selectcommand.ExecuteReader();
            if (datareader.Read())
            {
                MessageBox.Show("login successfully");
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
        }



    }
}
