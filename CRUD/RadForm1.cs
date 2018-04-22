using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CRUD
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        Class1 con = new Class1();

        int id;
        bool editar = false;

        public void limpiar()
        {
            txtnombre.Text = "";
            txtapelllido.Text = "";
            txtedad.Text = "";

        }




        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {





        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
          

            con.actualizargrid(this.dataGridView1, "select * from Registro");
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editar == true)
            {
                con.conectar();

                string actualizar = "update registro set nombre = '" + txtnombre.Text + "', apellido ='" + txtapelllido.Text + "', edad = '" + txtedad.Text + "' where id = " + id + ";  ";

                con.Ejecutarsql(actualizar);

                //consultar nuevamente despues de la insercion

                con.actualizargrid(this.dataGridView1, "select * from Registro");

                limpiar();

                con.desconectar();

                editar = false;
            }
            else
            {
                con.conectar();


                //codigo de insercion a la base de datos

                string insertar = "insert into Registro (Nombre, apellido, Edad) values ('" + txtnombre.Text + "','" + txtapelllido.Text + "'," + txtedad.Text + " ); ";


                con.Ejecutarsql(insertar);


                //consultar nuevamente despues de la insercion

                con.actualizargrid(this.dataGridView1, "select * from Registro");
                
                //limpiar los textboxs

                limpiar();


                //descibectar la conexcion luego de realizar la insercion
                con.desconectar();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.conectar();

            string a = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();


            string eliminar = "delete from registro where id =" + a + "; ";

            con.Ejecutarsql(eliminar);

            //consultar nuevamente despues de eliminar

            con.actualizargrid(this.dataGridView1, "select * from Registro");

            con.desconectar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            editar = true;

            id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtnombre.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtapelllido.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtedad.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();


        }

        private void buscar_Click(object sender, EventArgs e)
        {
           

            con.actualizargrid(this.dataGridView1, "select * from Registro where nombre = '"+txtbuscar.Text+"'");

          
        }
    }
}
