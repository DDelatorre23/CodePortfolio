<%@ Page Title="" Language="C#" MasterPageFile="~/EvaluationMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EvaluationApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="loginForm">
          <div>
            <h1>Login</h1>
          </div>
          <p>Please enter your user id and password to login.</p>
          <form runat="server" role="form">
            <div>
                <label for="userid">User Id:</label>
                <div>
                    <input runat="server" type="text" id="userid" placeholder="Enter user id"/>
                </div> 
                <div>
                    <!-- validation control goes here -->
                    <asp:RequiredFieldValidator ID="valReqUserid" runat="server" ControlToValidate="userid" 
                        ErrorMessage="You must enter a user id" SetFocusOnError="True"> 
                    </asp:RequiredFieldValidator>
               
                </div>
            </div>
            <div>
                <label for="pwd">Password:</label>
                <div> 
                    <input  runat="server" type="password" id="pwd" placeholder="Enter password"/>
                </div>
                <div>
                    <!-- validation control goes here -->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="pwd" 
                        ErrorMessage="Password must be 8 to 16 characters" SetFocusOnError="True" 
                        ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$"> 
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valReqPassword" runat="server" ControlToValidate="pwd" 
                        ErrorMessage="You must enter a password" SetFocusOnError="True"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div> 
                <div>
                    <div>
                    <label><input runat="server" id="saveChk" type="checkbox" /> Remember me</label>
                    </div>
                </div>
            </div>
            <div> 
                <div>
                    <asp:Button ID="submitButton" runat="server" Text="Login" CssClass="buttons" OnClick="submitButton_Click"/>
                </div>
            </div>
            <div>
                <div>
                    <asp:Label ID="loginErrorMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
            </form>
        </div>
</asp:Content>
