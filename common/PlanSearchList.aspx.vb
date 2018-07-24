Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

Namespace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class PlanSearchList
        Inherits BaseUserPage

        Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
            If Not Me.IsLoad Then Return

            'サイトを判断します。
            If MyBase.SessionInfo.セッションDic情報.ContainsKey("SITE") Then

                If MyBase.SessionInfo.セッションDic情報("SITE").Equals(BasePage.SITE_USER_D) Then
                    PageUtility.SendPage(Me.Page, "../Plan_DormyInn/PlanSearchList.aspx")
                Else
                    PageUtility.SendPage(Me.Page, "../Plan_Resort/PlanSearchList.aspx")
                End If

            Else
                PageUtility.SendPage(Me.Page, "../Plan_DormyInn/PlanSearchList.aspx")
            End If

            Me.IsLoad = False
            Return
        End Sub

    End Class

End NameSpace
