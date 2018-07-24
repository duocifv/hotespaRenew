Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control
Imports Com.Fujitsu.Hotespa.Web.Common

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    ''' <summary>
    ''' 予約情報を入力するコントロール
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class ReserveInfo
        Inherits System.Web.UI.UserControl

        Private Const SPACE As String = "&nbsp;&nbsp;&nbsp;"

        Private Const C_QS_施設CD   As String = "s_cd"
        Private Const C_QS_プランCD As String = "p_cd"

        Private _予約タイプ情報 As DataTable
        Private _朝食情報 As DataTable
        Private _夕食情報 As DataTable
        Private _予約選択料理 As DataTable
        Private _プラン情報 As DataRow

#Region "プロパティ"

        ''' <summary>
        ''' 到着日を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 到着日() As Date
            Get
                Return Me.ViewState("_到着日")
            End Get
            Set
                Me.ViewState("_到着日") = Value
            End Set
        End Property

        ''' <summary>
        ''' 宿泊数を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 宿泊数() As Integer
            Get
                If Not Me.ddl出発日.Visible Then Return 0
                Return Me.ViewState("_宿泊数")
            End Get
            Set
                Me.ViewState("_宿泊数") = Value
                If Value <= 0 Then Me.ViewState("_宿泊数") = 1
            End Set
        End Property

        ''' <summary>
        ''' 部屋数を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 部屋数() As Integer
            Get
                Return Me.ViewState("_部屋数")
            End Get
            Set
                Me.ViewState("_部屋数") = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約タイプ情報を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 予約タイプ情報() As DataTable
            Get
                Return Me.Get予約タイプ情報()
            End Get
            Set
                _予約タイプ情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 朝食情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 朝食情報() As DataTable
            Set
                _朝食情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 夕食情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 夕食情報() As DataTable
            Set
                _夕食情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約選択料理を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 予約選択料理() As DataTable
            Get
                Return Me.Get予約選択料理()
            End Get
            Set
                _予約選択料理 = Value
            End Set
        End Property

        ''' <summary>
        ''' 施設名を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 施設名() As String
            Set
                Me.lbl施設名.Text = Value
            End Set
        End Property

        ''' <summary>
        ''' 部屋タイプ名を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 部屋タイプ名() As String
            Set
                Me.lbl部屋タイプ名.Text = Value
            End Set
        End Property

        ''' <summary>
        ''' プランCDを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property プランCD() As String
            Get
                Return Me.ViewState("プランCD")
            End Get
            Set
                Me.ViewState("プランCD") = Value
            End Set
        End Property

        ''' <summary>
        ''' 施設CDを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 施設CD() As String
            Get
                Return Me.ViewState("施設CD")
            End Get
            Set
                Me.ViewState("施設CD") = Value
            End Set
        End Property

        ''' <summary>
        ''' 施設区分を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 施設区分() As String
            Get
                Return Me.ViewState("施設区分")
            End Get
            Set
                Me.ViewState("施設区分") = Value
            End Set
        End Property

        ''' <summary>
        ''' 湯めぐり倶楽部区分を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 湯めぐり倶楽部区分() As String
            Get
                Return Me.ViewState("湯めぐり倶楽部区分")
            End Get
            Set(ByVal value As String)
                Me.ViewState("湯めぐり倶楽部区分") = value
            End Set
        End Property

        ''' <summary>
        ''' プラン情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property プラン情報() As DataRow
            Set(ByVal value As DataRow)
                _プラン情報 = Value
            End Set
        End Property

