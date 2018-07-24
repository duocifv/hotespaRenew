<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RoomTypeContent.aspx.vb"
    Inherits="Com.Fujitsu.Hotespa.Web.User.Common.RoomTypeContent" %>

<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部屋タイプ詳細</title>
    <link href="../css/font/default.css" rel="stylesheet" type="text/css" media="screen, print" title="default" />
    <link href="../css/font/large.css" rel="alternate stylesheet" type="text/css" media="screen, print" title="large" />
    <link href="../css/font/small.css" rel="alternate stylesheet" type="text/css" media="screen, print" title="small" />
    <link href="../css/import.css" rel="stylesheet" type="text/css" media="screen, print" />
    <link href="../css/form.css" rel="stylesheet" type="text/css" media="screen, print" />

    <link href="../js/fancybox/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css" media="screen" />

    <link href="../css/form_ext.css" rel="stylesheet" type="text/css" media="screen, print" />

    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../js/fancybox/jquery.mousewheel-3.0.2.pack.js"></script>
    <script type="text/javascript" src="../js/fancybox/jquery.fancybox-1.3.1.js"></script>

    <script type="text/javascript" src="../js/base.js"></script>
    <script type="text/javascript" src="../js/styleswitcher.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript" src="../js/form.js"></script>
    <script type="text/javascript" src="../js/swfobject.js"></script>

</head>
<body>
    <form runat="server">
        <div id="wrapper">
            <div id="container">
                <div id="content">
                    <table border="0" cellspacing="0" cellpadding="0" width="700" align="Center">
                        <tr>
                            <td>
                                <h2>
                                    <img src="../image/form_divide/tit_roominfo.png" alt="部屋タイプ詳細" width="700" height="35" /></h2>
                                <div id="roominfo">
                                    <h3>
                                        <cc1:Label ID="lbl部屋タイプ名" runat="server"></cc1:Label></h3>
                                    <h4>
                                        部屋のイメージ</h4>
                                    <ul class="pct">
                                        <li>
                                            <cc1:Image ID="imgRoom1" runat="server" Width="150" Height="120" /></li>
                                        <li>
                                            <cc1:Image ID="imgRoom2" runat="server" Width="150" Height="120" /></li>
                                        <li>
                                            <cc1:Image ID="imgRoom3" runat="server" Width="150" Height="120" /></li>
                                        <li>
                                            <cc1:Image ID="imgRoom4" runat="server" Width="150" Height="120" /></li>
                                    </ul>
                                    <h4>
                                        詳細情報</h4>
                                    <ul class="etc">
                                        <cc1:NoEncodeLabel ID="lbl詳細情報" runat="server"></cc1:NoEncodeLabel>
                                    </ul>
                                    <cc1:GridView ID="gv料金表" runat="server" AutoGenerateColumns="False" CssClass="plan th" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="一室あたり料金">
                                                <itemstyle cssclass="th" />
                                            </asp:TemplateField>
                                            <asp:TemplateField></asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="hd" />
                                    </cc1:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
