namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerBirthDateColumnDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerBirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerBirthDate", c => c.String());
        }
    }
}
