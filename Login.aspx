<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html lang="en" class="body-full-height">
<head runat="server">
    <title></title>
    <!-- META SECTION -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <!-- END META SECTION -->

    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="css/theme-default.css" />
    <!-- EOF CSS INCLUDE -->
</head>
<body>
    <form id="form1" runat="server" class="body-full-height" >
        <div class="body-full-height">
            <div class="login-container">

                <div class="login-box animated fadeInDown">
                    <div class="login-logo"></div>
                    <div class="login-body">
                        <div class="login-title"><strong>Welcome Admin</strong>, Please login</div>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <input type="text" runat="server" ID="tbxEmail" class="form-control" placeholder="Username" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <input type="password" runat="server" ID="tbxPassword" class="form-control" placeholder="Password" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <a href="#" class="btn btn-link btn-block">Forgot your password?</a>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button class="btn btn-info btn-block" ID="btnLogin" runat="server" Text="Login" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="login-footer">
                        <div class="pull-left">
                            &copy; 2017 RentHere
                   
                        </div>
                        <div class="pull-right">
                            <a href="#">About</a> |
                       
                        <a href="#">Privacy</a> |
                       
                        <a href="#">Contact Us</a>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
