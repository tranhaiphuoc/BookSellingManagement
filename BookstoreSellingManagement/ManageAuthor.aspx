<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAuthor.aspx.cs" Inherits="BookstoreSellingManagement.ManageAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">Author</h4>
                    </div>

                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div>
                                    <div class="mb-3">
                                        <label for="AuthorName" class="form-label">Name</label>
                                        <asp:TextBox ID="AuthorName" runat="server" CssClass="form-control"/>
                                        <asp:CustomValidator
                                            ID="Cv_authorName" runat="server"
                                            ControlToValidate="AuthorName"
                                            ValidateEmptyText="true"
                                            OnServerValidate="Cv_authorName_ServerValidate"
                                            CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                    </div>
                                    <div class="mb-3">
                                        <label for="AuthorBiography" class="form-label">Biography</label>
                                        <asp:TextBox ID="AuthorBiography" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"/>
                                        <asp:CustomValidator
                                            ID="Cv_authorBiography" runat="server"
                                            ControlToValidate="AuthorBiography"
                                            ValidateEmptyText="true"
                                            OnServerValidate="Cv_authorBiography_ServerValidate"
                                            CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                    </div>
                                    <div>
                                        <h5 class="font-size-14 mb-3">Status</h5>
                                        <div class="form-check mb-3">
                                            <input class="form-check-input" type="radio" name="IsActivated" id="IsActivatedTrue" runat="server" checked>
                                            <label class="form-check-label" for="IsActivatedTrue">Active</label>
                                        </div>
                                        <div class="form-check">
                                            <input class="form-check-input" type="radio" name="IsActivated" id="IsActivatedFalse" runat="server">
                                            <label class="form-check-label" for="IsActivatedFalse">Inactive</label>
                                        </div>
                                    </div>
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

    <asp:HiddenField ID="AuthorId" runat="server" Value=""/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
</asp:Content>
