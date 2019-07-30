<!-- default file list -->
*Files to look at*:

* [Languages.xml](./CS/App_Data/Languages.xml) (VB: [Languages.xml](./VB/App_Data/Languages.xml))
* [ProgLanguages.xml](./CS/App_Data/ProgLanguages.xml) (VB: [ProgLanguages.xml](./VB/App_Data/ProgLanguages.xml))
* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [Success.cshtml](./CS/Views/Home/Success.cshtml)
<!-- default file list end -->
# How to use the CheckBoxList and RadioButtonList editors to edit Model fields
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4125/)**
<!-- run online end -->


<p>This example illustrates how to edit Model fields with different DevExpress MVC Editors.</p><p>Here are main requirements:<br />
- The <strong>editor's Name</strong> property should be equal to the corresponding Model field;<br />
- The <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcDevExpressEditorsBinderMembersTopicAll"><u>DevExpressEditorsBinder</u></a> should be used for retrieving Model fields from corresponding Editors.</p><p>The CheckBoxList Extension is used in an <strong>Unbound</strong> mode and bound with the specific Model field manually (with custom code):<br />
The <strong>CheckBoxListSettings.PreRender</strong> handler/delegate is used for specifying multiple selected Items based on the enumerable Model field;<br />
The <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcCheckBoxListExtension_GetSelectedValues[T]topic"><u>CheckBoxListExtension.GetSelectedValues<T></u></a> is used for retrieving multiple selected Items on the Controller side.</p>

<br/>


