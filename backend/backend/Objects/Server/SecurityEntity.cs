namespace backend.Objects.DTOs.Entities
{
    public class SecurityEntity
    {
        public string Issuer { get; } = "Server API";
        public string Audience { get; } = "WebSite";
        public string Key { get; } = "SGED_BarramentUser_API_Autentication";
    }
}