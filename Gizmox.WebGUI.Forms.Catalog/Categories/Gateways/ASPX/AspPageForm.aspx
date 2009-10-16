<%@ Page Language="c#" ValidateRequest="false" AutoEventWireup="false" CodeBehind="AspPageForm.aspx.cs" Inherits="Gizmox.WebGUI.Forms.Catalog.Categories.Gateways.ASPX.ASPXBoxForm" %>
<html>
<head runat="server">
    <title>Untitled Page</title>
    <script src="Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Interfaces.js.wgx" type="text/javascript"></script>
    <script>
        function ShowMessageBox(strMessage)
        {
            var objEvent = VWG.Events.CreateEvent("<%= PageContext.ID %>","MessageBox");
            VWG.Events.SetEventAttribute(objEvent,"message",strMessage);
            VWG.Events.RaiseEvents();
        }
        
        function ShowMessageFromServer(strMessage)
        {
            alert(strMessage);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></div>
        <button onclick="ShowMessageBox(document.getElementById('TextBox1').value)">Raise event to VWG</button>
    </form>
</body>
</html>
