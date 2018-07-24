<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReserveDemand.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.ReserveDemand" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<h2 class="sub"><cc1:Image ID="img要望" runat="server" AlternateText="ご予約におけるご要望" ImageUrl="../../image/reservation/sub_hope.png" /></h2>
<div  align="left">
<cc1:Panel ID="pnl入力" runat="server">
    <cc1:NoEncodeLabel ID="lbl予約通信欄" runat="server"></cc1:NoEncodeLabel><br /><br />
    <table class="odd" summary="ご要望入力表" cellspacing="1">
    <tr>
    <td class="one"><cc1:TextBox ID="txt要望" runat="server" BindSource="予約通信欄" ImeMode="Active" MaxLength="500" TextMode="MultiLine" CssClass="ImeActive hope" DisplayName="ご要望" ></cc1:TextBox></td>
    </tr>
    </table>
</cc1:Panel>
<cc1:Panel ID="pnl表示" runat="server">
    <p class="m_b10">※ご希望に添えない場合もございますのでご了承願います。</p>
    <table class="odd" summary="ご要望表" cellspacing="1">
    <tr>
    <td class="one"><cc1:NoEncodeLabel ID="lbl要望" runat="server"></cc1:NoEncodeLabel></td>
    </tr>
    </table>
</cc1:Panel>
</div>
