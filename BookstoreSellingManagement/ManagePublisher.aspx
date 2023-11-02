<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManagePublisher.aspx.cs" Inherits="BookstoreSellingManagement.ManagePublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">Publisher</h4>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div>
                                    <div class="mb-3">
                                        <label for="PublisherName" class="form-label">Name</label>
                                        <asp:TextBox ID="PublisherName" runat="server" CssClass="form-control"/>
                                        <asp:CustomValidator
                                            ID="Cv_publisherName" runat="server"
                                            ControlToValidate="PublisherName"
                                            ValidateEmptyText="true"
                                            OnServerValidate="Cv_publisherName_ServerValidate"
                                            CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                    </div>
                                    <div class="mb-3">
                                        <label for="PublisherAddress" class="form-label">Address</label>
                                        <asp:TextBox ID="PublisherAddress" runat="server" CssClass="form-control"/>
                                        <asp:CustomValidator
                                            ID="Cv_publisherAddress" runat="server"
                                            ControlToValidate="PublisherAddress"
                                            ValidateEmptyText="true"
                                            OnServerValidate="Cv_publisherAddress_ServerValidate"
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

    <asp:HiddenField ID="PublisherId" runat="server" Value=""/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
</asp:Content>
