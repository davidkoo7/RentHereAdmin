<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ICVerificationList.aspx.cs" Inherits="ICVerificationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- START BREADCRUMB -->
    <ul class="breadcrumb">
        <li><a href="#">Home</a></li>
        <li class="active">Item Information</li>
    </ul>
    <!-- END BREADCRUMB -->

    <!-- PAGE TITLE -->
    <div class="page-title">
        <h2><span class="fa fa-arrow-circle-o-left"></span>Item Information</h2>
    </div>
    <!-- END PAGE TITLE -->

    <!-- PAGE CONTENT WRAPPER -->
    <div class="page-content-wrap">

        <div class="row">
            <div class="col-md-12">

                <!-- START DEFAULT DATATABLE -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">List of Member</h3>
                        <ul class="panel-controls">
                            <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a></li>
                            <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                            <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                        </ul>
                    </div>

                    <div class="panel-body">
                        <table class="table datatable">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Address</th>
                                    <th>Email</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptListOfICVerification" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMemberID" runat="server" Text='<%# Eval("memberID") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblMemberName" runat="server" Text='<%# Eval("name") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("address") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' /></td>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' /></td>
                                            <td>
                                                <asp:LinkButton CssClass="btn btn-info" OnClick="lbViewInfo_Click" ID="lbViewInfo" runat="server">View</asp:LinkButton>

                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
                <!-- END DEFAULT DATATABLE -->
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />

            </div>
        </div>

    </div>
    <!-- START PRELOADS -->

    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <asp:Repeater ID="rptMemberInfo" runat="server">
                    <ItemTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">IC Information</h4>
                        </div>
                        <div class="modal-body">
                            <div class="gallery">
                                <label class="">IC Image</label>
                                <div class="">
                                    <a class="gallery-item" href="/image/item/<%# DataBinder.Eval(Container.DataItem, "identificationPicture") %>" title="IC Image" data-gallery>
                                        <div class="image">
                                            <img src="assets/images/gallery/nature-1.jpg" alt="Nature Image 1" />
                                        </div>
                                    </a>
                                </div>


                            </div>


                            <label class="">IC Number</label>
                            <div class="">
                                <asp:TextBox ID="tbxICNum" CssClass="form-control" type="text" Text='<%# Eval("identificationNumber") %>' runat="server"></asp:TextBox>
                            </div>
                            <label class="">Full Name</label>
                            <div class="">
                                <asp:TextBox ID="tbxFullName" CssClass="form-control" type="text" Text='<%# Eval("name") %>' runat="server"></asp:TextBox>
                            </div>

                            <label class="">Date Of Birth</label>
                            <div class="">
                                <asp:TextBox ID="tbxDOB" CssClass="form-control" type="text" Text='<%# Eval("dateOfBirth") %>' runat="server"></asp:TextBox>
                            </div>
                            <label class="">Phone Number</label>
                            <div class="">
                                <asp:TextBox ID="tbxPhoneNumber" CssClass="form-control" type="text" Text='<%# Eval("phoneNumber") %>' runat="server"></asp:TextBox>
                            </div>
                            <p>
                            </p>
                            <asp:Button ID="btnApproved" OnClick="btnApproved_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                            <asp:Button ID="btnReject" OnClick="btnReject_Click" CssClass="btn btn-warning" runat="server" Text="Reject" />


                        </div>
                        <div class="modal-footer">

                            <button type="button" class="close" data-dismiss="modal">&times;</button>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>
    <!-- BLUEIMP GALLERY -->
    <div id="blueimp-gallery" class="blueimp-gallery blueimp-gallery-controls">
        <div class="slides"></div>
        <h3 class="title"></h3>
        <a class="prev">‹</a>
        <a class="next">›</a>
        <a class="close">×</a>
        <a class="play-pause"></a>
        <ol class="indicator"></ol>
    </div>

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

    <!-- START THIS PAGE PLUGINS-->
    <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
    <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>

    <script type="text/javascript" src="js/plugins/blueimp/jquery.blueimp-gallery.min.js"></script>
    <script type="text/javascript" src="js/plugins/dropzone/dropzone.min.js"></script>
    <script type="text/javascript" src="js/plugins/icheck/icheck.min.js"></script>
    <!-- END THIS PAGE PLUGINS-->

    <!-- START TEMPLATE -->
    <script type="text/javascript" src="js/settings.js"></script>

    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript" src="js/actions.js"></script>
    <!-- END TEMPLATE -->

    <script>            
        document.getElementById('links').onclick = function (event) {
            event = event || window.event;
            var target = event.target || event.srcElement;
            var link = target.src ? target.parentNode : target;
            var options = {
                index: link, event: event, onclosed: function () {
                    setTimeout(function () {
                        $("body").css("overflow", "");
                    }, 200);
                }
            };
            var links = this.getElementsByTagName('a');
            blueimp.Gallery(links, options);
        };
        </script>


</asp:Content>

