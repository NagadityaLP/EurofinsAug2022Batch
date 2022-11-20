using KnowledgeHubPortalProject.Models;
using KnowledgeHubPortalProject.Models.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using Category = KnowledgeHubPortalProject.Models.Entities.Category;

namespace KnowledgeHubPortalProject.Controllers
{
    [Authorize(Roles = "admin")]

    public class CategoriesController : Controller
    {

        //private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        private ICategoriesRepository repo = null;// new CategoriesRepository();


        public CategoriesController(ICategoriesRepository repo)
        {
            this.repo = repo;
        }
        
        // GET: Categories
        // ...../Categories/index  - List categories
        [AllowAnonymous]
        public ActionResult Index()
        {
            //fetch the categories information from  the model
            //var categories = db.Categories.ToList();
            var categories = repo.GetCategories();

            // ViewBag.Categories = categories;
            //ViewData["Categories"] = categories;
            //TempData["Categories"] = categories;

            //pass the data into view
            return View(categories );
        }

        //Create category
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Category category)
        {
            //validate
            if (!ModelState.IsValid)
                return View("Create");
            //db.Categories.Add(category);
            //db.SaveChanges();
            repo.Create(category);
            TempData["Message"] = $"Category {category.Name} Successfully Created";
            return RedirectToAction("Index");
        }

        //Asychronous function - It's just a convention to name the function ending with Asych - not mandatory
       
        public async Task<ActionResult> SaveAsynch(Category category)
        {
            //validate
            if (!ModelState.IsValid)
                return View("Create");
            //db.Categories.Add(category);
            //db.SaveChanges();
            await repo.CreateAsync(category);
            TempData["Message"] = $"Category {category.Name} Successfully Created";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View("Delete");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var categoryToDelete = repo.GetCategory(id);
            repo.Delete(id);
            //db.Categories.Remove(categoryToDelete);
            //db.SaveChanges();
            TempData["Message"] = $"Category {categoryToDelete.Name} Successfully Deleted";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var categoryToEdit = db.Categories.Find(id);
            var categoryToEdit = repo.GetCategory(id);
            return View(categoryToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View();
            //db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            repo.Update(category);
            TempData["Message"] = $"Category {category.Name} Successfully Modified";
            return RedirectToAction("Index");
        }
    }
}