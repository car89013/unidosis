namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.uni_asignacion_camas", "fk_ingreso", "dbo.uni_ingresos");
            DropIndex("dbo.uni_asignacion_camas", new[] { "fk_ingreso" });
            AddColumn("dbo.uni_ingresos", "uni_asignacion_cama_id", c => c.Int());
            CreateIndex("dbo.uni_ingresos", "uni_asignacion_cama_id");
            AddForeignKey("dbo.uni_ingresos", "uni_asignacion_cama_id", "dbo.uni_asignacion_camas", "id");
            DropColumn("dbo.uni_asignacion_camas", "fk_ingreso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.uni_asignacion_camas", "fk_ingreso", c => c.Int(nullable: false));
            DropForeignKey("dbo.uni_ingresos", "uni_asignacion_cama_id", "dbo.uni_asignacion_camas");
            DropIndex("dbo.uni_ingresos", new[] { "uni_asignacion_cama_id" });
            DropColumn("dbo.uni_ingresos", "uni_asignacion_cama_id");
            CreateIndex("dbo.uni_asignacion_camas", "fk_ingreso");
            AddForeignKey("dbo.uni_asignacion_camas", "fk_ingreso", "dbo.uni_ingresos", "id", cascadeDelete: true);
        }
    }
}
