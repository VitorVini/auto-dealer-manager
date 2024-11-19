namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConcessionariaEndereco : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Enderecos", newName: "ConcessionariaEndereco");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ConcessionariaEndereco", newName: "Enderecos");
        }
    }
}
