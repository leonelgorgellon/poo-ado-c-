using System;
using System.Linq;
using System.Collections.Generic; 

namespace Entities
{
    public abstract class Pedido
    {
        public int Codigo { get; set; }
        public string Direccion { get; set; }
        public int Distancia {get;set;}
        public double Precio { get; set; }

        public Pedido (int codigo, string direccion,int distancia, double precio)
        {
            Codigo = codigo;
            Direccion = direccion;
            Distancia = distancia;
            Precio = precio;
        }

        //public List<Electrodomesticos> Electrodomesticos;

        public abstract void AgregarElectrodomestico (Electrodomesticos equipo);

        public abstract int PesoTotal {get;}


        //clase estatica
        public static int Suma (int a, int b, int c)
        {
            return a+b+c;
        }
    }
}