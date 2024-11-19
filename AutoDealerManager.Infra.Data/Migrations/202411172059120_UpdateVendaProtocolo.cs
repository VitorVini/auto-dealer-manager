namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVendaProtocolo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendas", "Preco", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Vendas", "ProtocoloVenda", c => c.Long(nullable: false));
            DropColumn("dbo.Vendas", "DataVenda");
            DropColumn("dbo.Vendas", "PrecoVenda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "PrecoVenda", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AddColumn("dbo.Vendas", "DataVenda", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vendas", "ProtocoloVenda", c => c.String(nullable: false, maxLength: 20, unicode: false));
            DropColumn("dbo.Vendas", "Preco");
            DropColumn("dbo.Vendas", "Data");
        }
    }
}
