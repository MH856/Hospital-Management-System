<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ICT365_Assignment2._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid">
    <div class="col-md-2"></div>
    <div class="col-md-8">
        <br />
        <br />
        <h2 class="text-danger">Welcome to St John of God Murdoch Hospital</h2>
        <h2>Login Form</h2>
        <form>
  <div class="mb-3">
    <label for="" class="form-label text-danger" id="ErrMsg" runat="server" visible="false">Invalid Username Or Password</label> <br />
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="Email" runat="server" required>
  </div>
  <br />
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="Password" runat="server" required>
  </div>
  <br />
  <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-danger btn-block" OnClick="LoginBtn_Click" />
</form>
    </div>
    <div class="col-md-2"></div>
</div>

</asp:Content>
