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

        public virtual MealCategory MealCategory { get; set; }
        [ForeignKey(nameof(MealCategory) )]
        [Display(Name = "Meal Category")]
        public int CategoryID { get; set; }

        public virtual Reference Reference { get; set; }
        [ForeignKey(nameof(Reference))]
        [Display(Name = "Cookbook Name")]
        public int ReferenceID { get; set; }

        public SkillLevel CookingLevel { get; set; }

        public enum SkillLevel
        {
            BeginnerFriendly,
            Intermediate,
            Advanced
        }

       
        //Social Media Link?

        
    }
}



