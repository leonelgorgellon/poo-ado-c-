using Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLConductor
    {
         public List<Conductor> Listar()
        {
            var dalconduc= new DALConductor();
            return dalconduc.MostrarTodo();
        }

        public void Insertar (Conductor conduc)
        {
            var dalconduc = new DALConductor();
            dalconduc.InsertarConductor(conduc);

            
        }

        public void Modificar (Conductor conduc){
            var dalconduc = new DALConductor();
            dalconduc.ModificarConductor(conduc);
        }

        public void Eliminar(int leg){
            var dalconduc = new DALConductor();
            dalconduc.BorrarConductor(leg);
        }

        public Conductor BuscarProdLeg ( int legcond){
            var dalconduc = new DALConductor();
            return dalconduc.MostrarUnConductor(legcond);
        }
    }
}