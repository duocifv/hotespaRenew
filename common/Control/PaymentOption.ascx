<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PaymentOption.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.PaymentOption" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<div  align="left">
<h2 class="sub"><cc1:Image ID="img支払方法" runat="server" AlternateText="お支払い方法" ImageUrl="../../image/reservation/sub_pay.png" height="26px" width="700px" /></h2>
<cc1:Panel ID="pnlクレジット決済" runat="server" Width="700px">
    <h3 class="radio"><cc1:RadioButton ID="rdo支払方法カード" runat="server" Text="クレジットカード決済" GroupName="支払方法" BindSource="決済区分" />
    <span>予約完了後クレジットカード決済専用画面にて登録を行います。<br />
    <cc1:CheckBox ID="chk前回カード利用" runat="server" Text="前回予約時のカード情報を使用する"></cc1:CheckBox></span>
    </h3>

</cc1:Panel>

<cc1:Panel ID="pnl現地決済" runat="server" Width="700px">
    <h3 class="radio"><cc1:RadioButton ID="rdo支払方法現地" runat="server" Text="現地決済" GroupName="支払方法" BindSource="決済区分" />
    <span>現地宿泊施設にて直接お支払いください。</span></h3>
</cc1:Panel>

<cc1:Panel ID="pnlクレジット決済R" runat="server" Width="700px">
  <p>クレジットカード決済<br/>
  <cc1:CheckBox ID="chk強制キャンセル" runat="server" Text="キャンセル料を請求しない"></cc1:CheckBox></p>
  </cc1:Panel>
<cc1:Panel ID="pnl現地決済R" runat="server" Width="700px">
    <p>現地決済</p>
</cc1:Panel>
</div>
