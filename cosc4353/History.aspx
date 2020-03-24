<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="cosc4353.History" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Histroy</title>
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
      .row.content {height:100%;} 
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
        <li><a href="Profile.aspx">Profile</a></li>
        <li class="active"><a href="#">History</a></li>
        <li><a href="Form.aspx">Fuel Quote</a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
      </ul>
    </div>
  </div>
</nav>
  
<div class="container-fluid text-center frontpart">    
  <div class="row">
    <div class="col-sm-2 sidenav"></div>
    <div class="col-sm-8"> 
      <h1>Quote Price History</h1>
      <hr style="color:lightblue;">
      <br>
      <br>
      <h4>Fuel Quote From: 12/24/2019</h4>
      <ul class="list-group list-group-horizontal">
      <li class="list-group-item">Requested: 11 Gallons</li>
      <li class="list-group-item">Deliver Address: 534 Trace Ln.</li>
      <li class="list-group-item">Delivery Date: 01/23/2020</li>
      <li class="list-group-item">Suggested Price: $50</li>
      </ul>
    </div>
    <div class="col-sm-2 sidenav">
    </div>
  </div>
</div>


</body>
</html>
