using System;
using System.Linq;
using System.Collections.Generic; 

namespace Entities
{
    public class Camioneta : ICamioneta
    {

        // public Camioneta (int id, string patente, string modelo, int km)
        // {
        //     Id = id;
        //     Patente = patente;
        //     Modelo = modelo;
        //     KM = km;
        //     //Pedido = pedido;
        // }

        public int Id {get;set;}
        public string Patente {get;set;}
        public string Modelo {get;set;}
        public int KM {get;set;}
    
        public Pedido Pedido {get;set;}
    
        
       //Metodo Virtual 

        public virtual double CalcularEnvio()
       {
            var distancia = 0;
            var precioExtra = 100;
            distancia += this.Pedido.Distancia;

            if(distancia > 50)
                Pedido.Precio += precioExtra;
            return Pedido.Precio;
       }

       
    }
    
}