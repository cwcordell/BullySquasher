namespace BullySquasher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMessageAndIsBullyMessageNamesInChildMessage : DbMigration
    {
        public override void Up()
        {
            RenameColumn("ChildMessages", "message", "Message");
            RenameColumn("ChildMessages", "isBullyMessage", "IsBullyMessage");
        }
        
        public override void Down()
        {
            RenameColumn("ChildMessages", "Message", "message");
            RenameColumn("ChildMessages", "IsBullyMessage", "isBullyMessage");
        }
    }
}
