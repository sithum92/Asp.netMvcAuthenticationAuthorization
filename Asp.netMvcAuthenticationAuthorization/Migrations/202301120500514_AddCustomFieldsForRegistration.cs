namespace Asp.netMvcAuthenticationAuthorization.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomFieldsForRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StaffNo", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NIC", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Mobile", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Notes", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Notes");
            DropColumn("dbo.AspNetUsers", "JoinDate");
            DropColumn("dbo.AspNetUsers", "Mobile");
            DropColumn("dbo.AspNetUsers", "NIC");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "StaffNo");
        }
    }
}
