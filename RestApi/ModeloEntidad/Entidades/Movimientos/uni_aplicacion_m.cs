using ModeloEntidad.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_aplicaciones_m")]
    public class uni_aplicacion_m
    {
        [Key()]
        public int id { get; set; }

        [ForeignKey("fk_enfermera")]
        public virtual uni_enfermera enfermera { get; set; }

        public int fk_enfermera { get; set; }

        public DateTime fecha_app { get; set; }

        [StringLength(50)]
        public string id_bolsa { get; set; }

        [StringLength(50)]
        public string id_brazalete { get; set; }

        public string observaciones { get; set; }

        public int estatus { get; set;}

        public int num_toma { get; set; }

        [ForeignKey("fk_ingreso")]
        public virtual uni_ingreso ingreso { get; set; }

        public int fk_ingreso { get; set; }

        [ForeignKey("fk_pedido")]
        public virtual uni_reabasto_servicio pedido { get; set; }

        public int fk_pedido { get; set; }

        public virtual List<uni_aplicacion_d> detalle { get; set; }

    }
}
