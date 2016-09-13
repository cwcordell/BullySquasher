namespace BullySquasher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentsAndChiltrenAndDevicesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        ChildId = c.Int(nullable: false),
                        DeviceTypeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.ChildId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceTypeId, cascadeDelete: true)
                .Index(t => t.ChildId)
                .Index(t => t.DeviceTypeId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        ParentId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ParentDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 64),
                        DeviceTypeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.DeviceTypeId);
            
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildDevices", "DeviceTypeId", "dbo.DeviceTypes");
            DropForeignKey("dbo.Children", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.Parents", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParentDevices", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.ParentDevices", "DeviceTypeId", "dbo.DeviceTypes");
            DropForeignKey("dbo.ChildDevices", "ChildId", "dbo.Children");
            DropIndex("dbo.ParentDevices", new[] { "DeviceTypeId" });
            DropIndex("dbo.ParentDevices", new[] { "ParentId" });
            DropIndex("dbo.Parents", new[] { "Id" });
            DropIndex("dbo.Children", new[] { "ParentId" });
            DropIndex("dbo.ChildDevices", new[] { "DeviceTypeId" });
            DropIndex("dbo.ChildDevices", new[] { "ChildId" });
            DropTable("dbo.DeviceTypes");
            DropTable("dbo.ParentDevices");
            DropTable("dbo.Parents");
            DropTable("dbo.Children");
            DropTable("dbo.ChildDevices");
        }
    }
}
