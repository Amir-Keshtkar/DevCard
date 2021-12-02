using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevCard_MVC.Models; 

namespace DevCard_MVC.Data {
    public class ProjectStore {
        public static List<Project> GetProjects() {
            return new List<Project> {
                new Project(1, "تاکسی", "درخواست تاکسی","project-1.jpg", "Amir"),
                new Project(2, "زودفود", "درخواست غذا","project-2.jpg", "keshtkar"),
                new Project(3, "مدارس", "سیستم مدارس","project-3.jpg", "Amirhossein"),
                new Project(4, "فضاپیما", "مدیریت فضاپیما","project-4.jpg", "hawkeye"),
            };
        }

        public static Project GetProjectBy(long id){
            return GetProjects().FirstOrDefault(project => id==project.Id);
        }
    }
}
