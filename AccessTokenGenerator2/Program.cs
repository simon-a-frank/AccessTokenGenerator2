using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


//TODO alle Kommentare übersetzen
namespace AccessTokenGenerator2
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

            //Registry-Check for WebBrowser-Update
            //für das Browser-Steuerelement muss in der Registry
            //die Internet-Explorer-Version eingestellt werden, die
            //es simmulieren soll (ansonsten ist die Version 7 voreingestellt,
            //was den Browser sozusagen unbruachbar macht)

            //Hier wird geprüft ob es den Registry-Eintrag gibt
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\" 
                                + @"Main\FeatureControl\FEATURE_BROWSER_EMULATION\");
            try
            {
                string v = key.GetValue(AppDomain.CurrentDomain.FriendlyName).ToString();
                //MessageBox.Show("Registry-Value exists (" + v + ")");
                //beim debuggen entsteht ein merkwürdiger Fehler - Schlüssel wird angezeigt ist aber nicht in der Registry!
                //dies ist jedoch nur an dem Rechner, an dem Visual Studio installiert wird, ansonsten funktioniert das
            }
            catch
            {
                //jetzt muss die Registry angelegt werden!
                MessageBox.Show("Error: Registry-Setting missing - Updating ...");
                //TODO: Yes or now?
                
                //folgendes geht leider nicht für ClickOnce-Anwendungen, das benötigt Admin-Rechte
                //Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                //    AppDomain.CurrentDomain.FriendlyName, "11000", RegistryValueKind.DWord);

                //deshalb: regedit mit Datei starten
                string p = "/s " + System.IO.Path.GetDirectoryName(System
                    .Reflection
                    .Assembly
                    .GetExecutingAssembly()
                    .Location) + @"\regupdate.reg";

                Process regeditProcess = Process.Start("regedit.exe", p);
                regeditProcess.WaitForExit();
            }


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
