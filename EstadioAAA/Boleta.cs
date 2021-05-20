using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Boleta
    {
        private string _uid, _ticketID;
        private int _valorBoleta;

        public Boleta(string uid, string ticketID, int valorBoleta)
        {
            _uid = uid;
            _ticketID = ticketID;
            _valorBoleta = valorBoleta;
        }

        public string UID { get => _uid; set => _uid = value; }
        public string TicketID { get => _ticketID; set => _ticketID = value; }
        public int ValorBoleta { get => _valorBoleta; set => _valorBoleta = value; }

        
    }



}
