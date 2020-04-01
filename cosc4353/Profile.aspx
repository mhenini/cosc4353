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

    body, html {height: 100vh;}

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
      height: 100vh;
      overflow: hidden;
    }

    .active {
        color: lightblue !important;
    }

    .frontpart {
        height: auto;
        overflow: hidden;
    }

    .mainbody {
        padding: 40px;
        justify-content: space-evenly;
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
        <li><a href="Form.aspx">Fuel Quote</a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span> Logout</a></li>
      </ul>
    </div>
  </div>
</nav>
  
<div class="container-fluid text-center frontpart">    
  <div class="row">
      <div class="col-sm-2 sidenav"></div>
      <div class="col-sm-8">
          <div class="row text-left">
              <div class="col-sm-12">
                  <br />
                  <br />
                  <asp:Label ID="welcome" Font-Size="XX-Large" runat="server" Text="Welcome!"></asp:Label>
              </div>
          </div>
          <div class="row">
              <hr />
              <br />
              <br />
              <div class="col-sm-12 text-center">
                  <p><a href="Change_Password.aspx"><span class="glyphicon-pencil"> Change Password</span></a></p>
              </div>
          </div>
          <div class="row">
              <div class="col-md-4">
                  <div class="card">
                      <div class="view overlay">
                          <img class="card-img-top" src="clock.png" alt="Card image cap"/>
                          <a>
                              <div class="mask waves-effect waves-light rgba-white-slight"></div>
                          </a>
                      </div>
                      <div class="card-body">
                          <h4 class="card-title">Recent Activity</h4>
                          <hr />
                          <a class="link-text">
                              <h5>Go to History Page<i class="fas fa-angle-double-right ml-2"></i></h5>
                          </a>
                      </div>
                  </div>
              </div>
          </div>
      </div>
      <div class="col-sm-2 sidenav"></div>
  </div>
</div>


</body>
</html>
