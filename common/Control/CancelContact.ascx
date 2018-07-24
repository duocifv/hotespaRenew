<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CancelContact.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.CancelContact" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<h2 class="sub"><cc1:Image ID="imgタイトル" runat="server" AlternateText="キャンセル時連絡先" ImageUrl="../../image/reservation/sub_contact.png" /></h2>

<table class="odd" summary="キャンセル時連絡先表" cellspacing="1">
<tr>
<th>キャンセル予約連絡先</th>
<td><cc1:Label ID="lbl電話1" runat="server"></cc1:Label></td>
</tr>
<tr>
<th>住所</th>
<td>〒<cc1:Label ID="lbl郵便番号" runat="server"></cc1:Label> <cc1:Label ID="lbl住所" runat="server"></cc1:Label></td>
</tr>
</table>
