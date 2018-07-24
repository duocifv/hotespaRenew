<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GesutInfo.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.GesutInfo" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>

<h2 class="sub"><cc1:Image ID="ImageTitle" runat="server" ImageUrl="../../image/reservation/sub_peopleinfo.png" AlternateText="宿泊者情報" Height="26px" Width="700px" /></h2>
<cc1:GridView ID="gv1室目" runat="server" AutoGenerateColumns="False" Caption="<span>以下の宿泊者情報を入力してください。<br />"
    CellSpacing="1" CssClass="odd_t info th" GridLines="None">
    <Columns>
        <asp:TemplateField HeaderText="1室目">
            <itemtemplate>
<cc1:Label id="lblタイトル" runat="server" __designer:wfdid="w1"></cc1:Label> 
</itemtemplate>
            <itemstyle cssclass="th" />
        </asp:TemplateField>
        <asp:TemplateField>
            <itemtemplate>
<cc1:Panel id="pnl宿泊者1" runat="server" Visible="False">
    <TABLE class="shimei">
    <TBODY>
    <TR>
    <TH>姓</TH>
    <TD>
    <cc1:TextBox id="txt姓宿泊者1" runat="server" CssClass="ImeActive nam_k" ImeMode="Active" maxlength="19">
    </cc1:TextBox> </TD>
    <TH>名</TH>
    <TD>
    <cc1:TextBox id="txt名宿泊者1" runat="server" CssClass="ImeActive nam_k" ImeMode="Active" maxlength="20">
    </cc1:TextBox> </TD>
    </TR>
    <TR>
    <TH>セイ</TH>
    <TD>
    <cc1:TextBox id="txtセイ宿泊者1" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="19">
    </cc1:TextBox> </TD>
    <TH>メイ</TH>
    <TD>
    <cc1:TextBox id="txtメイ宿泊者1" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="20">
    </cc1:TextBox> </TD>
    <cc1:Panel id="pnl続柄1" runat="server" Visible="False">
        <TH>続柄</TH>
        <TD>
        <cc1:DropDownList id="ddl続柄1" runat="server">
        </cc1:DropDownList>
        </TD>
    </cc1:Panel>
    </TR>
    </TBODY>
    </TABLE>
    <P class="sp">
    <cc1:RadioButton id="rdo男性宿泊者1" runat="server" GroupName="性別宿泊者1" Text="男性">
    </cc1:RadioButton>　　 <cc1:RadioButton id="rdo女性宿泊者1" runat="server" GroupName="性別宿泊者1" Text="女性">
    </cc1:RadioButton> </P>
    <TABLE class="m_b5">
    <TBODY>
    <TR>
    <TH class="sp">会社名・団体名（全角漢字）</TH>
    <TD class="sp">
    <cc1:TextBox id="txt会社名漢字" runat="server" CssClass="ImeActive com_k" ImeMode="Active" maxlength="80">
    </cc1:TextBox> </TD>
    </TR>
    <TR>
    <TH class="sp">会社名・団体名（全角フリガナ）</TH>
    <TD class="sp">
    <cc1:TextBox id="txt会社名カナ" runat="server" CssClass="ImeActive com_f" ImeMode="Active" maxlength="80">
    </cc1:TextBox> </TD>
    </TR>
    </TBODY>
    </TABLE>
    <TABLE id="tblStayInfo" runat="server">
    <TBODY>
    <TR>
    <TH class="sp">
    <SPAN class="b">今回の宿泊者情報について</SPAN>
    </TH>
    </TR>
    <TR>
    <TD>
    <cc1:RadioButton id="rdo次回利用" runat="server" GroupName="情報更新" Text="次回の予約に利用する">
    </cc1:RadioButton> 　 <cc1:RadioButton id="rdo今回のみ" runat="server" GroupName="情報更新" Text="今回の予約のみ利用する">
    </cc1:RadioButton> 　 <cc1:RadioButton id="rdo利用しない" runat="server" GroupName="情報更新" Text="利用しない(次回は会員情報を表示)">
    </cc1:RadioButton> </TD>
    </TR>
    </TBODY>
    </TABLE>
