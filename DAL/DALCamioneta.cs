using Entities;
using System.Collections.Generic;
using Microsoft.Data;
using System.Data.SqlClient;



namespace DAL
{
    public class DALCamioneta
    {
        Datos datos = new Datos();

        //MOSTRAR TODO ----------------------------------------------
        public List<Camioneta> MostrarTodo(){
            var camionetas = new List<Camioneta>();
            var cnx = new SqlConnection(); //es un objeto de conexion a la base de datos. 
            
            cnx.ConnectionString = "Server = data_host; Database=data_database; trusted_connection = true;"; 

            cnx.Open();//abre conexion
                var consulta = "select * from Camionetas";
                //creamos el objeto comando para ejecutar la consulta 
                var comando = new SqlCommand(consulta, cnx); //se le pasa la consulta y la conexion
                SqlDataReader dr = comando.ExecuteReader();  //aca tenemos los datos en el dr. ahora hay q recorrer el reader con el while. 
                while(dr.Read()){
                    var camioneta = new Camioneta ();
                    camioneta.Id = dr.GetInt32(0);//ponemos 0 porq la primera posicion es la ID de la tabla .. columna 0 1 2 3 
                    camioneta.Patente = dr.GetString(1); //ponemos 1 porq la segunda cposicion de columnas es nombre en la tabla. 
                    camioneta.Modelo = dr.GetString(2);
                    camioneta.KM = dr.GetInt32(3); //lo casteamos y le indicamos el campo. es otra forma de ir mapeandolo. 
                    camionetas.Add(camioneta);//agregamos el profesor. 
                    
                     
                }

            cnx.Close(); //cierra conexion

            return camionetas;
        }

        //INSERTAR UNA CAMIONETA --------------------------------------
        public void InsertarCamioneta (Camioneta camioneta){
            
            var consulta = "insert into Camionetas (Id, Patente, Modelo, KM) values(@cod,@pat,@mod,@km)";
            datos.EjecutarConsulta(consulta,MostrarParametros(true,camioneta));

            //Excepcion, GetType, typeof 
            if(camioneta.GetType()!=typeof(Camioneta))
                throw new System.Exception ("El elemento que esta intentando agregar no es de tipo Camioneta.");
            
        }

         //BORRAR CAMIONETA --------------------------------------------
        public void BorrarCamioneta(int id){
            var consulta = "delete Camionetas where id = @cod";
            var paramId = new SqlParameter("@cod", id);

            datos.EjecutarConsulta(consulta,new SqlParameter[]{paramId});   

        }

         //MODIFICAR CAMIONETA -------------------------------------------
        public void ModificarCamioneta(Camioneta camioneta){
           
            var consulta = "update Camionetas set Patente = @pat, Modelo= @mod, KM = @km where id = @cod";
            datos.EjecutarConsulta(consulta,MostrarParametros(true,camioneta));

        }

        //MOSTRAR UNA CAMIONETA ---------------------------------------
        public Camioneta MostrarUnaCamioneta( int id ){

            var camioneta = new Camioneta();
            var cnx = new SqlConnection();
            cnx.ConnectionString =  "Server = data_host; Database=data_database; trusted_connection = true;";

            cnx.Open();//abre conexion
                var comando = new SqlCommand("select * from Camionetas where id = @cod",cnx); //podemos agregar otro paramentro por ej and @campo = cc
                var paramId = new SqlParameter("@cod", id); //idicamos cual paramentro le pasamos al constructor.  y el id va a reemplazar al @cod 

                comando.Parameters.Add(paramId); //agregamos el parametro que creamos. 
                SqlDataReader dr = comando.ExecuteReader();

                 while(dr.Read()){
                    
                    camioneta.Id = dr.GetInt32(0);//ponemos 0 porq la primera posicion es la ID de la tabla .. columna 0 1 2 3 
                    camioneta.Patente = dr.GetString(1); //ponemos 1 porq la segunda cposicion de columnas es nombre en la tabla. 
                    camioneta.Modelo = dr.GetString(2);
                    camioneta.KM = dr.GetInt32(3); //lo casteamos y le indicamos el campo. es otra forma de ir mapeandolo. 
                    
                    
                    //ASI MAPEAMOS LOS DATOS DE LA TABLA en herramientas el entity lo hace solo el mapeo. 
                    //asi traemos los datos. 
                }

            cnx.Close();

            return camioneta;

        }




        private SqlParameter [] MostrarParametros (bool InsUpd, Camioneta camioneta)
        {
            var paramId = new SqlParameter ("@cod", camioneta.Id);
            var paramPaten = new SqlParameter ("@pat", camioneta.Patente);
            var paramModel = new SqlParameter ("@mod", camioneta.Modelo);
            var paramKM = new SqlParameter ("@km", camioneta.KM);

            if(InsUpd)
                return new SqlParameter[]{paramId,paramPaten,paramModel,paramKM};
            return new SqlParameter[]{paramId};
        }

    }
}