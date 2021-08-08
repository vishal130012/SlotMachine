<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlotMachine.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: large">
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
            <asp:Image ID="Image2" runat="server" Height="200px" Width="200px" />
            <asp:Image ID="Image3" runat="server" Height="200px" Width="200px" />
        </div>
        <p>
            &nbsp;</p>
        <p>
            Your Bet :
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="playButton" runat="server" OnClick="playButton_Click" Text="Pull The Lever!" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="playerMoneyLabel" runat="server"></asp:Label>
        </p>
        <p>
            1 Cherry - x2 Your Bet 
            </p>
        <p>
            2&nbsp; Cherry - x3 Your Bet </p>
        <p>
            3&nbsp; Cherry - x4Your Bet
        </p>
        <p>
            3 7&#39;s Jackpot - x100 Your Bet
        </p>
        <p>
            HOWEVER... if there&#39;s even one bar you win nothing.</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
