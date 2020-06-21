<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfile.aspx.cs" Inherits="graduate.net.uploadfile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
</head>
<body text="确定">
    <form id="form1" runat="server">
        <div>
            
        </div>
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定"/>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>