Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

NameSpace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class MasterPage
        Inherits System.Web.UI.MasterPage

        Private Const MasterPage_Logout As String = "MasterPage_Logout"
        Private Const MasterPage_Path As String = "MasterPage_Path"

        Protected Const COOKIE_KEY_SID As String = "ASP.NET_SessionId"

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

            'Dim page_css As HtmlLink = New HtmlLink
            'Dim page_side_css As HtmlLink = New HtmlLink

            ''スタイルシートの追加
            'page_css.Href = "../css/resort.css"
            'page_css.Attributes("rel") = "stylesheet"
            'page_css.Attributes("type") = "text/css"

            'page_side_css.Href = "../css/resort_side.css"
            'page_side_css.Attributes("rel") = "stylesheet"
            'page_side_css.Attributes("type") = "text/css"

            'Me.Page.Header.Controls.Add(page_css)
            'Me.Page.Header.Controls.Add(page_side_css)


            ''メニューの表示
            'Me.Resort.Visible = True

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                'ログイン情報を判断し、先頭のメッセージを設定します。
                If CType(Me.Page, BasePage).LoginInfo Is Nothing Then
                    Me.lblLoginName.Text = "ゲスト"
                Else
                    '会員名称を表示
                    Me.lblLoginName.Text = CType(Me.Page, BasePage).LoginInfo.会員名称
                    Me.lblDate.Text = "前回ログイン：" & CType(Me.Page, BasePage).LoginInfo.前回ログイン日時.ToString("yyyy/MM/dd HH:mm")
                    If ConvertValueUtility.IsDefaultValue(CType(Me.Page, BasePage).LoginInfo.前回ログイン日時) Then
                        Me.lblDate.Text = "初回ログイン"
                    End If
                End If

                Me.liログイン.Visible = (CType(Me.Page, BasePage).LoginInfo Is Nothing)
                Me.li新規会員.Visible = (CType(Me.Page, BasePage).LoginInfo Is Nothing)
                Me.li法人ログイン.Visible = (CType(Me.Page, BasePage).LoginInfo Is Nothing)
                Me.liログアウト.Visible = Not (CType(Me.Page, BasePage).LoginInfo Is Nothing)
                Me.li法人ログイン.Visible = False

                Dim page_css As HtmlLink = New HtmlLink
                Dim page_side_css As HtmlLink = New HtmlLink
                Dim page_divide_css As HtmlLink = New HtmlLink
                Dim page_custom_css As HtmlLink = New HtmlLink
                Dim page_import_css As HtmlLink = New HtmlLink
                Dim page_style_css As HtmlLink = New HtmlLink

                page_css.Attributes("rel") = "stylesheet"
                page_css.Attributes("type") = "text/css"
                page_side_css.Attributes("rel") = "stylesheet"
                page_side_css.Attributes("type") = "text/css"
                page_divide_css.Attributes("rel") = "stylesheet"
                page_divide_css.Attributes("type") = "text/css"
                page_custom_css.Attributes("rel") = "stylesheet"
                page_custom_css.Attributes("type") = "text/css"
                page_import_css.Attributes("rel") = "stylesheet"
                page_import_css.Attributes("type") = "text/css"
                page_style_css.Attributes("rel") = "stylesheet"
                page_style_css.Attributes("type") = "text/css"

                Dim metaDescript As HtmlMeta = New HtmlMeta
                Dim metaKeywords As HtmlMeta = New HtmlMeta
                metaDescript.Name = "description"
                metaKeywords.Name = "keywords"

                Dim title As HtmlTitle = New HtmlTitle
                title.Text = "ドーミーイン【公式】 | 出張・温泉旅行・一人旅のホテル予約"

                'ドーミイン/湯めぐり/リゾートで切り替えを行ないます。
                Me.SetLink(Me.Attributes.Item("type"))
                Select Case Me.Attributes.Item("type")

                    Case "Resort"

                        'スタイルシートの追加
                        page_css.Href = "../css/resort.css"
                        page_side_css.Href = "../css/resort_side.css"
                        page_divide_css.Href = "../css/form_divide_r.css"
                        page_custom_css.Href = "../css/resortnew.css"
                        page_import_css.Href = "../css/import.css"

                        Me.Page.Header.Controls.Add(page_css)
                        Me.Page.Header.Controls.Add(page_side_css)
                        Me.Page.Header.Controls.Add(page_divide_css)
                        Me.Page.Header.Controls.Add(page_custom_css)
                        Me.Page.Header.Controls.Add(page_import_css)

                        title.Text = "温泉旅館・ホテルの宿泊予約は 癒しの湯宿｜ホテスパ - HOTESPA.net"

                        '/Resort/ の場合の metaデータ
                        metaDescript.Content = "ホテスパドットネットがご提供するのは、皆様の「行きたい！」に合わせてお選びいただける、お得でベストなプラン。日本有数のリゾート 各地に共立メンテナンスが展開中の「癒しの湯宿&amp;リゾートホテル」を、どこよりも便利に、お得にご予約いただけます。"
                        metaKeywords.Content = "ホテスパ,hotespa,癒しの湯宿,旅館,リゾートホテル,予約,スパ,温泉,屋号に思いあり"
                        Me.Page.Header.Controls.Add(metaDescript)
                        Me.Page.Header.Controls.Add(metaKeywords)

                        'メニューの表示
                        Me.logoRes.Visible = True
                        Me.ulRes1.Visible = True
                        Me.ulRes2.Visible = True

                        Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "cssset", "<script type=""text/javascript"">$(""#header"").attr(""class"", ""res"");</script>")

                    Case "Biz"

                        'スタイルシートの追加
                        page_css.Href = "../css/business.css"
                        page_side_css.Href = "../css/business_side.css"
                        page_divide_css.Href = "../css/form_divide.css"
                        page_import_css.Href = "../css/import.css"

                        Me.Page.Header.Controls.Add(page_css)
                        Me.Page.Header.Controls.Add(page_side_css)
                        Me.Page.Header.Controls.Add(page_divide_css)
                        Me.Page.Header.Controls.Add(page_import_css)

                        '/DormyInn/ の場合の metaデータ
                        metaDescript.Content = "日本全国展開する「ドーミーイン」がご提供するのは、至るところに心配りを施した、わが家の感覚のビジネスホテル。心も体もリフレッシュして頂くために、天然温泉、露天風呂、サウナをご用意。ご予約は公式サイトホテスパがお得！"
                        metaKeywords.Content = "ドーミーイン,ホテスパ,dormy inn,dormyinn,ホテル,ビジネスホテル,予約,温泉"
                        Me.Page.Header.Controls.Add(metaDescript)
                        Me.Page.Header.Controls.Add(metaKeywords)

                        'メニューの表示
                        Me.logoBiz.Visible = True
                        Me.ulBiz1.Visible = True
                        Me.ulBiz2.Visible = True

                        Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "cssset", "<script type=""text/javascript"">$(""#header"").attr(""class"", ""biz"");</script>")

                    Case "ForMember"

                        'スタイルシートの追加
                        page_css.Href = "../formembers/css/style.css"
                        page_import_css.Href = "../css/import.css"

                        Me.Page.Header.Controls.Add(page_css)
                        Me.Page.Header.Controls.Add(page_import_css)

                        'メニューの表示
                        Me.logoOth.Visible = True
                        Me.ulOth1.Visible = True
                        Me.ulOth2.Visible = True

                    Case "Yumeguri"

                        'スタイルシートの追加
                        page_css.Href = "../YumeguriClub/common/css/main.css"
                        page_style_css.Href = "../YumeguriClub/common/css/style.css"
                        page_import_css.Href = "../YumeguriClub/common/css/import.css"
                        page_divide_css.Href = "../css/form_divide.css"

                        Me.Page.Header.Controls.Add(page_css)
                        Me.Page.Header.Controls.Add(page_style_css)
                        Me.Page.Header.Controls.Add(page_divide_css)
                        Me.Page.Header.Controls.Add(page_import_css)

                        title.Text = "湯めぐり倶楽部"

                        '/Yumeguri/ の場合の metaデータ
                        'TODO yamanaka メタタグ検討中

                        Me.yumeguri.Visible = True
                        Me.nomal.Visible = False
                        Me.hd_member_nomal.Visible = False
                        Me.nomalFooter.Visible = False
                        Me.yumeguriFooter.Visible = True

                        'ログイン情報を判断し、先頭のメッセージを設定します。
                        If CType(Me.Page, BasePage).LoginInfo Is Nothing Then
                            Me.lblLoginCoName.Text = String.Empty
                        Else
                            '法人名称を表示
                            Me.lblLoginCoName.Text = CType(Me.Page, BasePage).LoginInfo.法人名称
                            Me.lblCoDate.Text = "前回ログイン：" & CType(Me.Page, BasePage).LoginInfo.前回ログイン日時.ToString("yyyy/MM/dd HH:mm")
                            If ConvertValueUtility.IsDefaultValue(CType(Me.Page, BasePage).LoginInfo.前回ログイン日時) Then
                                Me.lblCoDate.Text = "初回ログイン"
                            End If
                        End If
                        Me.li湯めぐりログアウト.Visible = Not (CType(Me.Page, BasePage).LoginInfo Is Nothing)

                    Case "YumeguriNoHeader"

                        'スタイルシートの追加
                        page_css.Href = "../YumeguriClub/common/css/main.css"
                        page_style_css.Href = "../YumeguriClub/common/css/style.css"
                        page_import_css.Href = "../YumeguriClub/common/css/import.css"

                        Me.Page.Header.Controls.Add(page_css)
                        Me.Page.Header.Controls.Add(page_style_css)
                        Me.Page.Header.Controls.Add(page_import_css)

                        title.Text = "湯めぐり倶楽部"

                        '/Yumeguri/ の場合の metaデータ
                        'TODO yamanaka メタタグ検討中
                        Me.yumeguri.Visible = True
                        Me.nomal.Visible = False
                        Me.headerL.Visible = False
                        Me.hd_member_nomal.Visible = False
                        Me.nomalFooter.Visible = False
                        Me.yumeguriFooter.Visible = False

                    Case Else

                        'スタイルシートの追加
                        page_import_css.Href = "../css/import.css"

                        Me.Page.Header.Controls.Add(page_import_css)

                        'メニューの表示
                        Me.logoOth.Visible = True
                        Me.ulOth1.Visible = True
                        Me.ulOth2.Visible = True

                End Select

                'タイトルタグ作成
                Me.Page.Header.Controls.Add(title)

                If Not (Me.Request.Url.AbsoluteUri.EndsWith("/") OrElse Me.Request.Url.AbsoluteUri.EndsWith("index.aspx")) Then
                    Dim form_css As HtmlLink = New HtmlLink
                    form_css.Attributes("rel") = "stylesheet"
                    form_css.Attributes("type") = "text/css"
                    form_css.Href = "../css/form.css"
                    Me.Page.Header.Controls.Add(form_css)
                End If

                'autocompleteを外す
                If InStr(Me.Request.Url.AbsolutePath, "DominClubLogin.aspx") > 0 OrElse _
                   InStr(Me.Request.Url.AbsolutePath, "TeraPassportLogin.aspx") > 0 OrElse _
                   InStr(Me.Request.Url.AbsolutePath, "threehundred/Login.aspx") > 0 Then
                    Me.form.Attributes.Remove("autocomplete")
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' ログインボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtnログイン_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnログイン.Click
            Try
                CType(Me.Page, BasePage).SessionInfo.遷移先URL = CType(Me.Page, BasePage).Request.Url.AbsoluteUri
                CType(Me.Page, BasePage).StoreSession()
                PageUtility.SendPage(Me.Page, "../Members/UserLogin.aspx")
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 新規会員ボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtn新規会員_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn新規会員.Click
            Try
                PageUtility.SendPage(Me.Page, "../Members/UserLogin.aspx")
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 法人ログインボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtn法人ログイン_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn法人ログイン.Click
            Try
                PageUtility.SendPage(Me.Page, "../Members/CorporateLogin.aspx")
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' ログアウトボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtnログアウト_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnログアウト.Click
            Try
                CType(Me.Page, BasePage).RedirectLogout()
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' ログアウトボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtn湯めぐりログアウト_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn湯めぐりログアウト.Click
            Try
                CType(Me.Page, BasePage).RedirectLogout()
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        Protected Sub ibtn検索_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn検索.Click
            Try
                Dim uri As New StringBuilder
                uri.Append("../Search/result.html")
                uri.Append("?cx=001472873533726067630:xfx8gdokpce")
                uri.Append("&cof=FORID:10;NB:1")
                uri.Append("&ie=UTF-8")
                uri.Append("&q=").Append(Me.txtサイト内検索.Text)

                PageUtility.SendPage(Me.Page, uri.ToString())
                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    #region "リンクの設定"

        Private Const BIZ_REF As String = "../DormyInn/"
        Private Const RES_REF As String = "../Resort/"
        Private Const SPA_REF As String = "../spa/"

        Private Const GBIZ_REF As String = "../hotels/garosugil/"
        Private Const GRES_REF As String = "../hotels/garosugil/"

        Private Const NV1_REF As String = "../hotels/"
        Private Const NV2_REF As String = "../guide/"
        Private Const NV3_REF As String = "../Common/PlanSearchList.aspx"
        Private Const NV3B_REF As String = "../Plan_DormyInn/PlanSearchList.aspx"
        Private Const NV3R_REF As String = "../Plan_Resort/PlanSearchList.aspx"
        Private Const NV4_REF As String = "../Rsv/ReservationList.aspx"
        Private Const NV5_REF As String = "../Users/QAInfo.aspx"
        Private Const NV6_REF As String = "../Members/MemberInfoTop.aspx"

        '湯めぐり用のリンク設定
        Private Const NV1Y_REF As String = "../yume_club/info.html"
        Private Const NV2Y_REF As String = "../yume_club/guide.html"
        Private Const NV3Y_REF As String = "../Plan_Yumeguri/PlanSearchList.aspx"
        Private Const NV5Y_REF As String = "../Members/MemberInfoTop.aspx"
        Private Const NV6Y_REF As String = "../yume_club/contact.html"
        Private Const NV7Y_REF As String = "../yume_club/rule.html"
        Private Const NV8Y_REF As String = "../yume_club/privacy.html"

        Private Sub SetLink(ByRef site As String)

            Select Case site

                Case "Resort"
                    Me.rbiz.HRef = BIZ_REF
                    Me.rres.HRef = RES_REF
                    Me.rspa.HRef = SPA_REF
                    Me.rgres.HRef = GRES_REF

                    Me.rnv01.HRef = NV1_REF
                    Me.rnv02.HRef = NV2_REF
                    Me.rnv03.HRef = NV3R_REF
                    Me.rnv04.HRef = NV4_REF
                    Me.rnv05.HRef = NV5_REF
                    Me.rnv06.HRef = NV6_REF

                Case "Biz"
                    Me.dbiz.HRef = BIZ_REF
                    Me.dres.HRef = RES_REF
                    Me.dspa.HRef = SPA_REF
                    Me.dgbiz.HRef = GBIZ_REF

                    Me.dnv01.HRef = NV1_REF
                    Me.dnv02.HRef = NV2_REF
                    Me.dnv03.HRef = NV3B_REF
                    Me.dnv04.HRef = NV4_REF
                    Me.dnv05.HRef = NV5_REF
                    Me.dnv06.HRef = NV6_REF

                Case "Yumeguri", "YumeguriNoHeader"
                    If CType(Me.Page, BasePage).LoginInfo Is Nothing Then
                        '湯めぐり未ログインの場合
                        Me.ynv01.HRef = String.Empty
                        Me.ynv02.HRef = String.Empty
                        Me.ynv03.HRef = String.Empty
                        Me.ynv04.HRef = String.Empty
                        Me.ynv05.HRef = String.Empty
                        Me.ynv06.HRef = String.Empty

                        Me.fynv01.HRef = String.Empty
                        Me.fynv02.HRef = String.Empty
                        Me.fynv03.HRef = String.Empty
                        Me.fynv04.HRef = String.Empty
                        Me.fynv05.HRef = String.Empty
                        Me.fynv06.HRef = String.Empty
                        Me.fynv07.HRef = String.Empty
                        Me.fynv08.HRef = String.Empty
                    Else
                        '湯めぐりログイン済みの場合
                        Me.ynv01.HRef = NV1Y_REF
                        Me.ynv02.HRef = NV2Y_REF
                        Me.ynv03.HRef = NV3Y_REF
                        Me.ynv04.HRef = NV4_REF
                        Me.ynv05.HRef = NV5Y_REF
                        Me.ynv06.HRef = NV6Y_REF

                        Me.fynv01.HRef = NV1Y_REF
                        Me.fynv02.HRef = NV2Y_REF
                        Me.fynv03.HRef = NV3Y_REF
                        Me.fynv04.HRef = NV4_REF
                        Me.fynv05.HRef = NV5Y_REF
                        Me.fynv06.HRef = NV6Y_REF
                        Me.fynv07.HRef = NV7Y_REF
                        Me.fynv08.HRef = NV8Y_REF
                    End If

                Case Else
                    Me.obiz.HRef = BIZ_REF
                    Me.ores.HRef = RES_REF
                    Me.ospa.HRef = SPA_REF

                    Me.onv01.HRef = NV1_REF
                    Me.onv02.HRef = NV2_REF
                    Me.onv03.HRef = NV3_REF
                    Me.onv04.HRef = NV4_REF
                    Me.onv05.HRef = NV5_REF
                    Me.onv06.HRef = NV6_REF

            End Select

            Me.fbiz.HRef = BIZ_REF
            Me.fres.HRef = RES_REF
            Me.fspa.HRef = SPA_REF

            Me.fnv01.HRef = NV1_REF
            Me.fnv02.HRef = NV2_REF
            Me.fnv03.HRef = NV3_REF
            Me.fnv04.HRef = NV4_REF
            Me.fnv05.HRef = NV5_REF
            Me.fnv06.HRef = NV6_REF

            Return
        End Sub

    #End Region

    End Class

End NameSpace

