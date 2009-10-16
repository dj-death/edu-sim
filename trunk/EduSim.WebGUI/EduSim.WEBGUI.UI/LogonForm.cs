#region Using

using System;
using System.Globalization;


using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using EduSim.UserManagementBL;
using EduSim.CoreFramework.DTO;
using System.Web;
using EduSim.WebGUI.UI;



#endregion

namespace Gizmox.WebGUI.Forms.Catalog
{
	#region Logon Class
	
	/// <summary>
	/// Impementation for Logon class.
	/// </summary>

    [Serializable()]
    public class LogonForm : Form ,ILogonForm
	{
	
		#region Classes

		/// <summary>
		/// Language option class
		/// </summary>

        [Serializable()]
        private class LanguageOption
		{
			private string mstrLabel;
			private string mstrCulture;

			/// <summary>
			/// Creates a new <see cref="LanguageOption"/> instance.
			/// </summary>
			/// <param name="strCulture">culture.</param>
			/// <param name="strLabel">label.</param>
			internal LanguageOption(string strCulture,string strLabel)
			{
				mstrCulture = strCulture;
				mstrLabel = strLabel;
			}

			/// <summary>
			/// Gets the culture.
			/// </summary>
			/// <value></value>
			public CultureInfo Culture
			{
				get
				{
					return new CultureInfo(mstrCulture);
				}
			}

			/// <summary>
			/// Returns the language label
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return mstrLabel;
			}

		}
		#endregion Classes

		#region Class Members

		private TextBox mobjTextUsername;
		private TextBox mobjTextPassword;
		private ComboBox mobjComboLanguage;
		private Button mobjButtonLogon;
		private Label mobjLabelPassword;
		private Label mobjLabelUsername;
		private Label mobjLabelLanguage;
		private CheckBox mobjCheckSavePassword;
		private Button mobjButtonClear;
		private Panel mobjPanelTitle;
		private Panel mobjPanelLine;
		private Label mobjLabelMessage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		#endregion

        BaseForm baseForm = null;

		#region C'Tor/D'Tor

		/// <summary>
		/// Creates a new <see cref="LogonForm"/> instance.
		/// </summary>
		public LogonForm( BaseForm baseForm)
		{
            this.baseForm = baseForm;

			InitializeComponent();

			#region Attach Events

			this.mobjButtonLogon.Click+=new EventHandler(mobjButtonLogon_Click);
			this.mobjButtonClear.Click+=new EventHandler(mobjButtonClear_Click);

			#endregion 


			this.Load+=new EventHandler(Logon_Load);

			this.mobjTextUsername.EnterKeyDown+=new KeyEventHandler(mobjTextUsername_EnterKeyDown);

            this.KeyDown += new KeyEventHandler(LogonForm_KeyDown);
		}

        void LogonForm_KeyDown(object objSender, KeyEventArgs objArgs)
        {
        }

		#endregion 

		#region Windows Form Designer generated code


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjTextUsername = new TextBox();
			this.mobjTextPassword = new TextBox();
			this.mobjComboLanguage = new ComboBox();
			this.mobjButtonLogon = new Button();
			this.mobjLabelPassword = new Label();
			this.mobjLabelUsername = new Label();
			this.mobjLabelLanguage = new Label();
			this.mobjCheckSavePassword = new CheckBox();
			this.mobjButtonClear = new Button();
			this.mobjPanelTitle = new Panel();
			this.mobjPanelLine = new Panel();
			this.mobjLabelMessage = new Label();
			this.SuspendLayout();
			// 
			// mobjTextUsername
			// 
			this.mobjTextUsername.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
			this.mobjTextUsername.Location = new System.Drawing.Point(88, 80);
			this.mobjTextUsername.Name = "mobjTextUsername";
			this.mobjTextUsername.Size = new System.Drawing.Size(192, 20);
			this.mobjTextUsername.TabIndex = 0;
			this.mobjTextUsername.Text = "";
			// 
			// mobjTextPassword
			// 
			this.mobjTextPassword.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
			this.mobjTextPassword.Location = new System.Drawing.Point(88, 112);
			this.mobjTextPassword.Name = "mobjTextPassword";
			this.mobjTextPassword.PasswordChar = '*';
			this.mobjTextPassword.Size = new System.Drawing.Size(192, 20);
			this.mobjTextPassword.TabIndex = 1;
			this.mobjTextPassword.Text = "";
			// 
			// mobjComboLanguage
			// 
			this.mobjComboLanguage.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
			this.mobjComboLanguage.Location = new System.Drawing.Point(88, 144);
			this.mobjComboLanguage.Name = "mobjComboLanguage";
			this.mobjComboLanguage.Size = new System.Drawing.Size(192, 20);
			this.mobjComboLanguage.TabIndex = 2;
			this.mobjComboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
			this.mobjComboLanguage.Items.AddRange(new object[]{
																  new LanguageOption("en-US","English"),
																  new LanguageOption("he-IL","Hebrew"),
                                                                    new LanguageOption("zh-CHS","Chinese (Simplified)")}
				);

