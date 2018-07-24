<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ChargeInfo.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.ChargeInfo" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<div  align="left">
<div class="tbox">
    <h3>各種料金</h3>
    <cc1:GridView ID="gv宿泊料金" runat="server" AutoGenerateColumns="False" Caption="[宿泊料金]"
        CssClass="odd_t row3 th" CellSpacing="1" GridLines="None">
        <Columns>
            <asp:TemplateField HeaderText="日付">
                <itemtemplate>
    <cc1:Label id="lbl日付" runat="server" __designer:wfdid="w8"></cc1:Label> 
    
</itemtemplate>
                <headerstyle cssclass="day" />
                <itemstyle cssclass="th" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="内訳">
                <itemtemplate>
    <cc1:NoEncodeLabel id="lbl内訳" runat="server" __designer:wfdid="w5"></cc1:NoEncodeLabel>
    
</itemtemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金額">
                <itemtemplate>
    （<cc1:Label id="lbl税区分" runat="server" __designer:wfdid="w9"></cc1:Label>）<cc1:Label id="lbl金額" runat="server" __designer:wfdid="w9"></cc1:Label>
      <cc1:Label id="lbl通貨単位" runat="server" __designer:wfdid="w9"></cc1:Label>
    
</itemtemplate>
                <headerstyle cssclass="yen" />
                <itemstyle cssclass="ar" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="hd" />
    </cc1:GridView>
    <cc1:GridView ID="gv食事料金" runat="server" AutoGenerateColumns="False" Caption="[食事料金 セレクト料理]" CellSpacing="1" CssClass="odd_t th" GridLines="None">
        <Columns>
            <asp:TemplateField HeaderText="日付">
                <itemtemplate>
    <cc1:Label id="lbl日付" runat="server" __designer:wfdid="w2"></cc1:Label>
    
</itemtemplate>
                <headerstyle cssclass="day" />
                <itemstyle cssclass="th" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="朝食">
                <itemtemplate>
    <cc1:Label id="lbl朝食" runat="server" __designer:wfdid="w2"></cc1:Label>&nbsp;
    
</itemtemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="夕食">
                <itemtemplate>
    <cc1:Label id="lbl夕食" runat="server" __designer:wfdid="w2"></cc1:Label>&nbsp;
    
</itemtemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金額">
                <itemtemplate>
    <cc1:Label id="lbl金額" runat="server" __designer:wfdid="w2"></cc1:Label>
    <cc1:Label id="lbl通貨単位" runat="server" __designer:wfdid="w2"></cc1:Label>
    
</itemtemplate>
                <headerstyle cssclass="yen" />
                <itemstyle cssclass="ar" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="hd" />
    </cc1:GridView>
    
    <div style="padding:10px;text-align:right;font-weight:bold;"><cc1:Label id="lbl割引金額" runat="server"></cc1:Label></div>
    <div class="total">合計：<cc1:Label id="lbl合計料金" runat="server"></cc1:Label></div>
<!-- /.tbox --></div>

<cc1:Panel ID="pnl入力" runat="server">
    <table class="odd" summary="ポイント利用入力表" cellspacing="1">
        <caption>ポイント利用 </caption>
        <tr>
        <th>ご利用可能ポイント</th>
        <td><cc1:Label ID="lbl利用可能ポイント" runat="server" CssClass="b"></cc1:Label>　ポイント</td>
        </tr>
        <tr>
        <th>利用ポイント数</th>
        <td><cc1:TextBox ID="txt利用ポイント" runat="server" ImeMode="Disabled" CssClass="ImeDisabled" DisplayName="利用ポイント数"></cc1:TextBox>　ポイント &nbsp;<cc1:Label ID="lblポイント備考" runat="server" ForeColor="#cc0000"></cc1:Label></td>
        </tr>
    </table>
</cc1:Panel>

<cc1:Panel ID="pnl表示" runat="server">

    <table class="odd" summary="ポイント利用表" cellspacing="1">
        <caption>ポイント利用 </caption>
        <tr>
        <th>ご利用ポイント数</th>
        <td><cc1:Label ID="lbl利用ポイント" runat="server" CssClass="b"></cc1:Label>　ポイント</td>
        </tr>
        <tr>
        <td colspan="2" class="total">合計：<cc1:Label ID="lbl最終料金" runat="server"></cc1:Label></td>
        </tr>
    </table>

    <table class="odd" summary="ポイント付与表" cellspacing="1">
        <caption>ポイント付与</caption>
        <tr>
        <th>付与予定ポイント</th>
        <td><cc1:Label ID="lbl付与ポイント" runat="server" CssClass="b"></cc1:Label>　ポイント</td>
        </tr>
    </table>

</cc1:Panel>
</div>
