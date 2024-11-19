namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecoFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConcessionariaEndereco", "Id", "dbo.Concessionarias");
            DropIndex("dbo.ConcessionariaEndereco", new[] { "Id" });
            AddColumn("dbo.Concessionarias", "Rua", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AddColumn("dbo.Concessionarias", "Cidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Concessionarias", "Estado", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Concessionarias", "Numero", c => c.Int(nullable: false));
            AddColumn("dbo.Concessionarias", "CEP", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropTable("dbo.ConcessionariaEndereco");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ConcessionariaEndereco",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ConcessionariaId = c.Guid(nullable: false),
                        Rua = c.String(nullable: false, maxLength: 255, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.Int(nullable: false),
                        CEP = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Concessionarias", "CEP");
            DropColumn("dbo.Concessionarias", "Numero");
            DropColumn("dbo.Concessionarias", "Estado");
            DropColumn("dbo.Concessionarias", "Cidade");
            DropColumn("dbo.Concessionarias", "Rua");
            CreateIndex("dbo.ConcessionariaEndereco", "Id");
            AddForeignKey("dbo.ConcessionariaEndereco", "Id", "dbo.Concessionarias", "Id");
        }
    }
}
