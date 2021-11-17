using MyFavoriteRecipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFavoriteRecipe.WebMVC.Controllers
{
    [Authorize]
    public class MealCategoryController : Controller
    {
        // GET: MealCategory
        public ActionResult Index()
        {
            var model = new MealCategoryList[0];
            return View(model);
        }
    }
}