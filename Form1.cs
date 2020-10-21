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

namespace basededatos601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;usename=root;password=;database=alumnos";
            string query = "SELECT * FROM user";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);

                    }
                }
                else
                {
                    Console.WriteLine("No tienes datos en la bd amix :C");
                }
                conectionDatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GuardarUsuario()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=alumnos";
            string query = "INSERT INTO user (`id`, `first_name`, `last_name`, `address`) VALUES (NULL,  readeMessage '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader reader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Tu dato esta guardado");
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void MostrarUsuario()
        {
            string Connect = "datasurce=localhost;port=3306;username=root;password=;database=alumnos";
            string query = "SELECT * FROM user";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatadase = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var ListViewItem = new ListViewItem(row);
                        listView1.Item.Add(ListViewItem);
                    }
                }
                else
                {
                    Console.WriteLine("No hay datos, no hay nada");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteFrom()
        {
            string Connect = "datasurce=localhost;port=3306;usename=root;password=;database=alumnos";
            string query = "DELETE  * FROM user" WHERE (id= "' + textBox4.Text '") ;
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader reader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Se ha eliminado");
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(DataObjectMethodType sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Falta nombre");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Falta apellido");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Falta direccion");
            }
            else
            {
                GuardarUsuario();
                MostrarUsuario();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MostrarUsuario();
        }

        private void textBox1.TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2.TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3.TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteFrom();
        }

    }
}