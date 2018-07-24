Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Utility

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    ''' <summary>
    ''' メール送信確認
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class MailSend
        Inherits System.Web.UI.UserControl

        Private _isReadOnly As Boolean = False
        Private _予約基本情報 As DataRow
        Private _会員情報 As DataRow
        Private _ドメイン情報 As DataTable

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
            Set(ByVal value As Boolean)
                _isReadOnly = value
            End Set
        End Property

        ''' <summary>
        ''' 予約基本情報を設定します。
        ''' </summary>
        ''' <value></value>
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
        ''' ドメイン情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property ドメイン情報() As DataTable
            Set
                _ドメイン情報 = Value
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
            If Me.chkPCその他.Checked AndAlso String.IsNullOrEmpty(Me.txtPCメールアドレスその他.Text) Then
                msg.Add(Messages.GetMessage("E001", Me.txtPCメールアドレスその他.DisplayName))
            End If
            If Me.chk携帯その他.Checked AndAlso String.IsNullOrEmpty(Me.txt携帯メールアドレスその他.Text) Then
                msg.Add(Messages.GetMessage("E001", Me.txt携帯メールアドレスその他.DisplayName))
            End If
            If Me.chk携帯その他.Checked AndAlso Me.ddlドメイン.SelectedIndex <= 0 Then
                msg.Add(Messages.GetMessage("E014", Me.ddlドメイン.DisplayName))
            End If

            '型の検証を行ないます。
            If Me.chkPCその他.Checked AndAlso Not String.IsNullOrEmpty(Me.txtPCメールアドレスその他.Text) AndAlso _
               Not CheckValueUtility.IsValidEmail(Me.txtPCメールアドレスその他.Text) Then
                msg.Add(Messages.GetMessage("E006", Me.txtPCメールアドレスその他.DisplayName))
            End If
            If Me.chk携帯その他.Checked AndAlso Not String.IsNullOrEmpty(Me.txt携帯メールアドレスその他.Text) AndAlso _
               Not CheckValueUtility.IsValidEmail(Me.txt携帯メールアドレスその他.Text & "@" & Me.ddlドメイン.SelectedItem.Text) Then
                msg.Add(Messages.GetMessage("E006", Me.txt携帯メールアドレスその他.DisplayName))
            End If

            '確認の検証を行ないます。
            If Me.chkPCその他.Checked AndAlso Not String.IsNullOrEmpty(Me.txtPCメールアドレスその他.Text) AndAlso _
               Not Me.txtPCメールアドレスその他.Text.Equals(Me.txtPCメールアドレスその他確認.Text) Then
                msg.Add(Messages.GetMessage("E003", Me.txtPCメールアドレスその他.DisplayName, "確認用"))
            End If
            If Me.chk携帯その他.Checked AndAlso Not String.IsNullOrEmpty(Me.txt携帯メールアドレスその他.Text) AndAlso _
               Not Me.txt携帯メールアドレスその他.Text.Equals(Me.txt携帯メールアドレスその他確認.Text) Then
                msg.Add(Messages.GetMessage("E003", Me.txt携帯メールアドレスその他.DisplayName, "確認用"))
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

                Me.pnl入力.Visible = Not _isReadOnly
                Me.pnl表示.Visible = _isReadOnly

                If _会員情報 IsNot Nothing Then
                    CType(Me.Page, BasePage).BindItem(Me.Controls, _会員情報)
                End If

                If Me.pnl表示.Visible Then
                    Me.tr1.Visible = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス1"))
                    Me.tr2.Visible = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス2"))
                    Me.tr3.Visible = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス3"))
                    Me.tr4.Visible = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス4"))

                    If Me.tr1.Visible Then Me.td1.InnerText = _予約基本情報("予約通知先メールアドレス1")
                    If Me.tr2.Visible Then Me.td2.InnerText = _予約基本情報("予約通知先メールアドレス2")
                    If Me.tr3.Visible Then Me.td3.InnerText = _予約基本情報("予約通知先メールアドレス3")
                    If Me.tr4.Visible Then Me.td4.InnerText = _予約基本情報("予約通知先メールアドレス4")

                    Me.trNone.Visible = Not Me.tr1.Visible AndAlso Not Me.tr2.Visible AndAlso _
                                        Not Me.tr3.Visible AndAlso Not Me.tr4.Visible

                    Return
                End If

                Me.trIn1.Visible = Not String.IsNullOrEmpty(Me.lblPCメールアドレス.Text)
                Me.trIn2.Visible = Not String.IsNullOrEmpty(Me.lbl携帯メールアドレス.Text)

                CType(Me.Page, BasePage).SetDDLDataTable(Me.ddlドメイン, _ドメイン情報)
                CType(Me.Page, BasePage).AddDDLDataTable(Me.ddlドメイン, 0, String.Empty, "選択してください")

                Me.txtPCメールアドレスその他.CssClass       = Me.txtPCメールアドレスその他.CssClass       & " email"
                Me.txtPCメールアドレスその他確認.CssClass   = Me.txtPCメールアドレスその他確認.CssClass   & " email"
                Me.txt携帯メールアドレスその他.CssClass     = Me.txt携帯メールアドレスその他.CssClass     & " mmail"
                Me.txt携帯メールアドレスその他確認.CssClass = Me.txt携帯メールアドレスその他確認.CssClass & " mmail"

                Me.chkPCメール.Checked   = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス1"))
                Me.chk携帯メール.Checked = Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス2"))

                If Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス3")) Then
                    Me.chkPCその他.Checked = True
                    Me.txtPCメールアドレスその他.Text     = _予約基本情報("予約通知先メールアドレス3")
                    Me.txtPCメールアドレスその他確認.Text = _予約基本情報("予約通知先メールアドレス3")
                End If

                If Not String.IsNullOrEmpty(_予約基本情報("予約通知先メールアドレス4")) Then
                    Me.chk携帯その他.Checked = True
                    Dim 携帯メール As String() = _予約基本情報("予約通知先メールアドレス4").ToString().Split(New String(){"@"}, StringSplitOptions.RemoveEmptyEntries)
                    Me.txt携帯メールアドレスその他.Text     = 携帯メール(0)
                    Me.txt携帯メールアドレスその他確認.Text = 携帯メール(0)
                    Me.ddlドメイン.SelectedValue = Me.ddlドメイン.Items.FindByText(携帯メール(1)).Value
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
            table.Columns.Add("予約通知先メールアドレス1", GetType(String))
            table.Columns.Add("予約通知先メールアドレス2" , GetType(String))
            table.Columns.Add("予約通知先メールアドレス3" , GetType(String))
            table.Columns.Add("予約通知先メールアドレス4" , GetType(String))

            Dim result As DataRow = table.NewRow()

            result("予約通知先メールアドレス1") = String.Empty
            result("予約通知先メールアドレス2") = String.Empty
            result("予約通知先メールアドレス3") = String.Empty
            result("予約通知先メールアドレス4") = String.Empty

            If Me.chkPCメール.Checked   Then result("予約通知先メールアドレス1") = Me.lblPCメールアドレス.Text
            If Me.chk携帯メール.Checked Then result("予約通知先メールアドレス2") = Me.lbl携帯メールアドレス.Text
            If Me.chkPCその他.Checked   Then result("予約通知先メールアドレス3") = Me.txtPCメールアドレスその他.Text
            If Me.chk携帯その他.Checked Then result("予約通知先メールアドレス4") = Me.txt携帯メールアドレスその他.Text & "@" & Me.ddlドメイン.SelectedItem.Text

            Return result
        End Function

    End Class

End NameSpace
