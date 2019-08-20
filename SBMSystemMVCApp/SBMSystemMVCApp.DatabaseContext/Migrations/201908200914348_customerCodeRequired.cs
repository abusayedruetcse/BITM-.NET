namespace SBMSystemMVCApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerCodeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Code", c => c.String());
        }
    }
}
