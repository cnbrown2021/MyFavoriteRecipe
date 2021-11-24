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
    public class RecipesService
    {
        public bool CreateRecipes(RecipesCreate recipes)
        {
            var content = new Recipes()
            {
                RecipeName = recipes.RecipeName,
                Ingredients = recipes.Ingredients,
                CookingInstructions = recipes.CookingInstructions,
                CategoryName = recipes.CategoryName,
                CookbookName = recipes.CookbookName,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipe.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipesList> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Recipe
                    .Select(r => new RecipesList
                    {
                        RecipeID = r.RecipeID,
                        RecipeName = r.RecipeName,
                        Ingredients = r.Ingredients,
                        CategoryName = r.CategoryName,
                        CookbookName = r.CookbookName
                    });
                return query.ToArray();
            }
        }

        public RecipesDetail GetRecipesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Recipe.Single(r => r.RecipeID == id);

                return new RecipesDetail
                {
                    RecipeID = content.RecipeID,
                    RecipeName = content.RecipeName,
                    Ingredients = content.Ingredients,
                    CookingInstructions = content.CookingInstructions,
                    CategoryName = content.CategoryName,
                    CookbookName = content.CookbookName,
                };
            }
        }
    }
}
