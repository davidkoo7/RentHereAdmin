<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

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
        <li class="active">Messages</li>
    </ul>
    <!-- END BREADCRUMB -->

    <!-- START CONTENT FRAME -->
    <div class="content-frame">
        <!-- START CONTENT FRAME TOP -->
        <div class="content-frame-top">
            <div class="page-title">
                <h2><span class="fa fa-comments"></span>MemberInboxID: 
                    <asp:Label ID="lblInboxID" runat="server" Text=""></asp:Label></h2>
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
                        <a href="MemberInfo.aspx?memberID=<%#Eval("sender.memberID") %>" class="list-group-item">
                            <div class="list-group-status status-online"></div>
                            <img src="assets/images/users/user.jpg" class="pull-left" alt="Dmitry Ivaniuk">
                            <span class="contacts-title">
                                <asp:Label ID="lblSender" runat="server" Text='<%#Eval("sender.Name") %>'></asp:Label></span>
                            <p>Status:
                                <asp:Label ID="lblSenderStatus" runat="server" Text='<%#Eval("sender.Status") %>'></asp:Label></p>

                        </a>


                        <a href="MemberInfo.aspx?memberID=<%#Eval("Item.Renter.memberID") %>" class="list-group-item">
                            <div class="list-group-status status-online"></div>
                            <img src="assets/images/users/user3.jpg" class="pull-left" alt="Nadia Ali">
                            <span class="contacts-title"><span class="contacts-title">
                                <asp:Label ID="lblItemOwner" runat="server" Text='<%#Eval("Item.Renter.Name") %>'></asp:Label></span>
                            </span>
                            <p>Status:
                                <asp:Label ID="lblItemOwnerStatus" runat="server" Text='<%#Eval("item.Renter.status") %>'></asp:Label></p>
                        </a>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- END CONTENT FRAME RIGHT -->

        <!-- START CONTENT FRAME BODY -->
        <div class="content-frame-body content-frame-body-left">
            <div id="scroll2">
                <div class="messages messages-img">

                    <asp:Repeater ID="rptMessages" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# retrieveMessage(Convert.ToString(Eval("Sender.MemberID")), Convert.ToString(Eval("reply")), String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:Repeater>



                </div>
            </div>
            <div class="panel panel-default push-up-10">
                <div class="panel-body panel-body-search">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button class="btn btn-default"><span class="fa fa-camera"></span></button>
                            <button class="btn btn-default"><span class="fa fa-chain"></span></button>
                        </div>
                        <input type="text" class="form-control" placeholder="Your message..." />
                        <div class="input-group-btn">
                            <button class="btn btn-default">Send</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!-- END CONTENT FRAME BODY -->
    </div>
    <!-- END PAGE CONTENT FRAME -->

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
    <!-- END PAGE PLUGINS -->

    <!-- START TEMPLATE -->
    <script type="text/javascript" src="js/settings.js"></script>

    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript" src="js/actions.js"></script>
    <!-- END TEMPLATE -->
    <!-- END SCRIPTS -->

    <script>
        $("#scroll2").scrollTop($("#scroll2")[0].scrollHeight);

	</script>
</asp:Content>

