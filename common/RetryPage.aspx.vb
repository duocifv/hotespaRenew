Imports System.Collections.Generic
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports System.Data
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common
Imports ReservationWS
Imports Com.Fujitsu.Hotespa.Framework.Constant

NameSpace Com.Fujitsu.Hotespa.Web.User.Common

    ''' <summary>
    ''' エラーページ
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class RetryPage
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
            Me.lblタイトル.Text = "カード決済処理が完了していない為、ご予約手続きは完了しておりません"
            Me.errorInfo.SetMessage(messages)

            Me.ibtn前ページ.Visible = Not String.IsNullOrEmpty(Page.Session.Item("page"))

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
                PageUtility.SendPage(Me.Page, Page.Session.Item("page"))
                Me.Session.Item("page") = Nothing
                Return
            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 現地決済ボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtn現地決済_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn現地決済.Click
            Try
                Dim data As ReservationBF = Me.SessionInfo.セッション情報
                If data.eReserveBE.tbleReserve(0).決済区分 = CodeConst.C_決済区分_現地決済 Then
                    MyBase.SendRetryPage(Messages.GetMessage("E000", "既に予約されています。"), "", False)
                    Return
                End If

                Dim service As ReservationBS = MyBase.GetWebService(New ReservationBS)
                Dim input As ReservationBF = New ReservationBF
                input.retry_settlementDiv = CodeConst.C_決済区分_現地決済

                input.予約No = data.eReserveBE.tbleReserve(0).予約No
                input.会員ID = Me.LoginInfo.会員ID
                input.法人ID = Me.LoginInfo.法人ID

                Dim output As ReservationBF = service.UpdateRetry(input)

                'エラーの場合、エラーメッセージを設定します。
                If Not output.Result Then
                    Me.errorInfo.SetMessage(output.MessageDS.Tables(0))
                    Return
                End If

                '結果をセッション情報に保持します。
                Me.SessionInfo.セッション情報 = output
                Me.StoreSession()

                '予約完了画面へ遷移します。
                PageUtility.SendPage(Me.Page, "../Rsv/ReservationAction.aspx")

            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 再決済ボタンがクリックされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub lbtn再決済_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn再決済.Click
            Try
                Dim data As ReservationBF = Me.SessionInfo.セッション情報
                If data.eReserveBE.tbleReserve(0).決済区分 = CodeConst.C_決済区分_現地決済 Then
                    MyBase.SendRetryPage(Messages.GetMessage("E000", "既に予約されています。"), "", False)
                    Return
                Else
                    If data.eReserveBE.tbleReserve(0).少額与信区分 = CodeConst.C_カード決済状態区分_成功 OrElse _
                       data.eReserveBE.tbleReserve(0).全額与信区分 = CodeConst.C_カード決済状態区分_成功 Then
                        MyBase.SendRetryPage(Messages.GetMessage("E000", "既に予約されています。"), "", False)
                        Return
                    End If
                End If

                Dim 連番 As Short = CShort(data.eReserveBE.tbleReserve(0).取引連番 + 1)

                Dim service As ReservationBS = MyBase.GetWebService(New ReservationBS)
                Dim input As ReservationBF = New ReservationBF
                input.retry_settlementDiv = CodeConst.C_決済区分_ｶｰﾄﾞ決済
                input.orderId = Mid(data.eReserveBE.tbleReserve(0).取引ID, 1, Len(data.eReserveBE.tbleReserve(0).取引ID) - 3) & 連番.ToString("000")

                input.予約No = data.eReserveBE.tbleReserve(0).予約No
                input.会員ID = Me.LoginInfo.会員ID
                input.法人ID = Me.LoginInfo.法人ID

                Dim output As ReservationBF = service.UpdateRetry(input)

                'エラーの場合、エラーメッセージを設定します。
                If Not output.Result Then
                    Me.errorInfo.SetMessage(output.MessageDS.Tables(0))
                    Return
                End If

                '結果をセッション情報に保持します。
                Me.SessionInfo.セッション情報 = output
                Me.StoreSession()

                'VTWeb決済URLに画面遷移
                PageUtility.SendPage(Me.Page, "../Rsv/DoPostActionReservation.aspx")

            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try
        End Sub
    End Class

End NameSpace
