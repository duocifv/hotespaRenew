Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class PaymentOption
        Inherits System.Web.UI.UserControl

        Private _isReadOnly As Boolean = False
        Private _予約基本情報 As DataRow
        Private _プラン情報 As DataRow
        Private _カード会社情報 As DataTable
        Private _isChargeSelectDisp As Boolean = False
        Private _isLastCreditExists As Boolean = False
        Private _カード番号 As String

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
        ''' キャンセル料請求選択チェックボックスの表示有無を示す値を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Category("その他")> _
        <System.ComponentModel.Description("キャンセル料請求選択チェックボックスの表示有無を示す値を取得または設定します。")> _
        <System.ComponentModel.DefaultValue(False)> _
        Public Property IsChargeSelectDisp() As Boolean
            Get
                Return _isChargeSelectDisp
            End Get
            Set(ByVal value As Boolean)
                _isChargeSelectDisp = value
            End Set
        End Property

        ''' <summary>
        ''' 前回のクレジット情報を使用するかどうか
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property IsLastCreditExists() As Boolean
            Get
                Return _isLastCreditExists
            End Get
            Set(ByVal value As Boolean)
                _isLastCreditExists = value
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
        ''' カード会社情報を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property カード会社情報() As DataTable
            Set
                _カード会社情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' 前回のクレジットカード番号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property カード番号() As String
            Get
                Return _カード番号
            End Get
            Set(ByVal value As String)
                _カード番号 = value
            End Set
        End Property

        ''' <summary>
        ''' 検証が終了したかどうかを示す値を取得します。
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValid(ByRef msg As List(Of String)) As Boolean

            '必須の検証を行ないます。
            If Not Me.rdo支払方法カード.Checked AndAlso Not Me.rdo支払方法現地.Checked Then
                msg.Add(Messages.GetMessage("E014", "お支払い方法"))
                Return False
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

                Me.pnlクレジット決済.Visible  = Not _isReadOnly AndAlso _プラン情報 IsNot Nothing AndAlso Not _プラン情報("決済方法区分").Equals(CodeConst.C_決済方法区分_現地決済のみ)
                Me.pnl現地決済.Visible        = Not _isReadOnly AndAlso _プラン情報 IsNot Nothing AndAlso Not _プラン情報("決済方法区分").Equals(CodeConst.C_決済方法区分_ｶｰﾄﾞ決済のみ)
                Me.pnlクレジット決済R.Visible = _isReadOnly AndAlso _予約基本情報 IsNot Nothing AndAlso _予約基本情報("決済区分").Equals(CodeConst.C_決済区分_ｶｰﾄﾞ決済)
                Me.pnl現地決済R.Visible       = _isReadOnly AndAlso _予約基本情報 IsNot Nothing AndAlso _予約基本情報("決済区分").Equals(CodeConst.C_決済区分_現地決済)
                '前回カード利用の有無表示
                Me.chk前回カード利用.Visible = Me.IsLastCreditExists
                Me.chk前回カード利用.Text = "前回予約時のカード情報を使用する"
                If Not String.IsNullOrEmpty(Me.カード番号) Then
                    Me.chk前回カード利用.Text = Me.chk前回カード利用.Text & "　（クレジットカードNo.　" & Me.カード番号 & "）"
                End If

                Dim base As BasePage = CType(Me.Page, BasePage)

                '読取専用ではない場合、入力項目の設定を行ないます。
                If Not _isReadOnly Then
                    Me.rdo支払方法カード.Value = CodeConst.C_決済区分_ｶｰﾄﾞ決済
                    Me.rdo支払方法現地.Value = CodeConst.C_決済区分_現地決済

                    If Me.pnl現地決済.Visible Then
                        Me.rdo支払方法現地.Checked = True
                    Else
                        Me.rdo支払方法カード.Checked = True
                    End If

                    '予約基本情報が渡された場合、情報の設定を行ないます。
                    If _予約基本情報 IsNot Nothing Then
                        If String.IsNullOrEmpty(_予約基本情報("決済区分").ToString) = False Then
                            base.BindItem(Me.Controls, _予約基本情報)
                        End If
                    End If
                Else
                    If Me.pnlクレジット決済R.Visible Then
                        If _予約基本情報("予約状態区分").Equals(CodeConst.C_予約状態区分_予約中) AndAlso _isChargeSelectDisp Then
                            Me.chk強制キャンセル.Visible = True
                            Me.chk強制キャンセル.Checked = False
                        Else
                            Me.chk強制キャンセル.Visible = False
                        End If
                    End If
                End If

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
            table.Columns.Add("決済区分", GetType(String))
            table.Columns.Add("強制キャンセル", GetType(Boolean))
            table.Columns.Add("前回クレジット", GetType(Boolean))

            Dim result As DataRow = table.NewRow()

            result("前回クレジット") = False
            If Me.rdo支払方法現地.Checked Then
                result("決済区分") = Me.rdo支払方法現地.Value
            Else
                result("決済区分") = Me.rdo支払方法カード.Value
                If Me.chk前回カード利用.Checked Then
                    result("前回クレジット") = True
                End If
            End If

            If _isChargeSelectDisp Then
                If Me.chk強制キャンセル.Checked Then
                    result("強制キャンセル") = True
                Else
                    result("強制キャンセル") = False
                End If
            Else
                result("強制キャンセル") = False
            End If
            table.Rows.Add(result)

            Return result
        End Function

    End Class

End NameSpace
