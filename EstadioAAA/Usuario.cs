using System;
using System.Collections.Generic;
using System.Text;

namespace EstadioAAA
{
    class Usuario
    {
        private string _username, _password, _email, _uid, _rut;

        public Usuario(string username, string password, string email, string uid, string rut)
        {
            _username = username;
            _password = password;
            _email = email;
            _uid = uid;
            _rut = rut;
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string UID { get => _uid; set => _uid = value; }
        public string RUT { get => _rut; set => _rut = value; }
    }
}
