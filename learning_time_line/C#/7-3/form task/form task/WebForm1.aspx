<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="form_task.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous">
    <style>
        .div-1{
            height: 100px;
            width: 400px;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            align-items: center
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <div class="form-group div-1">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter text"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="write" CssClass="btn btn-primary" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="content" CssClass="btn btn-primary" OnClick="Button2_Click" />
        </div>
    </form>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8sh+pwAHAJgPOfkd1LZdjUn+1d2m+2aO93Q6jz" crossorigin="anonymous"></script>
</body>

</html>
