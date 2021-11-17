using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipes.Model
{
    public class MealCategoryCreate
    {
        [Required]
        [MinLength(3, ErrorMessage ="Please enter at least 3 characters.")]
        [MaxLength(30, ErrorMessage = "There are too many characters in this field.")]
        public string CategoryName { get; set; }
        [MaxLength(100)]
        public string CategoryDescription { get; set; }
    }
}

