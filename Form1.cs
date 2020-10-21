using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DATABASE
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "SELECT * FROM test";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            string datos;
         //   MostrarUsuarios();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
                        datos = reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3);
                       
                    }
                
                }
                else
                {
                    Console.WriteLine("No hay datos papu :( ");

                }
                databaseConnection.Close();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        private void Eliminar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "DELETE FROM `test` WHERE id = '" + textBox4.Text + "' ";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {

                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Dato Eliminado D:");
                MostrarUsuarios();
                databaseConnection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       private void Actualizar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "UPDATE `test` SET `first_name`='"+textBox1.Text+ "',`last_name`='"+textBox2.Text+ "',`address`='"+textBox3.Text+"' WHERE id = '"+textBox4.Text+"' ";//Modificar
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {

                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Dato Actualizado :D");
                databaseConnection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Buscar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "SELECT * FROM user where id= '"+textBox4.Text+"' ";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnection.Open(); // Se Abre la interfaz MYSQL
                reader = commandDatabase.ExecuteReader(); // Se Leen Tablas
                if (reader.HasRows)
                {
                    listView1.Items.Clear();// Se actualiza el ListView
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)};
                      //  var ListViewItems = new ListViewItem(row);
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];
                      

                    }

                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void GuardarUsuario()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "INSERT INTO test(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
               
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Lograste insertar el usuario, eres un crack");
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarUsuarios()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=user;";
            string query = "SELECT * FROM test";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
          
            try {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read()) { 
                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    var ListViewItems = new ListViewItem(row);   
                    listView1.Items.Add(ListViewItems);
                }

               }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Parte a Mostrar cuando demuestres insertar dato vacio  
            if (textBox1.Text == "")
            {
                MessageBox.Show("Te falta el nombre de usuario, ojo aqui man");
            }
         else   if (textBox2.Text == "")
            {
                MessageBox.Show("Te falta el appellido, ojo aqui tambien man");
            }
         else   if (textBox3.Text == "")
            {
                MessageBox.Show("Te falta la direccion, te digo -.-");
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Que onda aqui? te faltan los 3 campos :'v ");
            }
            else
            {


                GuardarUsuario();
                // listView1.Clear();
                MostrarUsuarios();
                //Aplicar Posterior al primer Guardado
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar();
            MostrarUsuarios();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Actualizar();
            MostrarUsuarios();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
            Eliminar();
        }
    }
}
