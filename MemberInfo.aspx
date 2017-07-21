<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberInfo.aspx.cs" Inherits="MemberInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- START BREADCRUMB -->
    <ul class="breadcrumb">
        <li><a href="#">Home</a></li>
        <li><a href="#">Forms Stuff</a></li>
        <li><a href="#">Form Layout</a></li>
        <li class="active">Tabbed</li>
    </ul>
    <!-- END BREADCRUMB -->

    <!-- PAGE CONTENT WRAPPER -->
    <div class="page-content-wrap">

        <div class="row">
            <div class="col-md-12">

                <form class="form-horizontal">

                    <div class="panel panel-default tabs">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#tab-first" role="tab" data-toggle="tab">Personal Information</a></li>
                            <li><a href="#tab-second" role="tab" data-toggle="tab">Item Information</a></li>
                            <li><a href="#tab-third" role="tab" data-toggle="tab">Transaction History</a></li>
                        </ul>
                        <div class="panel-body tab-content">
                            <div class="tab-pane active" id="tab-first">
                                <p></p>
                                <asp:Repeater ID="rptMemberInfo" runat="server">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label"></label>
                                            <div class="col-md-6">

                                                <div class="panel-body profile bg-info">

                                                    <div class="profile-image">
                                                        <%--                                                                                                <img src="/image/item/<%# DataBinder.Eval(Container.DataItem, "profilePic") %>">--%>

                                                        <img src="assets/images/users/user2.jpg">
                                                    </div>

                                                </div>


                                            </div>
                                        </div>
                                        <!-- END PROFILE WIDGET -->
                                        <p></p>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Member ID</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxMemberID" CssClass="form-control" type="text" Text='<%# Eval("memberID") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Full Name</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxName" CssClass="form-control" type="text" Text='<%# Eval("name") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Date of birth</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxDOB" CssClass="form-control" type="text" Text='<%# Eval("dateOfBirth") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Email</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxEmail" CssClass="form-control" type="text" Text='<%# Eval("email") %>' runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Phone Number</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxPhoneNumber" CssClass="form-control" type="text" Text='<%# Eval("phoneNumber") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Registration Date</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxDateJoined" CssClass="form-control" type="text" Text='<%# Eval("dateJoined") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Status</label>
                                            <div class="col-md-6 col-xs-12">
                                                <asp:TextBox ID="tbxStatus" CssClass="form-control" type="text" Text='<%# Eval("memberID") %>' runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Gender:</label>
                                            <div class="col-md-3">
                                                <select class="validate[required] select" id="formGender">
                                                    <option value="">Choose option</option>
                                                    <option value="1">Male</option>
                                                    <option value="0">Female</option>
                                                </select>
                                                <span class="help-block">Required</span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">Address</label>
                                            <div class="col-md-6 col-xs-12">

                                                <textarea class="form-control" rows="5">Morbi tellus nulla, cursus non nisi sed, porttitor dignissim erat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc facilisis commodo lectus. Vivamus vel tincidunt enim, non vulputate ipsum. Ut pellentesque consectetur arcu sit amet scelerisque. Fusce commodo leo eros, ut eleifend massa congue at.</textarea>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-12 control-label">About</label>
                                            <div class="col-md-6 col-xs-12">
                                                <textarea class="form-control" rows="5">Morbi tellus nulla, cursus non nisi sed, porttitor dignissim erat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc facilisis commodo lectus. Vivamus vel tincidunt enim, non vulputate ipsum. Ut pellentesque consectetur arcu sit amet scelerisque. Fusce commodo leo eros, ut eleifend massa congue at.</textarea>
                                                <%--                                                <asp:TextBox ID="tbxAbout" CssClass="form-control" type="text" Text='<%# Eval("memberID") %>' runat="server"></asp:TextBox>--%>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="tab-pane" id="tab-second">
                                <p></p>
                                <table class="table datatable">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Name</th>
                                            <th>Deposit</th>
                                            <th>Date Posted</th>
                                            <th>Posted By</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptItemList" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblitemID" runat="server" Text='<%# Eval("itemID") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("name") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblDeposit" runat="server" Text='<%# Eval("deposit") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblPostedDate" runat="server" Text='<%# Eval("postedDate") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblPostedBy" runat="server" Text='<%# Eval("renter.memberID") %>' /></td>
                                                    <td>
                                                        <a href="ItemInfo.aspx?itemID=<%#Eval("itemID") %>" >   <button class="btn btn-warning btn-sm" type="button" data-toggle="tooltip" title="View Info"><span class="">View Info</span></button></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>



                            </div>
                            <div class="tab-pane" id="tab-third">
                                <p>This is non libero bibendum, scelerisque arcu id, placerat nunc. Integer ullamcorper rutrum dui eget porta. Fusce enim dui, pulvinar a augue nec, dapibus hendrerit mauris. Praesent efficitur, elit non convallis faucibus, enim sapien suscipit mi, sit amet fringilla felis arcu id sem. Phasellus semper felis in odio convallis, et venenatis nisl posuere. Morbi non aliquet magna, a consectetur risus. Vivamus quis tellus eros. Nulla sagittis nisi sit amet orci consectetur laoreet.</p>

                                <div class="form-group">
                                    <label class="col-md-3 col-xs-12 control-label">E-mail</label>
                                    <div class="col-md-6 col-xs-12">
                                        <input type="text" class="form-control" value="johndoe@domain.com" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 col-xs-12 control-label">Password</label>
                                    <div class="col-md-6 col-xs-12">
                                        <input type="password" class="form-control" value="password" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 col-xs-12 control-label">POP3</label>
                                    <div class="col-md-6 col-xs-12">
                                        <input type="text" class="form-control" value="pop3.domain.com" />
                                    </div>
                                </div>

                                <div class="form-group push-up-30">
                                    <label class="col-md-3 col-xs-12 control-label">Copy to</label>
                                    <div class="col-md-6 col-xs-12">
                                        <input type="text" class="form-control" value="doejohn@domain.com" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="panel-footer">
                            <button class="btn btn-primary pull-right">Save Changes <span class="fa fa-floppy-o fa-right"></span></button>
                        </div>
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

    <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-datepicker.js'></script>
    <script type='text/javascript' src='js/plugins/bootstrap/bootstrap-select.js'></script>

    <script type='text/javascript' src='js/plugins/validationengine/languages/jquery.validationEngine-en.js'></script>
    <script type='text/javascript' src='js/plugins/validationengine/jquery.validationEngine.js'></script>

    <script type='text/javascript' src='js/plugins/jquery-validation/jquery.validate.js'></script>

    <script type='text/javascript' src='js/plugins/maskedinput/jquery.maskedinput.min.js'></script>

    <script type="text/javascript" src="js/plugins/datatables/jquery.dataTables.min.js"></script>
    <!-- END THIS PAGE PLUGINS -->

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

