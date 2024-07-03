<%@ Page Title="Calculater" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="form_task.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn-add {
            background-color: #28a745; /* Green */
            color: white;
        }
        
        .btn-multiply {
            background-color: #007bff; /* Blue */
            color: white;
        }
        
        .btn-subtract {
            background-color: #dc3545; /* Red */
            color: white;
        }
    </style>
    
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Your application description page.</h3>
        
        <div>
            <h4>Calculator:</h4>
            
            <div>
                <div>
                    <label for="num1">Number 1:</label>
                    <asp:TextBox ID="num1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <label for="num2">Number 2:</label>
                    <asp:TextBox ID="num2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            
            <div style="margin-top: 10px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-add" OnClick="btnAdd_Click" />
                <asp:Button ID="btnMultiply" runat="server" Text="Multiply" CssClass="btn btn-multiply" OnClick="btnMultiply_Click" />
                <asp:Button ID="btnSubtract" runat="server" Text="Subtract" CssClass="btn btn-subtract" OnClick="btnSubtract_Click" />
            </div>
            
            <div id="result" style="margin-top: 10px;">
                Result: <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            </div>
            
        </div>
        
        <p>Use this area to provide additional information.</p>
    </main>
</asp:Content>
