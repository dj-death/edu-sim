<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="EduSim.WebGUI.UI.RegisterUser" %>

<!--#include virtual="header.inc" --> 

    <td width="569" height="37" valign="top">
    <form id="form1" runat="server">
    <div>
    
        <b>Register User</b><br />
        <br />
        <asp:Label ID="lblMessage" runat="server" BackColor="#FF3300"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email Id"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <cc1:captchacontrol id="CaptchaControl1" runat="server" ></cc1:captchacontrol>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Register" />
    
    </div>
    </form>

</td>
<!--#include virtual="header.inc" --> 
