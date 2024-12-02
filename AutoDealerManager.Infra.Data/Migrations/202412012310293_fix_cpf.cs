namespace AutoDealerManager.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_cpf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String(nullable: false, maxLength: 14, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "CPF", c => c.String(nullable: false, maxLength: 11, unicode: false));
        }
    }
}
