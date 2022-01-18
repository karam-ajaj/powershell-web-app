<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPowershell.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get-ChildItem</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div><h1 align="center">Get-ChildItem</h1></div>
            <p>Please type the directory for which you want to get the child items:
                <asp:TextBox ID="Input1" runat="server" Width="100%" Height="20px" ></asp:TextBox>
            </p>
            <asp:Button ID="ExecuteInput1" runat="server" Text="Execute" Width="200" onclick="ExecuteInputClick" />

            <p>Result
            <asp:TextBox ID="Result1" TextMode="MultiLine" Width="100%" Height="450px" runat="server"></asp:TextBox>
            </p>

        </div>


        <div>
            <div><h1 align="center">Get-ChildItem</h1></div>
            <p>Please type the directory for which you want to get the child items:
                <asp:TextBox ID="Input2" runat="server" Width="100%" Height="20px" ></asp:TextBox>
            </p>
            <asp:Button ID="ExecuteInput2" runat="server" Text="Execute" Width="200" onclick="ExecuteInputClick" />

            <p>Result
            <asp:TextBox ID="Result2" TextMode="MultiLine" Width="100%" Height="450px" runat="server"></asp:TextBox>
            </p>

        </div>
    </form>
</body>
</html>