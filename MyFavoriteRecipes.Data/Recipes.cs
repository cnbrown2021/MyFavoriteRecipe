using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipes.Data
{
    public class Recipes
    {
        [Key]
        public int RecipeID { get; set; }
        [Required]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        [Required]
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; }
        [Required]
        [Display(Name = "Instructions")]
        public string CookingInstructions { get; set; }

        [ForeignKey(nameof(MealCategory) )]
        public int CategoryID { get; set; }

        [ForeignKey(nameof(Reference))]
        public int ReferenceID { get; set; }

        public enum SkillLevel
        {
            BeginnerFriendly,
            Intermediate,
            Advanced
        }

        
        //Social Media Link?

        //Navigation
        public virtual Reference Reference { get; set; }
        public virtual MealCategory MealCategory { get; set; }
    }
}



