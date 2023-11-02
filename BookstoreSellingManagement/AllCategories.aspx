<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AllCategories.aspx.cs" Inherits="BookstoreSellingManagement.AllCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container-xl mt-5">
        <div class="row">

            <div class="col-lg-3 col-md-4 mb-sm-5">
                <nav class="nav flex-column nav-pills">
                    <a class="nav-item nav-link" href="AllCategories.aspx">All</a>
                    <div style="border: 1px solid var(--primary);"></div>
                    <asp:Repeater ID="Rpt_allCategory" runat="server" ItemType="BookstoreManagementDAL.TblCategory">
                        <ItemTemplate>
                            <a class="nav-item nav-link text-truncate" href="AllCategories.aspx?id=<%# Item.Id %>"><%# Item.Name %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </nav>
            </div>

            <div class="text-center col-lg-9 col-md-8">
                <asp:UpdatePanel ID="Up_books" runat="server" class="row">
                    <ContentTemplate>
                        <asp:Repeater ID="Rpt_bookOfCategory" runat="server" ItemType="BookstoreManagementDAL.TblBook">
                            <ItemTemplate>
                                <div class="col-lg-3 col-md-4 col-sm-6 mb-5">
                                    <div class="card product-item">
                                        <a href="#" class="d-block card-header product-img position-relative overflow-hidden bg-transparent border-0 p-0">
                                            <img class="mx-auto" style="height: 250px;" src="img/book/<%# Item.Image %>"/>
                                        </a>
                                        <div class="card-body py-2">
                                            <h6 class="card-title text-truncate m-0" title="<%# Item.Title %>"><%# Item.Title %></h6>
                                        </div>
                                        <div class="card-footer d-flex justify-content-between bg-light border-0">
                                            <asp:LinkButton ID="Btn_ViewDetail"
                                                            runat="server"
                                                            CommandArgument="<%# Item.Id %>"
                                                            OnCommand="Btn_ViewDetail_Command"
                                                            CssClass="card-link text-primary"
                                                            ToolTip="View Details">
                                                <i class="fas fa-eye mr-1"></i>Details
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="Btn_AddToCart"
                                                            runat="server"
                                                            CommandArgument="<%# Item.Id %>"
                                                            OnCommand="Btn_AddToCart_Command"
                                                            OnClientClick="addInfo()"
                                                            CssClass="card-link text-primary"
                                                            ToolTip="View Details">
                                                <i class="fas fa-shopping-cart mr-1"></i>Cart
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <%--<%
                    foreach (var item in CategoryService.GetRandom(5))
                    {
                        TblBookCollection tblBooks = BookService.GetByCategory(5, item.Id);
                        SetDataSourceRepeater(tblBooks);
                %>
                        <div><%: item.Name %></div>
                        <div class="d-flex">
                            <asp:Repeater ID="Rpt_bookOfCategory" runat="server" ItemType="BookstoreManagementDAL.TblBook">
                                <ItemTemplate>
                                    <div style="width: 20%">
                                        <a href="#">
                                            <img src="img/book/<%# Item.Image %>"/>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                <%
                    }
                %>--%>
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
