using System;
using System.Linq;
using System.Collections.Generic; 
using BLL;
using Entities;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bllcamioneta = new BLLCamioneta();
            var bllconductor = new BLLConductor();
            

            //INSTANCIA 
            //Ingreso camionetas

            var camioneta1 = new Camioneta();
            camioneta1.Id= 1;
            camioneta1.Patente = "AA224KL";
            camioneta1.Modelo ="Partner";
            camioneta1.KM = 22345;

            var camioneta2 = new Camioneta();
            camioneta2.Id= 2;
            camioneta2.Patente = "AF334OP";
            camioneta2.Modelo ="Kangoo";
            camioneta2.KM = 10366;

            var camioneta3 = new Camioneta();
            camioneta3.Id= 3;
            camioneta3.Patente = "AE784QE";
            camioneta3.Modelo ="Partner";
            camioneta3.KM = 15388;

            var camioneta4 = new Camioneta();
            camioneta4.Id= 4;
            camioneta4.Patente = "AF344LL";
            camioneta4.Modelo ="Berlingo";
            camioneta4.KM = 22345;

            var camioneta5 = new Camioneta();
            camioneta5.Id= 5;
            camioneta5.Patente = "AE399CV";
            camioneta5.Modelo ="Kangoo";
            camioneta5.KM = 10366;

            var camioneta6 = new Camioneta();
            camioneta6.Id= 6;
            camioneta6.Patente = "AD689LE";
            camioneta6.Modelo ="Fiorino";
            camioneta6.KM = 15388;

            // bllcamioneta.Insertar(camioneta1);
            // bllcamioneta.Insertar(camioneta2);
            // bllcamioneta.Insertar(camioneta3);
            // bllcamioneta.Insertar(camioneta4);
            // bllcamioneta.Insertar(camioneta5);
            // bllcamioneta.Insertar(camioneta6);

            //Ingreso Conductores.

            var conductor1 = new Conductor();
            conductor1.Legajo = 1111;
            conductor1.Nombre = "Fernando";
            conductor1.Apellido = "Sapio";
            conductor1.DNI = 34673847;

            var conductor2 = new Conductor();
            conductor2.Legajo = 2222;
            conductor2.Nombre = "Guido";
            conductor2.Apellido = "Gonzalez";
            conductor2.DNI = 33647584;

            var conductor3 = new Conductor();
            conductor3.Legajo = 3333;
            conductor3.Nombre = "Hernan";
            conductor3.Apellido = "Murdocca";
            conductor3.DNI = 35647589;

            var conductor4 = new Conductor();
            conductor4.Legajo = 4444;
            conductor4.Nombre = "Fabrizio";
            conductor4.Apellido = "Fernandez";
            conductor4.DNI = 36774859;

            // bllconductor.Insertar(conductor1);
            // bllconductor.Insertar(conductor2);
            // bllconductor.Insertar(conductor3);
            // bllconductor.Insertar(conductor4);


            //Pedidos de la mañana
            var listPedMan = new List<TrabajoDeLaManana>();
            var pedido1 = new TrabajoDeLaManana(1122, "Av Mitre 6688", 55, 500);
            var pedido2 = new TrabajoDeLaManana(2266, "Martin Fierro 89", 40, 500);
            var pedido3 = new TrabajoDeLaManana(3388, "Av Maipu 4080", 100, 700);

            //Pedidos de la tarde
            var listPedTar = new List<TrabajoDeLaTarde>();
            var pedido4 = new TrabajoDeLaTarde(9900, "Vedia 281", 25, 500);
            var pedido5 = new TrabajoDeLaTarde(5544, "Av Jujuy 950", 80, 700);
            var pedido6 = new TrabajoDeLaTarde(6611, "Bondpland 1441", 100, 1000);
          

            listPedMan.Add(pedido1);
            listPedMan.Add(pedido2);
            listPedMan.Add(pedido3);

            listPedTar.Add(pedido4);
            listPedTar.Add(pedido5);
            listPedTar.Add(pedido6);

            Console.WriteLine("--------------------------------------------------");

            var tv60 = new TV();
            var cocina = new Cocina();
            var heladera = new Heladera();

            //Agrego electrodomestidos a los pedidos 
           pedido4.AgregarElectrodomestico(tv60);
           pedido4.AgregarElectrodomestico(tv60);
           pedido4.AgregarElectrodomestico(tv60);

           pedido5.AgregarElectrodomestico(tv60);
           pedido5.AgregarElectrodomestico(tv60); 

            //FORZAMOS ERROR PARA QUE TIRE LA EXCEPCIÓN. (solo por la tarde se puede repartir tvs)
           try{
            pedido6.AgregarElectrodomestico(tv60);
            pedido6.AgregarElectrodomestico(cocina);
           }
           catch(Exception ex)
           { 
            Console.WriteLine("Error al agregar un equipo al pedido de la tarde " + ex.Message.ToString());
           }
            
            Console.WriteLine("--------------------------------------------------");

            
        

            //Sucursal sucursal = new Sucursal();
            Console.WriteLine("Bienvenido \n");

            while (true)
            {   
                Console.WriteLine("\n");
                Console.WriteLine("1. Listar trabajos del día");
                Console.WriteLine("2. Listar camionetas y conductores disponibles");
                Console.WriteLine("3. Asignar conductor y camioneta");
                Console.WriteLine("4. Agregar Camioneta");
                Console.WriteLine("5. Agregar Conductor");
                Console.WriteLine("6. Modificar KM de la Camioneta");
                Console.WriteLine("7. Modificar cantidad de viajes del Conductor");
                Console.WriteLine("8. Eliminar Camioneta");
                Console.WriteLine("9. Eliminar Conductor");
                Console.WriteLine("10. Ganancia del día estimada:");
                Console.WriteLine("11. Salir. \n");

                string opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1":
                        Console.WriteLine("PEDIDOS DE LA MAÑANA: \n");
                        Console.WriteLine("CODIGO     22DIRECCION        ");
                        Console.WriteLine("----------------------------------");
                        foreach(TrabajoDeLaManana trab in listPedMan)
                        {
                            Console.WriteLine(trab.Codigo +"   " + trab.Direccion );
                        }

                        Console.WriteLine("\n");

                        Console.WriteLine("PEDIDOS DE LA TARDE: \n");
                        Console.WriteLine("CODIGO     DIRECCION        ");
                        Console.WriteLine("----------------------------------");
                        foreach(TrabajoDeLaTarde trab in listPedTar)
                        {
                            Console.WriteLine(trab.Codigo +"   " + trab.Direccion );
                        }

                    break;

                    case "2":
                        var listarCamio = bllcamioneta.Listar();
                        var listarCondu = bllconductor.Listar();

                        Console.WriteLine("ID  PATENTE   MODELO     KM");
                        Console.WriteLine("----------------------------------");
                        foreach(Camioneta camio in listarCamio)
                        {
                            Console.WriteLine(camio.Id +"   "+ camio.Patente +" "+ camio.Modelo + " " + camio.KM);
                        }
                        Console.WriteLine("\n");
                        Console.WriteLine("LEAGAJO  NOMBRE y APELLIDO    DNI     VIAJES");
                        Console.WriteLine("---------------------------------------------");
                        foreach(Conductor conduc in listarCondu)
                        {
                            Console.WriteLine(conduc.Legajo + "     " + conduc.Nombre + " " + conduc.Apellido + "      " + conduc.DNI +"     "+ conduc.CantViajes);
                        }
                        Console.WriteLine("\n");
                    break;

                    case "3":
                        var listarCond = bllconductor.Listar();
                        var listarCamione = bllcamioneta.Listar();
                        Console.Write("Ingrese Legajo del conductor para realizar los envios de los pedidos:");
                        int legAsig = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Conductor elegido: " + bllconductor.BuscarProdLeg(legAsig).Nombre +" "+ bllconductor.BuscarProdLeg(legAsig).Apellido);
                        Console.Write("Ingrese ID de la camioneta que utilizará: ");
                        int idAsig = Convert.ToInt32(Console.ReadLine()); 
                        Console.Write("Ingrese codigo del pedido del envio que va a realizar:");
                        int codPed = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                        for(int i = 0; i< listPedMan.Count; i++ )
                        {
                            if(listPedMan[i].Codigo == codPed)
                            {
                                listPedMan.Remove(listPedMan[i]);
                            }
                        }

                        for(int i = 0; i< listPedTar.Count; i++ )
                        {
                            if(listPedTar[i].Codigo == codPed)
                            {
                                listPedTar.Remove(listPedTar[i]);
                            }
                        }
                        }catch(SystemException ex)
                        {
                            Console.WriteLine("No se encontro el codigo" + ex.Message) ;
                        }

                        Console.WriteLine("Su conductor asignado a realizar el envio del pedido " + codPed + " es " + bllconductor.BuscarProdLeg(legAsig).Nombre +" "+ bllconductor.BuscarProdLeg(legAsig).Apellido +" "+ bllconductor.BuscarProdLeg(legAsig).DNI);
                        Console.WriteLine("Con la camioneta: " + bllcamioneta.BuscarProdId(idAsig).Patente +" "+ bllcamioneta.BuscarProdId(idAsig).Modelo + "\n");
                        // Console.WriteLine("El costo de envio es: "+bllcamioneta.BuscarProdId(idAsig).CalcularEnvio());
                        
                    break;

                    case "4":
                        Console.Write("Ingrese ID:");
                        int idNue = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese Patente: ");
                        string patNue = Console.ReadLine();
                        Console.Write("Ingrese Modelo: ");
                        string modNue = Console.ReadLine();
                        Console.Write("Ingrese Kilometraje: ");
                        int kmNue = Convert.ToInt32(Console.ReadLine());
                        try{
                            bllcamioneta.Insertar(new Camioneta(){Id = idNue, Patente = patNue, Modelo = modNue, KM = kmNue}); 
                        }catch(Exception ex){
                            Console.WriteLine("Error al agregar la camioneta" + ex.Message.ToString());
                        }

                    break;

                    case "5":
                        Console.Write("Ingrese Legajo: ");
                        int legNue = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese Nombre: ");
                        string nombNue = Console.ReadLine();
                        Console.Write("Ingrese Apellido: ");
                        string apeNue = Console.ReadLine();
                        Console.Write("Ingrese DNI: ");
                        int dniNue = Convert.ToInt32(Console.ReadLine()); 
                        try{
                            bllconductor.Insertar(new Conductor(){Legajo = legNue, Nombre = nombNue, Apellido = apeNue, DNI = dniNue});
                        }catch(Exception ex){
                            Console.WriteLine("Error al agregar el conductor" + ex.Message.ToString());
                        }
                        

                    break;

                    case "6":
                        Console.Write("Ingrese ID: ");
                        int idBus = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La camioneta que va a modificar el kilometraje es: " + bllcamioneta.BuscarProdId(idBus).Patente);
                        Console.Write("Ingrese nuevo KM: ");
                        int nuekm = Convert.ToInt32(Console.ReadLine());
                        bllcamioneta.Modificar(new Camioneta(){Id = idBus, Patente = bllcamioneta.BuscarProdId(idBus).Patente, Modelo = bllcamioneta.BuscarProdId(idBus).Modelo, KM = nuekm });

                    break;

                    case "7":
                        Console.Write("Ingrese legajo: ");
                        int legBus = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El conductor que va a modificar la cantidad de viajes es: " + bllconductor.BuscarProdLeg(legBus).Nombre +" "+ bllconductor.BuscarProdLeg(legBus).Apellido);
                        Console.Write("Ingrese nueva cantidad de viajes:");
                        int cantviaj = Convert.ToInt32(Console.ReadLine());
                        bllconductor.Modificar(new Conductor(){Legajo = bllconductor.BuscarProdLeg(legBus).Legajo, Nombre = bllconductor.BuscarProdLeg(legBus).Nombre, Apellido = bllconductor.BuscarProdLeg(legBus).Apellido, DNI = bllconductor.BuscarProdLeg(legBus).DNI, CantViajes = cantviaj}); 
                    
                    break;

                    case "8":
                        Console.Write("Ingrese ID de la camioneta: ");
                        int idElim = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La camioneta que quiere eliminar es :" + bllcamioneta.BuscarProdId(idElim).Patente);
                        Console.Write("Seguro que desea eliminarla? si/no ");
                        string resp = Console.ReadLine();
                        if(resp == "si")
                            bllcamioneta.Eliminar(idElim);
                        else
                        {
                            break;
                        }
                    break;

                    case "9":
                        Console.Write("Ingrese Legajo del conductor: ");
                        int legElim = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("El conductor que quiere eliminar es :" + bllconductor.BuscarProdLeg(legElim).Nombre +" "+ bllconductor.BuscarProdLeg(legElim).Apellido);
                        Console.Write("Seguro que desea eliminarlo? si/no ");
                        string res = Console.ReadLine();
                        if(res == "si")
                            bllconductor.Eliminar(legElim);
                        else
                        {
                            break;
                        }
                    break;

                    case "10":
                        Console.WriteLine("Ganancia estimada de la mañana:" + TrabajoDeLaManana.SumaEnvio(pedido1.Precio,pedido2.Precio,pedido3.Precio));
                        Console.WriteLine("Ganancia estimada de la tarde: " + TrabajoDeLaTarde.SumaEnvio(pedido4.Precio,pedido5.Precio,pedido6.Precio));
                        
                    break;
                    
                    case "11":
                        
                    break;

                    default:
                        Console.WriteLine("No se ha seleccionado ninguna opción.");
                    break;

                    
                    
                }

                Console.WriteLine("Desea Salir? si/no: ");
                        if(Console.ReadLine()=="si")
                            break;

            }
        }

    }

}
