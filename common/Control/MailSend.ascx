<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MailSend.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.MailSend" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<h2 class="sub"><cc1:Image ID="imgTitle" runat="server" AlternateText="メール送信" ImageUrl="../../image/reservation/sub_sendmail.png" /></h2>
<div  align="left">
<cc1:Panel ID="pnl入力" runat="server">
<table class="odd" summary="予約確認アドレス入力表" cellspacing="1">
    <caption><span>ご指定のメールアドレスに、予約確認メールを送信します。</span></caption>
    <tr runat="server" id="trIn1">
        <th><cc1:CheckBox ID="chkPCメール" runat="server" Text="PCのメールアドレスに送付" BindSource="" Value="PCメールアドレス" /></th>
        <td><cc1:Label ID="lblPCメールアドレス" runat="server" BindSource="PCメールアドレス"></cc1:Label>&nbsp;</td>
    </tr>
    <tr runat="server" id="trIn2">
        <th><cc1:CheckBox ID="chk携帯メール" runat="server" Text="携帯のメールアドレスに送付" BindSource="" Value="携帯メールアドレス" /></th>
        <td><cc1:Label ID="lbl携帯メールアドレス" runat="server" BindSource="携帯メールアドレス"></cc1:Label>&nbsp;</td>
    </tr>
    <tr>
        <th><cc1:CheckBox ID="chkPCその他" runat="server" Text="その他の<br>PCのメールアドレスに送付" BindSource="" Value="その他PCメールアドレス" /></th>
        <td>
            <table>
                <tr>
                <td class="sp">
                    ※入力内容にお間違いがないかよく確認してください。</td>
                </tr>
                <tr>
                <td class="sp"><cc1:TextBox ID="txtPCメールアドレスその他" runat="server" ImeMode="Disabled" MaxLength="100" CssClass="ImeDisabled" DisplayName="その他のPCのメールアドレス" ></cc1:TextBox></td>
                </tr>
                <tr>
                <td><cc1:TextBox ID="txtPCメールアドレスその他確認" runat="server" ImeMode="Disabled" MaxLength="100" CssClass="ImeDisabled"></cc1:TextBox> （確認用）</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <th><cc1:CheckBox ID="chk携帯その他" runat="server" Text="その他の<br>携帯のメールアドレスに送付" BindSource="" Value="その他携帯メールアドレス" /></th>
        <td>
            <table>
                <tr>
                <td class="sp">
                    ※入力内容にお間違いがないかよく確認してください。</td>
                </tr>
                <tr>
                <td class="sp"><cc1:TextBox ID="txt携帯メールアドレスその他" runat="server" ImeMode="Disabled" MaxLength="80" CssClass="ImeDisabled" DisplayName="その他の携帯のメールアドレス"></cc1:TextBox>
                ＠
                <cc1:DropDownList ID="ddlドメイン" runat="server" DisplayName="その他の携帯のドメイン"></cc1:DropDownList>
                </td>
                </tr>
                <tr>
                <td><cc1:TextBox ID="txt携帯メールアドレスその他確認" runat="server" ImeMode="Disabled" MaxLength="80" CssClass="ImeDisabled"></cc1:TextBox> （確認用）</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</cc1:Panel>
<cc1:Panel ID="pnl表示" runat="server">
    <table class="odd" summary="予約確認アドレス表" cellspacing="1">
        <tr runat="server" id="tr1">
            <th>PCメールアドレス</th>
            <td runat="server" id="td1"></td>
        </tr>
        <tr runat="server" id="tr2">
            <th>携帯メールアドレス</th>
            <td runat="server" id="td2"></td>
        </tr>
        <tr runat="server" id="tr3">
            <th>その他PCメールアドレス</th>
            <td runat="server" id="td3"></td>
        </tr>
        <tr runat="server" id="tr4">
            <th>その他携帯メールアドレス</th>
            <td runat="server" id="td4"></td>
        </tr>
        <tr runat="server" id="trNone">
            <th>予約確認メールを受け取らない</th>
        </tr>
    </table>
</cc1:Panel>
</div>
