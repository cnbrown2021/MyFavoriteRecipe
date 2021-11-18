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

        // GET byId
        public MealCategoryDetail GetMealCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.MealCategories.Single(c => c.CategoryID == id);

                return new MealCategoryDetail
                {
                    CategoryID = content.CategoryID,
                    CategoryName = content.CategoryName,
                    CategoryDescription = content.CategoryDescription
                };
            }
        }
         
        // UPDATE
        public bool UpdateMealCategory(MealCategoryEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.MealCategories.Single(c => c.CategoryName == category.CategoryName);

                content.CategoryName = category.CategoryName;
                content.CategoryDescription = category.CategoryDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteMealCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.MealCategories.Single(c => c.CategoryID == categoryId);

                ctx.MealCategories.Remove(content);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

