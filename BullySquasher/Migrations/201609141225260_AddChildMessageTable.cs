namespace BullySquasher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChildMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChildDeviceId = c.Int(nullable: false),
                        message = c.String(),
                        isBullyMessage = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChildDevices", t => t.ChildDeviceId, cascadeDelete: true)
                .Index(t => t.ChildDeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildMessages", "ChildDeviceId", "dbo.ChildDevices");
            DropIndex("dbo.ChildMessages", new[] { "ChildDeviceId" });
            DropTable("dbo.ChildMessages");
        }
    }
}
