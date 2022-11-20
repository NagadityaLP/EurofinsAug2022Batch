using KnowledgeHubPortalProject.Models.Data;
using Humanizer;
using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubPortalProject.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticlesRepository articlesRepo = null;// new ArticlesRepository();
        private ICategoriesRepository categoryRepo = null; // new CategoriesRepository();
        // GET: Articles

        public ArticlesController(IArticlesRepository articlesRepo, ICategoriesRepository categoryRepo)
        {
            this.articlesRepo = articlesRepo;
            this.categoryRepo = categoryRepo;
        }


        //Cache is used to reduce database hits and thereby increasing the performance
        [OutputCache(Duration = 30, VaryByParam = "data", Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Index(string data = null )
        {
            //ViewBag.Msg = TimeSpan.FromDays(1).Humanize();

            //fetch articles for browse
            List<Article> articles = new List<Article>();
            if (data == null)
                articles = articlesRepo.GetArticlesForBrowse();
            else
                articles = (from a in articlesRepo.GetArticlesForBrowse()
                            where a.Title.ToLower().Contains(data.ToLower()) || a.Description.ToLower().Contains(data.ToLower()) 
                            || a.Category.Name.ToLower().Contains(data.ToLower()) || a.Category.Description.ToLower().Contains(data.ToLower())
                            select a).ToList();

            return View(articles);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Submit()
        {
            //fetch all categories
            //var categories = categoryRepo.GetCategories(); - use this for normal select
            var categories = from c in categoryRepo.GetCategories()
                             select new SelectListItem { Text = c.Name, Value = c.CategoryID.ToString() }; // use this for html helper select
            ViewBag.CategoryID = categories; //ViewBag name should match the table attribute name
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Submit(Article article)
        {
            if (!ModelState.IsValid)
                return View();
            article.IsApproved = false;
            article.DateSubmited = DateTime.Now;
            article.PostedBy = User.Identity.Name;

            articlesRepo.Submit(article);
            TempData["Message"] = $"Article {article.Title} submitted successfully and notified to administrator for review";

            return RedirectToAction("Submit");
        }

        public ActionResult Browse(int id)
        {
            List<Article> articles = articlesRepo.GetArticlesForBrowse();
            return View(articles);
        }
        [ChildActionOnly]
        public ActionResult CategoryHyperlinks()
        {
            var categories = categoryRepo.GetCategories();
            return PartialView(categories);
        }

        // [Authorize]
        //[Authorize(Users = "abcd,bmga")]
        [Authorize(Roles = "admin")]
        public ActionResult Review()
        {
            var articlesForReview = articlesRepo.GetArticlesForReview();
            return View(articlesForReview);
        }

        [Authorize]
        public ActionResult Approve(List<int> articleIds)
        {
            articlesRepo.Approve(articleIds);
            TempData["Message"] = $"{articleIds.Count} articles approved";
            //TODO : send mail notifications to article author
            return RedirectToAction("Review");
        }
        
        
        [Authorize]
        public ActionResult Reject(List<int> articleIds)
        {
            articlesRepo.Reject(articleIds);
            TempData["Message"] = $"{articleIds.Count} articles rejected";
            //TODO : send mail notifications to article author
            return RedirectToAction("Review");
        }
    }
}