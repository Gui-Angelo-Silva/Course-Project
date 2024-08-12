using Jose;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace backend.Objects.DTOs.Entities
{
    public class Token
    {
        [Required(ErrorMessage = "O token é requerido!")]
        public string TokenAccess { get; set; }


        public void GenerateToken(string email)
        {
            SecurityEntity securityEntity = new();

            var payload = new Dictionary<string, object>
            {
                { "iss", securityEntity.Issuer },
                { "aud", securityEntity.Audience },
                { "sub", email },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds() }
            };

            this.TokenAccess = JWT.Encode(payload, Encoding.UTF8.GetBytes(securityEntity.Key), JwsAlgorithm.HS256);
        }

        public bool ValidateToken()
        {
            SecurityEntity securityEntity = new();

            // Passo 1: Verificar se o token tem três partes
            string[] tokenParts = this.TokenAccess.Split('.');
            if (tokenParts.Length != 3)
            {
                return false;
            }

            try
            {
                // Passo 2: Decodificar o token
                string decodedToken = Encoding.UTF8.GetString(Base64Url.Decode(tokenParts[1]));

                // Passo 3: Verificar issue, audience e subject
                var payload = JsonConvert.DeserializeObject<Dictionary<string, object>>(decodedToken);
                if (!payload.TryGetValue("iss", out object issuerClaim) ||
                    !payload.TryGetValue("aud", out object audienceClaim))
                {
                    return false;
                }

                if (issuerClaim.ToString() != securityEntity.Issuer || audienceClaim.ToString() != securityEntity.Audience)
                {
                    return false;
                }

                // Passo 4: Verificar se o tempo expirou
                if (payload.TryGetValue("exp", out object expirationClaim))
                {
                    long expirationTime = long.Parse(expirationClaim.ToString());
                    var expirationDateTime = DateTimeOffset.FromUnixTimeSeconds(expirationTime).UtcDateTime;
                    if (expirationDateTime < DateTime.UtcNow)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                // Passo 5: Se tudo estiver certo
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}