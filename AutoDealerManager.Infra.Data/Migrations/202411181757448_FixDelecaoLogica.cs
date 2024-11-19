namespace AutoDealerManager.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixDelecaoLogica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Vendas", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Concessionarias", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Veiculos", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Fabricantes", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Usuarios", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
        }

        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Ativo");
            DropColumn("dbo.Fabricantes", "Ativo");
            DropColumn("dbo.Veiculos", "Ativo");
            DropColumn("dbo.Concessionarias", "Ativo");
            DropColumn("dbo.Vendas", "Ativo");
            DropColumn("dbo.Clientes", "Ativo");
        }
    }
}
