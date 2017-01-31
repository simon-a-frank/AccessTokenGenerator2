using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


//TODO alle Kommentare übersetzen
namespace AccessTokenManager2
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            XmlSerializer deserializer = new XmlSerializer(typeof(List<SocialNetwork>));
            TextReader textReader = new StreamReader(@"SocialNetworks.xml");
            List<SocialNetwork> socialNetworks;
            socialNetworks = (List<SocialNetwork>)deserializer.Deserialize(textReader);
            textReader.Close();

            OAuthTools atmControler = new OAuthTools();

            Application.Run(new FormMain(atmControler, socialNetworks));
        }
    }
}
