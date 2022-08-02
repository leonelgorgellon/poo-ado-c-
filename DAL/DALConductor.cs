using Entities;
using System.Collections.Generic;
using Microsoft.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALConductor
    {
        Datos datos = new Datos();

        //MOSTRAR TODO ----------------------------------------------
        public List<Conductor> MostrarTodo(){
            var conductores = new List<Conductor>();
            var cnx = new SqlConnection(); 
            
            cnx.ConnectionString = "Server = data_host; Database=data_database; trusted_connection = true;"; 

            cnx.Open();//abre conexion
                var consulta = "select * from Conductores";
                
                var comando = new SqlCommand(consulta, cnx); 
                SqlDataReader dr = comando.ExecuteReader();   
                while(dr.Read()){
                    var conductor = new Conductor ();
                    conductor.Legajo = dr.GetInt32(0);
                    conductor.Nombre = dr.GetString(1); 
                    conductor.Apellido = dr.GetString(2);
                    conductor.DNI = dr.GetInt32(3); 
                    conductor.CantViajes = dr.GetInt32(4);
                    conductores.Add(conductor);//agregamos el profesor. 
                    
                     
                }

            cnx.Close(); //cierra conexion

            return conductores;
        }

        //INSERTAR UN CONDUCTOR  --------------------------------------
        public void InsertarConductor (Conductor conductor){
            
            var consulta = "insert into Conductores (Legajo, Nombre, Apellido, DNI, CantViajes) values(@leg,@nom,@ape,@dni,@cant)";
            datos.EjecutarConsulta(consulta,MostrarParametros(true,conductor));

            //Excepcion, GetType, typeof 
            if(conductor.GetType()!=typeof(Conductor))
                throw new System.Exception ("El elemento que esta intentando agregar no es de tipo Conductor.");
            
        }

         //BORRAR CONDUCTOR --------------------------------------------
        public void BorrarConductor(int leg){
            var consulta = "delete Conductores where Legajo = @leg";
            var paramLeg = new SqlParameter("@leg", leg);

            datos.EjecutarConsulta(consulta,new SqlParameter[]{paramLeg});   

        }

         //MODIFICAR CONDUCTOR -------------------------------------------
        public void ModificarConductor(Conductor conductor){
           
            var consulta = "update Conductores set Nombre= @nom, Apellido = @ape, DNI = @dni, CantViajes = @cant where Legajo = @leg";
            datos.EjecutarConsulta(consulta,MostrarParametros(true,conductor));

        }

        //MOSTRAR UN CONDUCTOR ---------------------------------------
        public Conductor MostrarUnConductor( int leg ){

            var conductor = new Conductor();
            var cnx = new SqlConnection();
            cnx.ConnectionString =  "Server = data_host; Database=data_database; trusted_connection = true;";

            cnx.Open();//abre conexion
                var comando = new SqlCommand("select * from Conductores where Legajo = @leg",cnx); //podemos agregar otro paramentro por ej and @campo = cc
                var paramLeg = new SqlParameter("@leg", leg); //idicamos cual paramentro le pasamos al constructor.  y el id va a reemplazar al @cod 

                comando.Parameters.Add(paramLeg); //agregamos el parametro que creamos. 
                SqlDataReader dr = comando.ExecuteReader();

                 while(dr.Read()){
                    
                    conductor.Legajo = dr.GetInt32(0);
                    conductor.Nombre = dr.GetString(1); 
                    conductor.Apellido = dr.GetString(2);
                    conductor.DNI = dr.GetInt32(3); //lo casteamos y le indicamos el campo. es otra forma de ir mapeandolo. 
                    
                    
                    
                }

            cnx.Close();

            return conductor;

        }




        private SqlParameter [] MostrarParametros (bool InsUpd, Conductor cond)
        {
            var paramLeg = new SqlParameter ("@leg", cond.Legajo);
            var paramNomb = new SqlParameter ("@nom", cond.Nombre);
            var paramApell = new SqlParameter ("@ape", cond.Apellido);
            var paramDNI = new SqlParameter ("@dni", cond.DNI);
            var paramCant = new SqlParameter("@cant",cond.CantViajes);
            

            if(InsUpd)
                return new SqlParameter[]{paramLeg,paramNomb,paramApell,paramDNI,paramCant};
            return new SqlParameter[]{paramLeg};
        }
    }
}