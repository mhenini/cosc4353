﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="cosc4353.Change_Password" EnableSessionState="True" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Profile</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <style>

    body, html {height: 100%;}

    /* Remove the navbar's default margin-bottom and rounded borders */ 
    .navbar {
      margin-bottom: 0;
      border-radius: 0;
      background-color: white;
      border-color: white;
    }

    #unac {
        color: black;
    }
    
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {height: 100%}
    
    /* Set gray background color and 100% height */
    .sidenav {
      padding-top: 20px;
      background-color: #f1f1f1;
      min-height: 100%;
      margin-bottom: -9999px;
      padding-bottom: 9999px;
    }

    .active {
        color: lightblue !important;
    }

    .frontpart {
        min-height: 100%;
        overflow: hidden;
    }
    
    /* Set black background color, white text and some padding */
    footer {
      bottom: 0px;
      background-color: #555;
      color: white;
      padding: 15px;
    }
    
    /* On small screens, set height to 'auto' for sidenav and grid */
    @media screen and (max-width: 767px) {
      .sidenav {
        height: auto;
        padding-top: 15px;
      }
      .row.content {height:auto;} 
    }
  </style>
</head>
<body>

<nav class="navbar navbar-inverse">  <!-- Navigation Bar -->
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
        <li class="active"><a href="Profile.aspx">Profile</a></li>
        <li><a href="History.aspx">History</a></li>
        <li><a href="#">Fuel Quote</a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
      </ul>
    </div>
  </div>
</nav>
  
<div class="container">
    <div class="row">
        <div class="col text-center">
            <h3>Password Change</h3>
            <hr />
            <br />
        </div>
    </div>
    <form id="ChangePass" runat="server">
        <div class="row">
            <div class="col-sm-10">
                <h4>Old Password: </h4>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="OldPassword" runat="server" AutoCompleteType="None" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-10">
                <h4>New Password: </h4>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="NewPassword1" runat="server" AutoCompleteType="None" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-10">
                <h4>Confirm Password: </h4>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="NewPassword2" runat="server" AutoCompleteType="None" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <br />
            <div class="col-sm-10">
                <asp:Button ID="submit" Text="Submit" runat="server" OnClick="ChangePassClick" />
            </div>
        </div>
    </form>
    <div class="row">
        <div class="col-sm-10">
            <asp:Label ID="Correct" Text="" runat="server"></asp:Label>
        </div>
    </div>
</div>



</body>
</html>
