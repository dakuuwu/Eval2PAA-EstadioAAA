using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Boleta
    {
        private string _uuid, _ticketID;
        private int _valorBoleta;

        public Boleta(string uuid, string ticketID, int valorBoleta)
        {
            _uuid = uuid;
            _ticketID = ticketID;
            _valorBoleta = valorBoleta;
        }

        public string UUID { get => _uuid; set => _uuid = value; }
        public string TicketID { get => _ticketID; set => _ticketID = value; }
        public int ValorBoleta { get => _valorBoleta; set => _valorBoleta = value; }

        
    }



}
