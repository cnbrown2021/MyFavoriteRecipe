using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipes.Model
{
    public class RecipesDetail
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string CookingInstructions { get; set; }
        public string CategoryName { get; set; }
        public string CookbookName { get; set; }
        public enum SkillLevel
        {
            BeginnerFriendly,
            Intermediate,
            Advanced
        }
    }
}

