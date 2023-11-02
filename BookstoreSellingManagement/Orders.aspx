﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="BookstoreSellingManagement.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phMain" runat="server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0 font-size-18">Orders</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->
        <asp:UpdatePanel ID="Up_orders" runat="server" class="row">
            <ContentTemplate>
                <div class="col-12">
                    <div class="card">
                        <%--<div class="d-flex justify-content-end pt-3 px-3">
                            <asp:LinkButton ID="Btn_AddBook"
                                            runat="server"
                                            OnCommand="Btn_AddOrder_Command"
                                            CssClass="btn btn-primary"
                                            Text="Add Book"/>
                        </div>--%>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-editable table-nowrap align-middle table-edits">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Due Date</th>
                                            <th>Status</th>
                                            <th>Subtotal</th>
                                            <th>Total Discount</th>
                                            <th>Total</th>
                                            <th>Updated By</th>
                                            <th>Updated At</th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Rpt_BooksList" runat="server" ItemType="BookstoreManagementDAL.TblOrder">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 %></td>
                                                    <td><%# Item.DueDate %></td>
                                                    <td><%# CutString(Item.Status) %></td>
                                                    <td><%# Item.Subtotal %></td>
                                                    <td><%# Item.TotalDiscount %></td>
                                                    <td><%# Item.Total %></td>
                                                    <td><%# Item.UpdatedBy %></td>
                                                    <td><%# string.Format("{0:dd/MM/yyyy HH:mm:ss}", Item.UpdatedAt) %></td>
                                                    <td style="width: 50px">
                                                        <asp:LinkButton ID="Btn_EditBook" runat="server"
                                                                        CommandArgument="<%# Item.Id %>" OnCommand="Btn_EditOrder_Command"
                                                                        CssClass="btn btn-outline-secondary btn-sm edit" ToolTip="Edit">
                                                            <i class="fas fa-pencil-alt"></i>
                                                        </asp:LinkButton>
                                                    </td>
                                                    <td style="width: 50px">
                                                        <asp:LinkButton ID="Btn_details" runat="server"
                                                                        CommandArgument="<%# Item.Id %>" OnCommand="Btn_details_Command"
                                                                        CssClass="btn btn-outline-secondary btn-sm">
                                                            <i class="fas fa-list-ul"></i>
                                                        </asp:LinkButton>
                                                    </td>
                                                    <td style="width: 50px">
                                                        <a class="btn btn-outline-secondary btn-sm edit" onclick="storeDeleteId('<%# Item.Id %>');" data-bs-toggle="modal" data-bs-target="#confirmModal" title="Delete">
                                                            <i class="fas fa-trash-alt"></i>
                                                        </a>     
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end col -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- container-fluid -->

    <!-- Modal -->
    <div class="modal fade" id="confirmModal"  aria-labelledby="confirmModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="confirmModalLabel">Delete</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">Are you sure that you want to delete this row?</div>
                <asp:UpdatePanel ID="Up_action" runat="server" class="modal-footer">
                    <ContentTemplate>
                        <a class="btn btn-secondary" data-bs-dismiss="modal">Close</a>
                        <asp:Button ID="Btn_ConfirmDeleteOrder" runat="server"
                                    OnCommand="Btn_ConfirmDeleteOrder_Command"
                                    OnClientClick="deleteInfo()"
                                    CssClass="btn btn-outline-secondary" Text="Delete"
                                    data-bs-dismiss="modal"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="DeleteId" Value="" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phJs" runat="server">
    <script>
        let deleteFiled = document.getElementById("<%= DeleteId.ClientID %>");
        deleteFiled.addEventListener('click', storeDeleteId);

        function storeDeleteId(idValue) {
            deleteFiled.value = idValue;
        }

        function deleteInfo() {
            toastr.warning("Item has been succesfully deleted!", "Delete");
        }
    </script>
</asp:Content>
