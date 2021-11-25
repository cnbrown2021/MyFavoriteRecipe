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
        public int CategoryID { get; set; }
        public int ReferenceID { get; set; }
        public SkillLevel CookingLevel { get; set; }
        public enum SkillLevel
        {
            Beginner,
            Intermediate,
            Advanced
        }

        public List<MealCategoryList> Categories { get; set; }
        public List<ReferenceList> References { get; set; }
    }
}



