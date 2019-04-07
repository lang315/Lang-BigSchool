namespace Lang_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LecturerID = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CategroyID = c.Byte(nullable: false),
                        Category_ID = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerID, cascadeDelete: true)
                .Index(t => t.LecturerID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_ID" });
            DropIndex("dbo.Courses", new[] { "LecturerID" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
