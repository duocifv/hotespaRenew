Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Common
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

Namespace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class PlanContent
        Inherits BaseUserPage

#Region "パブリック定数"

        'パラメータ文字列
        Public Const C_QS_施設CD As String = "s_cd"
        Public Const C_QS_プランCD As String = "p_cd"

#End Region

        ''' <summary>
        ''' 項目内容を設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub SetItemContent()
            'プレビュー用
            '--------------------------------------------------------------------------------------------------------------
            Dim viewType As String

            'クエリストリングを取得
            viewType = Request.QueryString("view_type")

            'view_typeによって処理を分岐
            If String.IsNullOrEmpty(viewType) OrElse Not viewType.Equals("temp") Then
            Else
                If MyBase.SessionInfo.セッション情報 Is Nothing Then
                    Dim outputBE As PlanContent_DormyInnWS.PlanContentBE
                    outputBE = MyBase.SessionInfo.GetDeserializeセッション情報(Of PlanContent_DormyInnWS.PlanContentBE)()

                    Me.lblプラン名称.Text = outputBE.tblwPlan(0).プラン名称
                    Me.lblプラン詳細.Text = outputBE.tblwPlan(0).説明文.ToString.Replace(vbCrLf, "<br/>")
                    If Not String.IsNullOrEmpty(outputBE.tblwPlan(0).写真1Url) Then
                        Me.imgプランイメージ.ImageUrl = outputBE.tblwPlan(0).写真1Url
                        Me.imgプランイメージ.Visible = True
                    Else
                        Me.imgプランイメージ.Visible = False
                    End If

                    'スタイルシートの設定切り替えを行います。
                    Me.SetStyleSheet(outputBE.tblwPlan(0).施設区分)

                    Me.IsLoad = False

                    Return
                End If
            End If
            '--------------------------------------------------------------------------------------------------------------

            'Webサービスを取得します。
            Dim service As PlanContent_DormyInnWS.PlanContentBS = MyBase.GetWebService(New PlanContent_DormyInnWS.PlanContentBS)

            'パラメータを設定します。
            Dim input As PlanContent_DormyInnWS.PlanContentBF = New PlanContent_DormyInnWS.PlanContentBF
            input.PlanContentViewParam = New PlanContent_DormyInnWS.PlanContentParameters
            If String.IsNullOrEmpty(Me.Request.Params(C_QS_施設CD)) Then
                'エラーページに遷移します
                MyBase.SendErrorPage("取得中にエラーが発生したため、処理を中断します。")
                Me.IsLoad = False
                Return
            Else
                input.PlanContentViewParam.施設CD = Me.Request.Params(C_QS_施設CD)
            End If
            If String.IsNullOrEmpty(Me.Request.Params(C_QS_プランCD)) Then
                'エラーページに遷移します
                MyBase.SendErrorPage("取得中にエラーが発生したため、処理を中断します。")
                Me.IsLoad = False
                Return
            Else
                input.PlanContentViewParam.プランCD = Me.Request.Params(C_QS_プランCD)
            End If

            '検索処理を行ない、結果を取得します。
            Dim output As PlanContent_DormyInnWS.PlanContentBF = service.FetchPlanContent(input)

            If output.Result = True AndAlso output.PlanContentBE.PlanContentView.Count > 0 Then
            Else
                'エラーページに遷移します
                MyBase.SendErrorPage(output.MessageDS.Tables(0))
                Me.IsLoad = False
                Return
            End If

            'スタイルシートの設定切り替えを行います。
            Me.SetStyleSheet(output.PlanContentBE.PlanContentView(0).施設区分)

            '施設情報を設定します。
            Me.SetPlanInformation(output.PlanContentBE)

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
        ''' プラン情報を設定します。
        ''' </summary>
        Private Sub SetPlanInformation(ByVal Entity As PlanContent_DormyInnWS.UserPlanContentBE)

            '取得したプラン情報に編集を加えつつ各項目に設定します。
            Me.lbl施設名称.Text = Entity.PlanContentView(0).事業所名称漢字
            Me.imgプランイメージ.ImageUrl = Entity.PlanContentView(0).ファイルパス & "/" & Entity.PlanContentView(0).施設CD & "/" & Entity.PlanContentView(0).写真ファイル名
            Me.lblプラン名称.Text = Entity.PlanContentView(0).プラン名称漢字
            Me.lblプラン詳細.Text = Entity.PlanContentView(0).プラン説明文.Replace(vbCrLf, STR_BR)

            'プランイメージを制御します
            If String.IsNullOrEmpty(Entity.PlanContentView(0).写真ファイル名) Then
                Me.imgプランイメージ.Visible = False
            Else
                Me.imgプランイメージ.Visible = True
            End If

        End Sub

        ''' <summary>
        ''' スタイルシートの切り替えを行います。
        ''' </summary>
        Private Sub SetStyleSheet(ByVal 施設区分 As String)

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
            Select Case 施設区分

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
