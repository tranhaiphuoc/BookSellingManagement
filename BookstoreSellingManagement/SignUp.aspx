<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BookstoreSellingManagement.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container-fluid mt-3">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title m-0">Create Account</h4>
            </div>
            <div class="card-body p-4">
                <div class="row">
                    <div class="col-lg-5">
                        <div class="mb-3">
                            <img id="UserAvatar" src="img/avatar/placeholder.png" alt="User's Avatar" style="height: 328px; object-fit: contain;" />
                        </div>
                        <div class="mb-3">
                            <label for="FileUpload" class="form-label">Avatar</label>
                            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userAvatar" runat="server"
                                ControlToValidate="FileUpload"
                                OnServerValidate="Cv_userAvatar_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="row mb-3">
                            <div class="col-6">
                                <p class="mb-3">Gender</p>
                                <div class="form-check mb-2">
                                    <input class="form-check-input" type="radio" name="gender" id="Male" runat="server" checked>
                                    <label class="form-check-label" for="Male">Male</label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="radio" name="gender" id="Female" runat="server">
                                    <label class="form-check-label" for="Female">Female</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-7">
                        <div class="mb-3">
                            <label for="Txt_FirstName" class="form-label">First Name</label>
                            <asp:TextBox ID="Txt_FirstName" runat="server" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userFirstName" runat="server"
                                ControlToValidate="Txt_FirstName"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userFirstName_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_LastName" class="form-label">Last Name</label>
                            <asp:TextBox ID="Txt_LastName" runat="server" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userLastName" runat="server"
                                ControlToValidate="Txt_LastName"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userLastName_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Birthday" class="form-label">Birthday</label>
                            <input id="Txt_Birthday" runat="server" type="date" class="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userBirthday" runat="server"
                                ControlToValidate="Txt_Birthday"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userBirthday_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Address" class="form-label">Address</label>
                            <asp:TextBox ID="Txt_Address" runat="server" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userAddress" runat="server"
                                ControlToValidate="Txt_Address"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userAddress_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Phone" class="form-label">Phone</label>
                            <asp:TextBox ID="Txt_Phone" runat="server" TextMode="Number" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userPhone" runat="server"
                                ControlToValidate="Txt_Phone"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userPhone_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Email" class="form-label">Email</label>
                            <asp:TextBox ID="Txt_Email" runat="server" TextMode="Email" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_userEmail" runat="server"
                                ControlToValidate="Txt_Email"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_userEmail_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Username" class="form-label">Username</label>
                            <asp:TextBox ID="Txt_Username" runat="server" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_username" runat="server"
                                ControlToValidate="Txt_Username"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_username_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Txt_Password" class="form-label">Password</label>
                            <asp:TextBox ID="Txt_Password" runat="server" TextMode="Password" CssClass="form-control"/>
                            <asp:CustomValidator
                                ID="Cv_password" runat="server"
                                ControlToValidate="Txt_Password"
                                ValidateEmptyText="true"
                                OnServerValidate="Cv_password_ServerValidate"
                                CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-center my-3">
                <asp:Button ID="Btn_Submit" runat="server" OnCommand="Btn_Submit_Command" CssClass="btn btn-primary mr-5" Text="Create"/>
                <asp:Button ID="Btn_ReturnBack" runat="server" OnCommand="Btn_ReturnBack_Command" CssClass="btn btn-secondary" Text="Return Back"/>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJS" runat="server">
    <script type="text/javascript">
        let imgInp = document.getElementById('phHome_FileUpload');

        imgInp.onchange = (event) => {
            const [file] = imgInp.files;

            if (file) {
                let userAvatar = document.getElementById('UserAvatar');

                userAvatar.src = URL.createObjectURL(file);
                userAvatar.onload = () => {
                    URL.revokeObjectURL(userAvatar.src);
                }
            }
        }
    </script>
</asp:Content>