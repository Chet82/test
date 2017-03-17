<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.master" AutoEventWireup="true" CodeFile="AnAddress.aspx.cs" Inherits="AnAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <asp:Label ID="lblHouseNo" runat="server" Text="House No" Width="100px"></asp:Label>
            &nbsp;<asp:TextBox ID="txtHouseNo" runat="server" Width="127px" ></asp:TextBox>
            <br />
            <asp:Label ID="lblStreet" runat="server" Text="Street" Width="100px"></asp:Label>
            &nbsp;<asp:TextBox ID="txtStreet" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="lblTown" runat="server"  Text="Town" Width="100px"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTown" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="lblPostCode" runat="server" Text="Post Code" Width="100px"></asp:Label>
            &nbsp;<asp:TextBox ID="txtPostCode" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="lblCounty" runat="server" Text="County" Width="100px"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlCounty" runat="server" style="z-index: 1; "></asp:DropDownList>
            <br />
            <asp:Label ID="lblDateAdded" runat="server" Text="Date Added" Width="100px"></asp:Label>
            &nbsp;<asp:TextBox ID="txtDateAdded" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="chkActive" runat="server" style="z-index: 1;" Text="Active" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ></asp:Label>            
            <br />
            <br />
            <asp:Button ID="btnOK" runat="server" height="26px" Text="OK" width="61px" OnClick="btnOK_Click" />
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1;" Text="Cancel" height="26px" width="61px" OnClick="btnCancel_Click" />

</asp:Content>

