<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ErrorInfo.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.ErrorInfo" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<div class="error">
    <h2>以下の項目をご確認ください</h2>
    <ul>
        <cc1:NoEncodeLabel ID="lbl内容" runat="server"></cc1:NoEncodeLabel>
    </ul>
<!-- /.error --></div>
