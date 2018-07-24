<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReserveView.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.ReserveView" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<h3>宿泊予約情報</h3>
<div  align="left">
<table class="in_dot" summary="宿泊予約情報表">
    <tr id="tr予約No" runat="server">
        <th>予約受付番号</th>
        <td><cc1:Label ID="lbl予約No" runat="server" CssClass="att_b"></cc1:Label></td>
    </tr>
    <tr>
        <th>宿泊プラン名</th>
        <td><cc1:Label ID="lblプラン名" runat="server"></cc1:Label>　<cc1:HyperLink ID="hlkプラン内容" runat="server" CssClass="popup">プラン内容はこちら</cc1:HyperLink></td>
    </tr>
    <tr>
        <th>お食事</th>
        <td><cc1:Label ID="lbl食事条件" runat="server"></cc1:Label></td>
    </tr>
    <tr>
        <th>施設名</th>
        <td><cc1:Label ID="lbl施設名" runat="server"></cc1:Label></td>
    </tr>
    <tr>
        <th>宿泊日</th>
        <td><cc1:Label ID="lbl宿泊日" runat="server"></cc1:Label></td>
    </tr>
    <tr>
        <th>申込部屋数</th>
        <td><cc1:Label ID="lbl部屋数" runat="server"></cc1:Label>部屋</td>
    </tr>
    <tr>
        <th>申込人数</th>
        <td><cc1:NoEncodeLabel ID="lbl申込人数" runat="server"></cc1:NoEncodeLabel></td>
    </tr>
    <tr>
        <th>部屋タイプ</th>
        <td><cc1:Label ID="lbl部屋タイプ名" runat="server"></cc1:Label></td>
    </tr>
</table>
</div>
