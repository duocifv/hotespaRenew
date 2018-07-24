Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class ReserveDemand
        Inherits System.Web.UI.UserControl

        Private _isReadOnly As Boolean = False
        Private _プラン情報 As DataRow
        Private _予約基本情報 As DataRow

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
        ''' プラン情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property プラン情報() As DataRow
            Set
                _プラン情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 予約基本情報を取得または設定します。
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
        ''' 検証が終了したかどうかを示す値を取得します。
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValid(ByRef msg As List(Of String)) As Boolean

            '桁数の検証を行ないます。
            If Not String.IsNullOrEmpty(Me.txt要望.Text) AndAlso Me.txt要望.Text.Length > Me.txt要望.MaxLength Then
                msg.Add(Messages.GetMessage("E002", Me.txt要望.DisplayName, Me.txt要望.MaxLength & "文字以下"))
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

                '予約通信欄が設定されていない場合、コントロールを非表示に設定します。
                If _isReadOnly AndAlso String.IsNullOrEmpty(_予約基本情報("予約通信欄").ToString()) Then
                    Me.Visible = False
                    Return
                ElseIf Not _isReadOnly AndAlso String.IsNullOrEmpty(_プラン情報("予約通信欄").ToString()) Then
                    Me.Visible = False
                    Return
                End If

                Me.pnl入力.Visible  = Not _isReadOnly
                Me.pnl表示.Visible  = _isReadOnly

                Dim base As BasePage = CType(Me.Page, BasePage)

                '予約基本情報が渡された場合、情報の設定を行ないます。
                If _予約基本情報 IsNot Nothing Then
                    base.BindItem(Me.Controls, _予約基本情報)
                    Me.lbl要望.Text = _予約基本情報("予約通信欄").ToString().Replace(vbCrLf, BasePage.STR_BR)
                End If

                If _プラン情報 IsNot Nothing Then
                    Me.lbl予約通信欄.Text = _プラン情報("予約通信欄").ToString().Replace(vbCrLf, BasePage.STR_BR)
                End If

                'CSSを設定します。
                Me.txt要望.CssClass = Me.txt要望.CssClass & " hope"

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 予約基本情報を取得します。
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Get予約基本情報() As DataRow

            Dim table As New DataTable
            table.Columns.Add("予約通信欄", GetType(String))

            Dim result As DataRow = table.NewRow()
            result("予約通信欄") = Me.txt要望.Text

            Return result
        End Function

    End Class

End NameSpace
