Imports Com.Fujitsu.Hotespa.Web.Common
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control
Imports Com.Fujitsu.Hotespa.WebFramework

Namespace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class RoomTypeContent
        Inherits BaseUserPage

#Region "パブリック定数"

        'パラメータ文字列
        Public Const C_QS_施設CD As String = "s_cd"
        Public Const C_QS_タイプCD As String = "t_cd"

#End Region

#Region "プライベート定数"

        Private Const 一人当たり As String = "一人あたり料金"
        Private Const 一室当たり As String = "一室あたり料金"

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
                    Dim outputBE As RoomTypeContentWS.RoomTypeContentBE
                    outputBE = MyBase.SessionInfo.GetDeserializeセッション情報(Of RoomTypeContentWS.RoomTypeContentBE)()

                    'プレビューの設定をします。
                    SetRoomTypePreview(outputBE)
                    'スタイルシートの設定切り替えを行います。
                    Me.SetStyleSheet(outputBE.tblwRoomType(0).施設区分)
                    Me.IsLoad = False
                    Return
                End If
            End If
            '--------------------------------------------------------------------------------------------------------------

            'Webサービスを取得します。
            Dim service As RoomTypeContentWS.RoomTypeContentBS = MyBase.GetWebService(New RoomTypeContentWS.RoomTypeContentBS)

            'パラメータを設定します。
            Dim input As RoomTypeContentWS.RoomTypeContentBF = New RoomTypeContentWS.RoomTypeContentBF
            input.RoomTypeContentPram = New RoomTypeContentWS.RoomTypeContentParameters
            If String.IsNullOrEmpty(Me.Request.Params(C_QS_施設CD)) Then
                'エラーページに遷移します
                MyBase.SendErrorPage("取得中にエラーが発生したため、処理を中断します。")
                Me.IsLoad = False
                Return
            Else
                input.RoomTypeContentPram.施設CD = Me.Request.Params(C_QS_施設CD)
            End If
            If String.IsNullOrEmpty(Me.Request.Params(C_QS_タイプCD)) Then
                'エラーページに遷移します
                MyBase.SendErrorPage("取得中にエラーが発生したため、処理を中断します。")
                Me.IsLoad = False
                Return
            Else
                input.RoomTypeContentPram.タイプCD = Me.Request.Params(C_QS_タイプCD)
            End If

            '検索処理を行ない、結果を取得します。
            Dim output As RoomTypeContentWS.RoomTypeContentBF = service.FetchRoomTypeContent(input)

            If output.Result = True AndAlso output.RoomTypeContentBE.RoomTypeContentView.Count > 0 Then
            Else
                'エラーページに遷移します
                MyBase.SendErrorPage(output.MessageDS.Tables(0))
                Me.IsLoad = False
                Return
            End If

            'スタイルシートの設定切り替えを行います。
            Me.SetStyleSheet(output.RoomTypeContentBE.RoomTypeContentView(0).施設区分)

            '部屋タイプ情報を設定します。
            Me.SetRoomTypeInformation(output.RoomTypeContentBE)

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
        ''' 部屋タイプ情報を設定します。
        ''' </summary>
        Private Sub SetRoomTypeInformation(ByVal Entity As RoomTypeContentWS.UserRoomTypeContentBE)

            '写真イメージを全て表示するように設定します
            Me.imgRoom1.Visible = True
            Me.imgRoom2.Visible = True
            Me.imgRoom3.Visible = True
            Me.imgRoom4.Visible = True

            '取得した部屋タイプ情報に編集を加えつつ各項目に設定します。
            Me.lbl部屋タイプ名.Text = Entity.RoomTypeContentView(0).タイプ名称漢字 & "（定員：" & Entity.RoomTypeContentView(0).最少使用人数.ToString & _
                                      "～" & Entity.RoomTypeContentView(0).最大使用人数.ToString & "名）"
            Me.imgRoom1.ImageUrl = Entity.RoomTypeContentView(0).ファイルパス & "/" & Entity.RoomTypeContentView(0).施設CD & "/" & Entity.RoomTypeContentView(0).写真ファイル名1
            Me.imgRoom2.ImageUrl = Entity.RoomTypeContentView(0).ファイルパス & "/" & Entity.RoomTypeContentView(0).施設CD & "/" & Entity.RoomTypeContentView(0).写真ファイル名2
            Me.imgRoom3.ImageUrl = Entity.RoomTypeContentView(0).ファイルパス & "/" & Entity.RoomTypeContentView(0).施設CD & "/" & Entity.RoomTypeContentView(0).写真ファイル名3
            Me.imgRoom4.ImageUrl = Entity.RoomTypeContentView(0).ファイルパス & "/" & Entity.RoomTypeContentView(0).施設CD & "/" & Entity.RoomTypeContentView(0).写真ファイル名4

            '写真イメージが存在しないものは非表示にします。
            If String.IsNullOrEmpty(Entity.RoomTypeContentView(0).写真ファイル名1) Then
                Me.imgRoom1.Visible = False
            End If
            If String.IsNullOrEmpty(Entity.RoomTypeContentView(0).写真ファイル名2) Then
                Me.imgRoom2.Visible = False
            End If
            If String.IsNullOrEmpty(Entity.RoomTypeContentView(0).写真ファイル名3) Then
                Me.imgRoom3.Visible = False
            End If
            If String.IsNullOrEmpty(Entity.RoomTypeContentView(0).写真ファイル名4) Then
                Me.imgRoom4.Visible = False
            End If

            '詳細情報の編集を行います。
            Dim 説明文 As String = Entity.RoomTypeContentView(0).説明文.Replace(vbCrLf, STR_BR)
            Dim detailList() As String
            detailList = Split(説明文, BasePage.STR_BR, , CompareMethod.Text)
            Me.SetListLabel(Me.lbl詳細情報, detailList)

            '料金一覧のタイトル部を編集します
            Select Case Entity.RoomTypeContentView(0).料金設定区分
                Case CodeConst.C_料金設定区分_一人当たり
                    Me.gv料金表.Columns(0).HeaderText = 一人当たり
                Case CodeConst.C_料金設定区分_一室当たり
                    Me.gv料金表.Columns(0).HeaderText = 一室当たり
                Case Else
                    '通常ありえない
                    Me.gv料金表.Columns(0).HeaderText = String.Empty
            End Select

            Me.gv料金表.DataSource = Entity.RoomTypeChargeList
            Me.gv料金表.DataBind()

        End Sub

        ''' <summary>
        ''' 部屋タイプ情報を設定します。(プレビュー用)
        ''' </summary>
        Private Sub SetRoomTypePreview(ByVal Entity As RoomTypeContentWS.RoomTypeContentBE)

            '写真イメージを全て表示するように設定します
            Me.imgRoom1.Visible = True
            Me.imgRoom2.Visible = True
            Me.imgRoom3.Visible = True
            Me.imgRoom4.Visible = True

            '取得した部屋タイプ情報に編集を加えつつ各項目に設定します。
            Me.lbl部屋タイプ名.Text = Entity.tblwRoomType(0).タイプ名称漢字 & "（定員：" & Entity.tblwRoomType(0).最少使用人数.ToString & _
                                      "～" & Entity.tblwRoomType(0).最大使用人数.ToString & "名）"
            Me.imgRoom1.ImageUrl = Entity.tblwRoomType(0).写真1URL
            Me.imgRoom2.ImageUrl = Entity.tblwRoomType(0).写真2URL
            Me.imgRoom3.ImageUrl = Entity.tblwRoomType(0).写真3URL
            Me.imgRoom4.ImageUrl = Entity.tblwRoomType(0).写真4URL

            '詳細情報の編集を行います。
            Dim 説明文 As String = Entity.tblwRoomType(0).説明文.Replace(vbCrLf, STR_BR)
            Dim detailList() As String
            detailList = Split(説明文, BasePage.STR_BR, , CompareMethod.Text)
            Me.SetListLabel(Me.lbl詳細情報, detailList)

            '料金一覧のタイトル部を編集します
            Select Case Entity.tblwRoomType(0).Plan料金設定区分
                Case CodeConst.C_料金設定区分_一人当たり
                    Me.gv料金表.Columns(0).HeaderText = 一人当たり
                Case CodeConst.C_料金設定区分_一室当たり
                    Me.gv料金表.Columns(0).HeaderText = 一室当たり
                Case Else
                    '通常ありえない
                    Me.gv料金表.Columns(0).HeaderText = String.Empty
            End Select

            Me.gv料金表.DataSource = Entity.tblwPlanType
            Me.gv料金表.DataBind()

        End Sub

        ''' <summary>
        ''' 料金表上のデータバインドイベント
        ''' </summary>
        Protected Sub gv料金表_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv料金表.RowDataBound

            Try

                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then
                    e.Row.Cells(0).ColumnSpan = 2
                    e.Row.Cells(1).Visible = False
                    Return
                End If

                e.Row.Cells(0).Text = "通常料金：<span>" & (DataBinder.Eval(e.Row.DataItem, "利用人数").ToString()) & "</span>"
                e.Row.Cells(1).Text = (DataBinder.Eval(e.Row.DataItem, "料金").ToString())

            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try

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
