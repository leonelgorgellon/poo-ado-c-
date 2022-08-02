using Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLCamioneta
    {
        public List<Camioneta> Listar()
        {
            var dalcamio= new DALCamioneta();
            return dalcamio.MostrarTodo();
        }

        public void Insertar (Camioneta camio)
        {
            var dalcamio = new DALCamioneta();
            dalcamio.InsertarCamioneta(camio);
        }

        public void Modificar (Camioneta camio){
            var dalcamio = new DALCamioneta();
            dalcamio.ModificarCamioneta(camio);
        }

        public void Eliminar(int cod){
            var dalcamio = new DALCamioneta();
            dalcamio.BorrarCamioneta(cod);
        }

        public Camioneta BuscarProdId ( int idcamio){
            var dalcamio = new DALCamioneta();
            return dalcamio.MostrarUnaCamioneta(idcamio);
        }

        

    }
}
