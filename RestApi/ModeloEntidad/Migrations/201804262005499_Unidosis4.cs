namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.uni_ingresos", "ingreso_id", c => c.Int());
            CreateIndex("dbo.uni_ingresos", "ingreso_id");
            AddForeignKey("dbo.uni_ingresos", "ingreso_id", "dbo.uni_ingresos", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.uni_ingresos", "ingreso_id", "dbo.uni_ingresos");
            DropIndex("dbo.uni_ingresos", new[] { "ingreso_id" });
            DropColumn("dbo.uni_ingresos", "ingreso_id");
        }
    }
}
