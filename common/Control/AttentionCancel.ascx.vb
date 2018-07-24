Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.Constant

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class AttentionCancel
        Inherits System.Web.UI.UserControl

        Private _注意事項 As String
        Private _キャンセルポリシー As DataRow

        ''' <summary>
        ''' 注意事項を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 注意事項() As String
            Set
                _注意事項 = Value
            End Set
        End Property

        ''' <summary>
        ''' キャンセルポリシーを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property キャンセルポリシー() As DataRow
            Set
                _キャンセルポリシー = Value
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

                Me.dlAttention.Visible = Not String.IsNullOrEmpty(_注意事項)
                If Me.dlAttention.Visible Then
                    CType(Me.Page, BasePage).SetListLabel(Me.lbl注意事項, _注意事項.Split(New String(){vbCrLf}, StringSplitOptions.None))
                End If

                Dim list As New List(Of String)

                If _キャンセルポリシー("キャンセルポリシー利用可否区分1").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント1"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分2").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント2"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分3").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント3"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分4").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント4"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分5").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント5"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分6").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント6"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分7").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント7"))
                End If
                If _キャンセルポリシー("キャンセルポリシー利用可否区分8").Equals(CodeConst.C_可否区分_可) Then
                    list.Add(_キャンセルポリシー("キャンセルポリシーコメント8"))
                End If
                CType(Me.Page, BasePage).SetListLabel(Me.lblキャンセルポリシー, list)
                Me.lblキャンセルポリシー.Text = _キャンセルポリシー("キャンセルポリシー説明").ToString().Replace(vbCrLf, "<br/>") & "<br/>" & Me.lblキャンセルポリシー.Text

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace
