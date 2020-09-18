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
namespace ProyectoFaltantes
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
           
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        private void ingreso_Click(object sender, EventArgs e)
        {
            string obtener = "SELECT *FROM usuarios WHERE Usuario=@usuario and Contraseña=@contraseña";

            MySqlCommand cmd = new MySqlCommand(obtener, cn);

            cmd.Parameters.AddWithValue("@usuario", usuario.Text);
            cmd.Parameters.AddWithValue("@contraseña", contraseña.Text);

            


            cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();

            }
            
            else
            {

                MessageBox.Show("Usuario y/o contraseña incorrectos");
                recuperar.Visible = true;

            }
            cn.Close();

            

        }

        private void recuperar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recuperar re = new Recuperar();
            re.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void contraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
