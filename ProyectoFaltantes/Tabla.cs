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
    public partial class Tabla : Form
    {
        public Tabla()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt;

        private void Tabla_Load(object sender, EventArgs e)
        {
            Form1 c = new Form1();

            c.cargarProductos(productos);
        }

        private void productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            cn.Open();
            
            string obtener = "SELECT *FROM faltantes WHERE Nombre_Faltante=@nombre";

            MySqlCommand cmde = new MySqlCommand(obtener, cn);
            cmde.Parameters.AddWithValue("@nombre", this.productos.CurrentRow.Cells[2].Value.ToString());
            string insertar = "INSERT INTO faltantes( Nombre_Faltante,Presentacion_Faltante) values(@nombre,@presentacion)";
            MySqlCommand cmd = new MySqlCommand(insertar, cn);
            MySqlDataReader leer = cmde.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show("El producto ya ha sido ingresado en la lista de faltantes");
            }
            else {
                leer.Close();
                cmd.Parameters.AddWithValue("@nombre", this.productos.CurrentRow.Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@presentacion", this.productos.CurrentRow.Cells[3].Value.ToString());
                cmd.ExecuteNonQuery();
                

                MessageBox.Show("Producto enviado a lista de faltantes");
            }
            cn.Close();







        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faltantes fa = new Faltantes();
            this.Hide();
            fa.Show();
        }
        public void cargarProductos(DataGridView dgv)
        {

            da = new MySqlDataAdapter("SELECT *FROM faltantes", cn);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;

        }

        public void buscarProductos(DataGridView dgv, string palabra) 
        {
            da = new MySqlDataAdapter("SELECT * FROM faltantes Where Nombre_Faltante LIKE '%"+palabra+"%'",cn);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        public void buscarlista(DataGridView dgv, string palabra) {
            da = new MySqlDataAdapter("SELECT * FROM productos Where Nombre_Producto LIKE '%" + palabra + "%'", cn);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fo = new Form1();
            fo.Show();
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            buscarlista(productos,textBox1.Text);
        }
    }
}
