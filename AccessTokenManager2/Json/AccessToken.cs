using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace AccessTokenManager2
{
    [DataContract]
    class JsonAccessToken
    {
        /// <summary>
        /// Klasse für das Deserialisieren von JSON-Rückgabe
        /// </summary>
        [DataMember]
        public string access_token { get; set; }

        //es gibt teilweise noch andere Felder, z. B. "expires" - diese werden hier nicht benötigt
        //[DataMember]
        //public int expires { get; set; }
    }
}
