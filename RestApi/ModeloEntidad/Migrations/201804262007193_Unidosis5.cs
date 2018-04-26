namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.uni_ingresos", "ingreso_id", "dbo.uni_ingresos");
            DropIndex("dbo.uni_ingresos", new[] { "ingreso_id" });
            RenameColumn(table: "dbo.uni_ingresos", name: "uni_asignacion_cama_id", newName: "asignacion_id");
            RenameIndex(table: "dbo.uni_ingresos", name: "IX_uni_asignacion_cama_id", newName: "IX_asignacion_id");
            DropColumn("dbo.uni_ingresos", "ingreso_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.uni_ingresos", "ingreso_id", c => c.Int());
            RenameIndex(table: "dbo.uni_ingresos", name: "IX_asignacion_id", newName: "IX_uni_asignacion_cama_id");
            RenameColumn(table: "dbo.uni_ingresos", name: "asignacion_id", newName: "uni_asignacion_cama_id");
            CreateIndex("dbo.uni_ingresos", "ingreso_id");
            AddForeignKey("dbo.uni_ingresos", "ingreso_id", "dbo.uni_ingresos", "id");
        }
    }
}
