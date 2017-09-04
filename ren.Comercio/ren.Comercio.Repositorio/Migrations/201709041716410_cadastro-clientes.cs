namespace ren.Comercio.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cadastroclientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        cep = c.String(),
                        estado = c.String(),
                        cidade = c.String(),
                        endereco = c.String(),
                        telefone = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
