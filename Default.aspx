<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBook.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
            <asp:ListBox ID="lstAddresses" runat="server" style="z-index: 1; height: 197px; width: 327px"></asp:ListBox>
                        <br />
            <asp:Label ID="lblError" runat="server" style="z-index: 1; width: 393px"></asp:Label>

            <br />
            <br />
            <asp:Label ID="lblPostCode" runat="server" style="z-index: 1; width: 317px" Text="Please Enter a Post Code"></asp:Label>
            <br />
            <asp:TextBox ID="txtPostCode" runat="server" style="z-index: 1; width: 169px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnApply" runat="server" style="z-index: 1; width: 119px" Text="Apply" OnClick="btnApply_Click" />
            <asp:Button ID="btnDisplayAll" runat="server" height="26px" style="z-index: 1; width: 119px" Text="Display All" OnClick="btnDisplayAll_Click"/>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" style="z-index: 1; " Text="Add" height="26px" width="55px" OnClick="btnAdd_Click"  />
            <asp:Button ID="btnEdit" runat="server" style="z-index: 1; " Text="Edit" height="26px" width="55px" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="z-index: 1; right: 249px" Text="Delete" height="26px" width="55px"/>
        
</asp:Content>

