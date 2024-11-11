namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_numero_endereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enderecos", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enderecos", "Numero");
        }
    }
}
