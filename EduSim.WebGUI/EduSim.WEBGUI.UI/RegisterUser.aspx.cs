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

namespace EduSim.WebGUI.UI
{
    //TODO: When the user is registered, automatically create a Try Game
    //TODO: Disable all reports except P&L
    //TODO: Create computer Data
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

        private bool IsEmail(string address)
        {
            try
            {
                string[] host = (address.Split('@'));
                string hostname = host[1];

                IPHostEntry IPhst = Dns.Resolve(hostname);
                IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 25);
                Socket s = new Socket(endPt.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                s.Connect(endPt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
