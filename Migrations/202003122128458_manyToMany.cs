namespace BookLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Borrower_Id", "dbo.Borrowers");
            DropIndex("dbo.Books", new[] { "Borrower_Id" });
            CreateTable(
                "dbo.BorrowBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        BorrowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.BorrowerId });
            
            DropColumn("dbo.Books", "Borrower_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Borrower_Id", c => c.Int());
            DropTable("dbo.BorrowBooks");
            CreateIndex("dbo.Books", "Borrower_Id");
            AddForeignKey("dbo.Books", "Borrower_Id", "dbo.Borrowers", "Id");
        }
    }
}
