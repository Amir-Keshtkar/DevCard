using DevCard_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DevCard_MVC.Controllers {
    public class HomeController: Controller {
        private readonly List<Service> _services = new List<Service> {
            new Service(1, "نقره ای"),
            new Service(2, "طلایی"),
            new Service(3, "پلاتین"),
            new Service(4, "الماس"),
        };
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Contact() {
            var model = new Contact {
                Services = new SelectList(_services, "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        //public JsonResult Contact(IFormCollection form) {
        //    var name = form["name"];
        //    return Json(Ok());
        //}
        public IActionResult Contact(Contact model) {
            model.Services = new SelectList(_services, "Id", "Name");
            if(!ModelState.IsValid) {
                ViewBag.error = "اطلاعات وارد شده صحیح نیست دوباره تلاش کنید";
                return View(model);
            }
            ModelState.Clear();
            model = new Contact {
                Services = new SelectList(_services, "Id", "Name")
            };
            ViewBag.success = "فرم شما با موفقیت ارسال شد. با تشکر";
            return View(model);
            //return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
