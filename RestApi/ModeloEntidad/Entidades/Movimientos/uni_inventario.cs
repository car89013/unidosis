using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_inventarios")]
    public class uni_inventario
    {
        [Key()]
        [Column(Order=0)]
        [StringLength(3)]
        public string gpo { get; set; }

        [Key()]
        [Column(Order = 1)]
        [StringLength(3)]
        public string gen { get; set; }

        [Key()]
        [Column(Order = 2)]
        [StringLength(4)]
        public string esp { get; set; }

        public double disponible { get; set; }

        public double deteriorado { get; set; }

        public double caduco { get; set; }

        public DateTime fecha_ulm_mov { get; set; }

        public DateTime fecha_ult_reabasto { get; set; }

    }
}
