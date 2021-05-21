namespace EstadioAAA
{
    class Usuario
    {
        private string _username, _password, _email, _uuid, _rut;

        public Usuario()
        {
        }

        public Usuario(string username, string password, string email, string uuid, string rut)
        {
            _username = username;
            _password = password;
            _email = email;
            _uuid = uuid;
            _rut = rut;
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string UUID { get => _uuid; set => _uuid = value; }
        public string RUT { get => _rut; set => _rut = value; }
    }
}
