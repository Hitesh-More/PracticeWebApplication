namespace PracticeWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountViewModels2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserPhoto");
        }
    }
}
