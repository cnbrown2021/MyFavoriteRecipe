using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipes.Model
{
    public class RecipesCreate
    {
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string CookingInstructions { get; set; }
        public int CategoryID { get; set; }
        public int ReferenceID { get; set; }
        enum SkillLevel
        {
            BeginnerFriendly,
            Intermediate,
            Advanced
        }
    }
}