#End Region

        ''' <summary>
        ''' 検証が終了したかどうかを示す値を取得します。
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValid(ByRef msg As List(Of String)) As Boolean

            '湯めぐり倶楽部区分によりチェック内容を変更します。
            If Me.湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                If Me.gv人数_y.Rows.Count > 0 Then
                    Dim ddl As Template.DropDownList
                    Dim row As GridViewRow = Me.gv人数_y.Rows(0)
                    ddl = CType(row.FindControl("ddl大人_メンバー"), Template.DropDownList)
                    If ddl.Visible AndAlso (ddl.SelectedIndex <= 0) Then
                        msg.Add(Messages.GetMessage("E014", "（メンバー）大人人数"))
                    End If
                End If

                'システム日付から数えての月数。月末まで
                Dim limitDate As Date = Date.Now.Date.AddMonths(CInt(CType(Me.Page, BasePage).SessionInfo.先予約可能月数))

                If Me.宿泊数 = 0 Then
                    'デイユースの場合
                    If CDate(Me.ddl出発日.SelectedValue) > limitDate Then
                        msg.Add(Messages.GetMessage("E000", "先予約可能月数を超えている為、登録できません"))
                    End If
                Else
                    '１泊以上の場合
                    If CDate(Me.ddl出発日.SelectedValue).AddDays(-1) > limitDate Then
                        msg.Add(Messages.GetMessage("E000", "先予約可能月数を超えている為、登録できません"))
                    End If
                End If

            Else
                Dim ddl As Template.DropDownList
                For i As Integer = 0 To Me.宿泊数 - 1
                    Dim row As GridViewRow = Me.gv食事.Rows(i)

                    ddl = CType(row.FindControl("ddl朝食"), Template.DropDownList)

                    If ddl.Visible AndAlso (ddl.SelectedIndex <= 0) Then
                        msg.Add(Messages.GetMessage("E014", "食事"))
                    End If

                    ddl = CType(row.FindControl("ddl夕食"), Template.DropDownList)

                    If ddl.Visible AndAlso (ddl.SelectedIndex <= 0) Then
                        msg.Add(Messages.GetMessage("E014", "食事"))
                    End If
                Next
            End If

            Return (msg.Count <= 0)
        End Function

        ''' <summary>
        ''' ページが読み込まれると発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Me.IsPostBack Then Return
                If Not CType(Me.Page, BasePage).IsLoad Then Return

                Me.lblプラン名.Text = _プラン情報("プラン名称漢字")
                Me.lbl到着日.Text = Me.到着日.ToString("yyyy年MM月dd日(ddd)")

                '湯めぐり倶楽部区分により見出しの表示を変更します。
                If Me.湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                    If Not (_プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数_y.Columns(2).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_小学生_大人に準じた食事).Replace("（", "<br>（")
                    If Not (_プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数_y.Columns(3).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_小学生_お子様の食事).Replace("（", "<br>（")
                    If Not (_プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数_y.Columns(4).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_幼児_食事･布団付).Replace("（", "<br>（")
                    If Not (_プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数_y.Columns(5).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_幼児_食事･布団不要).Replace("（", "<br>（")
                Else
                    '施設区分により見出しの表示を変更します。
                    If Me.施設区分.Equals(CodeConst.C_施設区分_ﾋﾞｼﾞﾈｽ) Then
                        If Not (_プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(2).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_小学生_布団付).Replace("生", "生<br>")
                        If Not (_プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(3).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_小学生_布団無).Replace("生", "生<br>")
                        If Not (_プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(4).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_幼児_3歳_布団付).Replace("（", "<br>（")
                    Else
                        If Not (_プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(2).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_小学生高学年).Replace("生", "生<br>")
                        If Not (_プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(3).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_小学生低学年).Replace("生", "生<br>")
                        If Not (_プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(4).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事･布団付).Replace("（", "<br>（")
                        If Not (_プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(5).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事のみ).Replace("（", "<br>（")
                        If Not (_プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(6).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_布団のみ).Replace("（", "<br>（")
                        If Not (_プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)) Then Me.gv人数.Columns(7).HeaderText = CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事･布団不要).Replace("（", "<br>（")
                    End If
                End If

                'ポップアップの設定を行ないます。
                Dim param As New Dictionary(Of String, String)
                param.Add(C_QS_施設CD, Me.施設CD)
                param.Add(C_QS_プランCD, Me.プランCD)
                Me.hlkプラン内容.NavigateUrl = CType(Me.Page, BasePage).GetQueryStringURL("../PlanContent.aspx", param)

                If _プラン情報("デイユース区分").Equals(CodeConst.C_デイユース区分_ﾃﾞｲﾕｰｽ) Then
                    Me.ddl出発日.Visible = False
                    Me.lbl宿泊日.Visible = False
                    'Me.up宿泊日.Visible = False
                    'Me.tr宿泊数.Visible = False
                End If

                'ドロップダウンリストを設定します。
                Dim base As BasePage = CType(Me.Page, BasePage)
                'base.SetDDLCount(Me.ddl宿泊数, base.SessionInfo.予約可能泊数, False)
                base.SetDDLCount(Me.ddl部屋数, base.SessionInfo.予約可能室数, False)

                Dim list As New List(Of String)
                Dim i As Integer = CInt(_プラン情報("最短宿泊日数"))
                While i <= CInt(_プラン情報("最長宿泊日数")) AndAlso i <= base.SessionInfo.予約可能泊数
                    list.Add(Me.到着日.AddDays(i).ToString("yyyy年MM月dd日(ddd)"))
                    i += 1
                End While
                base.SetDDLList(Me.ddl出発日, list)

                'Dim del AS Integer = 0
                'For index As Integer = 1 To CInt(_プラン情報("最短宿泊日数")) - 1
                '    Me.ddl宿泊数.Items.RemoveAt(0)
                '    del += 1
                'Next
                'Dim str As Integer = CInt(_プラン情報("最長宿泊日数")) - del
                'For index As Integer = str To Me.ddl宿泊数.Items.Count - 1
                '    Me.ddl宿泊数.Items.RemoveAt(str)
                'Next

                'Me.ddl宿泊数.SelectedValue = Me.宿泊数
                Me.ddl部屋数.SelectedValue = Me.部屋数
                Me.ddl出発日.SelectedValue = Me.到着日.AddDays(Me.宿泊数).ToString("yyyy年MM月dd日(ddd)")

                'グリッドを設定します。
                Me.SetGridView()

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        '''' <summary>
        '''' 選択項目がサーバーへのポスト間で変更された場合に発生します。
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        '''' <remarks></remarks>
        'Protected Sub ddl宿泊数_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl宿泊数.SelectedIndexChanged
        '    Try
        '        If Not Me.tr宿泊数.Visible Then Return
        '        Me.宿泊数 = Convert.ToInt32(Me.ddl宿泊数.SelectedValue)

        '        '到着日と泊数から、出発日を計算します。
        '        Me.lbl出発日.Text = Me.到着日.AddDays(Me.宿泊数).ToString("yyyy年MM月dd日(ddd)")

        '        '泊数分グリッドを表示します。
        '        Dim cnt As Integer = DateDiff(DateInterval.Day, Me.到着日, Me.到着日.AddDays(Me.宿泊数))
        '        For i As Integer = 1 To Me.gv食事.Rows.Count - 1
        '            Me.gv食事.Rows(i).Visible = Not (cnt <= i)
        '        Next

        '        Return
        '    Catch ex As Exception
        '        CType(Me.Page, BasePage).ExceptionProcess(ex)
        '    End Try
        'End Sub

        ''' <summary>
        ''' 選択項目がサーバーへのポスト間で変更された場合に発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub ddl出発日_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl出発日.SelectedIndexChanged
            Try
                '到着日と出発日から、泊数を計算します。
                Dim day出発日 As Date = Date.ParseExact(Me.ddl出発日.SelectedValue, "yyyy年MM月dd日(ddd)", Nothing)
                Me.宿泊数 = DateDiff(DateInterval.Day, Me.到着日, day出発日)

                '泊数分グリッドを表示します。
                For i As Integer = 1 To Me.gv食事.Rows.Count - 1
                    Me.gv食事.Rows(i).Visible = Not (Me.宿泊数 <= i)
                Next

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 選択項目がサーバーへのポスト間で変更された場合に発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub ddl申込部屋数_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl部屋数.SelectedIndexChanged
            Try
                Me.部屋数 = Convert.ToInt32(Me.ddl部屋数.SelectedValue)

                '部屋数分グリッドを表示します。
                For i As Integer = 1 To Me.gv人数.Rows.Count - 1
                    Me.gv人数.Rows(i).Visible = Not (Me.部屋数 <= i)
                Next

                '部屋数分グリッドを表示します。
                For i As Integer = 1 To Me.gv人数_y.Rows.Count - 1
                    Me.gv人数_y.Rows(i).Visible = Not (Me.部屋数 <= i)
                Next

            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' データ行がデータにバインドされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub gv人数_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                CType(e.Row.FindControl("ddlこども1"), Template.DropDownList).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども2"), Template.DropDownList).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども3"), Template.DropDownList).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども4"), Template.DropDownList).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども5"), Template.DropDownList).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども6"), Template.DropDownList).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                CType(e.Row.FindControl("lbl人1"), Template.Label).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人2"), Template.Label).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人3"), Template.Label).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人4"), Template.Label).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人5"), Template.Label).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人6"), Template.Label).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                Me.Set人数Cell(e.Row, "ddl大人", "人数大人", True)
                Me.Set人数Cell(e.Row, "ddlこども1", "人数こども1")
                Me.Set人数Cell(e.Row, "ddlこども2", "人数こども2")
                Me.Set人数Cell(e.Row, "ddlこども3", "人数こども3")
                Me.Set人数Cell(e.Row, "ddlこども4", "人数こども4")
                Me.Set人数Cell(e.Row, "ddlこども5", "人数こども5")
                Me.Set人数Cell(e.Row, "ddlこども6", "人数こども6")

                '施設区分により表示を変更します。
                If Me.施設区分.Equals(CodeConst.C_施設区分_ﾘｿﾞｰﾄ) Then
                    Return
                End If

                CType(e.Row.FindControl("ddlこども4"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("ddlこども5"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("ddlこども6"), Template.DropDownList).Visible = False

                CType(e.Row.FindControl("lbl人4"), Template.Label).Visible = False
                CType(e.Row.FindControl("lbl人5"), Template.Label).Visible = False
                CType(e.Row.FindControl("lbl人6"), Template.Label).Visible = False

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' データ行がデータにバインドされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub gv人数_y_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                CType(e.Row.FindControl("ddlこども1_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども2_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども3_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども4_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども5_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども6_メンバー"), Template.DropDownList).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                CType(e.Row.FindControl("ddlこども1_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども2_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども3_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども4_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども5_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("ddlこども6_ビジター"), Template.DropDownList).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                CType(e.Row.FindControl("lbl人1_メンバー"), Template.Label).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人2_メンバー"), Template.Label).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人3_メンバー"), Template.Label).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人4_メンバー"), Template.Label).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人5_メンバー"), Template.Label).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人6_メンバー"), Template.Label).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                CType(e.Row.FindControl("lbl人1_ビジター"), Template.Label).Visible = Not _プラン情報("こども1料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人2_ビジター"), Template.Label).Visible = Not _プラン情報("こども2料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人3_ビジター"), Template.Label).Visible = Not _プラン情報("こども3料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人4_ビジター"), Template.Label).Visible = Not _プラン情報("こども4料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人5_ビジター"), Template.Label).Visible = Not _プラン情報("こども5料金区分").Equals(CodeConst.C_子供料金区分_受入不可)
                CType(e.Row.FindControl("lbl人6_ビジター"), Template.Label).Visible = Not _プラン情報("こども6料金区分").Equals(CodeConst.C_子供料金区分_受入不可)

                Me.Set人数Cell(e.Row, "ddl大人_メンバー", "人数大人")
                Me.Set人数Cell(e.Row, "ddlこども1_メンバー", "人数こども1")
                Me.Set人数Cell(e.Row, "ddlこども2_メンバー", "人数こども2")
                Me.Set人数Cell(e.Row, "ddlこども3_メンバー", "人数こども3")
                Me.Set人数Cell(e.Row, "ddlこども4_メンバー", "人数こども4")
                Me.Set人数Cell(e.Row, "ddlこども5_メンバー", "人数こども5")
                Me.Set人数Cell(e.Row, "ddlこども6_メンバー", "人数こども6")

                Me.Set人数Cell(e.Row, "ddl大人_ビジター", "ビジター人数大人")
                Me.Set人数Cell(e.Row, "ddlこども1_ビジター", "ビジター人数こども1")
                Me.Set人数Cell(e.Row, "ddlこども2_ビジター", "ビジター人数こども2")
                Me.Set人数Cell(e.Row, "ddlこども3_ビジター", "ビジター人数こども3")
                Me.Set人数Cell(e.Row, "ddlこども4_ビジター", "ビジター人数こども4")
                Me.Set人数Cell(e.Row, "ddlこども5_ビジター", "ビジター人数こども5")
                Me.Set人数Cell(e.Row, "ddlこども6_ビジター", "ビジター人数こども6")

                CType(e.Row.FindControl("ddlこども5_メンバー"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("ddlこども6_メンバー"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("lbl人5_メンバー"), Template.Label).Visible = False
                CType(e.Row.FindControl("lbl人6_メンバー"), Template.Label).Visible = False

                CType(e.Row.FindControl("ddlこども5_ビジター"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("ddlこども6_ビジター"), Template.DropDownList).Visible = False
                CType(e.Row.FindControl("lbl人5_ビジター"), Template.Label).Visible = False
                CType(e.Row.FindControl("lbl人6_ビジター"), Template.Label).Visible = False

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' データ行がデータにバインドされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub gv食事_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv食事.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                Dim 年月日 As Date = CType(DataBinder.Eval(e.Row.DataItem, "年月日"), Date)

                CType(e.Row.FindControl("lbl日付"), Template.Label).Text = 年月日.ToString("yyyy年MM月dd日")

                Dim ddl As Template.DropDownList
                Dim lbl As Template.Label

                '朝食を設定します。
                ddl = CType(e.Row.FindControl("ddl朝食"), Template.DropDownList)
                lbl = CType(e.Row.FindControl("lbl朝食"), Template.Label)

                '情報がない場合、何も表示しません。
                If _朝食情報 Is Nothing OrElse _朝食情報.Rows.Count <= 0 Then
                    ddl.Visible = False
                    lbl.Visible = True
                    lbl.Text = "-"
                Else
                    CType(Me.Page, BasePage).SetDDLDataTable(ddl, _朝食情報)
                    ddl.SelectedValue = Me.Get食事Value(年月日, CodeConst.C_食事区分_朝食)

                    '情報が1件の場合、ラベルを表示します。
                    If _朝食情報.Rows.Count = 1 Then
                        ddl.Visible = False
                        lbl.Visible = True
                        lbl.Text = ddl.SelectedItem.Text
                    Else
                        '情報が1件以上の場合、ドロップダウンリストに先頭項目を設定します。
                        CType(Me.Page, BasePage).AddDDLDataTable(ddl, 0, "", "選択してください")
                    End If
                End If

                '夕食を設定します。
                ddl = CType(e.Row.FindControl("ddl夕食"), Template.DropDownList)
                lbl = CType(e.Row.FindControl("lbl夕食"), Template.Label)

                '情報がない場合、何も表示しません。
                If _夕食情報 Is Nothing OrElse _夕食情報.Rows.Count <= 0 Then
                    ddl.Visible = False
                    lbl.Visible = True
                    lbl.Text = "-"
                Else
                    CType(Me.Page, BasePage).SetDDLDataTable(ddl, _夕食情報)
                    ddl.SelectedValue = Me.Get食事Value(年月日, CodeConst.C_食事区分_夕食)

                    '情報が1件の場合、ラベルを表示します。
                    If _夕食情報.Rows.Count = 1 Then
                        ddl.Visible = False
                        lbl.Visible = True
                        lbl.Text = ddl.SelectedItem.Text
                    Else
                        '情報が1件以上の場合、ドロップダウンリストに先頭項目を設定します。
                        CType(Me.Page, BasePage).AddDDLDataTable(ddl, 0, "", "選択してください")
                    End If
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' グリッドを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetGridView()

            '人数の情報を設定します。
            Dim roomtable As DataTable = New DataTable
            roomtable.Columns.Add("タイプ連番", GetType(Short))
            roomtable.Columns.Add("人数大人", GetType(Short))
            roomtable.Columns.Add("人数こども1", GetType(Short))
            roomtable.Columns.Add("人数こども2", GetType(Short))
            roomtable.Columns.Add("人数こども3", GetType(Short))
            roomtable.Columns.Add("人数こども4", GetType(Short))
            roomtable.Columns.Add("人数こども5", GetType(Short))
            roomtable.Columns.Add("人数こども6", GetType(Short))
            roomtable.Columns.Add("ビジター人数大人", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども1", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども2", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども3", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども4", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども5", GetType(Short))
            roomtable.Columns.Add("ビジター人数こども6", GetType(Short))

            For Each item As ListItem In Me.ddl部屋数.Items
                Dim row As DataRow = CType(Me.Page, BasePage).Find(_予約タイプ情報, "タイプ連番", CShort(item.Value))
                Dim newRow As DataRow = roomtable.NewRow()

                '情報が渡された場合、渡された情報を初期値に設定します。
                If row IsNot Nothing Then
                    DataSetUtility.CopyDataRow(row, newRow)
                    roomtable.Rows.Add(newRow)
                    Continue For
                End If

                '情報が渡されなかった場合、人数の初期値を設定します。
                row = CType(Me.Page, BasePage).Find(_予約タイプ情報, "タイプ連番", CShort(1))
                DataSetUtility.CopyDataRow(row, newRow)
                newRow("タイプ連番") = CShort(item.Value)
                roomtable.Rows.Add(newRow)
            Next

            '湯めぐり倶楽部区分によりバインド対象を変更します。
            If Me.湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                Me.gv人数_y.DataSource = roomtable
                Me.gv人数_y.DataBind()

                '食事の情報を非表示にします。
                Me.divSection.Visible = False
            Else

                Me.gv人数.DataSource = roomtable
                Me.gv人数.DataBind()

                '食事の情報を設定します。
                Me.divSection.Visible = True
                Dim mealtable As DataTable = New DataTable
                mealtable.Columns.Add("年月日", GetType(Date))

                Dim max As Integer = 1
                If Me.ddl出発日.Items.Count > 0 Then
                    'max = DateDiff(DateInterval.Day, Me.到着日, CDate(Me.ddl出発日.SelectedValue))
                    max = DateDiff(DateInterval.Day, Me.到着日, CDate(Me.ddl出発日.Items(Me.ddl出発日.Items.Count - 1).Text))
                End If

                For i As Integer = 0 To max - 1
                    Dim row As DataRow = mealtable.NewRow
                    row("年月日") = Me.到着日.AddDays(i)
                    mealtable.Rows.Add(row)
                Next

                Me.gv食事.DataSource = mealtable
                Me.gv食事.DataBind()

            End If

            Me.ddl出発日_SelectedIndexChanged(Nothing, Nothing)
            Me.ddl申込部屋数_SelectedIndexChanged(Nothing, Nothing)

            Return
        End Sub

        ''' <summary>
        ''' 食事情報を取得します。
        ''' </summary>
        ''' <param name="年月日"></param>
        ''' <param name="食事区分"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get食事Value(ByRef 年月日 As Date, ByRef 食事区分 As String) As String

            Dim row As DataRow = CType(Me.Page, BasePage).Find(_予約選択料理, "年月日", "食事区分", 年月日, 食事区分)
            If row Is Nothing Then Return String.Empty
            Return row("食事CD")

        End Function

        ''' <summary>
        ''' 人数のセルを設定します。
        ''' </summary>
        ''' <param name="row"></param>
        ''' <param name="dllName"></param>
        ''' <param name="dataName"></param>
        ''' <param name="is大人"></param>
        ''' <remarks></remarks>
        Private Sub Set人数Cell(ByRef row As GridViewRow, ByRef dllName As String, ByRef dataName As String, Optional ByVal is大人 As Boolean = False)

            Dim ddl As Template.DropDownList = CType(row.FindControl(dllName), Template.DropDownList)
            CType(Me.Page, BasePage).SetDDLCount(ddl, CType(Me.Page, BasePage).SessionInfo.予約可能人数, Not is大人)
            ddl.SelectedValue = DataBinder.Eval(row.DataItem, dataName)

            Return
        End Sub

        ''' <summary>
        ''' 人数の表示文字列を取得します。
        ''' </summary>
        ''' <param name="row"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get人数Text(ByRef row As GridViewRow) As String

            Dim result As New StringBuilder
            result.Append(Me.gv人数.Columns(1).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数大人").ToString()).Append("人")
            If Not DataBinder.Eval(row.DataItem, "人数こども1").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(2).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども1").ToString()).Append("人")
            End If
            If Not DataBinder.Eval(row.DataItem, "人数こども2").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(3).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども2").ToString()).Append("人")
            End If
            If Not DataBinder.Eval(row.DataItem, "人数こども3").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(4).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども3").ToString()).Append("人")
            End If
            If Not DataBinder.Eval(row.DataItem, "人数こども4").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(5).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども4").ToString()).Append("人")
            End If
            If Not DataBinder.Eval(row.DataItem, "人数こども5").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(6).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども5").ToString()).Append("人")
            End If
            If Not DataBinder.Eval(row.DataItem, "人数こども6").ToString().Equals("0") Then
                result.Append(SPACE)
                result.Append(Me.gv人数.Columns(7).HeaderText).Append("：").Append(DataBinder.Eval(row.DataItem, "人数こども6").ToString()).Append("人")
            End If

            Return result.ToString()
        End Function

        ''' <summary>
        ''' 予約タイプ情報を取得します。
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get予約タイプ情報() As DataTable
            Dim result As New DataTable
            result.Columns.Add("タイプ連番", GetType(Short))
            result.Columns.Add("人数大人", GetType(Short))
            result.Columns.Add("人数こども1", GetType(Short))
            result.Columns.Add("人数こども2", GetType(Short))
            result.Columns.Add("人数こども3", GetType(Short))
            result.Columns.Add("人数こども4", GetType(Short))
            result.Columns.Add("人数こども5", GetType(Short))
            result.Columns.Add("人数こども6", GetType(Short))
            result.Columns.Add("ビジター人数大人", GetType(Short))
            result.Columns.Add("ビジター人数こども1", GetType(Short))
            result.Columns.Add("ビジター人数こども2", GetType(Short))
            result.Columns.Add("ビジター人数こども3", GetType(Short))
            result.Columns.Add("ビジター人数こども4", GetType(Short))
            result.Columns.Add("ビジター人数こども5", GetType(Short))
            result.Columns.Add("ビジター人数こども6", GetType(Short))

            Dim cnt As Integer = Convert.ToInt32(Me.ddl部屋数.SelectedValue)

            '湯めぐり倶楽部区分によりバインド対象を変更します。
            If Me.湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                For i As Integer = 0 To cnt - 1
                    Dim row As GridViewRow = Me.gv人数_y.Rows(i)
                    Dim newRow As DataRow = result.NewRow()
                    newRow("タイプ連番") = CType(row.FindControl("lbl室番号_y"), Template.Label).Text
                    newRow("人数大人") = CType(row.FindControl("ddl大人_メンバー"), Template.DropDownList).SelectedValue
                    newRow("ビジター人数大人") = CType(row.FindControl("ddl大人_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども1_メンバー"), Template.DropDownList).Visible Then newRow("人数こども1") = CType(row.FindControl("ddlこども1_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども2_メンバー"), Template.DropDownList).Visible Then newRow("人数こども2") = CType(row.FindControl("ddlこども2_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども3_メンバー"), Template.DropDownList).Visible Then newRow("人数こども3") = CType(row.FindControl("ddlこども3_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども4_メンバー"), Template.DropDownList).Visible Then newRow("人数こども4") = CType(row.FindControl("ddlこども4_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども5_メンバー"), Template.DropDownList).Visible Then newRow("人数こども5") = CType(row.FindControl("ddlこども5_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども6_メンバー"), Template.DropDownList).Visible Then newRow("人数こども6") = CType(row.FindControl("ddlこども6_メンバー"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども1_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども1") = CType(row.FindControl("ddlこども1_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども2_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども2") = CType(row.FindControl("ddlこども2_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども3_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども3") = CType(row.FindControl("ddlこども3_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども4_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども4") = CType(row.FindControl("ddlこども4_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども5_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども5") = CType(row.FindControl("ddlこども5_ビジター"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども6_ビジター"), Template.DropDownList).Visible Then newRow("ビジター人数こども6") = CType(row.FindControl("ddlこども6_ビジター"), Template.DropDownList).SelectedValue
                    result.Rows.Add(newRow)
                Next
            Else
                For i As Integer = 0 To cnt - 1
                    Dim row As GridViewRow = Me.gv人数.Rows(i)
                    Dim newRow As DataRow = result.NewRow()
                    newRow("タイプ連番") = CType(row.FindControl("lbl室番号"), Template.Label).Text
                    newRow("人数大人") = CType(row.FindControl("ddl大人"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども1"), Template.DropDownList).Visible Then newRow("人数こども1") = CType(row.FindControl("ddlこども1"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども2"), Template.DropDownList).Visible Then newRow("人数こども2") = CType(row.FindControl("ddlこども2"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども3"), Template.DropDownList).Visible Then newRow("人数こども3") = CType(row.FindControl("ddlこども3"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども4"), Template.DropDownList).Visible Then newRow("人数こども4") = CType(row.FindControl("ddlこども4"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども5"), Template.DropDownList).Visible Then newRow("人数こども5") = CType(row.FindControl("ddlこども5"), Template.DropDownList).SelectedValue
                    If CType(row.FindControl("ddlこども6"), Template.DropDownList).Visible Then newRow("人数こども6") = CType(row.FindControl("ddlこども6"), Template.DropDownList).SelectedValue
                    result.Rows.Add(newRow)
                Next
            End If


            Return result
        End Function

        ''' <summary>
        ''' 予約選択料理を取得します。
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get予約選択料理() As DataTable

            Dim result As New DataTable

            If Me.湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                Return result
            End If

            result.Columns.Add("タイプ連番", GetType(Short))
            result.Columns.Add("年月日", GetType(Date))
            result.Columns.Add("食事連番", GetType(Short))
            result.Columns.Add("食事CD", GetType(String))

            Dim ddl As Template.DropDownList
            Dim lbl As Template.Label

            For i As Integer = 0 To Me.宿泊数 - 1
                Dim row As GridViewRow = Me.gv食事.Rows(i)
                Dim 食事連番 As Integer = 1

                ddl = CType(row.FindControl("ddl朝食"), Template.DropDownList)
                lbl = CType(row.FindControl("lbl朝食"), Template.Label)

                If ddl.Visible OrElse (lbl.Visible AndAlso Not lbl.Text.Equals("-")) Then
                    Dim newRow As DataRow = result.NewRow()
                    newRow("タイプ連番") = 1
                    newRow("年月日") = Me.到着日.AddDays(i)
                    newRow("食事連番") = 食事連番
                    newRow("食事CD") = ddl.SelectedValue
                    result.Rows.Add(newRow)
                    食事連番 += 1
                End If

                ddl = CType(row.FindControl("ddl夕食"), Template.DropDownList)
                lbl = CType(row.FindControl("lbl夕食"), Template.Label)

                If ddl.Visible OrElse (lbl.Visible AndAlso Not lbl.Text.Equals("-")) Then
                    Dim newRow As DataRow = result.NewRow()
                    newRow("タイプ連番") = 1
                    newRow("年月日") = Me.到着日.AddDays(i)
                    newRow("食事連番") = 食事連番
                    newRow("食事CD") = ddl.SelectedValue
                    result.Rows.Add(newRow)
                End If

            Next

            Return result
        End Function

    End Class

End NameSpace
