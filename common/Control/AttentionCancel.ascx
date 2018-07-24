<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AttentionCancel.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.AttentionCancel" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<div class="section" align="left">

    <h2 class="sub"><cc1:Image ID="img注意事項" runat="server" AlternateText="注意事項・キャンセルポリシー" ImageUrl="../../image/reservation/sub_policy.png" Height="26px" Width="700px" /></h2>
    <dl runat="server" id="dlAttention">
        <dt>注意事項</dt>
        <dd><ul>
            <cc1:NoEncodeLabel ID="lbl注意事項" runat="server"></cc1:NoEncodeLabel>
        </ul></dd>
    </dl>
    <dl>
        <dt>キャンセルポリシー</dt>
        <dd><ul>
            <cc1:NoEncodeLabel ID="lblキャンセルポリシー" runat="server"></cc1:NoEncodeLabel>
        </ul></dd>
    </dl>

<!-- /.section --></div>
