<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PropertyContent.aspx.vb"
    Inherits="Com.Fujitsu.Hotespa.Web.User.Common.PropertyContent" %>

<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>施設詳細</title>
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
                                <div id="hotel_hd">
                                    <h1>
                                        <cc1:Label ID="lbl施設名称" runat="server"></cc1:Label></h1>
                                    <div class="catch">
                                        <cc1:Image ID="img施設名称" runat="server" Width="700" Height="120" /></div>
                                </div>
                                <h2>
                                    <img src="../image/form_divide/tit_hotelinfo.png" alt="基本情報" width="700" height="35" /></h2>
                                <div id="hotelinfo">
                                    <div class="base clearfix">
                                            <cc1:Image ID="img施設写真" runat="server" Width="220" Height="177" CssClass="fl" />
                                        <dl class="fr">
                                            <dt>［住所］</dt>
                                            <dd>
                                                <cc1:NoEncodeLabel ID="lbl住所" runat="server"></cc1:NoEncodeLabel><cc1:HyperLink ID="lnkMap"
                                                    runat="server" ImageUrl="../image/form_divide/bt_map.png" Width="52" Height="20"></cc1:HyperLink>
                                                </dd>
                                            <dt>［TEL / FAX］</dt>
                                            <dd>
                                                <cc1:NoEncodeLabel ID="lbl連絡先" runat="server"></cc1:NoEncodeLabel>
                                            </dd>
                                            <dt>［チェックイン / チェックアウト］</dt>
                                            <dd>
                                                <cc1:NoEncodeLabel ID="lbl基本時刻" runat="server"></cc1:NoEncodeLabel></dd>
                                            <dt>［交通アクセス］</dt>
                                            <dd>
                                                <cc1:NoEncodeLabel ID="lbl交通アクセス" runat="server"></cc1:NoEncodeLabel>
                                            </dd>
                                            <dt>［駐車場］</dt>
                                            <dd>
                                                <cc1:NoEncodeLabel ID="lbl駐車場" runat="server"></cc1:NoEncodeLabel>
                                            </dd>
                                        </dl>
                                    </div>
                                    <h3 class="line">
                                        ■その他設備・サービス</h3>
                                    <cc1:Table ID="tblその他設備サービス表" runat="server" CellSpacing="1" CssClass="etc th">
                                        <cc1:TableRow ID="tblrow風呂種類">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    風呂（種類）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl風呂種類" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow風呂泉質">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    風呂（泉質）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl風呂泉質" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow風呂効能">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    風呂（効能）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl風呂効能" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow風呂備考">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    風呂（備考）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:NoEncodeLabel ID="lbl風呂備考" runat="server"></cc1:NoEncodeLabel><span runat="server" id="spn風呂URL"><br/><cc1:HyperLink ID="hlk風呂URL" runat="server"></cc1:HyperLink></span>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow食事場所朝食">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    食事場所（朝食）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl食事場所朝食" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow食事場所夕食">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    食事場所（夕食）
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl食事場所夕食" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow部屋施設備品">
                                            <cc1:TableCell Width="100" CssClass="th">
                                   部屋設備・備品
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl部屋施設備品" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow館内設備">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    館内設備
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl館内設備" runat="server"></cc1:Label>
                                    <div>
                                        <cc1:HyperLink ID="lbtn詳細" runat="server" Text="詳細はこちら" CssClass="arrow"></cc1:HyperLink>
                                    </div>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrowサービス">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    サービス
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lblサービス" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow身障者設備">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    身障者設備
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl身障者設備" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrow特典">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    特典
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lbl特典" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrowレジャー">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    周辺のレジャー
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lblレジャー" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                        <cc1:TableRow ID="tblrowカード">
                                            <cc1:TableCell Width="100" CssClass="th">
                                    カード
                                            </cc1:TableCell>
                                            <cc1:TableCell>
                                    <cc1:Label ID="lblカード" runat="server"></cc1:Label>
                                            </cc1:TableCell>
                                        </cc1:TableRow>
                                    </cc1:Table>
                                    <h3>
                                        ■条件・その他</h3>
                                    <ul class="etc">
                                        <cc1:NoEncodeLabel ID="lbl条件その他" runat="server"></cc1:NoEncodeLabel>
                                    </ul>
                                    <h3>
                                        ■キャンセルポリシー</h3>
                                    <div style="line-height: 20px">
                                        <cc1:NoEncodeLabel ID="lblキャンセルポリシー説明" runat="server">
                                        </cc1:NoEncodeLabel>
                                        <cc1:NoEncodeLabel ID="lblキャンセルポリシー補足" runat="server" ForeColor="#FF0000">
                                        </cc1:NoEncodeLabel>
                                    </div>
                                    <ul class="etc">
                                        <cc1:NoEncodeLabel ID="lblキャンセルポリシー" runat="server"></cc1:NoEncodeLabel>
                                    </ul>
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
