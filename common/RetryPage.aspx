<%@ Page Language="VB" MasterPageFile="~/Common/MasterPage.master" AutoEventWireup="false" CodeFile="RetryPage.aspx.vb" Inherits="Com.Fujitsu.Hotespa.Web.User.Common.RetryPage" title="エラー | HOTEL &amp; SPA" %>

<%@ Register Src="Control/ErrorInfo.ascx" TagName="ErrorInfo" TagPrefix="uc1" %>

<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphForm" Runat="Server">
<div id="content">

    <h1 id="tit"><cc1:Label ID="lblタイトル" runat="server"></cc1:Label></h1>
    <uc1:ErrorInfo ID="errorInfo" runat="server" Visible="false" />
        <li><cc1:LinkButton ID="lbtn現地決済" runat="server" Text="「現地決済」に変更し予約手続きを行う"></cc1:LinkButton></li><br/>
        <li><cc1:LinkButton ID="lbtn再決済" runat="server" Text="再度「カード決済」処理を行う"></cc1:LinkButton></li>
    <ul class="btns">

        <li><cc1:ImageButton ID="ibtn前ページ" runat="server" AlternateText="前のページに戻る" ImageUrl="~/image/form/bt_prev.png" /></li>
    </ul>
<!-- /#content --></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSideForm" Runat="Server">
</asp:Content>

