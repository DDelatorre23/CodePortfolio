<%@ Page Title="" Language="C#" MasterPageFile="~/EvaluationMaster.Master" AutoEventWireup="true" CodeBehind="Evaluations.aspx.cs" Inherits="EvaluationApp.Evaluations" %>
<%@ Register Src="~/EvaluationQuestionT1.ascx" TagPrefix="qt1"  TagName="EvaluationQuestionT1"%>
<%@ Register Src="~/EvaluationQuestionsT2.ascx" TagPrefix="qt2" TagName="EvaluationQuestionsT2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="questionT1">
       <asp:DropDownList ID="courseEvalsDropDown" runat="server" DataTextField="CourseNumber" DataValueField="EvaluationID"></asp:DropDownList>
       <asp:Button ID="getEvals" runat="server" Text="Get Evaluations"  CssClass="buttons" OnClick="getEvals_Click" />
        <br />
        <asp:Panel ID="questionPanel" runat="server">
            <qt1:EvaluationQuestionT1 runat="server" id="Question0" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question1" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question2" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question3" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question4" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question5" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question6" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question7" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question8" Visible="False"></qt1:EvaluationQuestionT1>
            <qt1:EvaluationQuestionT1 runat="server" id="Question9" Visible="False"></qt1:EvaluationQuestionT1>
            <qt2:EvaluationQuestionsT2 runat="server" id="T2Question0" Visible="false"/>
            <qt2:EvaluationQuestionsT2 runat="server" id="T2Question1" Visible="false"/>
            <asp:Button ID="submitButton" runat="server" Text="Submit" Visible="False" CssClass="buttons" OnClick="submitButton_Click" />

        </asp:Panel>

    </form>
</asp:Content>
