<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RentalInfo.aspx.cs" Inherits="RentalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- START BREADCRUMB -->
    <ul class="breadcrumb">
        <li><a href="#">Home</a></li>
        <li><a href="#">Forms Stuff</a></li>
        <li><a href="#">Form Layout</a></li>
        <li class="active">One Column</li>
    </ul>
    <!-- END BREADCRUMB -->

    <!-- PAGE CONTENT WRAPPER -->
    <div class="page-content-wrap">

        <div class="row">
            <div class="col-md-12">
                <asp:Repeater ID="repeaterRentalInfo" runat="server">
                    <ItemTemplate>
                        <form class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><strong>Rental Info - </strong>
                                        <asp:Label ID="lblRentalID" runat="server" Text='<%# Eval("rentalID") %>' /></td></h3>
                                    <ul class="panel-controls">
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                    </ul>
                                </div>
                                <div class="panel-body">
                                    <p></p>
                                </div>
                                <div class="panel-body">

                                    <!-- END PROFILE WIDGET -->
                                    <p></p>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Rental ID</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblRentalID2" CssClass="form-control" type="text" runat="server" Text='<%# Eval("rentalID") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Start Date</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblStartDate" CssClass="form-control" type="text" runat="server" Text='<%# Eval("startDate") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">End Date</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblEndDate" CssClass="form-control" type="text" runat="server" Text='<%# Eval("endDate") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Rental Fee</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblRentalFee" CssClass="form-control" type="text" runat="server" Text='<%# Eval("rentalFee") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Deposit</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblDeposit" CssClass="form-control" type="text" runat="server" Text='<%# Eval("deposit") %>' /></td>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Pick Up Time</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPickUpTime" CssClass="form-control" type="text" runat="server" Text='<%# Eval("pickUpTime") %>' /></td>
                                        </div>
                                    </div>

                                                                        <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Pick Up Location</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPickUpLocation" CssClass="form-control" type="text" runat="server" Text='<%# Eval("pickUpLocation") %>' /></td>
                                        </div>
                                    </div>

                                                                        <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Return Time</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblReturnTime" CssClass="form-control" type="text" runat="server" Text='<%# Eval("returnTime") %>' /></td>
                                        </div>
                                    </div>

                                                                        <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Return Location</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblReturnLocation" CssClass="form-control" type="text" runat="server" Text='<%# Eval("returnLocation") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Item ID</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblItemID" CssClass="form-control" type="text" runat="server" Text='<%# Eval("item.itemID") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Rentee ID</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblRenteeID" CssClass="form-control" type="text" runat="server" Text='<%# Eval("rentee.memberID") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Payment ID</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPaymentID" CssClass="form-control" type="text" runat="server" Text='<%# Eval("PaymentID.paymentID") %>' /></td>
                                        </div>
                                    </div>
                           

                                </div>

                            </div>
                            <div class="panel-footer">
                                <button class="btn btn-default">Clear Form</button>
                                <button class="btn btn-primary pull-right">Submit</button>
                            </div>
                            <p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            </form>
                            
                       
        </div>
    </div>

    </div>
               
    <!-- END PAGE CONTENT WRAPPER -->

    <!-- START PRELOADS -->
    <audio id="audio-alert" src="audio/alert.mp3" preload="auto"></audio>
    <audio id="audio-fail" src="audio/fail.mp3" preload="auto"></audio>
    <!-- END PRELOADS -->

    <!-- START SCRIPTS -->
    <!-- START PLUGINS -->
    <script type="text/javascript" src="js/plugins/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap.min.js"></script>
    <!-- END PLUGINS -->

    <!-- THIS PAGE PLUGINS -->
    <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
    <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>

    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-file-input.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-select.js"></script>
    <script type="text/javascript" src="js/plugins/tagsinput/jquery.tagsinput.min.js"></script>
    <!-- END THIS PAGE PLUGINS -->

    <!-- START TEMPLATE -->
    <script type="text/javascript" src="js/settings.js"></script>

    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript" src="js/actions.js"></script>
    <!-- END TEMPLATE -->
</asp:Content>

