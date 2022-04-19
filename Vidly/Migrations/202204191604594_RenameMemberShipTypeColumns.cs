namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMemberShipTypeColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "signUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "signUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
