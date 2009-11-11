using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduSim.CoreFramework.DTO;
using System.Net;
using System.Net.Sockets;
using EduSim.CoreFramework.BusinessLayer;
using System.Text.RegularExpressions;
using EduSim.CoreFramework.Common;

namespace EduSim.WebGUI.UI
{
    //When the user is registered, automatically create a Try Game
    //Disable all reports except P&L
    //Create computer Data
    //TODO: Analyse the player data to Computer data
    //TODO: Improve on the Homepage
    //Create a contact mail 
    //Email validation - Done
    //Make the Web UI light weight
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ValidateFormData())
            {
                UserDetails user = new UserDetails()
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Role = Role.Player.ToString(),
                    Try = true,
                    GameCount = 0
                };

                RegistrationManager.ProcessRegistration(user);
                lblMessage.Text = string.Empty;
            }

            Response.Redirect("./MainForm.wgx");
        }

        private bool ValidateFormData()
        {
            if (!CaptchaControl1.UserValidated)
            {
                return false;
            }
            if (txtEmail.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Email cannot be empty";
                return false;
            }
            if (!IsEmail(txtEmail.Text))
            {
                lblMessage.Text = "Invalid Email";
                return false;
            }
            Edusim db = new Edusim(Constants.ConnectionString);
            int count = (from u in db.UserDetails
                         where u.Email.Equals(txtEmail.Text)
                         select u).Count<UserDetails>();
            if (count > 0)
            {
                lblMessage.Text = "User already exists";
                return false;
            }

            if (txtPassword.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Password cannot be empty";
                return false;
            }
            if (!txtPassword.Text.Equals(txtConfirm.Text))
            {
                lblMessage.Text = "Password should match";
                return false;
            }

            return true;
        }

        private bool IsEmail(string inputEmail)
        {
            inputEmail = NulltoString(inputEmail);
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private string NulltoString(string inputEmail)
        {
            return inputEmail == null ? string.Empty : inputEmail;
        }
    }
}
