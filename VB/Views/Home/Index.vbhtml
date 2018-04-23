@ModelType VB.MyModel
@Using (Html.BeginForm())

    @<b>Automatically Bound Field - TextBox</b>
    @<br />
    @<br />
    
    @Html.DevExpress().TextBox( _
        Sub(settings)
            settings.Name = "Name"
        End Sub).Bind(Model.Name).GetHtml()
    
    @<br />
    @<br />
    @<br />

    @<b>Automatically Bound Field - RadioButtonList (single select)</b>
    @<br />
    @<br />
        
    @Html.DevExpress().RadioButtonList( _
        Sub(settings)
            settings.Name = "Language"
            settings.Properties.ValueField = "ID"
            settings.Properties.TextField = "Name"
            settings.Properties.ValueType = GetType(Integer)
            settings.Properties.RepeatLayout = System.Web.UI.WebControls.RepeatLayout.Table
            settings.Properties.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal
            settings.Properties.RepeatColumns = 5
        End Sub).BindToXML(HttpContext.Current.Server.MapPath("~/App_Data/Languages.xml"), "//Language").Bind(Model.Language).GetHtml()

    @Html.DevExpress().Button( _
        Sub(settings)
            settings.Name = "btnUnselectRadioButtonList"
            settings.Text = "Unselect All"
            settings.ClientSideEvents.Click = "function(s, e) { Language.SetValue(null); }"
        End Sub).GetHtml()
  
    @<br />
    @<br />
    @<br />
    
    @<b>Manually Bound Field - CheckBoxList (multi select)</b>
    @<br />
    @<br />
        
    @Html.DevExpress().CheckBoxList( _
        Sub(settings)
            settings.Name = "ProgLanguagesUnbound"
            settings.Properties.ValueField = "ID"
            settings.Properties.TextField = "Name"
            settings.Properties.ValueType = GetType(Integer)
            settings.Properties.RepeatLayout = System.Web.UI.WebControls.RepeatLayout.Table
            settings.Properties.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal
            settings.Properties.RepeatColumns = 5
            settings.PreRender = _
                Sub(sender, e)
                    Dim cbl As ASPxCheckBoxList = CType(sender, ASPxCheckBoxList)
                    For Each item As ListEditItem In cbl.Items
                        item.Selected = Model.ProgLanguages.Contains(CInt(Fix(item.Value)))
                    Next item
                End Sub
        End Sub).BindList(ViewData("ProgLanguageItems")).GetHtml()

    @<table>
        <tr>
            <td>
                @Html.DevExpress().Button( _
                    Sub(settings)
                        settings.Name = "btnSelectCheckBoxList"
                        settings.Text = "Select All"
                        settings.ClientSideEvents.Click = "function(s, e) { ProgLanguagesUnbound.SelectAll(); }"
                    End Sub).GetHtml()
            </td>
            <td>
                @Html.DevExpress().Button( _
                    Sub(settings)
                        settings.Name = "btnUnselectCheckBoxList"
                        settings.Text = "Unselect All"
                        settings.ClientSideEvents.Click = "function(s, e) { ProgLanguagesUnbound.UnselectAll(); }"
                    End Sub).GetHtml()
            </td>
        </tr>
    </table>
    
    @<br />

    @Html.DevExpress().Button( _
        Sub(settings)
            settings.Name = "btnSubmit"
            settings.UseSubmitBehavior = True
            settings.Text = "Submit"
        End Sub).GetHtml()

End Using