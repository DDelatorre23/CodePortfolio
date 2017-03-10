<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEvaTest.aspx.cs" Inherits="EvaluationApp.CourseEvaTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <asp:Button ID="FillButton" runat="server" Text="Fill" OnClick="FillButton_Click" />
        <asp:Button ID="GetEval" runat="server" Text="Get Eval" OnClick="GetEval_Click" />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
