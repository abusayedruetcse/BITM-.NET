namespace SBMSystemMVCApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierUpdated1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String());
        }
    }
}
