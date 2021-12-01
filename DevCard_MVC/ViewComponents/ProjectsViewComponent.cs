using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevCard_MVC.ViewComponents {
    public class ProjectsViewComponent: ViewComponent {
        public IViewComponentResult Invoke() {
            var projects = new List<Project> {
                new Project(1, "تاکسی", "درخواست تاکسی","project-1.jpg", "Amir"),
                new Project(2, "زودفود", "درخواست غذا","project-2.jpg", "keshtkar"),
                new Project(3, "مدارس", "سیستم مدارس","project-3.jpg", "Amirhossein"),
                new Project(4, "فضاپیما", "مدیریت فضاپیما","project-4.jpg", "hawkeye"),
            };
            return View("_Projects", projects);
        }
    }
}
