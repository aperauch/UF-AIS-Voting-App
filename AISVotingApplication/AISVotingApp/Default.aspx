<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AISVotingApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang="en">
<!--<![endif]-->
<head id="LandingPage" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Welcome to AIS Elections</title>
    <link rel="stylesheet" href="css/style.css">
    <!--[if lt IE 9]><script src="Scripts/landing-page.js"></script><![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <section class="container">
    <div class="login">
      <h1>Login to Vote</h1>
        <p><asp:TextBox ID="username" runat="server" placeholder="UFID" Width="265px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UFID_Required" runat="server" ErrorMessage="*" 
                ControlToValidate="username"></asp:RequiredFieldValidator>
        </p>
        <p><asp:TextBox ID="password" runat="server" placeholder="Password" Width="265px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Pwd_Required" runat="server" ErrorMessage="*" 
                ControlToValidate="password"></asp:RequiredFieldValidator>
        </p>
        <p><asp:Label ID="Error" runat="server" style="Color:Red;"></asp:Label></p>
        <p class="submit"><asp:Button ID="login_button" runat="server" Text="Sign in" 
                onclick="login_button_Click" /></p>
    </div>
    <div class="login-help">
      <p><a href="Default.aspx">Forgot your password?</a></p>
    </div>
  </section>
    </form>
</body>
</html>
