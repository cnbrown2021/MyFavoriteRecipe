using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteRecipes.Data
{
    public class Reference
    {
        [Key]
        public int ReferenceID { get; set; }
        [Required]
        public string CookbookName { get; set; }
        [Required]
        public string CookbookAuthor { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }

        //public bool IsThisAWebsite { get; set; }

    }
}


