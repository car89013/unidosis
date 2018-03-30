namespace ModeloEntidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unidosis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.uni_aplicaciones_d",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        gpo = c.String(maxLength: 3),
                        gen = c.String(maxLength: 3),
                        esp = c.String(maxLength: 4),
                        dif = c.String(maxLength: 2),
                        descricpion = c.String(),
                        cant = c.Int(nullable: false),
                        fk_cabecera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_aplicaciones_m", t => t.fk_cabecera, cascadeDelete: true)
                .Index(t => t.fk_cabecera);
            
            CreateTable(
                "dbo.uni_aplicaciones_m",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fk_enfermera = c.Int(nullable: false),
                        fecha_app = c.DateTime(nullable: false),
                        id_bolsa = c.String(maxLength: 50),
                        id_brazalete = c.String(maxLength: 50),
                        observaciones = c.String(),
                        estatus = c.Int(nullable: false),
                        num_toma = c.Int(nullable: false),
                        fk_ingreso = c.Int(nullable: false),
                        fk_pedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_enfermeras", t => t.fk_enfermera, cascadeDelete: true)
                .ForeignKey("dbo.uni_ingresos", t => t.fk_ingreso, cascadeDelete: true)
                .ForeignKey("dbo.uni_reabasto_servicios", t => t.fk_pedido, cascadeDelete: true)
                .Index(t => t.fk_enfermera)
                .Index(t => t.fk_ingreso)
                .Index(t => t.fk_pedido);
            
            CreateTable(
                "dbo.uni_enfermeras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        num_adscripcion = c.String(maxLength: 50),
                        Nombre = c.String(maxLength: 50),
                        Paterno = c.String(maxLength: 50),
                        Materno = c.String(maxLength: 50),
                        cedula_prof = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uni_ingresos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fk_paciente = c.String(maxLength: 50),
                        num_brazalete = c.String(),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_egreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_pacientes", t => t.fk_paciente)
                .Index(t => t.fk_paciente);
            
            CreateTable(
                "dbo.uni_pacientes",
                c => new
                    {
                        Afiliacion = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(maxLength: 50),
                        Paterno = c.String(maxLength: 50),
                        Materno = c.String(maxLength: 50),
                        fecha_nacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Afiliacion);
            
            CreateTable(
                "dbo.uni_prescripciones_m",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fk_tratante = c.Int(nullable: false),
                        num_receta = c.String(),
                        fecha_hora = c.DateTime(nullable: false),
                        fk_ingreso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_ingresos", t => t.fk_ingreso, cascadeDelete: true)
                .ForeignKey("dbo.uni_tratantes", t => t.fk_tratante, cascadeDelete: true)
                .Index(t => t.fk_tratante)
                .Index(t => t.fk_ingreso);
            
            CreateTable(
                "dbo.uni_prescripciones_d",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        gpo = c.String(maxLength: 3),
                        gen = c.String(maxLength: 3),
                        esp = c.String(maxLength: 4),
                        dif = c.String(maxLength: 2),
                        descricpion = c.String(),
                        dosis = c.Double(nullable: false),
                        frecuencia = c.Int(nullable: false),
                        observaciones = c.String(),
                        fk_cabecera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_prescripciones_m", t => t.fk_cabecera, cascadeDelete: true)
                .Index(t => t.fk_cabecera);
            
            CreateTable(
                "dbo.uni_tratantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        num_adscripcion = c.String(maxLength: 50),
                        Nombre = c.String(maxLength: 50),
                        Paterno = c.String(maxLength: 50),
                        Materno = c.String(maxLength: 50),
                        cedula_prof = c.String(maxLength: 50),
                        especialidad = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uni_reabasto_servicios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha_hora_sol = c.DateTime(nullable: false),
                        fecha_hora_rec = c.DateTime(nullable: false),
                        num_bolsas_sol = c.Int(nullable: false),
                        num_bolsas_rec = c.Int(nullable: false),
                        centro_costo = c.String(maxLength: 50),
                        num_pedido = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uni_asignacion_camas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fk_sala = c.Int(nullable: false),
                        fk_cama = c.Int(nullable: false),
                        fk_ingreso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.uni_camas", t => t.fk_cama, cascadeDelete: true)
                .ForeignKey("dbo.uni_ingresos", t => t.fk_ingreso, cascadeDelete: true)
                .ForeignKey("dbo.uni_salas", t => t.fk_sala, cascadeDelete: true)
                .Index(t => t.fk_sala)
                .Index(t => t.fk_cama)
                .Index(t => t.fk_ingreso);
            
            CreateTable(
                "dbo.uni_camas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        desc_cama = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uni_salas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        desc_sala = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uni_inventarios",
                c => new
                    {
                        gpo = c.String(nullable: false, maxLength: 3),
                        gen = c.String(nullable: false, maxLength: 3),
                        esp = c.String(nullable: false, maxLength: 4),
                        disponible = c.Double(nullable: false),
                        deteriorado = c.Double(nullable: false),
                        caduco = c.Double(nullable: false),
                        fecha_ulm_mov = c.DateTime(nullable: false),
                        fecha_ult_reabasto = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.gpo, t.gen, t.esp });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.uni_asignacion_camas", "fk_sala", "dbo.uni_salas");
            DropForeignKey("dbo.uni_asignacion_camas", "fk_ingreso", "dbo.uni_ingresos");
            DropForeignKey("dbo.uni_asignacion_camas", "fk_cama", "dbo.uni_camas");
            DropForeignKey("dbo.uni_aplicaciones_m", "fk_pedido", "dbo.uni_reabasto_servicios");
            DropForeignKey("dbo.uni_aplicaciones_m", "fk_ingreso", "dbo.uni_ingresos");
            DropForeignKey("dbo.uni_prescripciones_m", "fk_tratante", "dbo.uni_tratantes");
            DropForeignKey("dbo.uni_prescripciones_m", "fk_ingreso", "dbo.uni_ingresos");
            DropForeignKey("dbo.uni_prescripciones_d", "fk_cabecera", "dbo.uni_prescripciones_m");
            DropForeignKey("dbo.uni_ingresos", "fk_paciente", "dbo.uni_pacientes");
            DropForeignKey("dbo.uni_aplicaciones_m", "fk_enfermera", "dbo.uni_enfermeras");
            DropForeignKey("dbo.uni_aplicaciones_d", "fk_cabecera", "dbo.uni_aplicaciones_m");
            DropIndex("dbo.uni_asignacion_camas", new[] { "fk_ingreso" });
            DropIndex("dbo.uni_asignacion_camas", new[] { "fk_cama" });
            DropIndex("dbo.uni_asignacion_camas", new[] { "fk_sala" });
            DropIndex("dbo.uni_prescripciones_d", new[] { "fk_cabecera" });
            DropIndex("dbo.uni_prescripciones_m", new[] { "fk_ingreso" });
            DropIndex("dbo.uni_prescripciones_m", new[] { "fk_tratante" });
            DropIndex("dbo.uni_ingresos", new[] { "fk_paciente" });
            DropIndex("dbo.uni_aplicaciones_m", new[] { "fk_pedido" });
            DropIndex("dbo.uni_aplicaciones_m", new[] { "fk_ingreso" });
            DropIndex("dbo.uni_aplicaciones_m", new[] { "fk_enfermera" });
            DropIndex("dbo.uni_aplicaciones_d", new[] { "fk_cabecera" });
            DropTable("dbo.uni_inventarios");
            DropTable("dbo.uni_salas");
            DropTable("dbo.uni_camas");
            DropTable("dbo.uni_asignacion_camas");
            DropTable("dbo.uni_reabasto_servicios");
            DropTable("dbo.uni_tratantes");
            DropTable("dbo.uni_prescripciones_d");
            DropTable("dbo.uni_prescripciones_m");
            DropTable("dbo.uni_pacientes");
            DropTable("dbo.uni_ingresos");
            DropTable("dbo.uni_enfermeras");
            DropTable("dbo.uni_aplicaciones_m");
            DropTable("dbo.uni_aplicaciones_d");
        }
    }
}
