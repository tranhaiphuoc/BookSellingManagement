<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="BookstoreSellingManagement.ManageOrder" %>

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
                        <h4 class="card-title">Order</h4>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-lg-7">
                                <div class="mb-3">
                                    <label for="Txt_dueDate" class="form-label">Due Date</label>
                                    <input id="Txt_dueDate" runat="server" type="date" class="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_dueDate" runat="server"
                                        ControlToValidate="Txt_dueDate"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_dueDate_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Ddl_status" class="form-label">Publisher</label>
                                    <select class="selectpicker form-control" title="Nothing selected" id="Ddl_status" runat="server"></select>
                                    <asp:CustomValidator
                                        ID="Cv_orderStatus" runat="server"
                                        ControlToValidate="Ddl_status"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_orderStatus_ServerValidate"
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

    <asp:HiddenField ID="Hf_orderId" runat="server" Value=""/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/bootstrap-select.min.js"></script>
</asp:Content>
