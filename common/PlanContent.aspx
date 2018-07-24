<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PlanContent.aspx.vb" Inherits="Com.Fujitsu.Hotespa.Web.User.Common.PlanContent" %>

<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>プラン詳細</title>
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
            <div id="content">
                <div id="hotel_hd">
                    <h1>
                        <cc1:Label ID="lbl施設名称" runat="server"></cc1:Label></h1>
                </div>
                <div id="plancontent">
                    <h2>
                        <cc1:Label ID="lblプラン名称" runat="server"></cc1:Label></h2>
                    <dl class="detail">
                        <dt>[プラン内容]</dt>
                        <dd class="clearfix">
                            <cc1:Image ID="imgプランイメージ" runat="server" Width="300" Height="201" CssClass="fr" />
                            <cc1:NoEncodeLabel ID="lblプラン詳細" runat="server"></cc1:NoEncodeLabel>
                        </dd>
                    </dl>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
