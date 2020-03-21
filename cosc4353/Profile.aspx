<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="cosc4353.Profile" %>

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
  
<div class="container-fluid text-center frontpart">    
  <div class="row">
    <div class="col-sm-2 sidenav">
      <p><a href="#">Change Password</a></p>
      <p><a href="#">Edit Profile Info</a></p>
    </div>
    <div class="col-sm-8 text-left"> 
      <div class="row">
        <div class="col-sm-12">
            <h1>Welcome, John Smith!</h1>
            <hr>
            <br>
            <br>
        </div>
      </div>
      <div class="row">
          <div class="col-sm-12 text-center">
              <a href="#"><span class="glyphicon glyphicon-pencil"></span> Edit Profile Info</a>
              <br />
              <a href="#"><span class="glyphicon glyphicon-repeat"></span> Change Password</a>
          </div>
    </div>
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-sm-6 text-left">
            <h4>Personal Info:</h4>
            <ul class="list-group">
                <li class="list-group-item">Name: John Smith</li>
                <li class="list-group-item">Address 1: 543 Trace Ln.</li>
                <li class="list-group-item">Address 2:</li>
                <li class="list-group-item">City: Houston</li>
                <li class="list-group-item">State: TX</li>
                <li class="list-group-item">Zip: 77026</li>
            </ul>
        </div>
        <div class="col-sm-6 text-left">
            <h4>Account Info:</h4>
            <ul class="list-group">
                <li class="list-group-item">Username: JSmith25</li>
                <li class="list-group-item">Email: jsmith24@AOL.com</li>
                <li class="list-group-item">Company: BP</li>
            </ul>
        </div>
    </div>
    </div>
    </div>
    <div class="col-sm-2 sidenav">
    </div>
  </div>
</div>


</body>
</html>
