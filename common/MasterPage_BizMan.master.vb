Imports Com.Fujitsu.Hotespa.Framework.Utility
Imports Com.Fujitsu.Hotespa.WebFramework.Utility
Imports Com.Fujitsu.Hotespa.Web.Common

NameSpace Com.Fujitsu.Hotespa.Web.User.Common

    Partial Class MasterPage_BizMan
        Inherits System.Web.UI.MasterPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                Dim page_css As HtmlLink = New HtmlLink
                page_css.Attributes("rel") = "stylesheet"
                page_css.Attributes("type") = "text/css"

                Dim metaDescript As HtmlMeta = New HtmlMeta
                Dim metaKeywords As HtmlMeta = New HtmlMeta
                metaDescript.Name = "description"
                metaKeywords.Name = "keywords"

                Dim title As HtmlTitle = New HtmlTitle
                title.Text = "ドーミーイン【公式】 | 出張・温泉旅行・一人旅のホテル予約"

                'スタイルシートの追加
                page_css.Href = "../BizMan/css/members_form.css"
                Me.Page.Header.Controls.Add(page_css)

                'タイトルタグ作成
                title.Text = "ビジネスマン応援プラン"
                Me.Page.Header.Controls.Add(title)

                'autocompleteを外す

                Return
            Catch ex As Exception
                CType(Me.Page, BasePage).ExceptionProcess(ex)
            End Try
        End Sub

    End Class

End NameSpace

