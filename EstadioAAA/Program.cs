using System;
using System.Collections.Generic;

namespace EstadioAAA
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables & instances
            List<Usuario> userlist = new List<Usuario>();
            List<Evento> eventlist = new List<Evento>();
            Mantenedor man = new Mantenedor();
            man.InicializarCampos(userlist, eventlist);
            int option;
            bool loop = true;
            Console.WriteLine("Bienvenid@ al programa de Estadio AAA!");

            while (loop)
            {
                Console.WriteLine("Por favor, seleccione una de las siguientes opciones:");
                Console.WriteLine("(1) Agregar cliente");
                Console.WriteLine("(2) Agregar evento");
                Console.WriteLine("(3) Eliminar cliente");
                Console.WriteLine("(4) Eliminar evento");
                Console.WriteLine("(5) Listar clientes");
                Console.WriteLine("(6) Listar eventos");
                Console.WriteLine("(7) Salir");
                option = Mantenedor.ValidateInt();
                switch (option)
                {
                    case 1:
                        try
                        {
                            man.AddUser(userlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        try
                        {
                            man.AddEvento(eventlist, userlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 3:
                        try
                        {
                            man.EliminarUsuario(userlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 4:
                        try
                        {
                            man.EliminarEvento(eventlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 5:
                        try
                        {
                            man.ListarUsuario(userlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 6:
                        try
                        {
                            man.ListarEvento(eventlist);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 7:
                        loop = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Por favor, utilice un numero entre 1 y 7.");
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(150);
                        break;
                }
            }
        }
    }
}
