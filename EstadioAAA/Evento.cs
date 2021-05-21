using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Evento
    {
        private String _nombreEvento, _codigoEvento, _organizador, _descEvento, _uuid;
        private DateTime _fechaEvento;
        private int _valorEvento, _quorumEvento;

        public Evento()
        {
        }

        public Evento(string nombreEvento, string codigoEvento, string organizador, string descEvento, string uuid, DateTime fechaEvento, int valorEvento, int quorumEvento)
        {
            _nombreEvento = nombreEvento;
            _codigoEvento = codigoEvento;
            _organizador = organizador;
            _descEvento = descEvento;
            _uuid = uuid;
            _fechaEvento = fechaEvento;
            _valorEvento = valorEvento;
            _quorumEvento = quorumEvento;
        }

        public string NombreEvento { get => _nombreEvento; set => _nombreEvento = value; }
        public string CodigoEvento { get => _codigoEvento; set => _codigoEvento = value; }
        public string Organizador { get => _organizador; set => _organizador = value; }
        public string DescEvento { get => _descEvento; set => _descEvento = value; }
        public string UUID { get => _uuid; set => _uuid = value; }
        public DateTime FechaEvento { get => _fechaEvento; set => _fechaEvento = value; }
        public int ValorEvento { get => _valorEvento; set => _valorEvento = value; }
        public int QuorumEvento { get => _quorumEvento; set => _quorumEvento = value; }
    }
}
