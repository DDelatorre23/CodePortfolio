<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BlackJack</title>
    <link href="gameboard.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="hand dealer">



                    <div id="dealerPanel">

                        <asp:Image ID="dealerImage1" runat="server" CssClass="card" />
                        <asp:Image ID="dealerImage2" runat="server" CssClass="card" />
                        <asp:Image ID="dealerImage3" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="dealerImage4" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="dealerImage5" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="dealerImage6" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="dealerImage7" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="dealerImage8" runat="server" CssClass="card" Visible="false" />
                    </div>
                </div>
                <div class="scoreboard">

                    <asp:Label ID="results" runat="server" Text="" Style="font-size: x-large"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="playerLabel" runat="server" Text="Player's score"></asp:Label>
                    <asp:Label ID="playerScore" runat="server" Text="00" CssClass="score"></asp:Label>
                    <asp:Label ID="dealerLabel" runat="server" Text="Dealer's score"></asp:Label>
                    <asp:Label ID="dealerScore" runat="server" Text="00" CssClass="score"></asp:Label>

                </div>
                <div class="hand">
                    <div id="playerPanel">
                        <asp:Image ID="playerImage1" runat="server" CssClass="card" />
                        <asp:Image ID="playerImage2" runat="server" CssClass="card" />
                        <asp:Image ID="playerImage3" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="playerImage4" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="playerImage5" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="playerImage6" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="playerImage7" runat="server" CssClass="card" Visible="false" />
                        <asp:Image ID="playerImage8" runat="server" CssClass="card" Visible="false" />
                    </div>

                </div>

                <div class="controls">
                    <asp:Button ID="hitButton" runat="server" Text="Hit" CssClass="buttons" OnClick="hitButton_Click" />
                    <asp:Button ID="standButton" runat="server" Text="Stand" CssClass="buttons" OnClick="standButton_Click" />
                    <asp:Button ID="newGameButton" runat="server" Text="New Game" CssClass="buttons" OnClick="newGameButton_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
