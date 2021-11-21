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
    public class ReferenceService
    {
        //Create
        public bool CreateReference(ReferenceCreate reference)
        {
            var content = new Reference()
            {
                CookbookName = reference.CookbookName,
                CookbookAuthor = reference.CookbookAuthor
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.References.Add(content);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReferenceList> GetReferences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.References
                    .Select(r => new ReferenceList
                    {
                        ReferenceID = r.ReferenceID,
                        CookbookName = r.CookbookName,
                        CookbookAuthor = r.CookbookAuthor
                    });
                return query.ToArray();
            }
        }
    }
}
