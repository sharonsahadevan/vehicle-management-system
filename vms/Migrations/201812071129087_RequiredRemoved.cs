namespace vms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredRemoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "OtherExpenses", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Trips", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Trips", "OtherExpenses", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
