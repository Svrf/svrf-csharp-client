namespace Svrf.Models.Http
{
    internal class AuthResponse
    {
        public string Token { get; internal set; }
        public int ExpiresIn { get; internal set; }
    }
}
