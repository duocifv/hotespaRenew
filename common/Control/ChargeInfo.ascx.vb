Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    ''' <summary>
    ''' 料金情報を入力するコントロール
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class ChargeInfo
        Inherits System.Web.UI.UserControl

#Region "プロパティ"

        Private _isReadOnly As Boolean = False
        Private _到着日 As Date
        Private _宿泊数 As Integer
        Private _部屋数 As Integer

        Private _利用可能ポイント As Integer
        Private _発生ポイント As Integer
        Private _ポイント使用単位 As Integer
        Private _ポイント使用最小値 As Integer
        Private _法人区分 As String
        Private _ポイント利用可否区分 As String
        Private _国区分 As String

        Private _予約基本情報 As DataRow
        Private _予約料金情報 As DataTable
        Private _予約選択料理 As DataTable

        ''' <summary>
        ''' 読取専用かどうかを示す値を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Category("その他")> _
        <System.ComponentModel.Description("読取専用かどうかを示す値を取得または設定します。")> _
        <System.ComponentModel.DefaultValue(False)> _
        Public Property IsReadOnly() As Boolean
            Get
                Return _isReadOnly
            End Get
            Set
                _isReadOnly = Value
            End Set
        End Property

        ''' <summary>
        ''' 利用ポイントを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public ReadOnly Property 利用ポイント() As Integer
            Get
                Return Convert.ToInt32(Me.txt利用ポイント.Text)
            End Get
        End Property

        ''' <summary>
        ''' 利用可能ポイントを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 利用可能ポイント() As Integer
            Set
                _利用可能ポイント = Value
            End Set
        End Property

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
        ''' 予約料金情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約料金情報() As DataTable
            Set
                _予約料金情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約選択料理を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約選択料理() As DataTable
            Set
                _予約選択料理 = Value
            End Set
        End Property

        ''' <summary>
        ''' 到着日を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 到着日() As Date
            Set
                _到着日 = Value
            End Set
        End Property

        ''' <summary>
        ''' 宿泊数を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 宿泊数() As Integer
            Set
                _宿泊数 = Value
                If Value <= 0 Then _宿泊数 = 1
            End Set
        End Property

        ''' <summary>
        ''' 部屋数を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 部屋数() As Integer
            Set
                _部屋数 = Value
            End Set
        End Property

        ''' <summary>
        ''' 発生ポイントを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 発生ポイント() As Integer
            Set
                _発生ポイント = Value
            End Set
        End Property

        ''' <summary>
        ''' ポイント単位を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property ポイント使用単位() As Integer
            Set(ByVal value As Integer)
                _ポイント使用単位 = value
            End Set
        End Property

        ''' <summary>
        ''' ポイント最小値を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property ポイント使用最小値() As Integer
            Set(ByVal value As Integer)
                _ポイント使用最小値 = value
            End Set
        End Property

        ''' <summary>
        ''' 法人区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 法人区分() As String
            Set(ByVal value As String)
                _法人区分 = value
            End Set
        End Property

        ''' <summary>
        ''' ポイント利用可否区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property ポイント利用可否区分() As String
            Set(ByVal value As String)
                _ポイント利用可否区分 = value
            End Set
        End Property

        ''' <summary>
        ''' 国区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 国区分() As String
            Set(ByVal value As String)
                _国区分 = value
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
            If String.IsNullOrEmpty(Me.txt利用ポイント.Text) Then
                msg.Add(Messages.GetMessage("E001", Me.txt利用ポイント.DisplayName))
                Return False
            End If

            '型の検証を行ないます。
            If Not CheckValueUtility.IsValidStr(Me.txt利用ポイント.Text, CheckValueUtility.IsValidFormat.半角数字, False) Then
                msg.Add(Messages.GetMessage("E002", Me.txt利用ポイント.DisplayName, "半角数字"))
                Return False
            End If

            '値の検証を行ないます。
            Dim 利用可能 As Integer = CInt(Me.lbl利用可能ポイント.Text.Replace(",", String.Empty))
            If 利用可能 < CInt(Me.txt利用ポイント.Text) Then
                msg.Add(Messages.GetMessage("E002", Me.txt利用ポイント.DisplayName, "ご利用可能ポイント内"))
                Return False
            End If

            Return True
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

                Dim 通貨単位 As String = BizUtility.GetCurrencySign(_国区分)

                If _予約基本情報 IsNot Nothing Then
                    Me.lbl合計料金.Text = CType(_予約基本情報("合計料金"), Decimal).ToString("#,##0") & 通貨単位
                    Me.lbl最終料金.Text = (CType(_予約基本情報("合計料金"), Decimal) - CType(_予約基本情報("利用ポイント金額"), Decimal)).ToString("#,##0") & 通貨単位
                    Me.lbl利用可能ポイント.Text = _利用可能ポイント.ToString("#,##0")
                    Me.lbl利用ポイント.Text = CType(_予約基本情報("利用ポイント数"), Decimal).ToString("#,##0")
                    Me.txt利用ポイント.Text = CType(_予約基本情報("利用ポイント数"), Decimal).ToString()
                    Me.lbl付与ポイント.Text = _発生ポイント.ToString("#,##0")
                    'ポイント備考に表示する内容を編集します。
                    Dim ポイント備考 As String = String.Empty
                    If _ポイント使用最小値 > 0 AndAlso _ポイント使用単位 > 0 Then
                        ポイント備考 = Messages.GetMessage("E002", "利用ポイント数", _ポイント使用最小値.ToString() & "ポイント以上、" & _ポイント使用単位.ToString() & "ポイント単位")
                    Else
                        If _ポイント使用最小値 > 0 Then
                            ポイント備考 = Messages.GetMessage("E002", "利用ポイント数", _ポイント使用最小値.ToString() & "ポイント以上")
                        End If
                        If _ポイント使用単位 > 0 Then
                            ポイント備考 = Messages.GetMessage("E002", "利用ポイント数", _ポイント使用単位.ToString() & "ポイント単位")
                        End If
                    End If
                    Me.lblポイント備考.Text = ポイント備考
                End If

                Dim 割引金額 As Decimal = 0
                If _予約料金情報.Columns.Contains("割引金額") Then
                    For Each row As DataRow In _予約料金情報.Rows
                        割引金額 += row.Item("割引金額")
                    Next
                End If

                Me.lbl割引金額.Visible = False
                If 割引金額 <> 0 Then
                    Me.lbl割引金額.Visible = True
                    Me.lbl割引金額.Text = "割引：" & 割引金額.ToString("#,##0") & 通貨単位
                End If

                Me.gv宿泊料金.DataSource = _予約料金情報
                Me.gv宿泊料金.DataBind()

                For i As Integer = 0 To Me.gv宿泊料金.Rows.Count - 1
                    Me.gv宿泊料金.Rows(i).Cells(0).RowSpan = _部屋数
                    For j As Integer = i + 1 To (i + _部屋数 - 1)
                        Me.gv宿泊料金.Rows(j).Cells(0).Visible = False
                    Next
                    i += _部屋数 - 1
                Next

                Dim list As New List(Of Date)
                For i As Integer = 0 To _宿泊数 - 1
                    list.Add(_到着日.AddDays(i))
                Next

                '湯めぐり倶楽部区分によりセレクト食事の表示を切り替えます。
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    Me.gv食事料金.Visible = False
                Else
                    Me.gv食事料金.DataSource = list
                    Me.gv食事料金.DataBind()
                End If

                '湯めぐり倶楽部区分によりポイントの表示を切り替えます。
                If _予約基本情報("湯めぐり倶楽部区分").ToString = CodeConst.C_対象区分_対象 Then
                    Me.pnl入力.Visible = False
                    Me.pnl表示.Visible = False
                Else
                    'ポイントの表示を制御します
                    Me.pnl入力.Visible = Not _isReadOnly
                    Me.pnl表示.Visible = _isReadOnly

                    If Not _isReadOnly Then
                        Me.txt利用ポイント.MaxLength = Me.lbl利用可能ポイント.Text.Replace(",", String.Empty).Length
                        Me.txt利用ポイント.CssClass = Me.txt利用ポイント.CssClass & " point"
                    End If
                End If

                '法人の場合、利用可否区分を判断します。
                If Not String.IsNullOrEmpty(CType(Me.Page, BasePage).LoginInfo.法人ID) AndAlso _
                   CType(Me.Page, BasePage).LoginInfo.法人ポイント利用可否区分.Equals(CodeConst.C_可否区分_否) Then
                    Me.pnl入力.Visible = False
                    Me.pnl表示.Visible = False
                End If

                '施設マスタのポイント利用可否区分を判断します。
                If _ポイント利用可否区分.Equals(CodeConst.C_可否区分_否) Then
                    Me.pnl入力.Visible = False
                    Me.pnl表示.Visible = False
                End If

                '法人限定プランの場合、ポイント利用不可とします。
                If _法人区分 <> String.Empty Then
                    Me.pnl入力.Visible = False
                    Me.pnl表示.Visible = False
                End If

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
        Protected Sub gv宿泊料金_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv宿泊料金.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                CType(e.Row.FindControl("lbl日付"  ), Template.Label).Text         = CDate(DataBinder.Eval(e.Row.DataItem, "年月日")).ToString("yyyy年MM月dd日")
                CType(e.Row.FindControl("lbl内訳"  ), Template.NoEncodeLabel).Text = DataBinder.Eval(e.Row.DataItem, "利用内訳")
                CType(e.Row.FindControl("lbl税区分"), Template.Label).Text         = DataBinder.Eval(e.Row.DataItem, "税区分")
                CType(e.Row.FindControl("lbl金額"), Template.Label).Text = DataBinder.Eval(e.Row.DataItem, "利用合計")
                CType(e.Row.FindControl("lbl通貨単位"), Template.Label).Text = BizUtility.GetCurrencySign(Me._国区分)

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
        Protected Sub gv食事料金_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv食事料金.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                Dim 年月日 As Date = CType(e.Row.DataItem, Date)

                CType(e.Row.FindControl("lbl日付"), Template.Label).Text = 年月日.ToString("yyyy年MM月dd日")
                CType(e.Row.FindControl("lbl朝食"), Template.Label).Text = Me.Get食事Value(年月日, CodeConst.C_食事区分_朝食, Me._国区分)
                CType(e.Row.FindControl("lbl夕食"), Template.Label).Text = Me.Get食事Value(年月日, CodeConst.C_食事区分_夕食, Me._国区分)
                CType(e.Row.FindControl("lbl金額"), Template.Label).Text = Me.Get食事料金(年月日)
                CType(e.Row.FindControl("lbl通貨単位"), Template.Label).Text = BizUtility.GetCurrencySign(Me._国区分)

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 食事情報を取得します。
        ''' </summary>
        ''' <param name="年月日"></param>
        ''' <param name="食事区分"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get食事Value(ByRef 年月日 As Date, ByRef 食事区分 As String, ByVal 国区分 As String) As String

            Dim row As DataRow = CType(Me.Page, BasePage).Find(_予約選択料理, "年月日", "食事区分", 年月日, 食事区分)
            If row Is Nothing Then Return "-"

            Dim result As New StringBuilder
            result.Append(row("食事名称"))
            result.Append("(")
            result.Append(CDec(row("料金大人")).ToString("#,##0"))
            result.Append(BizUtility.GetCurrencySign(国区分))
            result.Append(")")

            Return result.ToString()

        End Function

        ''' <summary>
        ''' 食事料金を取得します。
        ''' </summary>
        ''' <param name="年月日"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get食事料金(ByRef 年月日 As Date) As String
            Dim result As Decimal = 0

            For Each row As DataRow In _予約選択料理.Rows
                If Not CDate(row("年月日")).Equals(年月日) Then Continue For
                result += CDec(row("食事合計"))
            Next

            Return result.ToString("#,##0")
        End Function

    End Class

End NameSpace
