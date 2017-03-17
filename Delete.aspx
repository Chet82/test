<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:TextBox ID="txtAddressNo" runat="server" OnTextChanged="txtAddressNo_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddressNo" runat="server" style="z-index: 1; width: 323px;" Text="Are you sure you want to delete this address?"></asp:Label>
            <br />
            <asp:Button ID="btnYes" runat="server" style="z-index: 1; width: 59px" Text="Yes" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" height="26px" style="z-index: 1;" Text="No" width="59px" OnClick="btnNo_Click" />

</asp:Content>

