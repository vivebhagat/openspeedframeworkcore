using System;
using System.Text.Json.Serialization;
using WebApi.Entities;

namespace WebApi.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userName { get; set; }
        public string subdomain { get; set; }
        public string access_token { get; set; }
        public long expires_in { get; set; }
        public DateTime expires {get; set; }  //.expires
        public DateTime issued { get; set; }   //.issued
        public string client_id { get; set; } //as:client_id


        //   [JsonIgnore] // refresh token is returned in http only cookie
        public string refresh_token { get; set; }
        public string dataroute { get; set; }
        public string domainkey { get; set; }

        public string token_type { get; set; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken, DateTime issued, DateTime expires)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            userName = user.Username;
            access_token = jwtToken;
            refresh_token = refreshToken;
            token_type = "bearer";
            dataroute = user.DataRoute;
            domainkey = user.domainkey;
            expires_in = expires.Ticks - issued.Ticks;
            this.expires = expires;
            this.issued = issued;

        }
    }
}