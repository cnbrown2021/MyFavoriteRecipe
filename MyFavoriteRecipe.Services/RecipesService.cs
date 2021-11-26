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
                ctx.Recipess.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipesList> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Recipess
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
                var content = ctx.Recipess.Single(r => r.RecipeID == id);

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
                var content = ctx.Recipess.Single(r => r.RecipeName == recipes.RecipeName);

                content.RecipeName = recipes.RecipeName;
                content.Ingredients = recipes.Ingredients;
                content.CookingInstructions = recipes.CookingInstructions;
                content.CategoryID = recipes.CategoryID;
                content.ReferenceID = recipes.ReferenceID;

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteRecipes(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var content = ctx.Recipess.Single(r => r.RecipeID == recipeId);

                ctx.Recipess.Remove(content);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
