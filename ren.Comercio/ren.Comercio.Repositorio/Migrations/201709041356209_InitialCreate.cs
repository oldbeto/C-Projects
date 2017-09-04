namespace ren.Comercio.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        valorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        valorVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        qtdEstoque = c.Int(nullable: false),
                        qtdMinimaEstoque = c.Int(nullable: false),
                        marca_codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Marcas", t => t.marca_codigo)
                .Index(t => t.marca_codigo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        administrador = c.Boolean(nullable: false),
                        clientes = c.Boolean(nullable: false),
                        vendas = c.Boolean(nullable: false),
                        fornecedores = c.Boolean(nullable: false),
                        compras = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "marca_codigo", "dbo.Marcas");
            DropIndex("dbo.Produtoes", new[] { "marca_codigo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Marcas");
        }
    }
}
