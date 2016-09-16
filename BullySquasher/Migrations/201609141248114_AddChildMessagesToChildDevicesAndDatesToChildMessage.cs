namespace BullySquasher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChildMessagesToChildDevicesAndDatesToChildMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChildMessages", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ChildMessages", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.ChildMessages", "DateDeleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChildMessages", "DateDeleted");
            DropColumn("dbo.ChildMessages", "DateModified");
            DropColumn("dbo.ChildMessages", "DateCreated");
        }
    }
}
