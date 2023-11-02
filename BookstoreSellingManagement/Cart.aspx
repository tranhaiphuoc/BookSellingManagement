<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BookstoreSellingManagement.Cart" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCSS" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phHome" runat="server">
    <div class="container mt-5">
<%
    if (Session["Cart"] == null)
    {
%>
        <h2>You haven't selected any book yet.</h2>
<%
    }
    else
    {
%>
        <asp:UpdatePanel ID="Up_userCart" runat="server" class="row mb-3">
            <ContentTemplate>
                <asp:Repeater ID="Rpt_cartItems" runat="server" ItemType="BookstoreManagementDAL.TblBook">
                    <ItemTemplate>
                        <div class="col-6 pr-4 mb-3">
                            <div class="row justify-content-between product-item position-relative">
                                <div class="col-4 overflow-hidden bg-transparent border-0 p-0">
                                    <img class="d-block mx-auto" style="height: 250px; width: 170px;" src="img/book/<%# Item.Image %>"/>
                                </div>

                                <div class="col-8">
                                    <div class="row" style="height: 50%;">
                                        <div class="col-10">
                                            <h6><%# Item.Title %></h6>
                                            <div class="btn btn-sm btn-primary" style="border-radius: 10px;"><%# Item.PriceOutput.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")) %></div>
                                            <div class="mt-2">Available: <%# GetAvailableQuantity(Item.Id) %></div>
                                        </div>
                                        <div class="col-2">
                                            <asp:LinkButton ID="Btn_deleteCartItem" runat="server"
                                                            CommandArgument="<%# Item.Id %>" OnCommand="Btn_deleteItem_Command"
                                                            CssClass="btn btn-danger">
                                                <i class="fas fa-trash text-white"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row flex-column justify-content-end align-items-end" style="height: 50%;">
                                        <div class="d-flex mb-3">
                                            <asp:Button ID="Btn_addQuantity" runat="server"
                                                        UseSubmitBehavior="false"
                                                        CommandArgument="<%# Item.Id %>" CommandName="Add" OnCommand="Btn_adjustQuantity_Command"
                                                        Text="+" CssClass="btn btn-primary" style="height: 35px;"/>
                                            <div class="btn btn-display-quantity"><%# Item.Quantity %></div>
                                            <asp:Button ID="Btn_subtractQuantity" runat="server"
                                                        UseSubmitBehavior="false"
                                                        CommandArgument="<%# Item.Id %>" CommandName="Subtract" OnCommand="Btn_adjustQuantity_Command"
                                                        Text="-" CssClass="btn btn-secondary" style="height: 35px;"/>
                                        </div>
                                        <div>Total: <%# Item.PriceOutput * Item.Quantity %></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="d-flex flex-column align-items-end">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="font-weight-bold mb-2">Total: <%= GetAllItemsTotal().ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")) %></div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="Btn_payment" runat="server"
                        OnCommand="Btn_payment_Command"
                        Text="Confirm Payment" CssClass="btn btn-primary"/>
        </div>
<%
    }
%>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJS" runat="server">
</asp:Content>
