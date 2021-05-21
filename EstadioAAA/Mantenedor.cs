using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EstadioAAA
{
    class Mantenedor
    {
        private static RNGCryptoServiceProvider rngCrypto = new RNGCryptoServiceProvider();
        
        private string UUIDGenerator(int length)
            //generar UIDs criptograficamente seguras
        {
            using (rngCrypto)
            {
                var bit_cnt = length * 6;
                var byte_cnt = ((bit_cnt + 7) / 8); //Aproximacion
                var bytes = new byte[byte_cnt];
                rngCrypto.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }

        public void AddUser(List<Usuario> usrlist)
        {
            Console.WriteLine();
            Usuario usr = new Usuario();
            Console.WriteLine("Por favor, ingrese el nombre del cliente:");
            usr.Username = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese la contraseña del cliente:");
            usr.Password = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese el e-mail del cliente:");
            usr.Email = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese el RUT del cliente:");
            usr.RUT = Console.ReadLine();
            usr.UUID = UUIDGenerator(32);
            usrlist.Add(usr);
            Console.WriteLine();
            Console.WriteLine($"El usuario con el RUT: {usr.RUT} ha sido añadido con exito. UUID: {usr.UUID}");
            Console.WriteLine();
        }

        public Usuario BuscarUsuario(List<Usuario> usrlist, string RUT)
        {
            Usuario usr = new Usuario();
            try
            {   
                usr = usrlist.Single(s => s.RUT.Equals(RUT));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            return usr;
        }

        public void EliminarUsuario(List<Usuario> usrlist)
        {
            Console.WriteLine();
            Console.WriteLine("Por favor, ingrese el RUT del usuario a eliminar:");
            string RUT = Console.ReadLine();
            Usuario usr = BuscarUsuario(usrlist, RUT);
            usrlist.Remove(usr);
            Console.WriteLine($"El usuario con el RUT: {RUT} y el UUID: {usr.UUID} ha sido eliminado con exito.");
            Console.WriteLine();
        }

        public void AddEvento(List<Evento> eventlist, List<Usuario> usrlist)
        {
            Console.WriteLine();
            Evento evt = new Evento();
            Console.WriteLine("Por favor, ingrese el nombre del evento:");
            evt.NombreEvento = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese la descripcion del evento:");
            evt.DescEvento = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese el valor (en pesos) del evento:");
            int valor;
            Int32.TryParse(Console.ReadLine(), out valor);
            evt.ValorEvento = valor;
            Console.WriteLine("Por favor, ingrese el quorum maximo del evento:");
            int quorum;
            Int32.TryParse(Console.ReadLine(), out quorum);
            evt.QuorumEvento = quorum;
            Console.WriteLine("Por favor, ingrese el RUT del organizador:");
            string RUT = Console.ReadLine();
            Usuario usr = BuscarUsuario(usrlist, RUT);
            evt.Organizador = usr.Username;
            evt.UUID = usr.UUID;
            evt.CodigoEvento = UUIDGenerator(32);
            eventlist.Add(evt);
            Console.WriteLine();
            Console.WriteLine($"El evento \"{evt.NombreEvento}\" ha sido agregado con exito.");
            Console.WriteLine();
        }

        public Evento BuscarEvento(List<Evento> eventlist, string nomEvento)
        {
            Evento evt = new Evento();
            try
            {
                evt = eventlist.Single(s => s.NombreEvento.Equals(nomEvento));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            return evt;
        }

        public void EliminarEvento(List<Evento> eventlist)
        {
            Console.WriteLine();
            Console.WriteLine("Por favor, ingrese el nombre del evento a eliminar:");
            string nomEvento = Console.ReadLine();
            Evento evt = BuscarEvento(eventlist, nomEvento);
            eventlist.Remove(evt);
            Console.WriteLine($"El evento con el nombre: {nomEvento} ha sido eliminado con exito.");
            Console.WriteLine();
        }

        public void ListarUsuario(List<Usuario> usrlist)
        {
            foreach (Usuario a in usrlist)
            {
                Console.WriteLine();
                Console.WriteLine($"Nombre: {a.Username}");
                Console.WriteLine($"E-mail: {a.Email}");
                Console.WriteLine($"RUT: {a.RUT}");
                Console.WriteLine($"UUID: {a.UUID}");
                Console.WriteLine();
                System.Threading.Thread.Sleep(50);
            }
        }
        public void ListarEvento(List<Evento> evtlist)
        {
            foreach (Evento a in evtlist)
            {
                Console.WriteLine();
                Console.WriteLine($"Nombre: {a.NombreEvento}");
                Console.WriteLine($"Organizador(a): {a.Organizador}");
                Console.WriteLine($"Valor: ${a.ValorEvento}");
                Console.WriteLine($"Quorum: {a.QuorumEvento} Personas");
                Console.WriteLine($"UUID Evento: {a.CodigoEvento}");
                Console.WriteLine();
                System.Threading.Thread.Sleep(50);
            }
        }

        public static int ValidateInt()
        {
            int num = 0;
            while (num == 0)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return num;
        }
        //metodo temporal para inicializar campos de datos
        public void InicializarCampos(List<Usuario> usrlist, List<Evento> evtlist)
        {
            string[] usernames = {"Alex", "Alexander", "Cristian", "Bastian", "Luna", "Joaquin", "Diego", "Benjamin", "Alfredo", "Sebastian", "Artemisa", "Selene", "Nyx", "Javiera", "Selma"};
            string[] rut = { "69696969-1", "69696969-2", "69696969-3", "69696969-4", "19363100-2", "69696969-5", "69696969-6", "69696969-7", "69696969-8", "69696969-9", "69696969-0", "69696969-K", "69696969-10", "69696969-11", "69696969-12" };
            for (int i=0; i<usernames.Length-1; i++)
            {
                Usuario usr = new Usuario();
                usr.Username = usernames[i];
                usr.Password = UUIDGenerator(16);
                usr.Email = $"{UUIDGenerator(12)}@mail.cl";
                usr.RUT = rut[i];
                usr.UUID = UUIDGenerator(32);
                usrlist.Add(usr);
            }
        }
    }
}
