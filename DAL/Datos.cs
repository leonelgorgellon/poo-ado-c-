using System.Data;
using System.IO;
using Microsoft.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Datos{

        private SqlConnection cnx;

        public Datos ()
        {
            cnx = new SqlConnection();
            cnx.ConnectionString= "Server = data_host; Database=data_database; trusted_connection = true;";
        }

        //usar con consultas del tipo insert, update y delete.
        public int EjecutarConsulta (string consulta, SqlParameter[] parametros){
            int cantFilasAfectadas = 0 ;

            using (var comando = new SqlCommand(consulta,cnx)){
                if(parametros != null && parametros.Length>0)
                    comando.Parameters.AddRange(parametros);
                cnx.Open();

                cantFilasAfectadas = comando.ExecuteNonQuery();

                cnx.Close();
            }

            return cantFilasAfectadas;
        }

        //usar cuando tengamos consultas de agregado por ej : count, sum, avg(promedio)
        public object EjecutarEscalar (string consulta, SqlParameter[] parametros)
        {
            object resultado = null;
            using (var comando = new SqlCommand(consulta,cnx)){
                if(parametros!= null && parametros.Length>0)
                    comando.Parameters.AddRange(parametros);
                cnx.Open();
                    resultado = comando.ExecuteScalar();
                cnx.Close();
            }
            return resultado;
        }
        

        //usar cuando tengamos consultas que devuelvan una o mas filas 
        public DataTable MostrarDatos (string consulta, SqlParameter[]parametros){
            var dt = new DataTable();
            using (var comando = new SqlCommand(consulta,cnx)){
                if(parametros!=null && parametros.Length>0)
                    comando.Parameters.AddRange(parametros);
                var da = new SqlDataAdapter();
                da.SelectCommand = comando;
                cnx.Open();
                da.Fill(dt);
                cnx.Close();
            }
            return dt;
        }
    }
}   