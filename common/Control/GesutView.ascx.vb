Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class GesutView
        Inherits System.Web.UI.UserControl

        Private _タイプ連番 As Short

#Region "プロパティ"

        Private _予約基本情報   As DataRow
        Private _会員情報       As DataRow
        Private _予約タイプ情報 As DataTable
        Private _予約氏名情報   As DataTable

        Private _最終チェックイン時刻 As String

        Private _会員処理区分 As String

        Private _txt電話番号 As String

        ''' <summary>
        ''' 予約基本情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約基本情報() As DataRow
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
        Public WriteOnly Property 予約氏名情報() As DataTable
            Set
                _予約氏名情報 = Value
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
        Public WriteOnly Property 会員処理区分() As String
            Set
                _会員処理区分 = Value
            End Set
        End Property

#End Region

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

                Dim cnt As Integer = 0
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    '湯めぐりの場合、全氏名情報を表示
                    Dim nameRows As DataRow() = CType(_予約氏名情報.Select("タイプ連番=" & _予約タイプ情報.Rows(0)("タイプ連番")), DataRow())
                    cnt = nameRows.Length
                Else
                    cnt = CInt(_予約タイプ情報.Rows(0)("人数合計"))
                End If

                Dim list As New List(Of String)
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    list.Add("宿泊代表者")
                Else
                    list.Add("宿泊者1")
                End If
                For i As Integer = 1 To cnt - 1
                    list.Add((i + 1).ToString())
                Next
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    _txt電話番号 = "宿泊者電話番号"
                Else
                    _txt電話番号 = "宿泊者連絡先"
                End If
                list.Add(_txt電話番号)
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

                If value.Equals("宿泊者1") OrElse value.Equals("宿泊代表者") Then
                    CType(e.Row.FindControl("pnl宿泊者1"), Template.Panel).Visible = True
                    row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", CShort(1), CShort(1))
                    If row Is Nothing Then Return
                    CType(e.Row.FindControl("lbl姓名宿泊者1"), Template.Label).Text = row("氏名全角漢字姓名").ToString()
                    CType(e.Row.FindControl("lblセイ宿泊者1"), Template.Label).Text = row("氏名全角かな姓")
                    CType(e.Row.FindControl("lblメイ宿泊者1"), Template.Label).Text = row("氏名全角かな名")

                    CType(e.Row.FindControl("lbl性別宿泊者1"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_性別区分, row("性別区分"))
                    CType(e.Row.FindControl("lbl続柄宿泊者1"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_続柄区分, row("続柄区分"))

                    CType(e.Row.FindControl("lbl会社名漢字"), Template.Label).Text = _予約基本情報("会社名漢字")
                    CType(e.Row.FindControl("lbl会社名カナ"), Template.Label).Text = _予約基本情報("会社名カナ")

                    CType(e.Row.FindControl("lbl会社名漢字"), Template.Label).Visible = Not String.IsNullOrEmpty(_予約基本情報("会社名漢字"))
                    CType(e.Row.FindControl("lbl会社名カナ"), Template.Label).Visible = Not String.IsNullOrEmpty(_予約基本情報("会社名カナ"))

                    If CType(e.Row.FindControl("lbl会社名漢字"), Template.Label).Visible AndAlso CType(e.Row.FindControl("lbl会社名カナ"), Template.Label).Visible Then
                        CType(e.Row.FindControl("lbl会社名カナ"), Template.Label).Text = "（" & CType(e.Row.FindControl("lbl会社名カナ"), Template.Label).Text & "）"
                    End If

                    Return
                End If

                If value.Equals(_txt電話番号) Then
                    CType(e.Row.FindControl("pnl連絡先"), Template.Panel).Visible = True
                    CType(e.Row.FindControl("lbl連絡先"), Template.Label).Text = _予約基本情報("連絡先電話番号")
                    Return
                End If

                If value.Equals("チェックイン時刻") Then
                    CType(e.Row.FindControl("pnl時刻"), Template.Panel).Visible = True
                    If Val(CDate(_予約基本情報("到着時間")).ToString("HH")) <= 12 AndAlso Val(Left(_最終チェックイン時刻, 2)) >= 24 Then
                        Dim h As Short = Val(CDate(_予約基本情報("到着時間")).ToString("HH")) + 24
                        Dim m As Short = Val(CDate(_予約基本情報("到着時間")).ToString("mm"))
                        CType(e.Row.FindControl("lblチェックイン時刻"), Template.Label).Text = h.ToString("00") & ":" & m.ToString("00")
                    Else
                        CType(e.Row.FindControl("lblチェックイン時刻"), Template.Label).Text = CDate(_予約基本情報("到着時間")).ToString("HH:mm")
                    End If
                    CType(e.Row.FindControl("lbl最終チェックイン時刻"), Template.Label).Text = _最終チェックイン時刻
                    Return
                End If

                row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", CShort(1), CShort(value))
                If row Is Nothing Then
                    e.Row.Visible = False
                    Return
                End If

                CType(e.Row.FindControl("pnl宿泊者"), Template.Panel).Visible = True
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = "宿泊者" & value

                CType(e.Row.FindControl("lblセイ宿泊者"), Template.Label).Text = row("氏名全角かな姓")
                CType(e.Row.FindControl("lblメイ宿泊者"), Template.Label).Text = row("氏名全角かな名")
                CType(e.Row.FindControl("lbl性別宿泊者"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_性別区分, row("性別区分"))
                CType(e.Row.FindControl("lbl続柄宿泊者"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_続柄区分, row("続柄区分"))

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

                _タイプ連番 = CShort(row("タイプ連番"))
                Dim cnt As Integer = 0
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    '湯めぐりの場合、全氏名情報を表示
                    Dim nameRows As DataRow() = CType(_予約氏名情報.Select("タイプ連番=" & _タイプ連番), DataRow())
                    cnt = nameRows.Length
                Else
                    cnt = CInt(row("人数合計"))
                End If

                Dim list As New List(Of String)
                list.Add("宿泊者1")
                For i As Integer = 1 To cnt - 1
                    list.Add((i + 1).ToString())
                Next

                Dim gv As Template.GridView = CType(e.Row.FindControl("gv宿泊者情報"), Template.GridView)
                gv.DataSource = list
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
                    CType(e.Row.FindControl("lblセイ宿泊者1"), Template.Label).Text = row("氏名全角かな姓")
                    CType(e.Row.FindControl("lblメイ宿泊者1"), Template.Label).Text = row("氏名全角かな名")
                    CType(e.Row.FindControl("lbl性別宿泊者1"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_性別区分, row("性別区分"))
                    CType(e.Row.FindControl("lbl続柄宿泊者1"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_続柄区分, row("続柄区分"))
                    Return
                End If

                row = CType(Me.Page, BasePage).Find(_予約氏名情報, "タイプ連番", "氏名連番", _タイプ連番, CShort(value))
                If row Is Nothing Then
                    e.Row.Visible = False
                    Return
                End If

                CType(e.Row.FindControl("pnl宿泊者"), Template.Panel).Visible = True
                CType(e.Row.FindControl("lblタイトル"), Template.Label).Text = "宿泊者" & value

                CType(e.Row.FindControl("lblセイ宿泊者"), Template.Label).Text = row("氏名全角かな姓")
                CType(e.Row.FindControl("lblメイ宿泊者"), Template.Label).Text = row("氏名全角かな名")
                CType(e.Row.FindControl("lbl性別宿泊者"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_性別区分, row("性別区分"))
                CType(e.Row.FindControl("lbl続柄宿泊者"), Template.Label).Text = CodeCatalog.GetGuide(CodeCatalog.KEY_続柄区分, row("続柄区分"))

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
