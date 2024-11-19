namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixVendaProtocolo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vendas", name: "ProtocoloVenda", newName: "Protocolo");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Vendas", name: "Protocolo", newName: "ProtocoloVenda");
        }
    }
}
