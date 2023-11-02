<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="BookstoreSellingManagement.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container my-5">
        <div class="row">

            <div class="col-4">
                <div class="mb-3">
                    <img id="user_avatar" runat="server" src="img/avatar/placeholder.png" alt="User's Avatar" class="d-block mx-auto" style="height: 350px; object-fit: contain;" />
                </div>
            </div>

            <div class="col-8">
                <asp:UpdatePanel ID="Up_userDetails" runat="server">
                    <ContentTemplate>
                        <div>
                            <p class="d-inline-block font-weight-bold">FirstName: <span id="user_firstname" runat="server" class="font-weight-normal"></span></p>
                            <div id="firstname_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_firstname" runat="server" type="text"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_firstname" runat="server"
                                                     ControlToValidate="change_firstname"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_firstname_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">LastName: <span id="user_lastname" runat="server" class="font-weight-normal"></span></p>
                            <div id="lastname_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_lastname" runat="server" type="text"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_lastname" runat="server"
                                                     ControlToValidate="change_lastname"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_lastname_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">Birthday: <span id="user_birthday" runat="server" class="font-weight-normal"></span></p>
                            <div id="birthday_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_birthday" runat="server" type="date"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_birthday" runat="server"
                                                     ControlToValidate="change_birthday"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_birthday_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">Gender: <span id="user_gender" runat="server" class="font-weight-normal"></span></p>
                            <div id="gender_container" runat="server" class="d-inline-block" visible="false">
                                <select id="change_gender" runat="server">
                                    <option value="Male">Male</option>
                                    <option value="Female">Female</option>
                                </select>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">Address: <span id="user_address" runat="server" class="font-weight-normal"></span></p>
                            <div id="address_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_address" runat="server" type="text"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_address" runat="server"
                                                     ControlToValidate="change_address"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_address_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">Phone: <span id="user_phone" runat="server" class="font-weight-normal"></span></p>
                            <div id="phone_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_phone" runat="server" type="number"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_phone" runat="server"
                                                     ControlToValidate="change_phone"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_phone_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div>
                            <p class="d-inline-block font-weight-bold">Email: <span id="user_email" runat="server" class="font-weight-normal"></span></p>
                            <div id="email_container" runat="server" class="d-inline-block" visible="false">
                                <asp:TextBox ID="change_email" runat="server" type="email"></asp:TextBox>
                                <asp:CustomValidator ID="Cv_email" runat="server"
                                                     ControlToValidate="change_email"
                                                     ValidateEmptyText="true"
                                                     OnServerValidate="Cv_email_ServerValidate"
                                                     CssClass="text-danger mt-1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="mt-3">
                            <asp:Button ID="Btn_action" runat="server"
                                        OnCommand="Btn_action_Command" CommandArgument="Edit"
                                        Text="Edit" CssClass="btn btn-primary mr-3"/>
                            <asp:Button ID="Btn_cancel" runat="server"
                                        OnCommand="Btn_action_Command" CommandArgument="Cancel"
                                        Text="Cancel" CssClass="btn btn-secondary" Visible="false"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="Hf_userId" runat="server"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
</asp:Content>
