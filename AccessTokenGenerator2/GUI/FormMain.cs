using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace AccessTokenGenerator2
{
    //TODO Link zu Projekt-Website, Lizenz-Info, Autor
    public partial class FormMain : Form
    {
        /// <summary>
        /// GUI der Anwendung
        /// </summary>
        private OAuthTools oAuthTools;
        private List<SocialNetwork> socialNetworks;
        private int selectedNetwork;
        private static bool firstRunComboBox=true;

        public FormMain(OAuthTools c, List<SocialNetwork> sn)
        {
            InitializeComponent();
            oAuthTools = c;
            socialNetworks = sn;

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

            //Reset des letzten Access-Token
            textBoxAccessToken.Text = "";
            textBoxAccessToken.BackColor = SystemColors.Control;
            
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
            //TODO Access Token abspeichern (verschlüsselt?)

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

            string[] ergebnis=oAuthTools.analyseBrowserResult(textBoxNavigation.Text,
                textBoxClientID.Text, textBoxClientSecret.Text, textBoxRedirectionUrl.Text, 
                textBoxEndpoint.Text);

            logMessage(ergebnis[1]);
            
            if (!ergebnis[0].Contains("error") && ergebnis[0] != "")
            {
                textBoxAccessToken.Text = ergebnis[0];
                logMessage("Access Token found: " + ergebnis[0]);
                textBoxAccessToken.Text = ergebnis[0];
                textBoxAccessToken.BackColor = Color.LightGreen;
            }
            else
            {
                //Fehler ausgeben
                logMessage(ergebnis[0]);
            }

            // Bei Aufrufen von "localhost" eine leere Seite einblenden um verwirrende 
            // Fehlermeldung (die keine ist) schnell auszublenden
            if (webBrowser1.Url.ToString().StartsWith("http://127")
                    || webBrowser1.Url.ToString().StartsWith("http://localhost")
                    || webBrowser1.Url.ToString().StartsWith("https://127")
                    || webBrowser1.Url.ToString().StartsWith("https://localhost")
                )
            {
                webBrowser1.Navigate("about:blank");
            }

        }

        private void logMessage(string message)
        {
            if (message != "")
            { 
                textBoxLog.Text = DateTime.Now.ToString()
                    + ": "
                    + message 
                    + "\r\n"
                    + textBoxLog.Text;
            }
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
                logMessage("Access Token Generator Version " + ApplicationDeployment.CurrentDeployment.CurrentVersion + " started.");
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

            //Access-Token löschen
            textBoxAccessToken.Text = "";


            //Scope löschen - nicht beim ersten Aufruf, da hier ggf. die Settings geladen werden
            if (!firstRunComboBox)
            { 
                comboBoxScope.Text = "";
            }

            firstRunComboBox = false;

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
