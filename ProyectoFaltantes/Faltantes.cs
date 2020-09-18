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
    public partial class Faltantes : Form
    {
        public Faltantes()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=faltantesfarmacia;UID=root";
        MySqlConnection cn = new MySqlConnection(conexion);
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataTable dt = new  DataTable();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Faltantes_Load(object sender, EventArgs e)
        {
            Tabla ta = new Tabla();

            ta.cargarProductos(falta);

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            try {
                string obtener = "SELECT *FROM Faltantes WHERE Nombre_Faltante=@nombre";

                MySqlCommand cmde = new MySqlCommand(obtener, cn);
                cmde.Parameters.AddWithValue("@nombre", this.falta.CurrentRow.Cells[0].Value.ToString());

                string eliminar = "DELETE from  faltantes WHERE Nombre_Faltante=@nombre";
                MySqlDataReader leer = cmde.ExecuteReader();
                if (leer.Read())
                {
                    leer.Close();
                    MySqlCommand cmd = new MySqlCommand(eliminar, cn);

                    cmd.Parameters.AddWithValue("@nombre", this.falta.CurrentRow.Cells[0].Value.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Faltante eliminado correctamente");


                    Tabla ta = new Tabla();

                    ta.cargarProductos(falta);
                }
                else
                {

                    MessageBox.Show("No hay datos para eliminar");
                }
            }
            catch (Exception ex) {

                MessageBox.Show("No hay datos para eliminar");
            }
            finally {
                cn.Close();
            }

           

        }

        private void falta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.falta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void buscar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Tabla ta = new Tabla();
            ta.Show();
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //(falta.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre_Faltante = '{0}'", textBox1.Text);
            Tabla ta = new Tabla();
            ta.buscarProductos(falta, textBox1.Text);
        }

      
    }
}
