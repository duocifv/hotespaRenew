Imports System.Collections.Generic
Imports System.Data

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class ErrorInfo
        Inherits System.Web.UI.UserControl

        ''' <summary>
        ''' メッセージを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetMessage(ByRef msg As DataTable)
            Dim messages As New List(Of String)
            For Each row As DataRow In msg.Rows
                messages.Add(row("メッセージ"))
            Next
            Me.SetMessage(messages)
            Return
        End Sub

        ''' <summary>
        ''' メッセージを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetMessage(ByRef msg As List(Of String))
            If msg Is Nothing OrElse msg.Count <= 0 Then
                Return
            End If
            Me.Visible = True
            CType(Me.Page, BasePage).SetListLabel(Me.lbl内容, msg)
            Return
        End Sub

        ''' <summary>
        ''' メッセージを設定します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetMessage(ByRef msg As String)
            If String.IsNullOrEmpty(msg) Then
                Return
            End If
            Me.Visible = True
            Me.lbl内容.Text = "<li>" & msg & "</li>"
            Return
        End Sub

        ''' <summary>
        ''' メッセージをクリアします。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearMessage()
            Me.Visible = False
            Me.lbl内容.Text = String.Empty
            Return
        End Sub

    End Class

End NameSpace
