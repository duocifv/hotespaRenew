Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

NameSpace Com.Fujitsu.Hotespa.Web.User.Common

    ''' <summary>
    ''' エラーページ
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class ErrorPage
        Inherits BaseUserPage

        ''' <summary>
        ''' 項目プロパティを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub SetItemProperty()
            Return
        End Sub

        ''' <summary>
        ''' ページが読み込まれると発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'エラーメッセージを設定します。
            Dim messages As New List(Of String)
            Select Case True
                Case Not String.IsNullOrEmpty(Me.Session.Item("ExceptionMessage"))
                    messages.Add("システムエラーが発生しました。")
                    Me.ibtn前ページ.Visible = False
                    Exit Select

                Case Me.Session.Item("Message") IsNot Nothing
                    If TypeOf Me.Session.Item("Message") Is String Then
                        messages.Add(Me.Session.Item("Message").ToString())
                        Exit Select
                    End If

                    Dim table As DataTable = Me.Session.Item("Message")
                    For Each row As DataRow In table.Rows
                        messages.Add(row("メッセージ"))
                    Next

                Case Else
                    messages.Add("エラーが発生しました。")
                    Exit Select

            End Select

            'エラー情報を設定します。
            If String.IsNullOrEmpty(Me.Session.Item("Title")) Then
                Me.lblタイトル.Text = "エラー"
            Else
                Me.lblタイトル.Text = Me.Session.Item("Title") & "のエラー"
            End If
            Me.errorInfo.SetMessage(messages)

            Me.ibtn前ページ.Visible = Not String.IsNullOrEmpty(page.Session.Item("page"))

            Me.Session.Item("Title") = Nothing
            Me.Session.Item("Message") = Nothing
            Me.Session.Item("ExceptionMessage") = Nothing

            Return
        End Sub

        ''' <summary>
        ''' 前ページボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub ibtn前ページ_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtn前ページ.Click
            Try
                '画面を遷移します。
                PageUtility.SendPage(Me.Page, page.Session.Item("page"))
                Me.Session.Item("page") = Nothing
                Return
            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
