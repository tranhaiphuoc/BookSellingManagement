<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="BookstoreSellingManagement.OrderHistory" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="BookstoreSellingManagement.BAL.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container mt-5">
    <%
    if (Page.Request.QueryString["id"] == null)
    {
    %>
        <asp:Repeater ID="Rpt_pastOrder" runat="server" ItemType="BookstoreManagementDAL.TblOrder">
            <ItemTemplate>
                <div class="row mb-4 py-2 border-dark border">
                    <div class="col-5 d-flex justify-content-between align-items-center">
                        <p class="m-0"><%# Container.ItemIndex + 1 %></p>
                        <p class="m-0"><%# Item.DueDate.ToString("dd-MM-yyyy") %></p>
                        <p class="m-0"><%# Item.Status %></p>
                    </div>
                    <div class="col-7 d-flex justify-content-between align-items-center">
                        <p class="m-0">Subtotal: <%# Item.Subtotal %></p>
                        <p class="m-0">Discount: <%# Item.TotalDiscount %></p>
                        <p class="m-0">Total: <%# Item.Total %></p>
                        <asp:LinkButton ID="Btn_orderDetails" runat="server"
                                        OnCommand="Btn_orderDetails_Command" CommandArgument="<%# Item.Id %>"
                                        CssClass="btn btn-sm btn-primary">
                            Details
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    <%
    }
    else
    {
    %>
        <div class="row mb-3">
            <asp:Repeater ID="Rpt_orderDetails" runat="server">
                <ItemTemplate>
                    <div class="col-6 pr-4 mb-3">
                        <div class="row justify-content-between product-item position-relative">
                            <div class="col-4 overflow-hidden bg-transparent border-0 p-0">
                                <img class="d-block mx-auto" style="height: 250px; width: 170px;" src="img/book/<%# Eval("Image") %>"/>
                            </div>

                            <div class="col-8">
                                <div class="row" style="height: 50%;">
                                    <div class="col-10">
                                        <h6><%# Eval("Title") %></h6>
                                        <div class="btn btn-sm btn-primary" style="border-radius: 10px;"><%# decimal.Parse(Eval("UnitPrice").ToString()).ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")) %></div>
                                    </div>
                                </div>
                                <div class="row flex-column justify-content-end align-items-end" style="height: 50%;">
                                    <div class="mb-3">
                                        <div>Quantity: <%# Eval("Quantity") %></div>
                                    </div>
                                    <div>
                                        <%--<div>Discount: <%# Eval("Discount") %></div>--%>
                                        <div>Total: <%# decimal.Parse(Eval("Total").ToString()).ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")) %></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="d-flex flex-column align-items-end">
            <div id="Txt_total" runat="server" class="font-weight-bold mb-2">Total: </div>
        </div>
    <%
    }
    %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJS" runat="server">
</asp:Content>
