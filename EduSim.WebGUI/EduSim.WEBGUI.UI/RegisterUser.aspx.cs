using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduSim.CoreFramework.DTO;

namespace EduSim.WebGUI.UI
{
    //TODO: When the user is registered, automatically create a Try Game
    //TODO: Disable all reports except P&L
    //TODO: Create computer Data
    //TODO: Analyse the player data to Computer data
    //TODO: Improve on the Homepage
    //TODO: Capcha
    //TODO: Email validation
    //Make the Web UI light weight
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!CaptchaControl1.UserValidated)
            {
                return;
            }
            if (txtEmail.Text.Equals(string.Empty ))
            {
                lblMessage.Text = "Email cannot be empty";
                return;
            }
            if (txtPassword.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Password cannot be empty";
                return;
            }
            if (!txtPassword.Text.Equals(txtConfirm.Text))
            {
                lblMessage.Text = "Password should match";
                return;
            }

            UserDetails user = new UserDetails()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Role = Role.Player.ToString(),
                Try = true,
                GameCount = 0
            };

            Edusim db = new Edusim();

            db.UserDetails.InsertOnSubmit(user);

            db.SubmitChanges();
            lblMessage.Text = string.Empty;
        }
    }
}
