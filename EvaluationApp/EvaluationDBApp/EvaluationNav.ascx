<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EvaluationNav.ascx.cs" Inherits="EvaluationApp.EvaluationNav" %>
<nav class="nav">
    
    <ul class="navlist">
        <li runat="server" id="loginLI">
            <a runat="server" id="loginA" href="#">Login</a></li>
        <li runat="server" id="evalLI">
            <a runat="server" id="evals" href="Evaluations.aspx">Evaluations</a></li>
        <li runat="server" id="logoutLI">
            <a runat="server" id="logoutA" href="Login.aspx">Logout</a></li>
    </ul>
</nav>
