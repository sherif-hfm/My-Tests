<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CkeEditor2.index" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>First Use &mdash; CKEditor for ASP.NET Sample</title>
	<link href="sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	<h1 class="samples">
		CKEditor for ASP.NET Sample &mdash; Adding the CKEditor for ASP.NET Control to a Page
	</h1>
	
	<div>
		<CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="200" BasePath="~/ckeditor"  Toolbar="Full">
		
		</CKEditor:CKEditorControl>
	</div>
	
	</form>
</body>
</html>
