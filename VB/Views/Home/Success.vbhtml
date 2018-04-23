@ModelType VB.MyModel

<h2>Data is successufully submitted:</h2>

Name: @Model.Name
<br />
<br />
Language: @Model.Language
<br />
ProgLanguages:
<ul>
@For Each item As Integer In Model.ProgLanguages
    @<li>@item</li>
Next item
</ul>                     
<br />
<br />
<br />
@Html.ActionLink("Reload Demo", "Index")