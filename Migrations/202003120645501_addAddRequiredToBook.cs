namespace BookLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddRequiredToBook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(maxLength: 255));
        }
    }
}
