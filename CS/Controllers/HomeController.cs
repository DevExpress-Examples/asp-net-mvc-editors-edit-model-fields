using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using DevExpress.Web.Mvc;

namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            MyModel model = new MyModel() {
                Name = "User Name",
                Language = 14,
                ProgLanguages = new int[] { 10, 12, 14 }
            };

            ViewData["ProgLanguageItems"] = GetProgLanguageItems();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(DevExpressEditorsBinder))] MyModel model) {
            //Manually Bound Field - CheckBoxList (multi select)
            model.ProgLanguages = CheckBoxListExtension.GetSelectedValues<int>("ProgLanguagesUnbound");

            TempData["PostedModel"] = model;
            return RedirectToAction("Success");
        }

        public ActionResult Success() {
            return View(TempData["PostedModel"]);
        }

        private IList GetProgLanguageItems() {
            List<CheckBoxListItemObject> items = new List<CheckBoxListItemObject>();
            XDocument document = XDocument.Load(Server.MapPath("~/App_Data/ProgLanguages.xml"));
            foreach(var item in document.Root.Elements("ProgLanguage")) {
                items.Add(new CheckBoxListItemObject() {
                    ID = Convert.ToInt32(item.Attribute("ID").Value),
                    Name = (string)item.Attribute("Name").Value
                });
            }

            return items;
        }
    }
    
    public class MyModel {
        public string Name { get; set; }
        public int? Language { get; set; }
        public int[] ProgLanguages { get; set; }
    }

    public class CheckBoxListItemObject {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
