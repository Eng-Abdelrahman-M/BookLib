namespace BookLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 255),
                        BookName = c.String(maxLength: 255),
                        AllNumber = c.Byte(nullable: false),
                        AvailableNumber = c.Byte(nullable: false),
                        Borrower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Borrowers", t => t.Borrower_Id)
                .Index(t => t.Borrower_Id);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Borrower_Id", "dbo.Borrowers");
            DropIndex("dbo.Books", new[] { "Borrower_Id" });
            DropTable("dbo.Borrowers");
            DropTable("dbo.Books");
        }
    }
}
