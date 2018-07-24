Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Common
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control.Template
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

Namespace Com.Fujitsu.Hotespa.Web.User.Common

    ''' <summary>
    ''' システム情報取得
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class GetControl
        Inherits BaseUserPage

        ''' <summary>
        ''' ページが初期化されると発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            MyBase.IsCheckSession = False
            Return
        End Sub

        ''' <summary>
        ''' ページが読み込まれる前に発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
            Try

                'パラメータを設定します。
                Dim input As LoginWS.LoginBF = New LoginWS.LoginBF
                input.システム区分 = CodeConst.C_システム区分_ﾕｰｻﾞｻｲﾄ

                'コントロール情報取得を行ないます。
                Dim service As LoginWS.LoginBS = MyBase.GetWebService(New LoginWS.LoginBS)
                Dim output As LoginWS.LoginBF = service.GetControl(input)

                '結果を判断し、エラーの場合エラーメッセージを設定します。
                If Not output.Result Then
                    MyBase.SendErrorPage(output.MessageDS.Tables(0))
                    Me.IsLoad = False
                    Return
                End If

                'コントロール情報を設定します。
                Me.SessionInfo.一覧表示行数 = Convert.ToInt32(Me.Find(output.mOwnControlBE.tblmControl, "キー2", "キー3", "一覧"    , "表示行数"  ).Item("データ"))
                Me.SessionInfo.年過去表示数 = Convert.ToInt32(Me.Find(output.mOwnControlBE.tblmControl, "キー2", "キー3", "年"      , "過去表示数").Item("データ"))
                Me.SessionInfo.年未来表示数 = Convert.ToInt32(Me.Find(output.mOwnControlBE.tblmControl, "キー2", "キー3", "年"      , "未来表示数").Item("データ"))
                Me.SessionInfo.到着日数     = Convert.ToInt32(Me.Find(output.mOwnControlBE.tblmControl, "キー2", "キー3", "検索条件", "到着日数"  ).Item("データ"))

                Me.SessionInfo.予約可能人数 = Convert.ToInt32(Me.Find(output.mControlBE.tblmControl, "キー2", "キー3", "予約", "人数").Item("データ"))
                Me.SessionInfo.予約可能泊数 = Convert.ToInt32(Me.Find(output.mControlBE.tblmControl, "キー2", "キー3", "予約", "可能泊数").Item("データ"))
                Me.SessionInfo.予約可能室数 = Convert.ToInt32(Me.Find(output.mControlBE.tblmControl, "キー2", "キー3", "予約", "可能室数").Item("データ"))
                Me.SessionInfo.IsLoad = True

                Me.SetWebSiteURL(output.mControlBE.tblmControl)

                'セッション情報を保存します。
                Me.StoreSession()

                Me.IsLoad = False
                PageUtility.SendPage(Me.Page, Me.SessionInfo.遷移元URL)

                Return
            Catch ex As Exception
                MyBase.ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
