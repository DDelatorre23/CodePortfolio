<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EvaluationQuestionT1.ascx.cs" Inherits="EvaluationApp.EvaluationQuestionT1" className="EvaluationApp.QuestionT1" %>
<div class="typeOne">
        <asp:Label ID="questionText" runat="server" Text="Question" CssClass="questionlabel"></asp:Label>
        <asp:RadioButtonList ID="typeOneRadioList" runat="server" CssClass="answers" RepeatDirection="Horizontal">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
        </asp:RadioButtonList>
</div>