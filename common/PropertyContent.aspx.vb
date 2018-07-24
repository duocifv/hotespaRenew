Imports System.Collections.Generic
Imports Com.Fujitsu.Hotespa.Web.Common
Imports Com.Fujitsu.Hotespa.Framework.Constant

Namespace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class PropertyContent
        Inherits BaseUserPage

#Region "パブリック定数"

        'パラメータ文字列
        Public Const C_QS_施設CD As String = "s_cd"

#End Region

#Region "プライベート定数"

        Private Const キャンセルポリシー補足 As String = "プランにより下記キャンセル料と異なる場合がございますのでご注意ください。"

#End Region

        ''' <summary>
        ''' 項目内容を設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub SetItemContent()

            'Webサービスを取得します。
            Dim service As PropertyContentWS.PropertyContentBS = MyBase.GetWebService(New PropertyContentWS.PropertyContentBS)

            'パラメータを設定します。
            Dim input As PropertyContentWS.PropertyContentBF = New PropertyContentWS.PropertyContentBF
            input.PropertyContentPram = New PropertyContentWS.PropertyContentParameters
            If String.IsNullOrEmpty(Me.Request.Params(C_QS_施設CD)) Then
                'エラーページに遷移します
                MyBase.SendErrorPage("取得中にエラーが発生したため、処理を中断します。")
                Me.IsLoad = False
                Return
            Else
                input.PropertyContentPram.施設CD = Me.Request.Params(C_QS_施設CD)
            End If

            '検索処理を行ない、結果を取得します。
            Dim output As PropertyContentWS.PropertyContentBF = service.FetchPropertyContent(input)

            If output.Result = False Then
                'エラーページに遷移します
                MyBase.SendErrorPage(output.MessageDS.Tables(0))
                Me.IsLoad = False
                Return
            End If

            'スタイルシートの設定切り替えを行います。
            Me.SetStyleSheet(output.PropertyContentBE)

            '施設情報を設定します。
            Me.SetHotelInformation(output.PropertyContentBE)

            Return

        End Sub

        ''' <summary>
        ''' 項目プロパティを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub SetItemProperty()

            '特になし

            Return

        End Sub

        ''' <summary>
        ''' ページが初期化されると発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

            MyBase.IsCheckSession = False

            Return

        End Sub

        ''' <summary>
        ''' 施設情報を設定します。
        ''' </summary>
        Private Sub SetHotelInformation(ByVal Entity As PropertyContentWS.UserPropertyContentBE)

            '取得した施設情報に編集を加えつつ各項目に設定します。
            Me.lbl施設名称.Text = Entity.PropertyContentView(0).事業所名称漢字
            Me.img施設名称.ImageUrl = Entity.PropertyContentView(0).ファイルパス & "/" & Entity.PropertyContentView(0).施設CD & "/" & Entity.PropertyContentView(0).施設イメージ画像
            Me.img施設写真.ImageUrl = Entity.PropertyContentView(0).ファイルパス & "/" & Entity.PropertyContentView(0).施設CD & "/" & Entity.PropertyContentView(0).施設写真
            Me.lbl住所.Text = "〒" & Entity.PropertyContentView(0).郵便番号 & Entity.PropertyContentView(0).住所
            Me.lbl連絡先.Text = Entity.PropertyContentView(0).電話1 & " / " & Entity.PropertyContentView(0).FAX
            Me.lbl基本時刻.Text = Entity.PropertyContentView(0).チェックイン時刻.ToString("HH:mm") & "（最終 " & Entity.PropertyContentView(0).最終チェックイン時刻.ToString("HH:mm") & _
                                  "）/ " & Entity.PropertyContentView(0).チェックアウト時刻.ToString("HH:mm")
            Me.lbl交通アクセス.Text = Entity.PropertyContentView(0).交通アクセス.Replace(vbCrLf, STR_BR)
            Me.lbl駐車場.Text = Entity.PropertyContentView(0).駐車場説明文.Replace(vbCrLf, STR_BR)
            Me.lbl風呂備考.Text = Entity.PropertyContentView(0).風呂説明文.Replace(vbCrLf, STR_BR)
            Me.hlk風呂URL.NavigateUrl = Entity.PropertyContentView(0).風呂URL
            Me.hlk風呂URL.Text = Me.hlk風呂URL.NavigateUrl
            Me.spn風呂URL.Visible = Not String.IsNullOrEmpty(Me.hlk風呂URL.NavigateUrl)

            '施設イメージ画像を制御します
            If String.IsNullOrEmpty(Entity.PropertyContentView(0).施設イメージ画像) Then
                Me.img施設名称.Visible = False
            Else
                Me.img施設名称.Visible = True
            End If

            '施設写真を制御します
            If String.IsNullOrEmpty(Entity.PropertyContentView(0).施設写真) Then
                Me.img施設写真.Visible = False
            Else
                Me.img施設写真.Visible = True
            End If

            '地図表示を制御します
            If String.IsNullOrEmpty(Entity.PropertyContentView(0).基本情報マップURL) Then
                Me.lnkMap.Visible = False
            Else
                Dim queryString As New Dictionary(Of String, String)
                queryString.Add(C_QS_施設CD, Me.Request.Params(C_QS_施設CD))
                Me.lnkMap.NavigateUrl = Me.ResolveUrl(Entity.PropertyContentView(0).基本情報マップURL)
            End If

            '行を全て表示にします。
            Me.tblrow風呂種類.Visible = True
            Me.tblrow風呂泉質.Visible = True
            Me.tblrow風呂効能.Visible = True
            Me.tblrow風呂備考.Visible = True
            Me.tblrow食事場所朝食.Visible = True
            Me.tblrow食事場所夕食.Visible = True
            Me.tblrow部屋施設備品.Visible = True
            Me.tblrow館内設備.Visible = True
            Me.tblrowサービス.Visible = True
            Me.tblrow身障者設備.Visible = True
            Me.tblrow特典.Visible = True
            Me.tblrowレジャー.Visible = True
            Me.tblrowカード.Visible = True
            Me.lbtn詳細.Visible = True

            '施設属性項目について編集を行います。
            Me.lbl風呂種類.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_風呂_種類 & "'"))
            Me.lbl風呂泉質.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_風呂_泉質 & "'"))
            Me.lbl風呂効能.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_風呂_効能 & "'"))
            Me.lbl食事場所朝食.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_食事場所_朝食 & "'"))
            Me.lbl食事場所夕食.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_食事場所_夕食 & "'"))
            Me.lbl部屋施設備品.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_部屋設備･備品 & "'"))
            Me.lbl館内設備.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_館内設備 & "'"))
            Me.lblサービス.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_ｻｰﾋﾞｽ & "'"))
            Me.lbl身障者設備.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_身障者設備 & "'"))
            Me.lbl特典.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_特典 & "'"))
            Me.lblレジャー.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_周辺のﾚｼﾞｬｰ & "'"))
            Me.lblカード.Text = Me.SetPropertyAttribute(Entity.PropertyAttributeView.Select("属性カテゴリ区分='" & CodeConst.C_属性カテゴリ区分_ｶｰﾄﾞ & "'"))

            '表示項目が存在しない行は非表示にします。
            If String.IsNullOrEmpty(Me.lbl風呂種類.Text) Then
                Me.tblrow風呂種類.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl風呂泉質.Text) Then
                Me.tblrow風呂泉質.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl風呂効能.Text) Then
                Me.tblrow風呂効能.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl風呂備考.Text) Then
                Me.tblrow風呂備考.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl食事場所朝食.Text) Then
                Me.tblrow食事場所朝食.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl食事場所夕食.Text) Then
                Me.tblrow食事場所夕食.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl部屋施設備品.Text) Then
                Me.tblrow部屋施設備品.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl館内設備.Text) Then
                Me.tblrow館内設備.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lblサービス.Text) Then
                Me.tblrowサービス.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl身障者設備.Text) Then
                Me.tblrow身障者設備.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lbl特典.Text) Then
                Me.tblrow特典.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lblレジャー.Text) Then
                Me.tblrowレジャー.Visible = False
            End If
            If String.IsNullOrEmpty(Me.lblカード.Text) Then
                Me.tblrowカード.Visible = False
            End If

            '詳細リンクの制御を行います
            If String.IsNullOrEmpty(Entity.PropertyContentView(0).館内説明URL) Then
                Me.lbtn詳細.Visible = False
            Else
                Me.lbtn詳細.Visible = True
                Dim queryString As New Dictionary(Of String, String)
                queryString.Add(C_QS_施設CD, Me.Request.Params(C_QS_施設CD))
                Me.lbtn詳細.NavigateUrl = GetQueryStringURL(Entity.PropertyContentView(0).館内説明URL, queryString)
            End If

            '条件・その他の編集を行います。
            If String.IsNullOrEmpty(Entity.PropertyContentView(0).予約時注意事項) = False Then
                Dim 予約時注意事項 As String = Entity.PropertyContentView(0).予約時注意事項.Replace(vbCrLf, STR_BR)
                Dim otherList() As String
                otherList = Split(予約時注意事項, BasePage.STR_BR, , CompareMethod.Text)
                Me.SetListLabel(Me.lbl条件その他, otherList)
            End If

            'キャンセルポリシーの編集を行います。
            If Entity.CancelPolicyView.Count > 0 Then

                If String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシー説明) Then
                    Me.lblキャンセルポリシー説明.Visible = False
                Else
                    Me.lblキャンセルポリシー説明.Visible = True
                    Me.lblキャンセルポリシー説明.Text = Entity.CancelPolicyView(0).キャンセルポリシー説明.Replace(vbCrLf, STR_BR) & BasePage.STR_BR
                End If

                Me.lblキャンセルポリシー補足.Text = キャンセルポリシー補足

                Dim cancelpolicyText As String = String.Empty
                Dim cancelpolicyList() As String
                'キャンセルポリシー1
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分1 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント1) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント1
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント1
                    End If
                End If
                'キャンセルポリシー2
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分2 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント2) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント2
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント2
                    End If
                End If
                'キャンセルポリシー3
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分3 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント3) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント3
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント3
                    End If
                End If
                'キャンセルポリシー4
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分4 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント4) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント4
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント4
                    End If
                End If
                'キャンセルポリシー5
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分5 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント5) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント5
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント5
                    End If
                End If
                'キャンセルポリシー6
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分6 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント6) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント6
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント6
                    End If
                End If
                'キャンセルポリシー7
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分7 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント7) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント7
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント7
                    End If
                End If
                'キャンセルポリシー8
                If Entity.CancelPolicyView(0).キャンセルポリシー利用可否区分8 = CodeConst.C_可否区分_可 AndAlso _
                        String.IsNullOrEmpty(Entity.CancelPolicyView(0).キャンセルポリシーコメント8) = False Then
                    If String.IsNullOrEmpty(cancelpolicyText) Then
                        cancelpolicyText = cancelpolicyText & Entity.CancelPolicyView(0).キャンセルポリシーコメント8
                    Else
                        cancelpolicyText = cancelpolicyText & BasePage.STR_BR & Entity.CancelPolicyView(0).キャンセルポリシーコメント8
                    End If
                End If

                'キャンセルポリシーの編集を行います。
                If String.IsNullOrEmpty(cancelpolicyText) = False Then
                    cancelpolicyList = Split(cancelpolicyText, BasePage.STR_BR, , CompareMethod.Text)
                    Me.SetListLabel(Me.lblキャンセルポリシー, cancelpolicyList)
                End If

            End If

        End Sub

        ''' <summary>
        ''' 施設属性情報を設定します。
        ''' </summary>
        Private Function SetPropertyAttribute(ByVal tableRows As PropertyContentWS.UserPropertyContentBE.PropertyAttributeViewRow()) As String

            Dim Text As New StringBuilder

            '文字列をカンマ編集します。
            For Each row As PropertyContentWS.UserPropertyContentBE.PropertyAttributeViewRow In tableRows
                If String.IsNullOrEmpty(Text.ToString) Then
                Else
                    Text.Append("、")
                End If
                Text.Append(row.属性名)
            Next

            Return Text.ToString

        End Function

        ''' <summary>
        ''' スタイルシートの切り替えを行います。
        ''' </summary>
        Private Sub SetStyleSheet(ByVal Entity As PropertyContentWS.UserPropertyContentBE)

            Dim page_css As HtmlLink = New HtmlLink
            Dim page_side_css As HtmlLink = New HtmlLink
            Dim page_divide_css As HtmlLink = New HtmlLink

            page_css.Attributes("rel") = "stylesheet"
            page_css.Attributes("type") = "text/css"
            page_side_css.Attributes("rel") = "stylesheet"
            page_side_css.Attributes("type") = "text/css"
            page_divide_css.Attributes("rel") = "stylesheet"
            page_divide_css.Attributes("type") = "text/css"

            'ドーミイン/湯めぐり/リゾートで切り替えを行ないます。
            Select Case Entity.PropertyContentView(0).施設区分

                Case CodeConst.C_施設区分_ﾘｿﾞｰﾄ

                    'スタイルシートの追加
                    page_css.Href = "../css/resort.css"
                    page_side_css.Href = "../css/resort_side.css"
                    page_divide_css.Href = "../css/form_divide_r.css"

                    Me.Page.Header.Controls.Add(page_css)
                    Me.Page.Header.Controls.Add(page_side_css)
                    Me.Page.Header.Controls.Add(page_divide_css)

                    Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "cssset", "<script type=""text/javascript"">$(""#header"").attr(""class"", ""res"");</script>")

                Case CodeConst.C_施設区分_ﾋﾞｼﾞﾈｽ

                    'スタイルシートの追加
                    page_css.Href = "../css/business.css"
                    page_side_css.Href = "../css/business_side.css"
                    page_divide_css.Href = "../css/form_divide.css"

                    Me.Page.Header.Controls.Add(page_css)
                    Me.Page.Header.Controls.Add(page_side_css)
                    Me.Page.Header.Controls.Add(page_divide_css)

                    Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "cssset", "<script type=""text/javascript"">$(""#header"").attr(""class"", ""biz"");</script>")

                Case Else

            End Select

        End Sub

    End Class

End Namespace
