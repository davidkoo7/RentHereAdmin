<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisputeInfo.aspx.cs" Inherits="DisputeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #scroll2 {
            overflow: scroll;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- START BREADCRUMB -->
    <ul class="breadcrumb push-down-0">
        <li><a href="#">Home</a></li>
        <li><a href="#">Pages</a></li>
        <li class="active">Support Ticket</li>
    </ul>
    <!-- END BREADCRUMB -->

    <!-- START CONTENT FRAME -->
    <div class="content-frame">
        <!-- START CONTENT FRAME TOP -->
        <div class="content-frame-top">
            <div class="page-title">
                <h2><span class="fa fa-comments"></span>Support Ticket</h2>
            </div>
            <div class="pull-right">
                <button class="btn btn-danger"><span class="fa fa-book"></span>Contacts</button>
                <button class="btn btn-default content-frame-right-toggle"><span class="fa fa-bars"></span></button>
            </div>
        </div>
        <!-- END CONTENT FRAME TOP -->

        <!-- START CONTENT FRAME RIGHT -->
        <div class="content-frame-right">
            <asp:Repeater ID="rptMemberInfoRedirect" runat="server">
                <ItemTemplate>
                    <div class="list-group list-group-contacts border-bottom push-down-10">
                        <a href="MemberInfo.aspx?memberID=<%#Eval("SubmittedBy.memberID") %>" class="list-group-item">
                            <div class="list-group-status status-online"></div>
                            <img src="assets/images/users/user.jpg" class="pull-left" alt="Dmitry Ivaniuk">
                            <span class="contacts-title">
                                <asp:Label ID="lblSubmitterName" runat="server" Text='<%#Eval("SubmittedBy.Name") %>'></asp:Label></span>
                            <p></p>
                            <asp:Label ID="lblSubmitterStatus" runat="server" Text='<%#Eval("SubmittedBy.Status") %>'></asp:Label></p>

                        </a>
                        <a href="MemberInfo.aspx?memberID=<%#Eval("Rental.Item.Renter.memberID") %>" class="list-group-item">
                            <div class="list-group-status status-online"></div>
                            <img src="assets/images/users/user.jpg" class="pull-left" alt="Dmitry Ivaniuk">
                            <span class="contacts-title">
                                <asp:Label ID="lblRenterName" runat="server" Text='<%#Eval("Rental.Item.Renter.Name") %>'></asp:Label></span>
                            <p></p>
                            <asp:Label ID="lblRenterStatus" runat="server" Text='<%#Eval("Rental.Item.Renter.Status") %>'></asp:Label></p>

                        </a>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- END CONTENT FRAME RIGHT -->

        <!-- START CONTENT FRAME BODY -->
        <div class="content-frame-body content-frame-body-left">
            <div id="scroll2">
                <div class="messages">
                    <asp:Repeater ID="rptMessages" runat="server">
                        <ItemTemplate>
                                    <asp:Label ID="lblMessages" runat="server" Text='<%# retrieveMessage(Convert.ToString(Eval("Member.MemberID")), Convert.ToString(Eval("Staff.StaffID")), Convert.ToString(Eval("reply")), String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="panel panel-default push-up-10">
                <div class="panel-body panel-body-search">
                    <div class="input-group">
                        <div class="">

                            <div class="col-md-4">
                                Status
                                <br>
                                <asp:DropDownList CssClass="col-sm-12" ID="ddlStatus" runat="server">
                                    <asp:ListItem>Answered</asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Closed</asp:ListItem>
                                </asp:DropDownList>
                                <span class="help-block"></span>
                            </div>
                            <div class="col-md-4">
                                Urgency
                                <br>
                                <asp:DropDownList CssClass="col-sm-12" ID="ddlUrgency" runat="server">
                                    <asp:ListItem>Low</asp:ListItem>
                                    <asp:ListItem>Medium</asp:ListItem>
                                    <asp:ListItem>High</asp:ListItem>
                                </asp:DropDownList>
                                <span class="help-block"></span>
                            </div>
                            <div class="col-md-12">
                                <br />
                                Messages
                                <textarea runat="server" id="txtMsg" class="form-control" cols="150" rows="5"></textarea>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <asp:Button CssClass="btn btn-primary" ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Send" />
                            </div>
                        </div>

                    </div>
                    <br />
                </div>
            </div>

        </div>
        <!-- END CONTENT FRAME BODY -->
    </div>
    <!-- END PAGE CONTENT FRAME -->

    <script type="text/javascript" src="js/plugins/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap.min.js"></script>
    <!-- END PLUGINS -->

    <!-- THIS PAGE PLUGINS -->
    <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
    <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>

    <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-datepicker.js'></script>
    <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-select.js'></script>

    <script type='text/javascript' src='js/plugins/validationengine/languages/jquery.validationEngine-en.js'></script>
    <script type='text/javascript' src='js/plugins/validationengine/jquery.validationEngine.js'></script>

    <script type='text/javascript' src='js/plugins/jquery-validation/jquery.validate.js'></script>

    <script type='text/javascript' src='js/plugins/maskedinput/jquery.maskedinput.min.js'></script>
    <!-- END THIS PAGE PLUGINS -->

    <!-- START TEMPLATE -->
    <script type="text/javascript" src="js/settings.js"></script>

    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript" src="js/actions.js"></script>
    <script>
        $("#scroll2").scrollTop($("#scroll2")[0].scrollHeight);

	</script>
</asp:Content>
