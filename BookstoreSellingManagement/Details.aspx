<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BookstoreSellingManagement.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container my-5">
        <div class="row">

            <div class="col-4">
                <div class="mb-3">
                    <img id="book_img" runat="server" src="img/book/placeholder.jpg" alt="Book's Cover" class="d-block mx-auto" style="height: 350px; object-fit: contain;" />
                </div>
            </div>

            <div class="col-8">
                <h4 id="book_title" runat="server" class="mb-4">Book's Title</h4>
                <div>
                    <p class="font-weight-bold">ISBN: <span id="book_isbn" runat="server" class="font-weight-normal"></span></p>
                    <p class="font-weight-bold">Author: <span id="book_author" runat="server" class="font-weight-normal"></span></p>
                    <p class="font-weight-bold">Publisher: <span id="book_publisher" runat="server" class="font-weight-normal"></span></p>
                    <p class="font-weight-bold">Category: <span id="book_category" runat="server" class="font-weight-normal"></span></p>
                    <p class="font-weight-bold">Description: <span id="book_description" runat="server" class="font-weight-normal"></span></p>
                </div>
                <asp:UpdatePanel ID="Up_add" runat="server" class="mt-4">
                    <ContentTemplate>
                        <asp:LinkButton ID="Btn_addToCart" runat="server"
                                        OnCommand="Btn_addToCart_Command"
                                        OnClientClick="addInfo()"
                                        CssClass="btn btn-primary text-dark"
                                        ToolTip="Add To Cart">
                            <i class="fas fa-shopping-cart text-secondary mr-2"></i>Add Cart
                        </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJS" runat="server">
    <script>
        function addInfo() {
            toastr.info("The item has been add to your cart!", "Add To Cart");
        }
    </script>
</asp:Content>
