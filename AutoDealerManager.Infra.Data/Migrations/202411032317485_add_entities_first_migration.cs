namespace AutoDealerManager.Infra.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;

    public partial class add_entities_first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    CPF = c.String(nullable: false, maxLength: 11, unicode: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                {
                                    "IX_CPF",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    Telefone = c.String(nullable: false, maxLength: 15, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Vendas",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    VeiculoId = c.Guid(nullable: false),
                    ConcessionariaId = c.Guid(nullable: false),
                    ClienteId = c.Guid(nullable: false),
                    DataVenda = c.DateTime(nullable: false),
                    PrecoVenda = c.Decimal(nullable: false, precision: 10, scale: 2),
                    ProtocoloVenda = c.String(nullable: false, maxLength: 20, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concessionarias", t => t.ConcessionariaId)
                .ForeignKey("dbo.Veiculos", t => t.VeiculoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.VeiculoId)
                .Index(t => t.ConcessionariaId)
                .Index(t => t.ClienteId);

            CreateTable(
                "dbo.Concessionarias",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Nome = c.String(nullable: false, maxLength: 100, unicode: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                {
                                    "IX_Nome",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    Telefone = c.String(maxLength: 15, unicode: false),
                    Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    CapacidadeMaximaVeiculos = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Enderecos",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ConcessionariaId = c.Guid(nullable: false),
                    Rua = c.String(nullable: false, maxLength: 255, unicode: false),
                    Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                    Estado = c.String(nullable: false, maxLength: 50, unicode: false),
                    CEP = c.String(nullable: false, maxLength: 10, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concessionarias", t => t.ConcessionariaId)
                .Index(t => t.ConcessionariaId);

            CreateTable(
                "dbo.Veiculos",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Modelo = c.String(nullable: false, maxLength: 100, unicode: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                {
                                    "IX_Modelo",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    AnoFabricacao = c.Int(nullable: false),
                    Preco = c.Decimal(nullable: false, precision: 10, scale: 2),
                    FabricanteId = c.Guid(nullable: false),
                    TipoVeiculo = c.Int(nullable: false),
                    Descricao = c.String(maxLength: 8000, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Fabricantes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    PaisOrigem = c.String(nullable: false, maxLength: 50, unicode: false),
                    AnoFundacao = c.Int(nullable: false),
                    Website = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);

            CreateTable(
                "dbo.Usuarios",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    NivelAcesso = c.Int(nullable: false),
                    Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    EmailConfirmed = c.Boolean(nullable: false),
                    Senha = c.String(nullable: false, maxLength: 255, unicode: false),
                    PasswordHash = c.String(maxLength: 8000, unicode: false),
                    SecurityStamp = c.String(maxLength: 8000, unicode: false),
                    PhoneNumber = c.String(maxLength: 8000, unicode: false),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    NomeUsuario = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.FabricanteVeiculo",
                c => new
                {
                    FabricanteID = c.Guid(nullable: false),
                    VeiculoID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.FabricanteID, t.VeiculoID })
                .ForeignKey("dbo.Fabricantes", t => t.FabricanteID)
                .ForeignKey("dbo.Veiculos", t => t.VeiculoID)
                .Index(t => t.FabricanteID)
                .Index(t => t.VeiculoID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Vendas", "VeiculoId", "dbo.Veiculos");
            DropForeignKey("dbo.FabricanteVeiculo", "VeiculoID", "dbo.Veiculos");
            DropForeignKey("dbo.FabricanteVeiculo", "FabricanteID", "dbo.Fabricantes");
            DropForeignKey("dbo.Vendas", "  ", "dbo.Concessionarias");
            DropForeignKey("dbo.Enderecos", "ConcessionariaId", "dbo.Concessionarias");
            DropIndex("dbo.FabricanteVeiculo", new[] { "VeiculoID" });
            DropIndex("dbo.FabricanteVeiculo", new[] { "FabricanteID" });
            DropIndex("dbo.Fabricantes", new[] { "Nome" });
            DropIndex("dbo.Enderecos", new[] { "ConcessionariaId" });
            DropIndex("dbo.Vendas", new[] { "ClienteId" });
            DropIndex("dbo.Vendas", new[] { "ConcessionariaId" });
            DropIndex("dbo.Vendas", new[] { "VeiculoId" });
            DropTable("dbo.FabricanteVeiculo");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Fabricantes");
            DropTable("dbo.Veiculos",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Modelo",
                        new Dictionary<string, object>
                        {
                            { "IX_Modelo", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Concessionarias",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Nome",
                        new Dictionary<string, object>
                        {
                            { "IX_Nome", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Vendas");
            DropTable("dbo.Clientes",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CPF",
                        new Dictionary<string, object>
                        {
                            { "IX_CPF", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
