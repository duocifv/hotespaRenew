
NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class AreaMap
        Inherits System.Web.UI.UserControl

        Private _キャプション As String
        Private _ファイル名 As String

        ''' <summary>
        ''' キャプションを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property キャプション() As String
            Set
                _キャプション = Value
            End Set
        End Property

        ''' <summary>
        ''' ファイル名を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property ファイル名() As String
            Set
                _ファイル名 = Value
            End Set
        End Property

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

                Me.img地図.AlternateText = _キャプション
                Me.img地図.ImageUrl = _ファイル名
                If String.IsNullOrEmpty(_ファイル名) Then
                    Me.img地図.Visible = False
                Else
                    Me.img地図.Visible = True
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
