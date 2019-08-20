namespace SBMSystemMVCApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Contact", c => c.String());
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.Suppliers", "Code", c => c.String());
        }
    }
}
