<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemInfo.aspx.cs" Inherits="ItemInfo" %>

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
                <asp:Repeater ID="repeaterItemInformation" runat="server">
                    <ItemTemplate>
                        <form class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><strong>Item Info - </strong>
                                        <asp:Label ID="lblitemID" runat="server" Text='<%# Eval("itemID") %>' /></td></h3>
                                    <ul class="panel-controls">
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                    </ul>
                                </div>
                                <div class="panel-body">
                                    <p></p>
                                </div>
                                <div class="panel-body">

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label"></label>
                                        <div class="col-md-6">

                                            <div class="panel-body profile bg-info">

                                                <div class="profile-image">
                                                    <img src="/img/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>">
                                                    <img src="/img/item/<%# DataBinder.Eval(Container.DataItem, "img2") %>">
                                                    <img src="/img/item/<%# DataBinder.Eval(Container.DataItem, "img3") %>">
                                                    <img src="/img/item/<%# DataBinder.Eval(Container.DataItem, "img4") %>">
                                                </div>

                                            </div>


                                        </div>
                                    </div>
                                    <!-- END PROFILE WIDGET -->
                                    <p></p>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Item ID</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblItemID2" CssClass="form-control" type="text" runat="server" Text='<%# Eval("itemID") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Name</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblItemName" CssClass="form-control" type="text" runat="server" Text='<%# Eval("name") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Date Posted</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPostedDate" CssClass="form-control" type="text" runat="server" Text='<%# Eval("postedDate") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Deposit</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblDeposit"  CssClass="form-control" type="text" runat="server" Text='<%# Eval("deposit") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Price Per Day</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPricePerDay" CssClass="form-control" type="text" runat="server" Text='<%# Eval("pricePerDay") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Price Per Week</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblPricePerWeek" CssClass="form-control" type="text" runat="server" Text='<%# Eval("pricePerWeek") %>' /></td>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Price Per Month</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label CssClass="form-control" type="text" ID="lblPricePerMonth" runat="server" Text='<%# Eval("pricePerMonth") %>' /></td>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Category</label>
                                        <div class="col-md-6 col-xs-12">
                                            <input type="text" class="form-control" value="Doe" />
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Description</label>
                                        <div class="col-md-6 col-xs-12">
                                            <asp:Label ID="lblDescription" CssClass="form-control" rows="5" runat="server" Text='<%# Eval("itemID") %>' /></td>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-md-3 col-xs-12 control-label">Posted By</label>
                                        <div class="col-md-6 col-xs-12">
                                            <input type="text" class="form-control" value="Doe" />
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

