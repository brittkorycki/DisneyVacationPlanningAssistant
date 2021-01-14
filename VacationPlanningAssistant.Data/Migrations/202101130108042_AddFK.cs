namespace VacationPlanningAssistant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accommodation", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Accommodation", new[] { "Id" });
            AlterColumn("dbo.Accommodation", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Accommodation", "Id");
            AddForeignKey("dbo.Accommodation", "Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accommodation", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Accommodation", new[] { "Id" });
            AlterColumn("dbo.Accommodation", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Accommodation", "Id");
            AddForeignKey("dbo.Accommodation", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
