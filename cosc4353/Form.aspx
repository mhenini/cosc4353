<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="cosc4353.Form" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="http://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/src/js/bootstrap-datetimepicker.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            <%--validate gallons field--%>
            $('#gallons').keyup(function () {
                if ($('#gallons').val() > 0 || $('#gallons').val() == '') {
                    $('#error').attr('hidden', 'hidden');
                } else {
                    $('#error').removeAttr('hidden');
                }
            });

            <%--enable getPrice button--%>
            $('input, textarea').keyup(function () {

                var empty = false;

                $('input, textarea').each(function () {
                    if ($(this).prop('required') && $(this).val() == '') {
                        empty = true;
                    }
                });

                if (empty || !$('#error').prop('hidden')) {
                    $('#getPrice').attr('disabled', 'disabled');
                } else {
                    $('#getPrice').removeAttr('disabled');
                }

                <%--enable submitPrice button--%>
                var empty1 = false;

                if ($('#price').val() == '' || $('#total').val() == '') {
                    empty1 = true;
                }

                if (empty || empty1 || $('#getPrice').prop('disabled')) {
                    $('#submitPrice').attr('disabled', 'disabled');
                } else {
                    $('#submitPrice').removeAttr('disabled');
                }
            });
        });
    </script>

    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link href="http://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/build/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <style>
        /* Remove the navbar's default margin-bottom and rounded borders */
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }

        /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
        .row.content {
            height: 600px;
        }

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

            .row.content {
                height: auto;
            }
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
                    <li><a href="Profile.aspx">Profile</a></li>
                    <li><a href="History.aspx">History</a></li>
                    <li class="active"><a href="Form.aspx">Fuel Quote</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-out"></span>Logout</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container-fluid text-center">
        <div class="row content">
            <div class="col-sm-2 sidenav">
            </div>
            <div class="col-sm-8 text-left">
                <br />
                <h2>Fuel Quote Form</h2>
                <p>Complete all fields and then click on "Get Price" to view the suggested price. Click on "Submit Quote" to save the quote.</p>
                <hr>

                <form class="form-horizontal" runat="server">

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <script type="text/javascript">
                        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                        function EndRequestHandler(sender, args) {
                             //Binding Code Again
                            <%--validate gallons field--%>
                            $('#gallons').keyup(function () {
                                if ($('#gallons').val() > 0 || $('#gallons').val() == '') {
                                    $('#error').attr('hidden', 'hidden');
                                } else {
                                    $('#error').removeAttr('hidden');
                                }
                            });

                            <%--enable getPrice button--%>
                            $('input, textarea').keyup(function () {

                                var empty = false;

                                $('input, textarea').each(function () {
                                    if ($(this).prop('required') && $(this).val() == '') {
                                        empty = true;
                                    }
                                });

                                if (empty || !$('#error').prop('hidden')) {
                                    $('#getPrice').attr('disabled', 'disabled');
                                } else {
                                    $('#getPrice').removeAttr('disabled');
                                }

                                <%--enable submitPrice button--%>
                                var empty1 = false;

                                if ($('#price').val() == '' || $('#total').val() == '') {
                                    empty1 = true;
                                }

                                if (empty || empty1 || $('#getPrice').prop('disabled')) {
                                    $('#submitPrice').attr('disabled', 'disabled');
                                } else {
                                    $('#submitPrice').removeAttr('disabled');
                                }
                            });
                        }
                    </script>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Gallons Requested:</label>
                                <div class="col-sm-10">
                                    <input runat="server" class="form-control" id="gallons" type="text" placeholder="Input a number > 0..." required="required">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Delivery Address:</label>
                                <div class="col-sm-10">
                                    <input runat="server" class="form-control" id="address" type="text" placeholder="Address from profile..." disabled>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Delivery Date:</label>
                                <div class="col-sm-10">
                                    <div class='input-group date' id='datetimepicker'>
                                        <input runat="server" id="date" type='text' class="form-control" required="required" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $(function () {
                                        $('#datetimepicker').datetimepicker({
                                            format: 'L',
                                            minDate: moment(),
                                        });
                                    });

                                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                                    function EndRequestHandler(sender, args) {
                                        //Binding Code Again
                                        $('#datetimepicker').datetimepicker({
                                            format: 'L',
                                            minDate: moment().millisecond(0).second(0).minute(0).hour(0),
                                            useCurrent: false
                                        });
                                    }
                                </script>
                            </div>

                            <fieldset disabled>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Suggested Price:</label>
                                    <div class="col-sm-10">
                                        <input runat="server" type="text" id="price" class="form-control" placeholder="Suggested Price">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Total Amount Due:</label>
                                    <div class="col-sm-10">
                                        <input runat="server" type="text" id="total" class="form-control" placeholder="Total Price">
                                    </div>
                                </div>
                            </fieldset>

                            <asp:Button ID="getPrice" runat="server" class="btn btn-default" disabled="disabled" Text="Get Price" OnClick="getPrice_Click" />
                            <asp:Button ID="submitPrice" runat="server" class="btn btn-default" disabled="disabled" Text="Submit Quote" OnClick="savePrice_Click" />
                            <br />
                            <label id="error" style="color: red" hidden="hidden">Error: Gallons requested must be a number greater than 0.</label>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </form>
                <hr>
            </div>
            <div class="col-sm-2 sidenav">
            </div>
        </div>
    </div>

    <footer class="container-fluid text-center">
    </footer>

</body>
</html>
