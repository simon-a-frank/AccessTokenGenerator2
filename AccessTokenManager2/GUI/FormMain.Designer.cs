namespace AccessTokenManager2
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxScope = new System.Windows.Forms.ComboBox();
            this.linkLabelScopeInfo = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelClientSecret = new System.Windows.Forms.Label();
            this.labelEndpoint = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonApiTestC = new System.Windows.Forms.Button();
            this.buttonApiTestB = new System.Windows.Forms.Button();
            this.buttonApiTestA = new System.Windows.Forms.Button();
            this.textBoxEndpoint = new System.Windows.Forms.TextBox();
            this.comboBoxSettings = new System.Windows.Forms.ComboBox();
            this.checkBoxAuthGrant = new System.Windows.Forms.CheckBox();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.textBoxAccessToken = new System.Windows.Forms.TextBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAuthServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRedirectionUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBoxNavigation = new System.Windows.Forms.TextBox();
            this.buttonOpenUrl = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.comboBoxScope);
            this.groupBox1.Controls.Add(this.linkLabelScopeInfo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labelClientSecret);
            this.groupBox1.Controls.Add(this.labelEndpoint);
            this.groupBox1.Controls.Add(this.groupBoxInfo);
            this.groupBox1.Controls.Add(this.textBoxEndpoint);
            this.groupBox1.Controls.Add(this.comboBoxSettings);
            this.groupBox1.Controls.Add(this.checkBoxAuthGrant);
            this.groupBox1.Controls.Add(this.textBoxClientSecret);
            this.groupBox1.Controls.Add(this.textBoxAccessToken);
            this.groupBox1.Controls.Add(this.checkBoxSave);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxAuthServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxRedirectionUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxClientID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 689);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OAuth 2.0 Settings";
            // 
            // comboBoxScope
            // 
            this.comboBoxScope.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "Scope", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxScope.FormattingEnabled = true;
            this.comboBoxScope.Location = new System.Drawing.Point(9, 179);
            this.comboBoxScope.Name = "comboBoxScope";
            this.comboBoxScope.Size = new System.Drawing.Size(435, 21);
            this.comboBoxScope.TabIndex = 4;
            this.comboBoxScope.Text = global::AccessTokenManager2.Properties.Settings.Default.Scope;
            // 
            // linkLabelScopeInfo
            // 
            this.linkLabelScopeInfo.AutoSize = true;
            this.linkLabelScopeInfo.Location = new System.Drawing.Point(414, 163);
            this.linkLabelScopeInfo.Name = "linkLabelScopeInfo";
            this.linkLabelScopeInfo.Size = new System.Drawing.Size(30, 13);
            this.linkLabelScopeInfo.TabIndex = 20;
            this.linkLabelScopeInfo.TabStop = true;
            this.linkLabelScopeInfo.Text = "more";
            this.linkLabelScopeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelScopeInfo_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Access Token:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Social Network:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelClientSecret
            // 
            this.labelClientSecret.AutoSize = true;
            this.labelClientSecret.Enabled = false;
            this.labelClientSecret.Location = new System.Drawing.Point(7, 284);
            this.labelClientSecret.Name = "labelClientSecret";
            this.labelClientSecret.Size = new System.Drawing.Size(224, 13);
            this.labelClientSecret.TabIndex = 12;
            this.labelClientSecret.Text = "Client Secret (App Secret / Consumer Secret):";
            // 
            // labelEndpoint
            // 
            this.labelEndpoint.AutoSize = true;
            this.labelEndpoint.Enabled = false;
            this.labelEndpoint.Location = new System.Drawing.Point(7, 323);
            this.labelEndpoint.Name = "labelEndpoint";
            this.labelEndpoint.Size = new System.Drawing.Size(155, 13);
            this.labelEndpoint.TabIndex = 12;
            this.labelEndpoint.Text = "Access Token Endpoint (URL):";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxInfo.Controls.Add(this.label7);
            this.groupBoxInfo.Controls.Add(this.labelDescription);
            this.groupBoxInfo.Controls.Add(this.buttonApiTestC);
            this.groupBoxInfo.Controls.Add(this.buttonApiTestB);
            this.groupBoxInfo.Controls.Add(this.buttonApiTestA);
            this.groupBoxInfo.Location = new System.Drawing.Point(10, 492);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(434, 191);
            this.groupBoxInfo.TabIndex = 17;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "NetworkName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "API Tests (Access-Token required):";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDescription.Location = new System.Drawing.Point(6, 78);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(414, 110);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            // 
            // buttonApiTestC
            // 
            this.buttonApiTestC.Location = new System.Drawing.Point(290, 43);
            this.buttonApiTestC.Name = "buttonApiTestC";
            this.buttonApiTestC.Size = new System.Drawing.Size(129, 23);
            this.buttonApiTestC.TabIndex = 13;
            this.buttonApiTestC.Text = "C";
            this.buttonApiTestC.UseVisualStyleBackColor = true;
            this.buttonApiTestC.Click += new System.EventHandler(this.buttonApiTestC_Click);
            // 
            // buttonApiTestB
            // 
            this.buttonApiTestB.Location = new System.Drawing.Point(148, 43);
            this.buttonApiTestB.Name = "buttonApiTestB";
            this.buttonApiTestB.Size = new System.Drawing.Size(129, 23);
            this.buttonApiTestB.TabIndex = 12;
            this.buttonApiTestB.Text = "B";
            this.buttonApiTestB.UseVisualStyleBackColor = true;
            this.buttonApiTestB.Click += new System.EventHandler(this.buttonApiTestB_Click);
            // 
            // buttonApiTestA
            // 
            this.buttonApiTestA.Location = new System.Drawing.Point(6, 43);
            this.buttonApiTestA.Name = "buttonApiTestA";
            this.buttonApiTestA.Size = new System.Drawing.Size(129, 23);
            this.buttonApiTestA.TabIndex = 11;
            this.buttonApiTestA.Text = "A";
            this.buttonApiTestA.UseVisualStyleBackColor = true;
            this.buttonApiTestA.Click += new System.EventHandler(this.buttonApiTestA_Click);
            // 
            // textBoxEndpoint
            // 
            this.textBoxEndpoint.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "Endpoint", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxEndpoint.Enabled = false;
            this.textBoxEndpoint.Location = new System.Drawing.Point(10, 339);
            this.textBoxEndpoint.Name = "textBoxEndpoint";
            this.textBoxEndpoint.Size = new System.Drawing.Size(434, 20);
            this.textBoxEndpoint.TabIndex = 8;
            this.textBoxEndpoint.Text = global::AccessTokenManager2.Properties.Settings.Default.Endpoint;
            // 
            // comboBoxSettings
            // 
            this.comboBoxSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSettings.FormattingEnabled = true;
            this.comboBoxSettings.Location = new System.Drawing.Point(155, 23);
            this.comboBoxSettings.Name = "comboBoxSettings";
            this.comboBoxSettings.Size = new System.Drawing.Size(289, 24);
            this.comboBoxSettings.TabIndex = 1;
            this.comboBoxSettings.SelectedIndexChanged += new System.EventHandler(this.comboBoxSettings_SelectedIndexChanged);
            // 
            // checkBoxAuthGrant
            // 
            this.checkBoxAuthGrant.Checked = global::AccessTokenManager2.Properties.Settings.Default.UserAuthCode;
            this.checkBoxAuthGrant.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AccessTokenManager2.Properties.Settings.Default, "UserAuthCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAuthGrant.Location = new System.Drawing.Point(9, 256);
            this.checkBoxAuthGrant.Name = "checkBoxAuthGrant";
            this.checkBoxAuthGrant.Size = new System.Drawing.Size(422, 25);
            this.checkBoxAuthGrant.TabIndex = 6;
            this.checkBoxAuthGrant.Text = "Instead of \'Implicit\' use \'Authorization Code\' (Client Secret and Endpoint requir" +
    "ed):";
            this.checkBoxAuthGrant.UseVisualStyleBackColor = true;
            this.checkBoxAuthGrant.CheckedChanged += new System.EventHandler(this.checkBoxAuthGrant_CheckedChanged);
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "ClientSecret", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxClientSecret.Enabled = false;
            this.textBoxClientSecret.Location = new System.Drawing.Point(10, 300);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.Size = new System.Drawing.Size(434, 20);
            this.textBoxClientSecret.TabIndex = 7;
            this.textBoxClientSecret.Text = global::AccessTokenManager2.Properties.Settings.Default.ClientSecret;
            // 
            // textBoxAccessToken
            // 
            this.textBoxAccessToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccessToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccessToken.Location = new System.Drawing.Point(10, 439);
            this.textBoxAccessToken.Multiline = true;
            this.textBoxAccessToken.Name = "textBoxAccessToken";
            this.textBoxAccessToken.ReadOnly = true;
            this.textBoxAccessToken.Size = new System.Drawing.Size(434, 47);
            this.textBoxAccessToken.TabIndex = 10;
            this.textBoxAccessToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Checked = true;
            this.checkBoxSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSave.Location = new System.Drawing.Point(361, 0);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(83, 17);
            this.checkBoxSave.TabIndex = 15;
            this.checkBoxSave.Text = "save on exit";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(9, 376);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(435, 42);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start Authorization Flow and fetch Access Token";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Authorization Server (URL)";
            // 
            // textBoxAuthServer
            // 
            this.textBoxAuthServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "AuthServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAuthServer.Location = new System.Drawing.Point(9, 230);
            this.textBoxAuthServer.Name = "textBoxAuthServer";
            this.textBoxAuthServer.Size = new System.Drawing.Size(435, 20);
            this.textBoxAuthServer.TabIndex = 5;
            this.textBoxAuthServer.Text = global::AccessTokenManager2.Properties.Settings.Default.AuthServer;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Scope (Permissions)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Redirection URI";
            // 
            // textBoxRedirectionUrl
            // 
            this.textBoxRedirectionUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "RedirUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRedirectionUrl.Location = new System.Drawing.Point(9, 128);
            this.textBoxRedirectionUrl.Name = "textBoxRedirectionUrl";
            this.textBoxRedirectionUrl.Size = new System.Drawing.Size(435, 20);
            this.textBoxRedirectionUrl.TabIndex = 3;
            this.textBoxRedirectionUrl.Text = global::AccessTokenManager2.Properties.Settings.Default.RedirUrl;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client ID (App ID / Consumer ID)";
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AccessTokenManager2.Properties.Settings.Default, "ClientId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxClientID.Location = new System.Drawing.Point(9, 77);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(435, 20);
            this.textBoxClientID.TabIndex = 2;
            this.textBoxClientID.Text = global::AccessTokenManager2.Properties.Settings.Default.ClientId;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(468, 568);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(693, 133);
            this.textBoxLog.TabIndex = 13;
            this.textBoxLog.WordWrap = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(468, 40);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(693, 522);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // textBoxNavigation
            // 
            this.textBoxNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNavigation.Location = new System.Drawing.Point(566, 14);
            this.textBoxNavigation.Name = "textBoxNavigation";
            this.textBoxNavigation.Size = new System.Drawing.Size(544, 20);
            this.textBoxNavigation.TabIndex = 0;
            // 
            // buttonOpenUrl
            // 
            this.buttonOpenUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenUrl.Location = new System.Drawing.Point(1116, 14);
            this.buttonOpenUrl.Name = "buttonOpenUrl";
            this.buttonOpenUrl.Size = new System.Drawing.Size(45, 20);
            this.buttonOpenUrl.TabIndex = 3;
            this.buttonOpenUrl.Text = ">";
            this.buttonOpenUrl.UseVisualStyleBackColor = true;
            this.buttonOpenUrl.Click += new System.EventHandler(this.buttonOpenUrl_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adress (Browser):";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 713);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonOpenUrl);
            this.Controls.Add(this.textBoxNavigation);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Access Token Generator for Auth 2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRedirectionUrl;
        private System.Windows.Forms.Label labelEndpoint;
        private System.Windows.Forms.TextBox textBoxEndpoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAuthServer;
        private System.Windows.Forms.Label labelClientSecret;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBoxNavigation;
        private System.Windows.Forms.Button buttonOpenUrl;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAccessToken;
        private System.Windows.Forms.CheckBox checkBoxAuthGrant;
        private System.Windows.Forms.ComboBox comboBoxSettings;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonApiTestC;
        private System.Windows.Forms.Button buttonApiTestB;
        private System.Windows.Forms.Button buttonApiTestA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxScope;
        private System.Windows.Forms.LinkLabel linkLabelScopeInfo;
    }
}

