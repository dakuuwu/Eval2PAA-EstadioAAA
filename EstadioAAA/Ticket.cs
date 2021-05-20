using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Ticket
    {
        private string _uid, _rutCliente, _codEvento;

        public Ticket(string uid, string rutCliente, string codEvento)
        {
            _uid = uid;
            _rutCliente = rutCliente;
            _codEvento = codEvento;
        }

        public string UID { get => _uid; set => _uid = value; }
        public string RUTCliente { get => _rutCliente; set => _rutCliente = value; }
        public string CodEvento { get => _codEvento; set => _codEvento = value; }
    }
}
