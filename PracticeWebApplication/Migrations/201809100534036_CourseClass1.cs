namespace PracticeWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseClass1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "CourseClass_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.CourseClasses", "Course_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.AspNetUserLogins", "CourseClass_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.AspNetUserRoles", "CourseClass_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.AspNetUserClaims", "StudentDataClass_Id", "dbo.StudentDataClasses");
            DropForeignKey("dbo.AspNetUserLogins", "StudentDataClass_Id", "dbo.StudentDataClasses");
            DropForeignKey("dbo.AspNetUserRoles", "StudentDataClass_Id", "dbo.StudentDataClasses");
            DropForeignKey("dbo.StudentDataClasses", "StudentData_Id", "dbo.StudentDataClasses");
            DropForeignKey("dbo.AspNetUserClaims", "SubjectClass_Id", "dbo.SubjectClasses");
            DropForeignKey("dbo.AspNetUserLogins", "SubjectClass_Id", "dbo.SubjectClasses");
            DropForeignKey("dbo.AspNetUserRoles", "SubjectClass_Id", "dbo.SubjectClasses");
            DropForeignKey("dbo.SubjectClasses", "Subject_Id", "dbo.SubjectClasses");
            DropForeignKey("dbo.AspNetUserClaims", "TeacherDataClass_Id", "dbo.TeacherDataClasses");
            DropForeignKey("dbo.AspNetUserLogins", "TeacherDataClass_Id", "dbo.TeacherDataClasses");
            DropForeignKey("dbo.AspNetUserRoles", "TeacherDataClass_Id", "dbo.TeacherDataClasses");
            DropForeignKey("dbo.TeacherDataClasses", "TeacherData_Id", "dbo.TeacherDataClasses");
            DropIndex("dbo.CourseClasses", new[] { "Course_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "CourseClass_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "StudentDataClass_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "SubjectClass_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "TeacherDataClass_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "CourseClass_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "StudentDataClass_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "SubjectClass_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "TeacherDataClass_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "CourseClass_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "StudentDataClass_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "SubjectClass_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "TeacherDataClass_Id" });
            DropIndex("dbo.StudentDataClasses", new[] { "StudentData_Id" });
            DropIndex("dbo.SubjectClasses", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherDataClasses", new[] { "TeacherData_Id" });
            DropColumn("dbo.AspNetUserClaims", "CourseClass_Id");
            DropColumn("dbo.AspNetUserClaims", "StudentDataClass_Id");
            DropColumn("dbo.AspNetUserClaims", "SubjectClass_Id");
            DropColumn("dbo.AspNetUserClaims", "TeacherDataClass_Id");
            DropColumn("dbo.AspNetUserLogins", "CourseClass_Id");
            DropColumn("dbo.AspNetUserLogins", "StudentDataClass_Id");
            DropColumn("dbo.AspNetUserLogins", "SubjectClass_Id");
            DropColumn("dbo.AspNetUserLogins", "TeacherDataClass_Id");
            DropColumn("dbo.AspNetUserRoles", "CourseClass_Id");
            DropColumn("dbo.AspNetUserRoles", "StudentDataClass_Id");
            DropColumn("dbo.AspNetUserRoles", "SubjectClass_Id");
            DropColumn("dbo.AspNetUserRoles", "TeacherDataClass_Id");
            DropTable("dbo.CourseClasses");
            DropTable("dbo.StudentDataClasses");
            DropTable("dbo.SubjectClasses");
            DropTable("dbo.TeacherDataClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherDataClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        TeacherData_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Subject_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentDataClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        StudentData_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "TeacherDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "SubjectClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "StudentDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "CourseClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "TeacherDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "SubjectClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "StudentDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "CourseClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "TeacherDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "SubjectClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "StudentDataClass_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "CourseClass_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TeacherDataClasses", "TeacherData_Id");
            CreateIndex("dbo.SubjectClasses", "Subject_Id");
            CreateIndex("dbo.StudentDataClasses", "StudentData_Id");
            CreateIndex("dbo.AspNetUserRoles", "TeacherDataClass_Id");
            CreateIndex("dbo.AspNetUserRoles", "SubjectClass_Id");
            CreateIndex("dbo.AspNetUserRoles", "StudentDataClass_Id");
            CreateIndex("dbo.AspNetUserRoles", "CourseClass_Id");
            CreateIndex("dbo.AspNetUserLogins", "TeacherDataClass_Id");
            CreateIndex("dbo.AspNetUserLogins", "SubjectClass_Id");
            CreateIndex("dbo.AspNetUserLogins", "StudentDataClass_Id");
            CreateIndex("dbo.AspNetUserLogins", "CourseClass_Id");
            CreateIndex("dbo.AspNetUserClaims", "TeacherDataClass_Id");
            CreateIndex("dbo.AspNetUserClaims", "SubjectClass_Id");
            CreateIndex("dbo.AspNetUserClaims", "StudentDataClass_Id");
            CreateIndex("dbo.AspNetUserClaims", "CourseClass_Id");
            CreateIndex("dbo.CourseClasses", "Course_Id");
            AddForeignKey("dbo.TeacherDataClasses", "TeacherData_Id", "dbo.TeacherDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "TeacherDataClass_Id", "dbo.TeacherDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "TeacherDataClass_Id", "dbo.TeacherDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "TeacherDataClass_Id", "dbo.TeacherDataClasses", "Id");
            AddForeignKey("dbo.SubjectClasses", "Subject_Id", "dbo.SubjectClasses", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "SubjectClass_Id", "dbo.SubjectClasses", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "SubjectClass_Id", "dbo.SubjectClasses", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "SubjectClass_Id", "dbo.SubjectClasses", "Id");
            AddForeignKey("dbo.StudentDataClasses", "StudentData_Id", "dbo.StudentDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "StudentDataClass_Id", "dbo.StudentDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "StudentDataClass_Id", "dbo.StudentDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "StudentDataClass_Id", "dbo.StudentDataClasses", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "CourseClass_Id", "dbo.CourseClasses", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "CourseClass_Id", "dbo.CourseClasses", "Id");
            AddForeignKey("dbo.CourseClasses", "Course_Id", "dbo.CourseClasses", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "CourseClass_Id", "dbo.CourseClasses", "Id");
        }
    }
}
