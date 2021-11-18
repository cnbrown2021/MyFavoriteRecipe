using MyFavoriteRecipe.WebMVC.Models;
using MyFavoriteRecipes.Data;
using MyFavoriteRecipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipe.Services
{
    public class MealCategoryService
    {
        // Create
        public bool CreateMealCategory(MealCategoryCreate category)
        {
            var content = new MealCategory()
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MealCategories.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET
        public IEnumerable<MealCategoryList> GetMealCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.MealCategories
                    .Select(c => new MealCategoryList
                    {
                        CategoryID = c.CategoryID,
                        CategoryName = c.CategoryName
                    });
                return query.ToArray();
            }
        }

        // GET ByName
         
    }
}
