Imports System.Collections.Generic
Imports System.Data
Imports Com.Fujitsu.Hotespa.Framework.BusinessCommon
Imports Com.Fujitsu.Hotespa.Framework.Constant

NameSpace Com.Fujitsu.Hotespa.Web.Common.Control

    ''' <summary>
    ''' 予約情報を表示するコントロール
    ''' </summary>
    ''' <remarks></remarks>
    Partial Class ReserveView
        Inherits System.Web.UI.UserControl

        Private Const C_QS_施設CD   As String = "s_cd"
        Private Const C_QS_プランCD As String = "p_cd"

#Region "プロパティ"

        Private _isLinkVisible As Boolean = True

        Private _予約No As String

        Private _到着日 As Date
        Private _宿泊数 As Integer
        Private _部屋数 As Integer

        Private _プランCD As String
        Private _プラン名称 As String
        Private _施設CD As String
        Private _施設区分 As String
        Private _湯めぐり倶楽部区分 As String

        Private _予約タイプ情報 As DataTable
        Private _プラン情報 As DataRow

        ''' <summary>
        ''' リンクを表示するかどうかを示す値を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        Public WriteOnly Property IsLinkVisible() As Boolean
            Set
                _isLinkVisible = Value
            End Set
        End Property

        ''' <summary>
        ''' 到着日を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約No() As String
            Set
                _予約No = Value
            End Set
        End Property

        ''' <summary>
        ''' 到着日を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 到着日() As Date
            Set
                _到着日 = Value
            End Set
        End Property

        ''' <summary>
        ''' 宿泊数を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 宿泊数() As Integer
            Set
                _宿泊数 = Value
                If Value <= 0 Then _宿泊数 = 1
            End Set
        End Property

        ''' <summary>
        ''' 部屋数を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 部屋数() As Integer
            Set
                _部屋数 = Value
                Me.lbl部屋数.Text = Value.ToString()
            End Set
        End Property

        ''' <summary>
        ''' 施設名を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 施設名() As String
            Set
                Me.lbl施設名.Text = Value
            End Set
        End Property

        ''' <summary>
        ''' 部屋タイプ名を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 部屋タイプ名() As String
            Set
                Me.lbl部屋タイプ名.Text = Value
            End Set
        End Property

        ''' <summary>
        ''' プランCDを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property プランCD() As String
            Set
                _プランCD = Value
            End Set
        End Property

        ''' <summary>
        ''' プラン名称を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property プラン名称() As String
            Set(ByVal value As String)
                _プラン名称 = value
            End Set
        End Property

        ''' <summary>
        ''' 施設CDを設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 施設CD() As String
            Set
                _施設CD = Value
            End Set
        End Property

        ''' <summary>
        ''' 施設区分を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 施設区分() As String
            Set
                _施設区分 = Value
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

        ''' <summary>
        ''' 予約タイプ情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property 予約タイプ情報() As DataTable
            Set
                _予約タイプ情報 = Value
            End Set
        End Property

        ''' <summary>
        ''' プラン情報を設定します。
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public WriteOnly Property プラン情報() As DataRow
            Set
                _プラン情報 = Value
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

                'プラン名称は、予約データに保持している名称を使用する
                'Me.lblプラン名.Text = _プラン情報("プラン名称漢字")
                Me.lblプラン名.Text = _プラン名称
                If String.IsNullOrEmpty(_プラン名称) Then
                    Me.lblプラン名.Text = _プラン情報("プラン名称漢字")
                End If

                '宿泊日を編集します。
                Dim work As New StringBuilder
                work.Append(_到着日.ToString("yyyy年MM月dd日(ddd)"))

                If (_プラン情報("デイユース区分").Equals(CodeConst.C_デイユース区分_宿泊)) Then
                    work.Append("～")
                    work.Append(_到着日.AddDays(_宿泊数).ToString("yyyy年MM月dd日(ddd)"))
                End If

                Me.lbl宿泊日.Text = work.ToString()

                '申込人数を編集します。
                work.Remove(0, work.Length)
                For Each row As DataRow In _予約タイプ情報.Rows
                    If work.Length > 0 Then work.Append("<br>")
                    work.Append(row("タイプ連番")).Append("部屋目")
                    Me.Set人数(work, Convert.ToInt16(row("人数大人")) + Convert.ToInt16(row("ビジター人数大人")), "大人")

                    If _湯めぐり倶楽部区分.Equals(CodeConst.C_対象区分_対象) Then
                        Me.Set人数(work, Convert.ToInt16(row("人数こども1")) + Convert.ToInt16(row("ビジター人数こども1")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_小学生_大人に準じた食事))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども2")) + Convert.ToInt16(row("ビジター人数こども2")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_小学生_お子様の食事))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども3")) + Convert.ToInt16(row("ビジター人数こども3")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_幼児_食事･布団付))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども4")) + Convert.ToInt16(row("ビジター人数こども4")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分湯めぐり, CodeConst.C_こども表記区分湯めぐり_幼児_食事･布団不要))
                    ElseIf _施設区分.Equals(CodeConst.C_施設区分_ﾋﾞｼﾞﾈｽ) Then
                        Me.Set人数(work, Convert.ToInt16(row("人数こども1")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_小学生_布団付))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども2")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_小学生_布団無))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども3")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分ビジネス, CodeConst.C_こども表記区分ビジネス_幼児_3歳_布団付))
                    Else
                        Me.Set人数(work, Convert.ToInt16(row("人数こども1")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_小学生高学年))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども2")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_小学生低学年))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども3")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事･布団付))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども4")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事のみ))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども5")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_布団のみ))
                        Me.Set人数(work, Convert.ToInt16(row("人数こども6")), CodeCatalog.GetGuide(CodeCatalog.KEY_こども表記区分リゾート, CodeConst.C_こども表記区分リゾート_幼児_食事･布団不要))
                    End If
                Next
                Me.lbl申込人数.Text = work.ToString()

                Me.lbl食事条件.Text = CodeCatalog.GetGuide(CodeCatalog.KEY_食事条件区分, _プラン情報("食事条件区分"))

                'ポップアップの設定を行ないます。
                Me.hlkプラン内容.Visible = _isLinkVisible
                If _isLinkVisible Then
                    Dim param As New Dictionary(Of String, String)
                    param.Add(C_QS_施設CD  , _施設CD)
                    param.Add(C_QS_プランCD, _プランCD)
                    Me.hlkプラン内容.NavigateUrl = CType(Me.Page, BasePage).GetQueryStringURL("../PlanContent.aspx", param)
                End If

                If String.IsNullOrEmpty(_予約No) Then
                    Me.tr予約No.Visible = False
                Else
                    Me.tr予約No.Visible = True
                    Me.lbl予約No.Text = _予約No
                End If

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 人数の文字列を取得します。
        ''' </summary>
        ''' <param name="work"></param>
        ''' <param name="value"></param>
        ''' <param name="name"></param>
        ''' <remarks></remarks>
        Private Sub Set人数(ByRef work As StringBuilder, ByRef value As Short, ByRef name As String)

            If value > 0 Then
                work.Append("　")
                work.Append(name)
                work.Append("：")
                work.Append(value.ToString())
                work.Append("人")
            End If

            Return
        End Sub

    End Class

End NameSpace
