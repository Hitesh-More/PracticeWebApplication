namespace PracticeWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInMappingClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MappingClass",
                c => new
                    {
                        MappingId = c.Long(nullable: false, identity: true),
                        CourseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MappingId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MappingClass", "CourseId", "dbo.Course");
            DropIndex("dbo.MappingClass", new[] { "CourseId" });
            DropTable("dbo.MappingClass");
        }
    }
}
