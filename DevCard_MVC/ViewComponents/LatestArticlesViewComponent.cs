using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevCard_MVC.ViewComponents {
    public class LatestArticlesViewComponent: ViewComponent {
        public IViewComponentResult Invoke() {
            var articles = new List<Article> {
                new Article(1, "آموزش Asp.net Core Mvc", "کاملترین پکیج آموزش Asp .net core", "blog-post-thumb-card-1.jpg"),
                new Article(1, "آموزش Git", "کاملترین پکیج آموزش Git", "blog-post-thumb-card-2.jpg"),
                new Article(1, "آموزش Onion Architecture", "کاملترین پکیج آموزش Onion Architecture", "blog-post-thumb-card-3.jpg"),
                new Article(1, "آموزش طراحی سایت", "کاملترین پکیج آموزش طراحی سایت", "blog-post-thumb-card-4.jpg"),
            };
            return View("_LatestArticles", articles);
        }
    }
}
