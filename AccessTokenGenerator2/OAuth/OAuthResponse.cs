using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessTokenGenerator2
{
    public class OAuthResponse
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
        public string accessToken { get; set; }
        public int expires { get; set; }
        public string refreshToken { get; set; }

    }
}
