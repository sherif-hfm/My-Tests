﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    welcome to web form Session<%=Session["Test"]  %>
        <br />
        <a href="/Home/Index">Link To MVC</a>

    </div>
    </form>
</body>
</html>