using System;
using System.Linq;
using System.Collections.Generic; 

namespace Entities
{
    public class TrabajoDeLaManana : Pedido
    {
        public TrabajoDeLaManana(int codigo, string direccion, int distancia, double precio) : base (codigo, direccion, distancia, precio)
        {

        }

        public List<Camioneta> Camionetas {get;set;}
        public List<Pedido> Pedidos {get;set;}
       
        private List<Electrodomesticos> Equipos;


        public override void AgregarElectrodomestico (Electrodomesticos equipo)
        {
            if (Equipos is null)
                Equipos = new List<Electrodomesticos>();
            
            Equipos.Add(equipo);
        }


        public override int PesoTotal{
            get{
                return Equipos.Sum(x=> x.Peso);
            }
        }


        //clase estatica
        public static double SumaEnvio (double a, double b, double c)
        {
            return a+b+c;
        }
        
    }

    public class TrabajoDeLaTarde : Pedido
    {
        public TrabajoDeLaTarde (int codigo, string direccion, int distancia, double precio) : base (codigo, direccion, distancia, precio)
        {
            
        }

        public List<Camioneta> Camionetas {get;set;}
        public List<Pedido> Pedidos {get;set;}
        private List<TV> Tvs {get;set;}

        public override void AgregarElectrodomestico(Electrodomesticos equipo)
        {
            //Operador Is
            if(Tvs is null)
                Tvs = new List<TV>();
            
            //Excepcion, GetType, typeof
            if(equipo.GetType()!=typeof(TV))
                throw new Exception ("El equipo que esta intentando agregar no es de tipo TV.");
            Tvs.Add((TV)equipo);
        }

        public override int PesoTotal {
            get{
                return Tvs.Sum(x=>x.Peso);
            }
        }

        //clase estatica
        public static double SumaEnvio (double a, double b, double c)
        {
            return a+b+c;
        }
        
    }
}