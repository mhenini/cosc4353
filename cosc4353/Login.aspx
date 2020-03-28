<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cosc4353.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<title>Bootstrap Example</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <style>
    /* Remove the navbar's default margin-bottom and rounded borders */ 
    .navbar {
      margin-bottom: 0;
      border-radius: 0;
    }
    
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {height: 450px}
    
    /* Set gray background color and 100% height */
    .sidenav {
      padding-top: 20px;
      background-color: #f1f1f1;
      height: 100%;
    }
    
    /* Set black background color, white text and some padding */
    footer {
      background-color: #555;
      color: white;
      padding: 15px;
    }
    
    /* On small screens, set height to 'auto' for sidenav and grid */
    @media screen and (max-width: 767px) {
      .sidenav {
        height: auto;
        padding: 15px;
      }
      .row.content {height:auto;} 
    }
  </style>
</head>
<body>

    <form id="form1" runat="server">

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">SD</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
      </ul>
      <ul class="nav navbar-nav navbar-right">
      </ul>
    </div>
  </div>
</nav>
  
<div class="container-fluid text-center">    
  <div class="row content">
    <div class="col-sm-2 sidenav">
    </div>
    <div class="col-sm-8 text-left"> 
      <h1>Welcome To Client Fuel Quote Login Page</h1>
      <p>Hello! Welcome to the Client Login Page. If you are a returning user, please enter your username and password to login into your account. If you are a new user ,please create a username and password. After creating an account, you will be direceted to create a profile.</p>
      <hr>


      <h3> <strong>
   Returning User:
</strong>
<span style="margin-left: 9.5em;">
   <strong> New User:</strong>
 </span> </h3>


      <p> <strong>
          Username:<asp:TextBox ID="LoginBox" runat="server"></asp:TextBox>
          </strong>
          <span style ="margin-left: 10em;">
          <strong><asp:Label ID="Label3" runat="server" Text="Create a Username:"></asp:Label></strong>
          <asp:TextBox ID="TxtBoxNewU" runat="server"></asp:TextBox>
         </span> </p>

        <p><strong>
            Password:<asp:TextBox ID="PassWordBox" runat="server" TextMode="Password"></asp:TextBox>
            </strong>
           <span style ="margin-left: 10em;">
          <strong><asp:Label ID="Label4" runat="server" Text="Create a Password:"></asp:Label></strong>
          <asp:TextBox ID="TextBoxNewPass" runat="server" TextMode="Password"></asp:TextBox>
           </span></p>


        <p><strong>
            <asp:Button ID="loginButton" runat="server" Text="Login" Width="147px" OnClick="loginButton_Click" />
        </strong>
          <span style ="margin-left: 18.5em;">
        <strong><asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="ConfirmTextBox1" runat="server" TextMode="Password"></asp:TextBox>
            </strong>
         </span></p>

        <p><strong>
           </strong>
            <span style ="margin-left: 35em;">
            <strong><asp:Button ID="RegButton" runat="server" Text="Register" Width="147px" OnClick="RegButton_Click" /></strong>
            </span></p>
        <p>
            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <span style ="margin-left: 18.5em;">
            <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </span></p>

         
    </div>
    <div class="col-sm-2 sidenav">
      </div>
    </div>
  </div>
</div>
    </form>
</body>
</html>

