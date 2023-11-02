<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="BookstoreSellingManagement.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/css/bootstrap-select.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">Add User</h4>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="mb-3">
                                    <img id="UserAvatar" runat="server" src="img/avatar/placeholder.png" alt="User's Avatar" style="height: 317px; object-fit: contain;" />
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
                                        <h5 class="font-size-14 mb-3">Status</h5>
                                        <div class="form-check mb-2">
                                            <input class="form-check-input" type="radio" name="IsActivated" id="IsActivatedTrue" runat="server" checked>
                                            <label class="form-check-label" for="IsActivatedTrue">Active</label>
                                        </div>
                                        <div class="form-check">
                                            <input class="form-check-input" type="radio" name="IsActivated" id="IsActivatedFalse" runat="server">
                                            <label class="form-check-label" for="IsActivatedFalse">Inactive</label>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <h5 class="font-size-14 mb-3">Gender</h5>
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
                                    <label for="UserFirstName" class="form-label">First Name</label>
                                    <asp:TextBox ID="UserFirstName" runat="server" CssClass="form-control"/>
                                    <i runat="server" id="iValidFirstName" visible="false">User's first name is required.</i>


                                    <asp:CustomValidator
                                        ID="Cv_userFirstName" runat="server"
                                        ControlToValidate="UserFirstName"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userFirstName_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="UserLastName" class="form-label">Last Name</label>
                                    <asp:TextBox ID="UserLastName" runat="server" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_userLastName" runat="server"
                                        ControlToValidate="UserLastName"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userLastName_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="UserBirthday" class="form-label">Birthday</label>
                                    <input id="UserBirthday" runat="server" type="date" class="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_userBirthday" runat="server"
                                        ControlToValidate="UserBirthday"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userBirthday_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="UserAddress" class="form-label">Address</label>
                                    <asp:TextBox ID="UserAddress" runat="server" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_userAddress" runat="server"
                                        ControlToValidate="UserAddress"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userAddress_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="UserPhone" class="form-label">Phone</label>
                                    <asp:TextBox ID="UserPhone" runat="server" TextMode="Number" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_userPhone" runat="server"
                                        ControlToValidate="UserPhone"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userPhone_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="UserEmail" class="form-label">Email</label>
                                    <asp:TextBox ID="UserEmail" runat="server" TextMode="Email" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_userEmail" runat="server"
                                        ControlToValidate="UserEmail"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_userEmail_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3" id="usernameComp" runat="server">
                                    <label for="Username" class="form-label">Username</label>
                                    <asp:TextBox ID="Username" runat="server" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_username" runat="server"
                                        ControlToValidate="Username"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_username_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Password" class="form-label">Password</label>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_password" runat="server"
                                        ControlToValidate="Password"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_password_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Ddl_Roles" class="form-label">Role</label>
                                    <select class="selectpicker form-control" id="Ddl_Roles" runat="server" multiple></select>
                                    <asp:CustomValidator
                                        ID="Cv_role" runat="server"
                                        ControlToValidate="Ddl_Roles"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_role_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center my-3">
                        <asp:Button ID="Btn_Submit" runat="server" OnCommand="Btn_Submit_Command" CssClass="btn btn-primary waves-effect waves-light me-3" Text="Submit"/>
                        <asp:Button ID="Btn_ReturnBack" runat="server" OnCommand="Btn_ReturnBack_Command" CssClass="btn btn-secondary waves-effect waves-light" Text="Return Back"/>
                    </div>
                </div>
            </div>
            <!-- end col -->
        </div>
        <!-- end row -->
    </div>

    <asp:HiddenField ID="UserId" runat="server" Value=""/>
    <asp:HiddenField ID="UserAvatarURI" runat="server" Value=""/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/bootstrap-select.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/i18n/defaults-*.min.js"></script>

    <script type="text/javascript">
        let imgInp = document.getElementById('phMain_FileUpload');

        imgInp.onchange = (event) => {
            const [file] = imgInp.files;

            if (file) {
                let userAvatar = document.getElementById('phMain_UserAvatar');

                userAvatar.src = URL.createObjectURL(file);
                userAvatar.onload = () => {
                    URL.revokeObjectURL(userAvatar.src);
                }
            }
        }
    </script>
</asp:Content>
