using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_reabastos_farmacia_m")]
    public class uni_reabasto_farmacia_m
    {
        [Key()]
        public int id { get; set; }

        [StringLength(10)]
        public string num_reabasto { get; set; }

        public DateTime fecha { get; set; }

        public int fk_usuario_genero { get; set; }

        public int fk_usuario_recibio { get; set; }

        [StringLength(50)]
        public string centro_costo { get; set; }

        public virtual List<uni_reabasto_farmacia_d> detalle { get; set; }

    }
}
