<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReserveInfo.ascx.vb" Inherits="Com.Fujitsu.Hotespa.Web.Common.Control.ReserveInfo" %>
<%@ Register Assembly="WebFramework" Namespace="Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template"
    TagPrefix="cc1" %>
<asp:ScriptManager ID="sm" runat="server">
</asp:ScriptManager>

<div class="section">

    <h2 class="sub">
        <cc1:Image ID="img宿泊予約情報" runat="server" AlternateText="宿泊予約情報" ImageUrl="../../image/reservation/sub_resinfo.png" Height="26px" Width="700px" /></h2>

    <table class="odd resinfo" summary="宿泊予約情報入力表" cellspacing="1">
        <tr>
            <th>宿泊プラン名</th>
            <td><cc1:Label ID="lblプラン名" runat="server"></cc1:Label>　<cc1:HyperLink ID="hlkプラン内容" runat="server" CssClass="popup">プラン内容はこちら</cc1:HyperLink></td>
        </tr>
        <tr>
            <th>施設名</th>
            <td><cc1:Label ID="lbl施設名" runat="server"></cc1:Label></td>
        </tr>
        <tr>
            <th>宿泊日</th>
            <td>
                <cc1:Label ID="lbl到着日" runat="server"></cc1:Label>
                <cc1:Label ID="lbl宿泊日" runat="server">～</cc1:Label>
                <cc1:DropDownList ID="ddl出発日" runat="server" AutoPostBack="True"></cc1:DropDownList>
<%--                <asp:UpdatePanel ID="up宿泊日" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        ～
                        <cc1:Label ID="lbl出発日" runat="server"></cc1:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl宿泊数" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
--%>            </td>
        </tr>
<%--        <tr runat="server" id="tr宿泊数">
            <th>宿泊数</th>
            <td>
                <cc1:DropDownList ID="ddl宿泊数" runat="server" AutoPostBack="True"></cc1:DropDownList>
                泊
            </td>
        </tr>
--%>        <tr>
            <th>申込部屋数</th>
            <td>
                <cc1:DropDownList ID="ddl部屋数" runat="server" AutoPostBack="True"></cc1:DropDownList>
                部屋
            </td>
        </tr>
        <tr>
            <th>申込人数</th>
            <td>
                <asp:UpdatePanel ID="up人数" runat="server">
                    <ContentTemplate>
                <cc1:GridView ID="gv人数" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv人数_RowDataBound" Width="580px">
                    <Columns>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:Label id="lbl室番号" runat="server" Text='<%# Bind("タイプ連番") %>'></cc1:Label>室目 
                            </itemtemplate>
                            <itemstyle width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="大人">
                            <itemtemplate>
                                <cc1:DropDownList id="ddl大人" runat="server"></cc1:DropDownList>人
                            </itemtemplate>
                            <itemstyle width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども1" runat="server"></cc1:DropDownList><cc1:Label id="lbl人1" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="12%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども2" runat="server"></cc1:DropDownList><cc1:Label id="lbl人2" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="13%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども3" runat="server"></cc1:DropDownList><cc1:Label id="lbl人3" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども4" runat="server"></cc1:DropDownList><cc1:Label id="lbl人4" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="13%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども5" runat="server"></cc1:DropDownList><cc1:Label id="lbl人5" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="13%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                                <cc1:DropDownList id="ddlこども6" runat="server"></cc1:DropDownList><cc1:Label id="lbl人6" runat="server">人</cc1:Label>
                            </itemtemplate>
                            <itemstyle width="17%" />
                        </asp:TemplateField>
                    </Columns>
                </cc1:GridView>
                <cc1:GridView ID="gv人数_y" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv人数_y_RowDataBound" Width="580px">
                    <Columns>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:Label id="lbl室番号_y" runat="server" Text='<%# Bind("タイプ連番") %>' __designer:wfdid="w3"></cc1:Label>室目</td>
                                  <td><cc1:Label id="lbl続柄_メンバー" runat="server" Text="（メンバー）" __designer:wfdid="w4"></cc1:Label></td>
                                </tr>
                                <tr>
                                  <td></td>
                                  <td><cc1:Label id="lbl続柄_ビジター" runat="server" Text="（ビジター）" __designer:wfdid="w5"></cc1:Label></td>
                                </tr>
                              </table>
                            </itemtemplate>
                            <itemstyle width="18%" horizontalalign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="大人">
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddl大人_メンバー" runat="server"></cc1:DropDownList>人</td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddl大人_ビジター" runat="server"></cc1:DropDownList>人</td>
                                </tr>
                              </table>
                            </itemtemplate>
                            <itemstyle width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども1_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人1_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども1_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人1_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table>
                            </itemtemplate>
                            <itemstyle width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども2_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人2_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども2_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人2_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table>
                            </itemtemplate>
                            <itemstyle width="17%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども3_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人3_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども3_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人3_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table>           
                            </itemtemplate>
                            <itemstyle width="17%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども4_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人4_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども4_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人4_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table>                           
                            </itemtemplate>
                            <itemstyle width="18%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども5_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人5_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども5_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人5_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table>      
                            </itemtemplate>
                            <itemstyle />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <itemtemplate>
                              <table width="100%">
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども6_メンバー" runat="server"></cc1:DropDownList><cc1:Label id="lbl人6_メンバー" runat="server">人</cc1:Label></td>
                                </tr>
                                <tr>
                                  <td><cc1:DropDownList id="ddlこども6_ビジター" runat="server"></cc1:DropDownList><cc1:Label id="lbl人6_ビジター" runat="server">人</cc1:Label></td>
                                </tr>
                              </table> 
                            <itemstyle />
                            </itemtemplate>
                        </asp:TemplateField>
                    </Columns>
                </cc1:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl部屋数" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <th>部屋タイプ</th>
            <td><cc1:Label ID="lbl部屋タイプ名" runat="server"></cc1:Label></td>
        </tr>
    </table>

<!-- /.section --></div>

<div class="section" runat="server" id="divSection">

    <h2 class="sub"><cc1:Image ID="img食事情報" runat="server" AlternateText="食事情報" ImageUrl="../../image/reservation/sub_foodinfo.png" Height="26px" Width="700px" /></h2>

    <asp:UpdatePanel ID="up食事" runat="server">
        <ContentTemplate>
            <cc1:GridView ID="gv食事" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="odd_t food_r th" Width="700px" Caption="食事料金 セレクト料理" CellSpacing="1">
                <Columns>
                    <asp:TemplateField HeaderText="日付">
                        <itemtemplate>
<cc1:Label id="lbl日付" runat="server" CssClass="darkred" __designer:wfdid="w2"></cc1:Label> 
</itemtemplate>
                        <itemstyle width="20%" cssclass="th" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="朝食">
                        <itemtemplate>
<cc1:DropDownList id="ddl朝食" runat="server" __designer:wfdid="w3"></cc1:DropDownList> <cc1:Label id="lbl朝食" runat="server" __designer:wfdid="w4" Visible="False"></cc1:Label>&nbsp;
</itemtemplate>
                        <itemstyle width="40%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="夕食">
                        <itemtemplate>
<cc1:DropDownList id="ddl夕食" runat="server" __designer:wfdid="w5"></cc1:DropDownList><cc1:Label id="lbl夕食" runat="server" __designer:wfdid="w6" Visible="False"></cc1:Label>&nbsp;
</itemtemplate>
                        <itemstyle width="40%" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="hd" HorizontalAlign="Left" />
                <AlternatingRowStyle CssClass="jq" />
            </cc1:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl出発日" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

<!-- /.section --></div>
