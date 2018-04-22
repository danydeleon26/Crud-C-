using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CRUD
{
    class Class1
    {
        SqlConnection Sqlconn;

        public void conectar()
        {
            Sqlconn = new SqlConnection("Data Source=DESKTOP-4I6PCMJ;Initial Catalog=CRUD;Integrated Security=True");

            Sqlconn.Open();
        }

        public void desconectar()

        {
            Sqlconn.Close();

        }

        public void Ejecutarsql(string consulta)

        {

            
                SqlCommand com = new SqlCommand(consulta, Sqlconn);
              

                int filasafectadas = com.ExecuteNonQuery();

                if (filasafectadas > 0)
                {
                    MessageBox.Show("La operacion se ha realizado correctamente", "la base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show("No se ha conectado con la base de datos", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        public void actualizargrid(DataGridView dg, string consulta)

        {
            this.conectar();

            System.Data.DataSet ds = new System.Data.DataSet();

            SqlDataAdapter da = new SqlDataAdapter(consulta, Sqlconn);

            da.Fill(ds, "Registro");

            dg.DataSource = ds;
            dg.DataMember = "registro";

            

            this.desconectar();

        }


    }
}
