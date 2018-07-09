namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cod_ultima_matricula = c.Int(nullable: false),
                        curso = c.Int(nullable: false),
                        dni_alumno = c.String(),
                        grupo_clase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupoClases", t => t.grupo_clase_Id)
                .Index(t => t.grupo_clase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "grupo_clase_Id", "dbo.GrupoClases");
            DropIndex("dbo.Matriculas", new[] { "grupo_clase_Id" });
            DropTable("dbo.Matriculas");
        }
    }
}
