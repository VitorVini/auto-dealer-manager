namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabricanteOneToOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FabricanteVeiculo", "FabricanteID", "dbo.Fabricantes");
            DropForeignKey("dbo.FabricanteVeiculo", "VeiculoID", "dbo.Veiculos");
            DropIndex("dbo.FabricanteVeiculo", new[] { "FabricanteID" });
            DropIndex("dbo.FabricanteVeiculo", new[] { "VeiculoID" });
            CreateIndex("dbo.Veiculos", "FabricanteId");
            AddForeignKey("dbo.Veiculos", "FabricanteId", "dbo.Fabricantes", "Id");
            DropTable("dbo.FabricanteVeiculo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FabricanteVeiculo",
                c => new
                    {
                        FabricanteID = c.Guid(nullable: false),
                        VeiculoID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FabricanteID, t.VeiculoID });
            
            DropForeignKey("dbo.Veiculos", "FabricanteId", "dbo.Fabricantes");
            DropIndex("dbo.Veiculos", new[] { "FabricanteId" });
            CreateIndex("dbo.FabricanteVeiculo", "VeiculoID");
            CreateIndex("dbo.FabricanteVeiculo", "FabricanteID");
            AddForeignKey("dbo.FabricanteVeiculo", "VeiculoID", "dbo.Veiculos", "Id");
            AddForeignKey("dbo.FabricanteVeiculo", "FabricanteID", "dbo.Fabricantes", "Id");
        }
    }
}
