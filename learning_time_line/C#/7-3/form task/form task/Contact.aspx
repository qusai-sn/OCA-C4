<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="form_task.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label for="txtName">Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <label for="txtID">ID:</label>
        <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <span>Gender:</span>
        <asp:RadioButtonList ID="genderRadio" runat="server">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <span>Courses:</span>
        <asp:CheckBoxList ID="courseCheckboxes" runat="server">
            <asp:ListItem Text="HTML" Value="HTML"></asp:ListItem>
            <asp:ListItem Text="CSS" Value="CSS"></asp:ListItem>
            <asp:ListItem Text="JavaScript" Value="JavaScript"></asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <div>
        <label for="txtDescription">Description:</label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
    </div>
    <div>
        <h4>Form Data:</h4>
        <ul>
            <li><strong>Name:</strong> <asp:Label ID="lblName" runat="server" /></li>
            <li><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></li>
            <li><strong>ID:</strong> <asp:Label ID="lblID" runat="server" /></li>
            <li><strong>Gender:</strong> <asp:Label ID="lblGender" runat="server" /></li>
            <li><strong>Courses:</strong> <asp:Label ID="lblCourses" runat="server" /></li>
            <li><strong>Description:</strong> <asp:Label ID="lblDescription" runat="server" /></li>
        </ul>
    </div>
</asp:Content>
