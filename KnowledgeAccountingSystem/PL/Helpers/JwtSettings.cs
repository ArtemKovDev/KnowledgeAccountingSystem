namespace PL.Helpers
{
    /// <summary>
    /// Class that provides jwt settings
    /// </summary>
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
