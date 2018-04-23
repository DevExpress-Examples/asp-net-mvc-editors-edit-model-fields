Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports System.Xml.Linq
Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits Controller
    Public Function Index() As ActionResult
        Dim model As New MyModel() With {.Name = "User Name", .Language = 14, .ProgLanguages = New Integer() {10, 12, 14}}

        ViewData("ProgLanguageItems") = GetProgLanguageItems()

        Return View(model)
    End Function

    <HttpPost()> _
    Public Function Index(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal model As MyModel) As ActionResult
        'Manually Bound Field - CheckBoxList (multi select)
        model.ProgLanguages = CheckBoxListExtension.GetSelectedValues(Of Integer)("ProgLanguagesUnbound")

        TempData("PostedModel") = model
        Return RedirectToAction("Success")
    End Function

    Public Function Success() As ActionResult
        Return View(TempData("PostedModel"))
    End Function

    Private Function GetProgLanguageItems() As IList
        Dim items As List(Of CheckBoxListItemObject) = New List(Of CheckBoxListItemObject)()
        Dim document As XDocument = XDocument.Load(Server.MapPath("~/App_Data/ProgLanguages.xml"))
        For Each item In document.Root.Elements("ProgLanguage")
            items.Add(New CheckBoxListItemObject() With {.ID = Convert.ToInt32(item.Attribute("ID").Value), .Name = CStr(item.Attribute("Name").Value)})
        Next item

        Return items
    End Function
End Class

Public Class MyModel
    Private privateName As String
    Public Property Name() As String
        Get
            Return privateName
        End Get
        Set(ByVal value As String)
            privateName = value
        End Set
    End Property
    Private privateLanguage As Nullable(Of Integer)
    Public Property Language() As Nullable(Of Integer)
        Get
            Return privateLanguage
        End Get
        Set(ByVal value As Nullable(Of Integer))
            privateLanguage = value
        End Set
    End Property
    Private privateProgLanguages As Integer()
    Public Property ProgLanguages() As Integer()
        Get
            Return privateProgLanguages
        End Get
        Set(ByVal value As Integer())
            privateProgLanguages = value
        End Set
    End Property
End Class

Public Class CheckBoxListItemObject
    Private privateID As Integer
    Public Property ID() As Integer
        Get
            Return privateID
        End Get
        Set(ByVal value As Integer)
            privateID = value
        End Set
    End Property
    Private privateName As String
    Public Property Name() As String
        Get
            Return privateName
        End Get
        Set(ByVal value As String)
            privateName = value
        End Set
    End Property
End Class