			// 
			// mobjLabelLanguage
			// 
			this.mobjLabelLanguage.Location = new System.Drawing.Point(16, 144);
			this.mobjLabelLanguage.Name = "mobjLabelLanguage";
			this.mobjLabelLanguage.Size = new System.Drawing.Size(64, 23);
			this.mobjLabelLanguage.TabIndex = 3;
			this.mobjLabelLanguage.Text = "Language:";
			// 
			// mobjButtonLogon
			// 
			this.mobjButtonLogon.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonLogon.Location = new System.Drawing.Point(128, 232);
			this.mobjButtonLogon.Name = "mobjButtonLogon";
			this.mobjButtonLogon.Size = new System.Drawing.Size(72, 23);
			this.mobjButtonLogon.TabIndex = 5;
            this.mobjButtonLogon.Text = "Logon";
			// 
			// mobjLabelPassword
			// 
			this.mobjLabelPassword.Location = new System.Drawing.Point(16, 112);
			this.mobjLabelPassword.Name = "mobjLabelPassword";
			this.mobjLabelPassword.Size = new System.Drawing.Size(64, 23);
			this.mobjLabelPassword.TabIndex = 3;
			this.mobjLabelPassword.Text = "Password:";
			// 
			// mobjLabelUsername
			// 
			this.mobjLabelUsername.Location = new System.Drawing.Point(16, 80);
			this.mobjLabelUsername.Name = "mobjLabelUsername";
			this.mobjLabelUsername.Size = new System.Drawing.Size(64, 16);
			this.mobjLabelUsername.TabIndex = 4;
			this.mobjLabelUsername.Text = "Email:";
			// 
			// mobjCheckSavePassword
			// 
			this.mobjCheckSavePassword.FlatStyle = FlatStyle.Flat;
			this.mobjCheckSavePassword.Location = new System.Drawing.Point(88, 176);
			this.mobjCheckSavePassword.Name = "mobjCheckSavePassword";
			this.mobjCheckSavePassword.TabIndex = 3;
			this.mobjCheckSavePassword.Size	= new System.Drawing.Size(200,23);
			this.mobjCheckSavePassword.Text = "Save Password";
			// 
			// mobjButtonClear
			// 
			this.mobjButtonClear.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonClear.Location = new System.Drawing.Point(208, 232);
			this.mobjButtonClear.Name = "mobjButtonClear";
			this.mobjButtonClear.TabIndex = 6;
			this.mobjButtonClear.Text = "Clear";
			// 
			// mobjPanelTitle
			// 
			this.mobjPanelTitle.BackColor = System.Drawing.Color.White;
			this.mobjPanelTitle.Dock = DockStyle.Top;
			this.mobjPanelTitle.Location = new System.Drawing.Point(0, 0);
			this.mobjPanelTitle.Name = "mobjPanelTitle";
			this.mobjPanelTitle.Size = new System.Drawing.Size(292, 56);
			this.mobjPanelTitle.TabIndex = 7;
			// 
			// mobjPanelLine
			// 
			this.mobjPanelLine.BackColor = System.Drawing.SystemColors.Desktop;
			this.mobjPanelLine.Dock = DockStyle.Top;
			this.mobjPanelLine.Location = new System.Drawing.Point(0, 56);
			this.mobjPanelLine.Name = "mobjPanelLine";
			this.mobjPanelLine.Size = new System.Drawing.Size(292, 6);
			this.mobjPanelLine.TabIndex = 8;
			// 
			// mobjLabelMessage
			// 
			this.mobjLabelMessage.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
			this.mobjLabelMessage.ForeColor = System.Drawing.Color.Red;
			this.mobjLabelMessage.Location = new System.Drawing.Point(88, 208);
			this.mobjLabelMessage.Name = "mobjLabelMessage";
			this.mobjLabelMessage.Size = new System.Drawing.Size(272, 40);
			this.mobjLabelMessage.TabIndex = 9;
			// 
			// LogonForm
			// 			
			this.ClientSize = new System.Drawing.Size(292, 264);
			this.Controls.Add(this.mobjLabelLanguage);
			this.Controls.Add(this.mobjComboLanguage);
			this.Controls.Add(this.mobjLabelMessage);
			this.Controls.Add(this.mobjLabelUsername);
			this.Controls.Add(this.mobjLabelPassword);
			this.Controls.Add(this.mobjPanelLine);
			this.Controls.Add(this.mobjPanelTitle);
			this.Controls.Add(this.mobjTextPassword);
			this.Controls.Add(this.mobjTextUsername);
			this.Controls.Add(this.mobjButtonClear);
			this.Controls.Add(this.mobjCheckSavePassword);
			this.Controls.Add(this.mobjButtonLogon);
			this.Name = "LogonForm";
			this.Text = "Login";
			this.ResumeLayout(false);
			this.ClientSize = new System.Drawing.Size(292, 284);
		}
		#endregion

		private void mobjButtonLogon_Click(object sender, EventArgs e)
		{
			if(mobjCheckSavePassword.Checked)
			{
				Context.Cookies["Username"] = this.mobjTextUsername.Text;
				Context.Cookies["Password"] = this.mobjTextPassword.Text;
				Context.Cookies["Lang"] = this.mobjComboLanguage.SelectedIndex.ToString();
			}
			else
			{
				Context.Cookies["Username"] = "";
				Context.Cookies["Password"] = "";
				Context.Cookies["Lang"] = "0";
			}

            UserDetails user = UserManager.Instance.ValidateUser(this.mobjTextUsername.Text, this.mobjTextPassword.Text);
            if (user != null)
			{
                HttpContext.Current.Session[SessionConstants.CurrentUser] = user;
				Context.Session.IsLoggedOn = true;
				Context.CurrentUICulture = ((LanguageOption)mobjComboLanguage.SelectedItem).Culture;
				mobjLabelMessage.Text="";
                this.Close();
			}
			else
			{
				mobjLabelMessage.Text = "Invalid username or password.";
				Context.Session.IsLoggedOn = false;
			}
		}

		private void mobjButtonClear_Click(object sender, EventArgs e)
		{
			Context.Session.IsLoggedOn = false;
			mobjLabelMessage.Text="";
			mobjTextUsername.Text="";
			mobjTextUsername.Text="";

		}

		private void Logon_Load(object sender, EventArgs e)
		{
            if (Context.Cookies["Username"] != "")
            {
                this.mobjTextUsername.Text = Context.Cookies["Username"];
                this.mobjTextPassword.Text = Context.Cookies["Password"];

                if (Context.Cookies["Lang"] != "" && Context.Cookies["Lang"] != null)
                {
                    this.mobjComboLanguage.SelectedIndex = int.Parse(Context.Cookies["Lang"]);
                }
                this.mobjCheckSavePassword.Checked = true;

                this.mobjButtonLogon.Focus();
            }
            else
            {
                this.mobjTextUsername.Focus();
            }

			

			if(Context.Arguments!=null)
			{
				if(Context.Arguments["Username"]!=null)
				{
					
					//Context.Session.IsLoggedOn = true;
					//MessageBox.Show(Context.Arguments["Test"] as string);
				}
			}
		}

		private void mobjTextUsername_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			mobjButtonLogon_Click(mobjButtonLogon,EventArgs.Empty);
		}

        protected override void OnClosed(EventArgs e)
        {
            bool showLoginForm = false;
            if (string.IsNullOrEmpty(mobjTextUsername.Text) || string.IsNullOrEmpty(mobjTextPassword.Text))
                showLoginForm = true;
            else
            {
                UserDetails user = HttpContext.Current.Session[SessionConstants.CurrentUser] as UserDetails;
                if (user == null)
                    showLoginForm = true;
            }
            if (showLoginForm)
            {
                LogonForm objLogonPopup = new LogonForm(baseForm);
                objLogonPopup.Closed += new EventHandler((baseForm as MainForm).objLogonPopup_Closed);
                objLogonPopup.ShowDialog();
            }

            base.OnClosed(e);
        }
	}
	
	#endregion
}
