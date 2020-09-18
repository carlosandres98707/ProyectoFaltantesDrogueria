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
    public partial class Recuperar : Form
    {
        public Recuperar()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Actualiza_Click(object sender, EventArgs e)
        {
            string obtener = "SELECT *FROM usuarios WHERE Cedula=@cedula";

            MySqlCommand cmde = new MySqlCommand(obtener, cn);

            cmde.Parameters.AddWithValue("@cedula", documento.Text);
            string actualizar = "UPDATE usuarios set Usuario=@usuario,Contraseña=@contraseña where  Cedula=@cedula";
            cn.Open();

            MySqlDataReader leer = cmde.ExecuteReader();
            if (leer.Read()) {

                leer.Close();
                MySqlCommand cmd = new MySqlCommand(actualizar, cn);
                cmd.Parameters.AddWithValue("@cedula", documento.Text);
                cmd.Parameters.AddWithValue("@usuario", usuario.Text);
                cmd.Parameters.AddWithValue("@contraseña", contraseña.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados exitosamente");
                login lo = new login();
                this.Hide();
                lo.Show();
            }
            else
            {

                MessageBox.Show("No pudimos recuperar tu cuenta.Tu numero de identificacion es incorrecto o no posees una cuenta");
                documento.Clear();
                usuario.Clear();
                contraseña.Clear();
            }

            cn.Close();

            
        }
    }
}
