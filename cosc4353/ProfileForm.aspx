<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileForm.aspx.cs" Inherits="cosc4353.ProfileForm" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Profile</title>
  <script type="text/javascript">
      function zipcheck() {          
          var a = document.getElementById("zip").value;
          var b = a.toString().length;
          if (b < 5) {
              $('#errormsg').removeAttr('hidden');
              document.getElementById("zip").value = "";
              return false
          }
          if (b > 9) {
              $('#errormsg').removeAttr('hidden');
              document.getElementById("zip").value = "";
              return false
          }
          return true;
      }
  </script>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
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

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-2 sidenav">
            </div>
            <div class="col-sm-8 text-center">
                <div class="row">
                    <div class="col-8 text-center">
                        <h2>Personal Information Form</h2>
                        <p>Please fill out the following form with your information!</p>
                    </div>
                </div>
                <br />
                <br />
                <div class="row text-left">
                    <div class="col-lg-12">
                        <form id="PerInfo" class="form-horizontal" runat="server">                            
                            <div class="row mainbody">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="Fullname">Full Name *</label>
                                        <input id="fname" type="text" class="form-control" required="required" placeholder="Enter Full Name" name="fname" maxlength="50"/>
                                    </div>
                                    <div class="form-group">
                                        <label for="Add1">Address 1 *</label>
                                        <input id="Addy1" type="text" class="form-control" required="required" placeholder="Enter Address 1" name="Addy1" maxlength="100"/>
                                    </div>
                                    <div class="form-group">
                                        <label for="Add2">Address 2</label>
                                        <input id="Addy2" type="text" class="form-control" placeholder="Enter Address 2" name="Addy2" maxlength="100"/>
                                    </div>
                                    <div class="form-group">
                                        <label for="City">City *</label>
                                        <input id="city" type="text" class="form-control" required="required" placeholder="Enter City" name="city" maxlength="100"/>
                                    </div>
                                    <div class="form-group">
                                        <label for="State">State *</label>
                                        <select id="state" required="required" name="State">
                                                <option value="AL">AL</option>
	                                            <option value="AK">AK</option>
	                                            <option value="AR">AR</option>	
	                                            <option value="AZ">AZ</option>
	                                            <option value="CA">CA</option>
	                                            <option value="CO">CO</option>
	                                            <option value="CT">CT</option>
	                                            <option value="DC">DC</option>
	                                            <option value="DE">DE</option>
	                                            <option value="FL">FL</option>
	                                            <option value="GA">GA</option>
	                                            <option value="HI">HI</option>
	                                            <option value="IA">IA</option>	
	                                            <option value="ID">ID</option>
	                                            <option value="IL">IL</option>
	                                            <option value="IN">IN</option>
	                                            <option value="KS">KS</option>
	                                            <option value="KY">KY</option>
	                                            <option value="LA">LA</option>
	                                            <option value="MA">MA</option>
	                                            <option value="MD">MD</option>
	                                            <option value="ME">ME</option>
	                                            <option value="MI">MI</option>
	                                            <option value="MN">MN</option>
	                                            <option value="MO">MO</option>	
	                                            <option value="MS">MS</option>
	                                            <option value="MT">MT</option>
	                                            <option value="NC">NC</option>	
	                                            <option value="NE">NE</option>
	                                            <option value="NH">NH</option>
	                                            <option value="NJ">NJ</option>
	                                            <option value="NM">NM</option>			
	                                            <option value="NV">NV</option>
	                                            <option value="NY">NY</option>
	                                            <option value="ND">ND</option>
	                                            <option value="OH">OH</option>
	                                            <option value="OK">OK</option>
	                                            <option value="OR">OR</option>
	                                            <option value="PA">PA</option>
	                                            <option value="RI">RI</option>
	                                            <option value="SC">SC</option>
	                                            <option value="SD">SD</option>
	                                            <option value="TN">TN</option>
	                                            <option value="TX">TX</option>
	                                            <option value="UT">UT</option>
	                                            <option value="VT">VT</option>
	                                            <option value="VA">VA</option>
	                                            <option value="WA">WA</option>
	                                            <option value="WI">WI</option>	
	                                            <option value="WV">WV</option>
	                                            <option value="WY">WY</option>
                                        </select>
                                    </div>
                                    <div class="form-group">
                                        <label for="Zip">Zip Code *</label>
                                        <input id="zip" type="text" class="form-control" required="required" placeholder="Enter Zip Code" name="zip"/>
                                        <label id="errormsg" style="color: red" hidden="hidden">Zip Code must be 5-9 digits long.</label>
                                    </div>
                                    <asp:Button ID="formSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClientClick="return zipcheck();" OnClick="Button_Submit" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col-sm-2 sidenav"></div>
        </div>
    </div>


</body>
</html>
