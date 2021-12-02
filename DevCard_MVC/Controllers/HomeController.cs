using DevCard_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DevCard_MVC.Data;

namespace DevCard_MVC.Controllers {
    //[Route("/inventory/products")]
    public class HomeController: Controller {
        private readonly List<Service> _services = new List<Service> {
            new Service(1, "نقره ای"),
            new Service(2, "طلایی"),
            new Service(3, "پلاتین"),
            new Service(4, "الماس"),
        };
        //[Route("Index/{name:int}/{model}")]
        public IActionResult Index() {
            return View();
        }

        public IActionResult ProjectDetails(long id){
            var project = ProjectStore.GetProjectBy(id);
            return View(project);
        }

        //[HttpGet("contactPage")]
        public IActionResult Contact(int id) {
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
