<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookstoreSellingManagement.Default" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="ctDefault" ContentPlaceHolderID="phHome" runat="server">
    <!-- Carousel Start -->
    <div class="container-fluid mb-5">
        <div id="header-carousel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active" style="height: 410px;">
                    <img class="img-fluid" src="img/carousel-1.png" alt="Image">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 700px;">
                            <h4 class="text-light text-uppercase font-weight-medium mb-3">10% Off Your First Order</h4>
                            <h3 class="display-4 text-white font-weight-semi-bold mb-4">All Kind Of Books</h3>
                        </div>
                    </div>
                </div>
                <div class="carousel-item" style="height: 410px;">
                    <img class="img-fluid" src="img/carousel-2.png" alt="Image">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 700px;">
                            <h4 class="text-light text-uppercase font-weight-medium mb-3">10% Off Your First Order</h4>
                            <h3 class="display-4 text-white font-weight-semi-bold mb-4">Reasonable Price</h3>
                        </div>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#header-carousel" data-slide="prev">
                <div class="btn btn-dark" style="width: 45px; height: 45px;">
                    <span class="carousel-control-prev-icon mb-n2"></span>
                </div>
            </a>
            <a class="carousel-control-next" href="#header-carousel" data-slide="next">
                <div class="btn btn-dark" style="width: 45px; height: 45px;">
                    <span class="carousel-control-next-icon mb-n2"></span>
                </div>
            </a>
        </div>
    </div>
    <!-- Carousel End -->

    <!-- Featured Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5 pb-3">
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-check text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">Quality Product</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-shipping-fast text-primary m-0 mr-2"></h1>
                    <h5 class="font-weight-semi-bold m-0">Free Shipping</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fas fa-exchange-alt text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">14-Day Return</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center border mb-4" style="padding: 30px;">
                    <h1 class="fa fa-phone-volume text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">24/7 Support</h5>
                </div>
            </div>
        </div>
    </div>
    <!-- Featured End -->

    <div class="container-fluid pt-5">
        <div class="text-center mb-4">
            <h2 class="section-title px-5"><span class="px-2">New Arivals</span></h2>
        </div>
        <asp:UpdatePanel ID="Up_new" runat="server">
            <ContentTemplate>
                <div class="row px-xl-5 pb-3">
                    <asp:Repeater ID="rpt_book" runat="server" ItemType="BookstoreManagementDAL.TblBook">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                            <div class="card product-item border-0 mb-4">
                                <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                                    <img class="w-100" style="height: 420px" src="img/book/<%# DataBinder.Eval(Container.DataItem, "Image") %>" alt="image">
                                </div>
                                <div class="card-body border-left border-right text-center px-2 py-3">
                                    <h6 class="text-truncate mb-4"><%# Item.Title %></h6>
                                    <div class="d-flex justify-content-center">
                                        <%--<h6 class="text-muted mr-3 mb-0"><del>140000</del></h6>--%>
                                        <h6 class="mb-0"><%# Item.PriceOutput.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")) %></h6>
                                    </div>
                                </div>
                                <div class="card-footer d-flex justify-content-between bg-light border">
                                    <asp:LinkButton ID="Btn_ViewDetail" runat="server"
                                                    CommandArgument="<%# Item.Id %>"
                                                    OnCommand="Btn_ViewDetail_Command"
                                                    CssClass="btn btn-sm text-dark p-0"
                                                    ToolTip="View Details">
                                        <i class="fas fa-eye text-primary mr-1"></i>Details
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="Btn_AddToCart" runat="server"
                                                    CommandArgument="<%# Item.Id %>"
                                                    OnCommand="Btn_AddToCart_Command"
                                                    OnClientClick="addInfo()"
                                                    CssClass="btn btn-sm text-dark p-0"
                                                    ToolTip="Add To Cart">
                                        <i class="fas fa-shopping-cart text-primary mr-1"></i>Add Cart
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="phJs" runat="server">
    <script>
        function addInfo() {
            toastr.info("The item has been add to your cart!", "Add To Cart");
        }
    </script>
</asp:Content>