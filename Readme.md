# How to use the CheckBoxList and RadioButtonList editors to edit Model fields


<p>This example illustrates how to edit Model fields with different DevExpress MVC Editors.</p><p>Here are main requirements:<br />
- The <strong>editor's Name</strong> property should be equal to the corresponding Model field;<br />
- The <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcDevExpressEditorsBinderMembersTopicAll"><u>DevExpressEditorsBinder</u></a> should be used for retrieving Model fields from corresponding Editors.</p><p>The CheckBoxList Extension is used in an <strong>Unbound</strong> mode and bound with the specific Model field manually (with custom code):<br />
The <strong>CheckBoxListSettings.PreRender</strong> handler/delegate is used for specifying multiple selected Items based on the enumerable Model field;<br />
The <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcCheckBoxListExtension_GetSelectedValues[T]topic"><u>CheckBoxListExtension.GetSelectedValues<T></u></a> is used for retrieving multiple selected Items on the Controller side.</p>

<br/>


