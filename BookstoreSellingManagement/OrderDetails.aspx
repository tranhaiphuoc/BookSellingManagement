<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="BookstoreSellingManagement.OrderDetails" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="BookstoreSellingManagement.BAL.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
</asp:Content>
