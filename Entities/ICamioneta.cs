using System.Collections.Generic;


namespace Entities
{
    public interface ICamioneta
    {
       public double CalcularEnvio();

       public void Buscar(List<Camioneta> camio, int id)
       {
        
       }
       
    }
}