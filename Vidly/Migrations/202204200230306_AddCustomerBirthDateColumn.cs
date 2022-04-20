namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBirthDateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerBirthDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerBirthDate");
        }
    }
}
