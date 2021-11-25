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
                CategoryID = recipes.CategoryID,
                ReferenceID = recipes.ReferenceID,
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
                        CategoryID = r.CategoryID,
                        ReferenceID = r.ReferenceID
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
                    CategoryID = content.CategoryID,
                    ReferenceID = content.ReferenceID,
                };
            }
        }

        public bool UpdateRecipes(RecipesEdit recipes)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Recipe.Single(r => r.RecipeName == recipes.RecipeName);

                content.RecipeName = recipes.RecipeName;
                content.Ingredients = recipes.Ingredients;
                content.CookingInstructions = recipes.CookingInstructions;

                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}
