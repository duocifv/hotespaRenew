Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    ''' <summary>
    ''' 宿泊者情報コントロール
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class GesutInfo_Yumeguri
        Inherits System.Web.UI.UserControl

        'ReservationBFに同様の定数を設定
        Private Const 会員処理区分_更新 As String = "1"
        Private Const 会員処理区分_なし As String = "2"
        Private Const 会員処理区分_削除 As String = "3"

#Region "プロパティ"

        Private _予約基本情報   As DataRow
        Private _会員情報       As DataRow
        Private _予約タイプ情報 As DataTable
        Private _予約氏名情報   As DataTable

        Private _isEdit As Boolean = True

        Private _連絡先     As String
        Private _会社名漢字 As String
        Private _会社名カナ As String

        Private _到着時間 As Date
        Private _チェックイン時刻 As String
        Private _最終チェックイン時刻 As String

        Private _会員処理区分 As String

        Private _タイプ連番 As Short

        ''' <summary>
        ''' 予約基本情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 予約基本情報() As DataRow
            Get
                Return Me.Get予約基本情報()
            End Get
            Set
                _予約基本情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 会員情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 会員情報() As DataRow
            Set
                _会員情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約タイプ情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約タイプ情報() As DataTable
            Set
                _予約タイプ情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約氏名情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 予約氏名情報() As DataTable
            Get
                Return Me.Get予約氏名情報()
            End Get
            Set
                _予約氏名情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' チェックイン時刻を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property チェックイン時刻() As String
            Set
                _チェックイン時刻 = Value
            End Set
        End Property

        ''' <summary>
        ''' 最終チェックイン時刻を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 最終チェックイン時刻() As String
            Set
                _最終チェックイン時刻 = Value
            End Set
        End Property

        ''' <summary>
        ''' 会員処理区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 会員処理区分() As String
            Get
                For Each row As GridViewRow In Me.gv1室目.Rows
                    If Not CType(row.FindControl("pnl宿泊者1"), Template.Panel).Visible Then Continue For
                    Select Case True
                        Case CType(row.FindControl("rdo次回利用"), Template.RadioButton).Checked
                            Return 会員処理区分_更新
                        Case CType(row.FindControl("rdo利用しない"), Template.RadioButton).Checked
                            Return 会員処理区分_削除
                        Case Else
                            Return 会員処理区分_なし
                    End Select
                Next
                Return 会員処理区分_なし
            End Get
            Set
                _会員処理区分 = Value
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

            '必須の検証を行ないます。
            For Each row As DataRow In _予約タイプ情報.Rows
                Dim タイプ As Integer = Convert.ToInt32(row("タイプ連番"))
                Dim 人数   As Integer = Convert.ToInt32(row("人数合計"))

                For i As Integer = 0 To 人数 - 1

                    Dim gvRow As GridViewRow
                    If タイプ = 1 Then
                        gvRow = Me.gv1室目.Rows(i)
                    Else
                        gvRow = CType(Me.gv2室目以降.Rows(タイプ - 2).FindControl("gv宿泊者情報"), Template.GridView).Rows(i)
                    End If

                    '省略の場合、次の行を処理します。
                    If CType(gvRow.FindControl("chk省略"), Template.CheckBox).Checked Then Continue For

                    If i = 0 Then
                        If CType(gvRow.FindControl("txtセイ宿泊者1"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", タイプ & "室目の宿泊者1のセイ"))
                        End If
                        If CType(gvRow.FindControl("txtメイ宿泊者1"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", タイプ & "室目の宿泊者1のメイ"))
                        End If

                        If Not CType(gvRow.FindControl("rdo男性宿泊者1"), Template.RadioButton).Checked And _
                           Not CType(gvRow.FindControl("rdo女性宿泊者1"), Template.RadioButton).Checked Then
                            msg.Add(Messages.GetMessage("E014", タイプ & "室目の宿泊者1の性別"))
                        End If
                    Else
                        If CType(gvRow.FindControl("txtセイ宿泊者"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", タイプ & "室目の宿泊者" & i + 1 & "のセイ"))
                        End If
                        If CType(gvRow.FindControl("txtメイ宿泊者"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", タイプ & "室目の宿泊者" & i + 1 & "のメイ"))
                        End If

                        If Not CType(gvRow.FindControl("rdo男性宿泊者"), Template.RadioButton).Checked And _
                           Not CType(gvRow.FindControl("rdo女性宿泊者"), Template.RadioButton).Checked Then
                            msg.Add(Messages.GetMessage("E014", タイプ & "室目の宿泊者" & i + 1 & "の性別"))
                        End If

                    End If

                    If タイプ = 1 AndAlso i = 0 Then
                        If CType(gvRow.FindControl("txt姓宿泊者1"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", "1室目の宿泊者1の姓"))
                        End If
                        If CType(gvRow.FindControl("txt名宿泊者1"), Template.TextBox).Text.Length <= 0 Then
                            msg.Add(Messages.GetMessage("E001", "1室目の宿泊者1の名"))
                        End If
                    End If
                Next
            Next
            'If CType(Me.gv1室目.Rows(0).FindControl("txt会社名漢字"), Template.TextBox).Text.Length <= 0 Then
            '    msg.Add(Messages.GetMessage("E001", "宿泊者1の会社名・団体名（全角漢字）"))
            'End If
            'If CType(Me.gv1室目.Rows(0).FindControl("txt会社名カナ"), Template.TextBox).Text.Length <= 0 Then
            '    msg.Add(Messages.GetMessage("E001", "宿泊者1の会社名・団体名（全角フリガナ）"))
            'End If

            For Each row As GridViewRow In Me.gv1室目.Rows
                If CType(row.FindControl("pnl宿泊者1"), Template.Panel).Visible Then
                    If Not CType(row.FindControl("rdo次回利用"), Template.RadioButton).Checked AndAlso _
                       Not CType(row.FindControl("rdo今回のみ"), Template.RadioButton).Checked AndAlso _
                       Not CType(row.FindControl("rdo利用しない"), Template.RadioButton).Checked Then
                        msg.Add(Messages.GetMessage("E014", "宿泊者1の今回の宿泊者情報について"))
                    End If
                Else If CType(row.FindControl("pnl連絡先"), Template.Panel).Visible Then
                    If CType(row.FindControl("txt連絡先"), Template.TextBox).Text.Length <= 0 Then
                        msg.Add(Messages.GetMessage("E001", "宿泊者連絡先"))
                    Else If Not CheckValueUtility.IsValidStr(CType(row.FindControl("txt連絡先"), Template.TextBox).Text, CheckValueUtility.IsValidFormat.半角数字, False, "-") Then
                        msg.Add(Messages.GetMessage("E002", "宿泊者連絡先", "半角数字と""-"""))
                    End If
                Else If CType(row.FindControl("pnl時刻"), Template.Panel).Visible Then
                    If CType(row.FindControl("ddlチェックイン時刻"), Template.DropDownList).SelectedIndex <= 0 Then
                        msg.Add(Messages.GetMessage("E014", "チェックイン時刻"))
                    End If
                End If
            Next

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
                If _予約タイプ情報 Is Nothing Then Return

                Me.Set予約氏名情報()

                Dim cnt As Integer = CInt(_予約タイプ情報.Rows(0)("人数合計"))
                Dim list As New List(Of String)
                list.Add("宿泊者1")
                For i As Integer = 1 To cnt - 1
                    list.Add((i + 1).ToString())
                Next
                list.Add("宿泊者連絡先")
                list.Add("チェックイン時刻")

                Me.gv1室目.DataSource = list
                Me.gv1室目.DataBind()

                If _予約タイプ情報.Rows.Count > 1 Then
                    Dim copyTable As DataTable = _予約タイプ情報.Copy()
                    copyTable.Rows.RemoveAt(0)
                    Me.gv2室目以降.DataSource = copyTable
                    Me.gv2室目以降.DataBind()
                End If

                Me.lbl会員氏名.Text     = _会員情報("名前漢字")
                Me.lbl会員郵便番号.Text = _会員情報("郵便番号").ToString().Substring(0, 3) & "-" & _会員情報("郵便番号").ToString().Substring(3)
                Me.lbl会員住所.Text     = _会員情報("住所1") & _会員情報("住所2")
                Me.lbl会員勤務先.Text   = _会員情報("会社名漢字")

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
        Protected Sub gv1室目_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv1室目.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then
                    e.Row.Cells(0).ColumnSpan = 2
                    e.Row.Cells(1).Visible = False
                    Return
                End If

                Dim value As String = e.Row.DataItem.ToString()
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = value

                Dim row As DataRow

                If value.Equals("宿泊者1") Then
                    CType(e.Row.FindControl("pnl宿泊者1"), Template.Panel).Visible = True
                    row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", CShort(1), CShort(1))
                    If row Is Nothing Then Return
                    Dim name() As String = row("氏名全角漢字姓名").ToString().Split(New String(){" ", "　"}, StringSplitOptions.None)
                    CType(e.Row.FindControl("txt姓宿泊者1"), Template.TextBox).Text = name(0)
                    CType(e.Row.FindControl("txt名宿泊者1"), Template.TextBox).Text = name(1)
                    CType(e.Row.FindControl("txtセイ宿泊者1"), Template.TextBox).Text = row("氏名全角かな姓")
                    CType(e.Row.FindControl("txtメイ宿泊者1"), Template.TextBox).Text = row("氏名全角かな名")

                    CType(e.Row.FindControl("rdo男性宿泊者1"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_男)
                    CType(e.Row.FindControl("rdo女性宿泊者1"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_女)

                    CType(e.Row.FindControl("txt会社名漢字"), Template.TextBox).Text = _会社名漢字
                    CType(e.Row.FindControl("txt会社名カナ"), Template.TextBox).Text = _会社名カナ

                    CType(e.Row.FindControl("rdo次回利用"  ), Template.RadioButton).Checked = 会員処理区分_更新.Equals(_会員処理区分)
                    CType(e.Row.FindControl("rdo今回のみ"  ), Template.RadioButton).Checked = 会員処理区分_なし.Equals(_会員処理区分)
                    CType(e.Row.FindControl("rdo利用しない"), Template.RadioButton).Checked = 会員処理区分_削除.Equals(_会員処理区分)
                    Return
                End If

                If value.Equals("宿泊者連絡先") Then
                    CType(e.Row.FindControl("pnl連絡先"), Template.Panel).Visible = True
                    CType(e.Row.FindControl("txt連絡先"), Template.TextBox).Text = _連絡先
                    Return
                End If

                If value.Equals("チェックイン時刻") Then
                    CType(e.Row.FindControl("pnl時刻"), Template.Panel).Visible = True
                    CType(Me.Page, BasePage).SetDDLTime(CType(e.Row.FindControl("ddlチェックイン時刻"), Template.DropDownList), _チェックイン時刻, _最終チェックイン時刻)
                    CType(Me.Page, BasePage).AddDDLDataTable(CType(e.Row.FindControl("ddlチェックイン時刻"), Template.DropDownList), 0, String.Empty, "お選びください")
                    CType(e.Row.FindControl("ddlチェックイン時刻"), Template.DropDownList).Items.RemoveAt(CType(e.Row.FindControl("ddlチェックイン時刻"), Template.DropDownList).Items.Count - 1)

                    CType(e.Row.FindControl("ddlチェックイン時刻"), Template.DropDownList).SelectedValue = _到着時間.ToString("HH:mm")
                    CType(e.Row.FindControl("lbl最終チェックイン時刻"), Template.Label).Text = _最終チェックイン時刻
                    Return
                End If

                CType(e.Row.FindControl("pnl宿泊者"), Template.Panel).Visible = True
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = "宿泊者" & value

                CType(e.Row.FindControl("chk省略"), Template.CheckBox).Attributes.Add("onclick", Me.GetCheckClickScript( _
                    CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).ClientID, _
                    CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).ClientID, _
                    CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).ClientID, _
                    CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).ClientID))

                row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", CShort(1), CShort(value))
                If row Is Nothing Then
                    CType(e.Row.FindControl("chk省略"), Template.CheckBox).Checked = _isEdit
                    CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).Enabled = Not _isEdit
                    CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).Enabled = Not _isEdit
                    CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).Enabled = Not _isEdit
                    CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).Enabled = Not _isEdit
                    Return
                End If
                CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).Text = row("氏名全角かな姓")
                CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).Text = row("氏名全角かな名")
                CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_男)
                CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_女)

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
        Protected Sub gv2室目以降_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv2室目以降.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                Dim row As DataRowView = CType(e.Row.DataItem, DataRowView)

                Dim cnt As Integer = CInt(row("人数合計"))
                Dim list As New List(Of String)
                list.Add("宿泊者1")
                For i As Integer = 1 To cnt - 1
                    list.Add((i + 1).ToString())
                Next

                Dim gv As Template.GridView = CType(e.Row.FindControl("gv宿泊者情報"), Template.GridView)
                gv.DataSource = list
                _タイプ連番 = CShort(row("タイプ連番"))
                gv.Columns(0).HeaderText = row("タイプ連番") & "室目"
                gv.DataBind()

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
        Protected Sub gv宿泊者情報_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then
                    e.Row.Cells(0).ColumnSpan = 2
                    e.Row.Cells(1).Visible = False
                    Return
                End If

                Dim value As String = e.Row.DataItem.ToString()
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = value

                Dim row As DataRow

                If value.Equals("宿泊者1") Then
                    CType(e.Row.FindControl("pnl宿泊者1"), Template.Panel).Visible = True
                    row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", _タイプ連番, CShort(1))
                    If row Is Nothing Then Return
                    CType(e.Row.FindControl("txtセイ宿泊者1"), Template.TextBox).Text = row("氏名全角かな姓")
                    CType(e.Row.FindControl("txtメイ宿泊者1"), Template.TextBox).Text = row("氏名全角かな名")
                    CType(e.Row.FindControl("rdo男性宿泊者1"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_男)
                    CType(e.Row.FindControl("rdo女性宿泊者1"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_女)
                    Return
                End If

                CType(e.Row.FindControl("pnl宿泊者"), Template.Panel).Visible = True
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = "宿泊者" & value

                CType(e.Row.FindControl("chk省略"), Template.CheckBox).Attributes.Add("onclick", Me.GetCheckClickScript( _
                    CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).ClientID, _
                    CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).ClientID, _
                    CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).ClientID, _
                    CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).ClientID))

                row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", _タイプ連番, CShort(value))
                If row Is Nothing Then
                    CType(e.Row.FindControl("chk省略"), Template.CheckBox).Checked = _isEdit
                    CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).Enabled = Not _isEdit
                    CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).Enabled = Not _isEdit
                    CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).Enabled = Not _isEdit
                    CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).Enabled = Not _isEdit
                    Return
                End If
                CType(e.Row.FindControl("txtセイ宿泊者"), Template.TextBox).Text = row("氏名全角かな姓")
                CType(e.Row.FindControl("txtメイ宿泊者"), Template.TextBox).Text = row("氏名全角かな名")
                CType(e.Row.FindControl("rdo男性宿泊者"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_男)
                CType(e.Row.FindControl("rdo女性宿泊者"), Template.RadioButton).Checked = row("性別区分").Equals(CodeConst.C_性別区分_女)

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 予約氏名情報を設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Set予約氏名情報()

            If _予約氏名情報 IsNot Nothing AndAlso _予約氏名情報.Rows.Count > 0 Then
                _連絡先     = _予約基本情報("連絡先電話番号")
                _会社名漢字 = _予約基本情報("会社名漢字")
                _会社名カナ = _予約基本情報("会社名カナ")
                _到着時間 = _予約基本情報("到着時間")
                Return
            End If

            _isEdit = False

            Dim result As New DataTable
            result.Columns.Add("タイプ連番"      , GetType(Short))
            result.Columns.Add("氏名連番"        , GetType(Short))
            result.Columns.Add("氏名全角かな姓"  , GetType(String))
            result.Columns.Add("氏名全角かな名"  , GetType(String))
            result.Columns.Add("氏名全角漢字姓名", GetType(String))
            result.Columns.Add("性別区分"        , GetType(String))

            Dim newRow As DataRow = result.NewRow()
            newRow("タイプ連番") = 1
            newRow("氏名連番")   = 1

            If _会員情報("宿泊者性別区分").ToString().Length <= 0 Then
                newRow("性別区分") = _会員情報("性別区分")
                newRow("氏名全角かな姓") = _会員情報("名前カナ姓")
                newRow("氏名全角かな名") = _会員情報("名前カナ名")
                newRow("氏名全角漢字姓名") = _会員情報("名前漢字姓") & " " & _会員情報("名前漢字名")

                _連絡先     = _会員情報("電話番号")
                _会社名漢字 = _会員情報("会社名漢字")
                _会社名カナ = _会員情報("会社名カナ")
            Else
                newRow("性別区分") = _会員情報("宿泊者性別区分")
                newRow("氏名全角かな姓") = _会員情報("宿泊者名称カナ姓")
                newRow("氏名全角かな名") = _会員情報("宿泊者名称カナ名")
                newRow("氏名全角漢字姓名") = _会員情報("宿泊者名称漢字姓") & " " & _会員情報("宿泊者名称漢字名")

                _連絡先     = _会員情報("宿泊者電話番号")
                _会社名漢字 = _会員情報("宿泊者会社名漢字")
                _会社名カナ = _会員情報("宿泊者会社名カナ")
                _到着時間 = _会員情報("宿泊者到着時間")
            End If

            result.Rows.Add(newRow)
            _予約氏名情報 = result

            Return
        End Sub

        ''' <summary>
        ''' 予約氏名情報を取得します。
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get予約氏名情報() As DataTable

            Dim result As New DataTable
            result.Columns.Add("タイプ連番"      , GetType(Short))
            result.Columns.Add("氏名連番"        , GetType(Short))
            result.Columns.Add("氏名全角かな姓"  , GetType(String))
            result.Columns.Add("氏名全角かな名"  , GetType(String))
            result.Columns.Add("氏名全角漢字姓名", GetType(String))
            result.Columns.Add("性別区分"        , GetType(String))

            For Each row As DataRow In _予約タイプ情報.Rows
                Dim タイプ As Integer = Convert.ToInt32(row("タイプ連番"))
                Dim 人数   As Integer = Convert.ToInt32(row("人数合計"))

                For i As Integer = 0 To 人数 - 1

                    Dim gvRow As GridViewRow

                    If タイプ = 1 Then
                        gvRow = Me.gv1室目.Rows(i)
                    Else
                        gvRow = CType(Me.gv2室目以降.Rows(タイプ - 2).FindControl("gv宿泊者情報"), Template.GridView).Rows(i)
                    End If

                    '省略の場合、次の行を処理します。
                    If CType(gvRow.FindControl("chk省略"), Template.CheckBox).Checked Then Continue For

                    Dim newRow As DataRow = result.NewRow()

                    newRow("タイプ連番") = タイプ
                    newRow("氏名連番"  ) = (i + 1)

                    If i = 0 Then
                        newRow("氏名全角かな姓") = CType(gvRow.FindControl("txtセイ宿泊者1"), Template.TextBox).Text
                        newRow("氏名全角かな名") = CType(gvRow.FindControl("txtメイ宿泊者1"), Template.TextBox).Text
                        If CType(gvRow.FindControl("rdo男性宿泊者1"), Template.RadioButton).Checked Then
                            newRow("性別区分") = CodeConst.C_性別区分_男
                        Else
                            newRow("性別区分") = CodeConst.C_性別区分_女
                        End If
                    Else
                        newRow("氏名全角かな姓") = CType(gvRow.FindControl("txtセイ宿泊者"), Template.TextBox).Text
                        newRow("氏名全角かな名") = CType(gvRow.FindControl("txtメイ宿泊者"), Template.TextBox).Text
                        If CType(gvRow.FindControl("rdo男性宿泊者"), Template.RadioButton).Checked Then
                            newRow("性別区分") = CodeConst.C_性別区分_男
                        Else
                            newRow("性別区分") = CodeConst.C_性別区分_女
                        End If
                    End If

                    If タイプ = 1 AndAlso i = 0 Then
                        newRow("氏名全角漢字姓名") = CType(gvRow.FindControl("txt姓宿泊者1"), Template.TextBox).Text & " " & CType(gvRow.FindControl("txt名宿泊者1"), Template.TextBox).Text
                    Else
                        newRow("氏名全角漢字姓名") = newRow("氏名全角かな姓") & " " & newRow("氏名全角かな名")
                    End If

                    result.Rows.Add(newRow)
                Next
            Next

            Return result
        End Function

        ''' <summary>
        ''' 予約基本情報を取得します。
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get予約基本情報() As DataRow

            Dim table As New DataTable
            table.Columns.Add("連絡先電話番号", GetType(String))
            table.Columns.Add("会社名カナ"    , GetType(String))
            table.Columns.Add("会社名漢字"    , GetType(String))
            table.Columns.Add("到着時間"      , GetType(Date))

            Dim result As DataRow = table.NewRow()

            result("会社名漢字") = CType(Me.gv1室目.Rows(0).FindControl("txt会社名漢字"), Template.TextBox).Text
            result("会社名カナ") = CType(Me.gv1室目.Rows(0).FindControl("txt会社名カナ"), Template.TextBox).Text

            For Each row As GridViewRow In Me.gv1室目.Rows
                If CType(row.FindControl("pnl連絡先"), Template.Panel).Visible Then
                    result("連絡先電話番号") = CType(row.FindControl("txt連絡先"), Template.TextBox).Text
                Else If CType(row.FindControl("pnl時刻"), Template.Panel).Visible Then
                    result("到着時間") = Date.ParseExact(CType(row.FindControl("ddlチェックイン時刻"), Template.DropDownList).SelectedValue, "HH:mm", Nothing)
                End If
            Next

            Return result
        End Function

        ''' <summary>
        ''' チェックボックスクリック時のスクリプトを取得します。
        ''' </summary>
        ''' <param name="names"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetCheckClickScript(ByVal ParamArray names() As String) As String
            Dim result As New StringBuilder

            For Each name As String In names
                result.Append(name).Append(".disabled=this.checked;")
            Next

            Return result.ToString()
        End Function

    End Class

End NameSpace
