using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace AccessTokenGenerator2
{
    [DataContract]
    class JsonAccessToken
    {
        /// <summary>
        /// Klasse für das Deserialisieren von JSON-Rückgabe
        /// </summary>
        [DataMember]
        public string access_token { get; set; }

        [DataMember]
        public int expires_in { get; set; }
    }
}
