using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFavoriteRecipe.WebMVC.Startup))]
namespace MyFavoriteRecipe.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
