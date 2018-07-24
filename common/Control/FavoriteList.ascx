<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FavoriteList.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.FavoriteList" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
    
<div id="divFavorite" runat="server" align="left">
<h2 class="sub"><cc1:Image ID="imgタイトル" runat="server" AlternateText="マイフェイバリット" ImageUrl="../../image/reservation/sub_favorite.png" Width="700px" Height="26px" /></h2>
<table class="cbx_ext three" summary="マイフェイバリット入力表" cellspacing="1" width="100%">
    <caption>
        <cc1:NoEncodeLabel ID="lblメッセージ" runat="server"></cc1:NoEncodeLabel></caption>
    <tr class="fav">
    <td width="33%">
<cc1:GridView ID="gvList1" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None" CssClass="cbxtext">
    <Columns>
        <asp:TemplateField>
            <itemtemplate>
<cc1:CheckBox id="chkItem1" runat="server" Text='<%# Bind("フェイバリット名称略称1") %>' Value='<%# Bind("フェイバリットCD1") %>'></cc1:CheckBox><cc1:Label id="lblItem1" runat="server" Visible="False" Text='<%# Bind("フェイバリット名称略称1") %>'></cc1:Label>&nbsp; 
</itemtemplate>
        </asp:TemplateField>
</Columns>
</cc1:GridView>
    </td>
    <td width="33%">
<cc1:GridView ID="gvList2" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None" CssClass="cbxtext">
    <Columns>
        <asp:TemplateField>
            <itemtemplate>
<cc1:CheckBox id="chkItem2" runat="server" Text='<%# Bind("フェイバリット名称略称2") %>' Value='<%# Bind("フェイバリットCD2") %>'></cc1:CheckBox> <cc1:Label id="lblItem2" runat="server" Visible="False" Text='<%# Bind("フェイバリット名称略称2") %>'></cc1:Label>&nbsp; 
</itemtemplate>
        </asp:TemplateField>
</Columns>
</cc1:GridView>
    </td>
    <td width="33%">
<cc1:GridView ID="gvList3" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None" CssClass="cbxtext">
    <Columns>
        <asp:TemplateField>
            <itemtemplate><li>
<cc1:CheckBox id="chkItem3" runat="server" Text='<%# Bind("フェイバリット名称略称3") %>' Value='<%# Bind("フェイバリットCD3") %>'></cc1:CheckBox> <cc1:Label id="lblItem3" runat="server" Visible="False" Text='<%# Bind("フェイバリット名称略称3") %>'></cc1:Label>&nbsp; 
</itemtemplate>
        </asp:TemplateField>
</Columns>
</cc1:GridView>
    </td>
    </tr>
</table>
<cc1:CheckBox ID="chk次回反映" runat="server" Text="選択したフェイバリット項目を次回に反映する" /><cc1:Label ID="lbl次回反映" runat="server">選択したフェイバリット項目を次回に反映する</cc1:Label>
</div>