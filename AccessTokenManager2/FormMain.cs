using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessTokenManager2
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// GUI der Anwendung
        /// </summary>
        private OAuthTools oAuthTools;
        private List<SocialNetwork> socialNetworks;
        private int selectedNetwork;

        public FormMain(OAuthTools c, List<SocialNetwork> sn)
        {
            InitializeComponent();
            oAuthTools = c;
            socialNetworks = sn;

            //für das Browser-Steuerelement muss in der Registry
            //die Internet-Explorer-Version eingestellt werden, die
            //es simmulieren soll (ansonsten ist die Version 7 voreingestellt,
            //was den Browser sozusagen unbruachbar macht)
            //die folgende Zeile stellt IE Version 11 ein:
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    AppDomain.CurrentDomain.FriendlyName, "11000", RegistryValueKind.DWord);
        }

        private void checkBoxAuthGrant_CheckedChanged(object sender, EventArgs e)
        {

            //Fehlermeldung wenn der Modus nicht unterstützt wird 
            if (checkBoxAuthGrant.Checked && socialNetworks.ElementAt(selectedNetwork).GrantType=="implicit")
            {
                MessageBox.Show("Attention: " + socialNetworks.ElementAt(selectedNetwork).NetworkName + " does not Support Grant Type Auth-Code!");
            }

            if (!checkBoxAuthGrant.Checked && socialNetworks.ElementAt(selectedNetwork).GrantType == "code")
            {
                MessageBox.Show("Attention: " + socialNetworks.ElementAt(selectedNetwork).NetworkName + " does not Support Grant Type Implicit!");
            }

            // für erhöhte Benutzerfreundlichkeit Endpoint und Secret Textbox-Felder ggf. ausblenden
            if (checkBoxAuthGrant.Checked)
            {
                textBoxClientSecret.Enabled = true;
                labelClientSecret.Enabled = true;

                labelEndpoint.Enabled = true;
                textBoxEndpoint.Enabled = true;
            }
            else
            {
                textBoxClientSecret.Enabled = false;
                labelClientSecret.Enabled = false;

                labelEndpoint.Enabled = false;
                textBoxEndpoint.Enabled = false;
            }

            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            string errorMessage = "";

            //erforderliche Felder prüfen
            if (textBoxClientID.Text == "")
            {
                errorMessage = "Client ID missing!\r\n";
            }
            if (textBoxRedirectionUrl.Text == "")
            {
                errorMessage += "Redirection URL missing!\r\n";
            }
            if (textBoxAuthServer.Text == "")
            {
                errorMessage += "Auth Server URL missing!\r\n";
            }
            if (errorMessage!="")
            {
                MessageBox.Show("ERROR: " + errorMessage);
                return;
            }

            // URL für den API Aufruf zusammenstellen
            string targetUrl = textBoxAuthServer.Text;
            if (checkBoxAuthGrant.Checked)
            {
                //Grant Type Auth-Code
                targetUrl += "?response_type=code";

            }
            else
            {
                //Grant Type Implicit
                targetUrl += "?response_type=token";
            }

            targetUrl += "&client_id=" + textBoxClientID.Text;
            targetUrl += "&redirect_uri=" + textBoxRedirectionUrl.Text;

            // ggf. noch Scopes anhängen
            if (comboBoxScope.Text !="")
            {
                targetUrl += "&scope=" + comboBoxScope.Text;
            }
            textBoxNavigation.Text = targetUrl;
            
            //URL an Browser übergeben
            webBrowser1.Navigate(targetUrl);
            logMessage("Navigate to " + targetUrl);
                
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ggf. Einstellungen speichern
            if (checkBoxSave.Checked)
            {
                Properties.Settings.Default.SelectedSetting = comboBoxSettings.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonOpenUrl_Click(object sender, EventArgs e)
        {
            //der interne Browser kann auch zum "manuellen" navigieren verwendet werden,#
            //z. B. um sich bei dem Social Network abzumelden 
            webBrowser1.Navigate(textBoxNavigation.Text);
            logMessage("Manual navigate to " + textBoxNavigation.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            //Wenn der Browser die Zielseite geladen hat wird diese analysiert,
            //ob hier ggf. ein Access-Token oder Code zurückgegeben wurde

            textBoxNavigation.Text = webBrowser1.Url.ToString();
            logMessage("Document completed: " + webBrowser1.Url.ToString());

            //ist in der URL bereits ein Access-Token?
            if (textBoxNavigation.Text.Contains("access_token="))
            {
                string accesstoken = oAuthTools.parseParameter(textBoxNavigation.Text,"access_token");                
                logMessage("Access Token found: " + accesstoken);
                textBoxAccessToken.Text = accesstoken;
                textBoxAccessToken.BackColor = Color.LightGreen;
                buttonStart.Enabled = true;
            }
            //Oder Auth-Code?
            else if (textBoxNavigation.Text.Contains("code="))
            {
                string code = oAuthTools.parseParameter(textBoxNavigation.Text, "code");
                logMessage("Code Token found: " + code);

                string parametersForPost = ""
                    + "client_id=" + textBoxClientID.Text
                    + "&client_secret=" + textBoxClientSecret.Text
                    + "&grant_type=authorization_code"
                    + "&redirect_uri=" + textBoxRedirectionUrl.Text
                    + "&code=" + code;

                logMessage("Get Access Token with Code, Params: " + parametersForPost);

                string antwort=oAuthTools.getTokenWithAuthCode(parametersForPost, textBoxEndpoint.Text);

                logMessage("Response: " + antwort);

                if (!antwort.Contains("Error"))
                {
                    textBoxAccessToken.Text = antwort;
                    logMessage("Access Token found: " + antwort);
                    textBoxAccessToken.BackColor = Color.LightGreen;
                }


            }

        }

        private void logMessage(string message)
        {
            textBoxLog.Text = DateTime.Now.ToString()
                + ": "
                + message 
                + "\r\n"
                + textBoxLog.Text;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            //Combo-Box füllen
            for (int i = 0; i < socialNetworks.Count; i++)
            {
                comboBoxSettings.Items.Add(socialNetworks.ElementAt(i).NetworkName);
            }

            //Welche Setting wurde zuletzt ausgewählt?
            comboBoxSettings.SelectedIndex = Properties.Settings.Default.SelectedSetting;

            //keins ausgewählt? Dann auf Facebook = 0 setzten
            if (comboBoxSettings.SelectedIndex == -1)
            {
                comboBoxSettings.SelectedIndex = 0;
            }

            if (checkBoxAuthGrant.Checked)
            {
                textBoxClientSecret.Enabled = true;
                labelClientSecret.Enabled = true;

                textBoxEndpoint.Enabled = true;                
                labelEndpoint.Enabled = true;
                
            }

            //Version in Log ausgeben (nicht möglich in Debug)
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                logMessage("Access Token Manager Version " + ApplicationDeployment.CurrentDeployment.CurrentVersion + " started.");
            }
            
        }

        private void comboBoxSettings_SelectedIndexChanged(object sender, EventArgs e)
        {

            //wird in der Settings-Combobox ein anderes Social Network gewählt
            //werden die entsprechenden Daten im Formular angezeigt

            selectedNetwork = comboBoxSettings.SelectedIndex;

            if (socialNetworks.ElementAt(selectedNetwork).RedirectUri!="")
            {
                textBoxRedirectionUrl.Text = socialNetworks.ElementAt(selectedNetwork).RedirectUri;
            }

            textBoxAuthServer.Text = socialNetworks.ElementAt(selectedNetwork).AuthServer;
            textBoxEndpoint.Text = socialNetworks.ElementAt(selectedNetwork).Endpoint;
            labelDescription.Text = "Notice:\n " + socialNetworks.ElementAt(selectedNetwork).Description;

            if (socialNetworks.ElementAt(selectedNetwork).GrantType== "implicit")
            {
                checkBoxAuthGrant.Checked = false;                
            }
            else if (socialNetworks.ElementAt(selectedNetwork).GrantType == "code")
            {
                checkBoxAuthGrant.Checked = true;                
            }

            //Knöpfe beschriften
            buttonApiTestA.Text = socialNetworks.ElementAt(selectedNetwork).ButtonA;
            buttonApiTestB.Text = socialNetworks.ElementAt(selectedNetwork).ButtonB;
            buttonApiTestC.Text = socialNetworks.ElementAt(selectedNetwork).ButtonC;

            //Group Box
            groupBoxInfo.Text = socialNetworks.ElementAt(selectedNetwork).NetworkName;

            //Scopes Dropdown befüllen
            comboBoxScope.Items.Clear();
            for (int i = 0; i < socialNetworks.ElementAt(selectedNetwork).Scopes.Count; i++)
            {
                comboBoxScope.Items.Add(socialNetworks.ElementAt(selectedNetwork).Scopes.ElementAt(i).ScopeName);
            }

        }

        private void sendTestApiCall(string api)
        {

            //API-Call ohne Webbrowser (der IE stellt JSON-Daten nicht sinnvoll da,
            //deshalb ist es besser, diese mit einem WebClient zu laden

            logMessage("API call with Access token: " + api);

            string ergebnis = oAuthTools.getJsonData(api);

            logMessage("Response: " + ergebnis);

            //das Ergebnis wird im Webbrowser angezeigt
            webBrowser1.DocumentText = "<pre>" + ergebnis + "</pre>";
        }

        //-----------------------------------------------------------------
        //die drei API-Test-Buttons

        private void buttonApiTestA_Click(object sender, EventArgs e)
        {

            string api = socialNetworks.ElementAt(selectedNetwork).ApiTestA
                    + textBoxAccessToken.Text;

            sendTestApiCall(api);

        }

        private void buttonApiTestB_Click(object sender, EventArgs e)
        {

            string api = socialNetworks.ElementAt(selectedNetwork).ApiTestB
                    + textBoxAccessToken.Text;

            sendTestApiCall(api);

        }

        private void buttonApiTestC_Click(object sender, EventArgs e)
        {

            string api = socialNetworks.ElementAt(selectedNetwork).ApiTestC
                    + textBoxAccessToken.Text;

            sendTestApiCall(api);

        }
        // Ende der API-Test-Knöpfe
        //-----------------------------------------------------------------

        private void linkLabelScopeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Info-Seite über weitere Scopes im Browser laden
            webBrowser1.Navigate(socialNetworks.ElementAt(selectedNetwork).ScopeInfo);
        }
    }
}
