Imports System.Data

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class CancelContact
        Inherits System.Web.UI.UserControl

        Dim _施設情報 As DataRow

        ''' <summary>
        ''' 施設情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 施設情報() As DataRow
            Set
                _施設情報 = Value
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

                If _施設情報 IsNot Nothing
                    Me.lbl電話1.Text    = _施設情報("電話1")
                    Me.lbl郵便番号.Text = _施設情報("郵便番号").ToString().Substring(0, 3) & _施設情報("郵便番号").ToString().Substring(3)
                    Me.lbl住所.Text     = _施設情報("住所").ToString().Replace("\r\n", String.Empty)
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
