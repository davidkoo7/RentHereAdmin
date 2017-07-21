﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupportTicketList.aspx.cs" Inherits="SupportTicketList" %>

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
                            <li class="active"><a href="#tab-first" role="tab" data-toggle="tab">Ticket Information</a></li>
                            <li><a href="#tab-second" role="tab" data-toggle="tab">Ticket - Closed</a></li>
                            <li><a href="#tab-third" role="tab" data-toggle="tab">Ticket - Answered</a></li>
                        </ul>
                        <div class="panel-body tab-content">
                            <div class="tab-pane active" id="tab-first">
                                <p></p>
                                <table class="table datatable">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Date Created/th>
                                            <th>Status</th>
                                            <th>Urgency</th>
                                            <th>Title</th>
                                            <th>Submitted By</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptSupportTicketList" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTicketID" runat="server" Text='<%# Eval("ticketID") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("date") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblUrgency" runat="server" Text='<%# Eval("urgency") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("title") %>' /></td>
                                                  
                                                    
                                                    <td>
                                                        <a href="MemberInfo.aspx?memberID=<%#Eval("Member.memberID") %>">
                                                            <asp:Label ID="lblRenteeID" runat="server" Text='<%# Eval("Member.memberID") %>' /></a>
                                                    </td>
                                                    <td>
                                                        <a href="SupportTicketInfo.aspx?ticketID=<%#Eval("ticketID") %>">
                                                            <button class="btn btn-warning btn-sm" type="button" data-toggle="tooltip" title="View Info"><span class="">View Info</span></button></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                            <div class="tab-pane" id="tab-second">
                                <p></p>
                                 <table class="table datatable">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Date Created/th>
                                            <th>Status</th>
                                            <th>Urgency</th>
                                            <th>Title</th>
                                            <th>Submitted By</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptSupportTicketListUrgency" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTicketID" runat="server" Text='<%# Eval("ticketID") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("date") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblUrgency" runat="server" Text='<%# Eval("urgency") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("title") %>' /></td>
                                                  
                                                    
                                                    <td>
                                                        <a href="MemberInfo.aspx?memberID=<%#Eval("Member.memberID") %>">
                                                            <asp:Label ID="lblRenteeID" runat="server" Text='<%# Eval("Member.memberID") %>' /></a>
                                                    </td>
                                                    <td>
                                                        <a href="SupportTicketInfo.aspx?ticketID=<%#Eval("ticketID") %>">
                                                            <button class="btn btn-warning btn-sm" type="button" data-toggle="tooltip" title="View Info"><span class="">View Info</span></button></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>



                            </div>
                            <div class="tab-pane" id="tab-third">
                                <p></p>
                                 <table class="table datatable">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Date Created/th>
                                            <th>Status</th>
                                            <th>Urgency</th>
                                            <th>Title</th>
                                            <th>Submitted By</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="rptSupportTicketListStatus" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTicketID" runat="server" Text='<%# Eval("ticketID") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("date") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblUrgency" runat="server" Text='<%# Eval("urgency") %>' /></td>
                                                    <td>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("title") %>' /></td>
                                                  
                                                    
                                                    <td>
                                                        <a href="MemberInfo.aspx?memberID=<%#Eval("Member.memberID") %>">
                                                            <asp:Label ID="lblRenteeID" runat="server" Text='<%# Eval("Member.memberID") %>' /></a>
                                                    </td>
                                                    <td>
                                                        <a href="SupportTicketInfo.aspx?ticketID=<%#Eval("ticketID") %>">
                                                            <button class="btn btn-warning btn-sm" type="button" data-toggle="tooltip" title="View Info"><span class="">View Info</span></button></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>

                            </div>
                        </div>
                        <div class="panel-footer">
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

