namespace Svrf.Models.Http
{
    public class AuthResponse
    {
        public string Token { get; internal set; }
        public int ExpiresIn { get; internal set; }
    }
}