</cc1:Panel>
<cc1:Panel id="pnl宿泊者" runat="server" Visible="False">
    <TABLE>
    <TBODY>
    <TR>
    <TD class="sp">
    <cc1:CheckBox id="chk省略" runat="server" Text="名前入力を省略する">
    </cc1:CheckBox>
    </TD>
    </TR>
    <tr>
    <td class="sp">セイ <cc1:TextBox id="txtセイ宿泊者" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="19">
    </cc1:TextBox></td><td>　　メイ <cc1:TextBox id="txtメイ宿泊者" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="20">
    </cc1:TextBox></td>
    <cc1:Panel id="pnl続柄" runat="server" Visible="False">
        <td>　　続柄 <cc1:DropDownList id="ddl続柄" runat="server">
        </cc1:DropDownList></td>
    </cc1:Panel>
    </tr><tr><td>
    <span class="ex2">（全角ひらがなもしくは全角カタカナ）</span>
    </td>
    </tr>
    <tr>
    <td>
    <cc1:RadioButton id="rdo男性宿泊者" runat="server" GroupName="性別宿泊者" Text="男性">
    </cc1:RadioButton>　　 <cc1:RadioButton id="rdo女性宿泊者" runat="server" GroupName="性別宿泊者" Text="女性">
    </cc1:RadioButton>
    </td>
    </tr>
    </TBODY>
    </TABLE>
</cc1:Panel>
<cc1:Panel id="pnl連絡先" runat="server" Visible="False">
    <cc1:TextBox id="txt連絡先" runat="server" CssClass="ImeDisabled tel" ImeMode="Disabled" maxlength="20">
    </cc1:TextBox> 　<SPAN class="att">予約に関して施設より連絡をする場合がございます。</SPAN> <SPAN class="ex">
    <cc1:Label id="lbl連絡先注意" runat="server"></cc1:Label></SPAN>
</cc1:Panel>
<cc1:Panel id="pnl時刻" runat="server" Visible="False">
    <cc1:DropDownList id="ddlチェックイン時刻" runat="server">
    </cc1:DropDownList> ～ <cc1:Label id="lbl最終チェックイン時刻" runat="server">
    </cc1:Label>
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
<cc1:GridView id="gv宿泊者情報" runat="server" GridLines="None" CssClass="odd_t info th" CellSpacing="1" AutoGenerateColumns="False" __designer:wfdid="w150" OnRowDataBound="gv宿泊者情報_RowDataBound"><Columns>
    <asp:TemplateField><ItemTemplate>
    <cc1:Label id="lblタイトル" runat="server" __designer:wfdid="w151"></cc1:Label> 
    </ItemTemplate>

    <ItemStyle CssClass="th"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField><ItemTemplate>
    <cc1:Panel id="pnl宿泊者1" runat="server" Visible="False">
        <TABLE>
        <TBODY>
        <tr>
        <td class="sp">セイ <cc1:TextBox id="txtセイ宿泊者1" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="19">
        </cc1:TextBox></td><td>　　メイ <cc1:TextBox id="txtメイ宿泊者1" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="20">
        </cc1:TextBox></td>
        <cc1:Panel id="pnl続柄1" runat="server" Visible="False">
            <td>　　続柄 <cc1:DropDownList id="ddl続柄1" runat="server">
            </cc1:DropDownList></td>
        </cc1:Panel>
        </tr><tr><td>
        <span class="ex2">（全角ひらがなもしくは全角カタカナ）</span>
        </td>
        </tr>
        <tr>
        <td>
        <cc1:RadioButton id="rdo男性宿泊者1" runat="server" GroupName="性別宿泊者1" Text="男性">
        </cc1:RadioButton>　　 <cc1:RadioButton id="rdo女性宿泊者1" runat="server" GroupName="性別宿泊者1" Text="女性">
        </cc1:RadioButton>
        </td>
        </tr>
        </TBODY>
        </TABLE>
    </cc1:Panel>
    <cc1:Panel id="pnl宿泊者" runat="server" Visible="False">
        <TABLE>
        <TBODY>
        <tr>
        <td class="sp">
        <cc1:CheckBox id="chk省略" runat="server" Text="名前入力を省略する">
        </cc1:CheckBox>
        </TD>
        </TR>
        <tr>
        <td class="sp">セイ <cc1:TextBox id="txtセイ宿泊者" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="19">
        </cc1:TextBox></td><td>　　メイ <cc1:TextBox id="txtメイ宿泊者" runat="server" CssClass="ImeActive nam_f" ImeMode="Active" maxlength="20">
        </cc1:TextBox></td>
        <cc1:Panel id="pnl続柄" runat="server" Visible="False">
            <td>　　続柄 <cc1:DropDownList id="ddl続柄" runat="server">
            </cc1:DropDownList></td>
        </cc1:Panel>
        </tr><tr><td>
        <span class="ex2">（全角ひらがなもしくは全角カタカナ）</span>
        </td>
        </tr>
        <tr>
        <td>
        <cc1:RadioButton id="rdo男性宿泊者" runat="server" GroupName="性別宿泊者" Text="男性">
        </cc1:RadioButton>　　 <cc1:RadioButton id="rdo女性宿泊者" runat="server" GroupName="性別宿泊者" Text="女性">
        </cc1:RadioButton>
        </td>
        </tr>
        </TBODY>
        </TABLE>
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
