<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AreaMap.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.AreaMap" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<h2 class="sub"><cc1:Image ID="imgタイトル" runat="server" AlternateText="施設周辺地図" ImageUrl="../../image/reservation/sub_map.png" /></h2>
<div class="map"><cc1:Image ID="img地図" runat="server" /></div>
