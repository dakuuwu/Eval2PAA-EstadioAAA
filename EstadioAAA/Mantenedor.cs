using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            Usuario usr = new Usuario();
            System.Console.WriteLine("Por favor, ingrese el nombre del cliente:");
            usr.Username = System.Console.ReadLine();
            System.Console.WriteLine("Por favor, ingrese la contraseña del cliente:");
            usr.Password = System.Console.ReadLine();
            System.Console.WriteLine("Por favor, ingrese el e-mail del cliente:");
            usr.Email = System.Console.ReadLine();
            System.Console.WriteLine("Por favor, ingrese el RUT del cliente:");
            usr.RUT = System.Console.ReadLine();
            usr.UUID = UUIDGenerator(8);
            usrlist.Add(usr);
            System.Console.WriteLine($"El usuario con el RUT: {usr.RUT} ha sido añadido con exito. UUID: {usr.UUID}");
        }

        public Usuario BuscarUsuario(List<Usuario> usrlist, string RUT)
        {
            Usuario usr = new Usuario();
            try
            {   
                usr = usrlist.Single(s => s.Equals(RUT));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            return usr;
        }

        public void EliminarUsuario(List<Usuario> usrlist)
        {
            System.Console.WriteLine("Por favor, ingrese el RUT del usuario a eliminar:");
            string RUT = System.Console.ReadLine();
            Usuario usr = BuscarUsuario(usrlist, RUT);
            usrlist.Remove(usr);
            System.Console.WriteLine($"El usuario con el RUT: {RUT} y el UUID: {usr.UUID} ha sido eliminado con exito.");
        }

        public void AddEvento(List<Evento> eventlist, List<Usuario> usrlist)
        {
            Evento evt = new Evento();
            System.Console.WriteLine("Por favor, ingrese el nombre del evento:");
            evt.NombreEvento = System.Console.ReadLine();
            System.Console.WriteLine("Por favor, ingrese la descripcion del evento:");
            evt.DescEvento = System.Console.ReadLine();
            System.Console.WriteLine("Por favor, ingrese el valor (en pesos) del evento:");
            int valor;
            Int32.TryParse(System.Console.ReadLine(), out valor);
            evt.ValorEvento = valor;
            System.Console.WriteLine("Por favor, ingrese el quorum maximo del evento:");
            int quorum;
            Int32.TryParse(System.Console.ReadLine(), out quorum);
            evt.QuorumEvento = quorum;
            System.Console.WriteLine("Por favor, ingrese el RUT del organizador:");
            string RUT = System.Console.ReadLine();
            Usuario usr = BuscarUsuario(usrlist, RUT);
            evt.Organizador = usr.Username;
            evt.UUID = usr.UUID;
            evt.CodigoEvento = UUIDGenerator(8);
            eventlist.Add(evt);
            System.Console.WriteLine($"El evento {evt.NombreEvento} ha sido agregado con exito.");
        }

        public Evento BuscarEvento(List<Evento> eventlist, string nomEvento)
        {
            Evento evt = new Evento();
            try
            {
                evt = eventlist.Single(s => s.Equals(nomEvento));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            return evt;
        }

        public void EliminarEvento(List<Evento> eventlist)
        {
            System.Console.WriteLine("Por favor, ingrese el nombre del evento a eliminar:");
            string nomEvento = System.Console.ReadLine();
            Evento evt = BuscarEvento(eventlist, nomEvento);
            eventlist.Remove(evt);
            System.Console.WriteLine($"El usuario con el RUT: {nomEvento} ha sido eliminado con exito.");
        }

    }
}
