﻿using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DevCard_MVC.Data;

namespace DevCard_MVC.ViewComponents {
    public class ProjectsViewComponent: ViewComponent {
        public IViewComponentResult Invoke() {
            var projects = ProjectStore.GetProjects();
            return View("_Projects", projects);
        }
    }
}
