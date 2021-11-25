namespace MyFavoriteRecipes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CookingLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "CookingLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "CookingLevel");
        }
    }
}
