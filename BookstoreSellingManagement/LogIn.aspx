<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BookstoreSellingManagement.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <asp:Panel runat="server" DefaultButton="Btn_logIn">
        <div class="d-flex justify-content-center mt-5">
            <div style="width: 550px">
                <div class="mb-4">
                    <label class="form-label font-weight-bold" for="Txt_username">Username</label>
                    <asp:TextBox ID="Txt_username" runat="server" CssClass="form-control"/>
                    <asp:CustomValidator
                        ID="Cv_username" runat="server"
                        ControlToValidate="Txt_username" 
                        ValidateEmptyText="true"
                        OnServerValidate="Cv_username_ServerValidate"
                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                </div>
                <div class="mb-4">
                    <label class="form-label font-weight-bold" for="Txt_password">Password</label>
                    <asp:TextBox ID="Txt_password" runat="server" TextMode="Password" CssClass="form-control"/>
                    <asp:CustomValidator
                        ID="Cv_password" runat="server"
                        ControlToValidate="Txt_password"
                        ValidateEmptyText="true"
                        OnServerValidate="Cv_password_ServerValidate"
                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                </div>

                <div class="text-center mb-4">
                    <a href="#!">Forgot password</a>
                </div>

                <asp:Button ID="Btn_logIn" runat="server"
                            OnClick="Btn_logIn_Click"
                            Text="Log In" CssClass="btn btn-primary btn-lg btn-block mb-4"/>

                <div class="text-center">
                    <p>Not a member? <a href="#!">Register</a></p>
                    <p>or sign up with:</p>
                    <button type="button" class="btn btn-link btn-floating mx-1">
                        <i class="fab fa-facebook-f"></i>
                    </button>
                    <button type="button" class="btn btn-link btn-floating mx-1">
                        <i class="fab fa-google"></i>
                    </button>
                    <button type="button" class="btn btn-link btn-floating mx-1">
                        <i class="fab fa-twitter"></i>
                    </button>
                    <button type="button" class="btn btn-link btn-floating mx-1">
                        <i class="fab fa-github"></i>
                    </button>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJS" runat="server">
</asp:Content>