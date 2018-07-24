Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.Constant
Imports Com.Fujitsu.Hotespa.WebFramework.UI.Control

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    Partial Class FavoriteList
        Inherits System.Web.UI.UserControl

        Private Const LIST_CD As String = "フェイバリットCD"

#Region "プロパティ"

        Private _isReadOnly     As Boolean = False
        Private _isImageVisible As Boolean = True
        Private _isNextVisible  As Boolean = True

        Private _dataSource As DataTable
        Private _checkItem As DataTable
        Private _Message As String
        Private _次回反映 As Boolean
        Private _湯めぐり倶楽部区分 As String

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
        ''' イメージを表示するかどうかを示す値を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Category("その他")> _
        <System.ComponentModel.Description("イメージを表示するかどうかを示す値を取得または設定します。")> _
        <System.ComponentModel.DesignOnly(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DefaultValue(True)> _
        Public Property IsImageVisible() As Boolean
            Get
                Return _isImageVisible
            End Get
            Set(ByVal value As Boolean)
                _isImageVisible = value
            End Set
        End Property

        ''' <summary>
        ''' 次回反映を表示するかどうかを示す値を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.Category("その他")> _
        <System.ComponentModel.Description("次回反映を表示するかどうかを示す値を取得または設定します。")> _
        <System.ComponentModel.DefaultValue(True)> _
        Public Property IsNextVisible() As Boolean
            Get
                Return _isNextVisible
            End Get
            Set(ByVal value As Boolean)
                _isNextVisible = value
            End Set
        End Property

        ''' <summary>
        ''' グリッドのデータソースを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property DataSource() As DataTable
            Get
                Return _dataSource
            End Get
            Set
                _dataSource = Value
            End Set
        End Property

        ''' <summary>
        ''' メッセージを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property Message() As String
            Set
                _Message = Value
            End Set
        End Property

        ''' <summary>
        ''' 次回反映するかどうかを示す値を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property 次回反映() As Boolean
            Get
                Return Me.chk次回反映.Checked
            End Get
            Set
                _次回反映 = Value
            End Set
        End Property

        ''' <summary>
        ''' チェックする項目を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property CheckItem() As DataTable
            Get
                Dim chk As Template.CheckBox

                Dim result As DataTable = New DataTable
                result.Columns.Add(LIST_CD, GetType(String))

                For i As Integer = 0 To Me.gvList1.Rows.Count - 1

                    chk = CType(Me.gvList1.Rows(i).FindControl("chkItem1"), Template.CheckBox)
                    If chk.Checked Then
                        result.Rows.Add(chk.Value)
                    End If

                    If Me.gvList2.Rows.Count <= i Then Return result
                    chk = CType(Me.gvList2.Rows(i).FindControl("chkItem2"), Template.CheckBox)
                    If chk.Checked Then
                        result.Rows.Add(chk.Value)
                    End If

                    If Me.gvList3.Rows.Count <= i Then Return result
                    chk = CType(Me.gvList3.Rows(i).FindControl("chkItem3"), Template.CheckBox)
                    If chk.Checked Then
                        result.Rows.Add(chk.Value)
                    End If
                Next
                Return result
            End Get
            Set
                _checkItem = Value
            End Set
        End Property

        ''' <summary>
        ''' 湯めぐり倶楽部区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 湯めぐり倶楽部区分() As String
            Set(ByVal value As String)
                _湯めぐり倶楽部区分 = value
            End Set
        End Property

#End Region

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

                If _dataSource.Rows.Count <= 0 Then
                    Me.Visible = False
                    Return
                End If

                If _isReadOnly AndAlso _checkItem.Rows.Count <= 0 Then
                    Me.Visible = False
                    Return
                End If

                Me.gvList1.DataSource = _dataSource
                Me.gvList2.DataSource = _dataSource
                Me.gvList3.DataSource = _dataSource
                Me.gvList1.DataBind()
                Me.gvList2.DataBind()
                Me.gvList3.DataBind()

                Me.imgタイトル.Visible = _isImageVisible
                Me.lblメッセージ.Text    = _Message
                Me.lblメッセージ.Visible = (_Message.Length > 0)

                If _isReadOnly Then
                    Me.lbl次回反映.Visible = (_isNextVisible)
                    If Not _次回反映 Then Me.lbl次回反映.Text = Me.lbl次回反映.Text.Replace("する", "しない")
                    Me.chk次回反映.Visible = False
                Else
                    Me.lbl次回反映.Visible = False
                    Me.chk次回反映.Visible = _isNextVisible
                    Me.chk次回反映.Checked = _次回反映
                End If

                '湯めぐりの場合はマイフェイバリットを非表示とします
                If _湯めぐり倶楽部区分 = CodeConst.C_対象区分_対象 Then
                    Me.divFavorite.Visible = False
                Else
                    Me.divFavorite.Visible = True
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' データ行がデータにバインドされたときに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList1.RowDataBound, gvList2.RowDataBound, gvList3.RowDataBound
            Try
                If Not e.Row.RowType.Equals(DataControlRowType.DataRow) Then Return

                Dim bol As Boolean
                Dim chk As Template.CheckBox = Nothing
                Dim lbl As Template.Label = Nothing

                If e.Row.FindControl("chkItem1") IsNot Nothing Then
                    chk = CType(e.Row.FindControl("chkItem1"), Template.CheckBox)
                    lbl = CType(e.Row.FindControl("lblItem1"), Template.Label)
                    bol = Me.Contains(_checkItem, chk.Value)
                    chk.Visible = Not _isReadOnly AndAlso Not String.IsNullOrEmpty(chk.Text)
                    chk.Checked = bol
                    lbl.Visible = _isReadOnly AndAlso bol
                End If
                If e.Row.FindControl("chkItem2") IsNot Nothing Then
                    chk = CType(e.Row.FindControl("chkItem2"), Template.CheckBox)
                    lbl = CType(e.Row.FindControl("lblItem2"), Template.Label)
                    bol = Me.Contains(_checkItem, chk.Value)
                    chk.Visible = Not _isReadOnly AndAlso Not String.IsNullOrEmpty(chk.Text)
                    chk.Checked = bol
                    lbl.Visible = _isReadOnly AndAlso bol
                End If
                If e.Row.FindControl("chkItem3") IsNot Nothing Then
                    chk = CType(e.Row.FindControl("chkItem3"), Template.CheckBox)
                    lbl = CType(e.Row.FindControl("lblItem3"), Template.Label)
                    bol = Me.Contains(_checkItem, chk.Value)
                    chk.Visible = Not _isReadOnly AndAlso Not String.IsNullOrEmpty(chk.Text)
                    chk.Checked = bol
                    lbl.Visible = _isReadOnly AndAlso bol
                End If

                e.Row.Visible = chk.Visible OrElse lbl.Visible

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 指定されている値が存在するかどうかを判断します。
        ''' </summary>
        ''' <param name="table"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Contains(ByRef table As DataTable, ByRef value As String) As Boolean
            If Not table.Columns.Contains(LIST_CD) Then Return False
            For Each row As DataRow In table.Rows
                If row(LIST_CD) IsNot Nothing AndAlso row(LIST_CD).Equals(value) Then
                    Return True
                End If
            Next
            Return False
        End Function

    End Class

End NameSpace
