<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AngularJS.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div ng-app="">
 	<p>Name: <input type="text" ng-model="name"></p>
 	<p ng-bind="name"></p>
</div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
