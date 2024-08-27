using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecount.kjd.Project1.Controllers
{
    public class StudyController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Select(Person person)
        {
            var head = this.HttpContext.Request.Headers;
            var nameIsJaehee = person.Name == "재희";
            var result = new { isSuccess = true, message = "Success" };

            return Json(result);
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}