namespace Identity.API.Configuration
{
    public class AppSetting
    {
         public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public string TokenUserName { get; set; }
        public string TokenPassword { get; set; }
        public int TokenExpirationSeconds { get; set; }
    }
}
