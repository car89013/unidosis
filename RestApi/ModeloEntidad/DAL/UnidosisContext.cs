using ModeloEntidad.Entidades.Catalogos;
using ModeloEntidad.Entidades.Movimientos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.DAL
{
    public class UnidosisContext : DbContext
    {
        public UnidosisContext() : base("UnidosisContext_Con")
        {
        }

        public UnidosisContext(string conn) : base(conn)
        {
        }

        public DbSet<uni_paciente> uni_pacientes { get; set; }
        public DbSet<uni_tratante> uni_tratantes { get; set; }
        public DbSet<uni_enfermera> uni_enfermeras { get; set; }
        public DbSet<uni_sala> uni_salas { get; set; }
        public DbSet<uni_cama> uni_camas { get; set; }
        public DbSet<uni_asignacion_cama> uni_asignacion_camas { get; set; }
        public DbSet<uni_ingreso> uni_ingresos { get; set; }
        public DbSet<uni_aplicacion_m> uni_aplicaciones_m { get; set; }
        public DbSet<uni_aplicacion_d> uni_aplicaciones_d { get; set; }
        public DbSet<uni_prescripcion_m> uni_prescripciones_m { get; set; }
        public DbSet<uni_prescripcion_d> uni_prescripciones_d { get; set; }
        public DbSet<uni_reabasto_servicio> uni_reabasto_servicios { get; set; }
        public DbSet<uni_inventario> uni_inventarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           //modelBuilder.Entity<uni_asignacion_cama>().HasOptional(f => f.ingreso).WithRequired(s => s.cama);
            //modelBuilder.Entity<uni_sala>().HasMany(t => t.camas).WithMany();
        }
    }
}
