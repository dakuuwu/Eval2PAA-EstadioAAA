using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Ticket
    {
        private string _uuid, _rutCliente, _codEvento;

        public Ticket(string uuid, string rutCliente, string codEvento)
        {
            _uuid = uuid;
            _rutCliente = rutCliente;
            _codEvento = codEvento;
        }

        public string UUID { get => _uuid; set => _uuid = value; }
        public string RUTCliente { get => _rutCliente; set => _rutCliente = value; }
        public string CodEvento { get => _codEvento; set => _codEvento = value; }
    }
}
