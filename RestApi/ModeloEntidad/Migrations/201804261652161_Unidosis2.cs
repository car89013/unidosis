namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.uni_bitacoras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaMovimiento = c.DateTime(nullable: false),
                        usuario = c.String(maxLength: 8),
                        tratanteId = c.Int(nullable: false),
                        enfermeraId = c.Int(nullable: false),
                        prescripcionIdM = c.Int(nullable: false),
                        prescripcionIdD = c.Int(nullable: false),
                        gpo = c.String(maxLength: 3),
                        gen = c.String(maxLength: 3),
                        esp = c.String(maxLength: 4),
                        dif = c.String(maxLength: 2),
                        descricpion = c.String(),
                        dosis = c.Double(nullable: false),
                        frecuencia = c.Int(nullable: false),
                        observaciones = c.String(),
                        ingreso_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_ingresos", t => t.ingreso_id)
                .Index(t => t.ingreso_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.uni_bitacoras", "ingreso_id", "dbo.uni_ingresos");
            DropIndex("dbo.uni_bitacoras", new[] { "ingreso_id" });
            DropTable("dbo.uni_bitacoras");
        }
    }
}
