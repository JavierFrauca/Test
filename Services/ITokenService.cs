namespace TEST.Services
{
    public interface ITokenService
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Validate(string token, string ip);
        public (bool, string) Create(string ip, string user, string pass);
    }
}
