using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessTokenGenerator2
{
    public class SocialNetwork
    {
        /// <summary>
        /// Klasse für das Deserialisieren von SocialNetworks.xml (zusamme mit Scopes.cs)
        /// </summary>
        public string NetworkName
        { get; set; }

        public string RedirectUri
        { get; set; }

        public string AuthServer
        { get; set; }

        public string Endpoint
        { get; set; }

        public string Description
        { get; set; }

        public string GrantType
        { get; set; }

        public string ButtonA
        { get; set; }

        public string ApiTestA
        { get; set; }

        public string ButtonB
        { get; set; }

        public string ApiTestB
        { get; set; }

        public string ButtonC
        { get; set; }

        public string ApiTestC
        { get; set; }

        public string ScopeInfo
        { get; set; }

        public List<Scope> Scopes
        { get; set; }

    }
}
