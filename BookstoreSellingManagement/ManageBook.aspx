<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageBook.aspx.cs" Inherits="BookstoreSellingManagement.ManageBook" %>

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
                        <h4 class="card-title">Add Book</h4>
                    </div>
                    <div class="card-body p-4">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="mb-3">
                                    <img id="BookImg" runat="server" src="img/book/placeholder.jpg" alt="Book's Cover" style="height: 317px; object-fit: contain;" />
                                </div>
                                <div class="mb-3">
                                    <label for="Image" class="form-label">Image</label>
                                    <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookImage" runat="server"
                                        ControlToValidate="FileUpload"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookImage_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Description" class="form-label">Description</label>
                                    <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookDescription" runat="server"
                                        ControlToValidate="Description"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookDescription_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
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

                            <div class="col-lg-7">
                                <div class="mb-3">
                                    <label for="ISBN" class="form-label">ISBN</label>
                                    <asp:TextBox ID="ISBN" runat="server" TextMode="Number" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookISBN" runat="server"
                                        ControlToValidate="ISBN"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookISBN_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="BookTitle" class="form-label">Title</label>
                                    <asp:TextBox ID="BookTitle" runat="server" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookTitle" runat="server"
                                        ControlToValidate="BookTitle"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookTitle_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="PriceInput" class="form-label">Price Input</label>
                                    <asp:TextBox ID="PriceInput" runat="server" TextMode="Number" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookPriceInput" runat="server"
                                        ControlToValidate="PriceInput"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookPriceInput_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="PriceOutput" class="form-label">Price Output</label>
                                    <asp:TextBox ID="PriceOutput" runat="server" TextMode="Number" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookPriceOutput" runat="server"
                                        ControlToValidate="PriceOutput"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookPriceOutput_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Quantity" class="form-label">Quantity</label>
                                    <asp:TextBox ID="Quantity" runat="server" TextMode="Number" CssClass="form-control"/>
                                    <asp:CustomValidator
                                        ID="Cv_bookQuantity" runat="server"
                                        ControlToValidate="Quantity"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookQuantity_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Ddl_Publisher" class="form-label">Publisher</label>
                                    <select class="selectpicker form-control" title="Nothing selected" id="Ddl_Publisher" runat="server"></select>
                                    <asp:CustomValidator
                                        ID="Cv_bookPublisher" runat="server"
                                        ControlToValidate="Ddl_Publisher"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookPublisher_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Ddl_Author" class="form-label">Author</label>
                                    <select class="selectpicker form-control" id="Ddl_Author" runat="server" multiple></select>
                                    <asp:CustomValidator
                                        ID="Cv_bookAuthor" runat="server"
                                        ControlToValidate="Ddl_Author"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookAuthor_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                                <div class="mb-3">
                                    <label for="Ddl_Category" class="form-label">Category</label>
                                    <select class="selectpicker form-control" id="Ddl_Category" runat="server" multiple></select>
                                    <asp:CustomValidator
                                        ID="Cv_bookCategory" runat="server"
                                        ControlToValidate="Ddl_Category"
                                        ValidateEmptyText="true"
                                        OnServerValidate="Cv_bookCategory_ServerValidate"
                                        CssClass="d-block text-danger mt-1"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center my-3">
                        <asp:Button ID="Btn_Submit" runat="server" OnCommand="Btn_Submit_Command" CssClass="btn btn-primary waves-effect waves-light me-3" Text="Submit"/>
                        <asp:Button ID="Btn_ReturnBack" runat="server" OnCommand="Btn_ReturnBack_Command" CssClass="btn btn-secondary waves-effect waves-light" Text="Return Back"/>
                        <%--<button type="button" class="btn btn-primary waves-effect waves-light">Add</button>
                        <button type="button" class="btn btn-secondary waves-effect waves-light">Return Back</button>--%>
                    </div>
                </div>
            </div>
            <!-- end col -->
        </div>
        <!-- end row -->
    </div>

    <asp:HiddenField ID="BookId" runat="server" Value=""/>
    <asp:HiddenField ID="BookImgURI" runat="server" Value=""/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/bootstrap-select.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/i18n/defaults-*.min.js"></script>

    <script>
        let bookImg = document.getElementById('phMain_BookImg');
        let imgInp = document.getElementById('phMain_FileUpload');

        imgInp.onchange = (event) => {
            const [file] = imgInp.files;

            if (file) {
                bookImg.src = URL.createObjectURL(file);
                bookImg.onload = () => {
                    URL.revokeObjectURL(bookImg.src);
                }
            }
        }
    </script>
</asp:Content>
