namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.uni_ingresos", "motivoIngreso", c => c.String());
            AlterColumn("dbo.uni_ingresos", "fecha_egreso", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.uni_ingresos", "fecha_egreso", c => c.DateTime(nullable: false));
            DropColumn("dbo.uni_ingresos", "motivoIngreso");
        }
    }
}
