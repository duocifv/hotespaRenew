<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GesutView.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.GesutView" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<div  align="left">
<h2 class="sub"><cc1:Image ID="ImageTitle" runat="server" ImageUrl="../../image/reservation/sub_peopleinfo.png" AlternateText="宿泊者情報" Height="26px" Width="700px" /></h2>
<cc1:GridView ID="gv1室目" runat="server" AutoGenerateColumns="False"
    CellSpacing="1" CssClass="odd_t info th" GridLines="None">
    <Columns>
        <asp:TemplateField HeaderText="1室目">
            <itemtemplate>
<cc1:Label id="lblタイトル" runat="server"></cc1:Label> 
</itemtemplate>
            <itemstyle cssclass="th" />
        </asp:TemplateField>
        <asp:TemplateField>
            <itemtemplate>
<cc1:Panel id="pnl宿泊者1" runat="server" Visible="False">
<cc1:Label ID="lbl姓名宿泊者1" runat="server"></cc1:Label><br />
<cc1:Label ID="lblセイ宿泊者1" runat="server"></cc1:Label>　<cc1:Label ID="lblメイ宿泊者1" runat="server"></cc1:Label>（<cc1:Label ID="lbl性別宿泊者1" runat="server"></cc1:Label>）&nbsp;&nbsp;&nbsp;&nbsp;<cc1:Label ID="lbl続柄宿泊者1" runat="server"></cc1:Label><br />
<cc1:Label ID="lbl会社名漢字" runat="server"></cc1:Label>　<cc1:Label ID="lbl会社名カナ" runat="server"></cc1:Label>
</cc1:Panel>
<cc1:Panel id="pnl宿泊者" runat="server" Visible="False">
<cc1:Label ID="lblセイ宿泊者" runat="server"></cc1:Label>　<cc1:Label ID="lblメイ宿泊者" runat="server"></cc1:Label>　（<cc1:Label ID="lbl性別宿泊者" runat="server"></cc1:Label>）&nbsp;&nbsp;&nbsp;&nbsp;<cc1:Label ID="lbl続柄宿泊者" runat="server"></cc1:Label>
</cc1:Panel>
<cc1:Panel id="pnl連絡先" runat="server" Visible="False">
<cc1:Label ID="lbl連絡先" runat="server"></cc1:Label>
</cc1:Panel>
<cc1:Panel id="pnl時刻" runat="server" Visible="False">
<cc1:Label ID="lblチェックイン時刻" runat="server"></cc1:Label>～<cc1:Label ID="lbl最終チェックイン時刻" runat="server"></cc1:Label>
</cc1:Panel>
</itemtemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle CssClass="hd" />
</cc1:GridView>

<cc1:GridView ID="gv2室目以降" runat="server" AutoGenerateColumns="False" GridLines="None"
    ShowHeader="False" Width="100%">
    <Columns>
        <asp:TemplateField>
            <itemtemplate>
<cc1:GridView id="gv宿泊者情報" runat="server" GridLines="None" CssClass="odd_t info th" CellSpacing="1" AutoGenerateColumns="False" OnRowDataBound="gv宿泊者情報_RowDataBound"><Columns>
<asp:TemplateField><ItemTemplate>
<cc1:Label id="lblタイトル" runat="server"></cc1:Label> 
</ItemTemplate>
<ItemStyle CssClass="th"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<cc1:Panel id="pnl宿泊者1" runat="server" Visible="False">
<cc1:Label ID="lblセイ宿泊者1" runat="server"></cc1:Label>　<cc1:Label ID="lblメイ宿泊者1" runat="server"></cc1:Label>　（<cc1:Label ID="lbl性別宿泊者1" runat="server"></cc1:Label>）&nbsp;&nbsp;&nbsp;&nbsp;<cc1:Label ID="lbl続柄宿泊者1" runat="server"></cc1:Label>
</cc1:Panel>
<cc1:Panel id="pnl宿泊者" runat="server" Visible="False">
<cc1:Label ID="lblセイ宿泊者" runat="server"></cc1:Label>　<cc1:Label ID="lblメイ宿泊者" runat="server"></cc1:Label>　（<cc1:Label ID="lbl性別宿泊者" runat="server"></cc1:Label>）&nbsp;&nbsp;&nbsp;&nbsp;<cc1:Label ID="lbl続柄宿泊者" runat="server"></cc1:Label>
</cc1:Panel>
</ItemTemplate>
</asp:TemplateField>
</Columns>
<HeaderStyle CssClass="hd"></HeaderStyle>
</cc1:GridView> 
</itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:GridView>

<table class="odd_t info" summary="会員情報表" cellspacing="1">
    <tr class="hd">
        <th colspan="2">会員情報（内容をご確認下さい。）</th>
    </tr>
    <tr>
        <th>氏名</th>
        <td><cc1:Label ID="lbl会員氏名" runat="server"></cc1:Label></td>
    </tr>
    <tr>
        <th>住所</th>
        <td>〒<cc1:Label ID="lbl会員郵便番号" runat="server"></cc1:Label><br />
        <cc1:Label ID="lbl会員住所" runat="server"></cc1:Label></td>
    </tr>
    <tr>
        <th>勤務先</th>
        <td><cc1:Label ID="lbl会員勤務先" runat="server"></cc1:Label></td>
    </tr>
</table>
</div>
