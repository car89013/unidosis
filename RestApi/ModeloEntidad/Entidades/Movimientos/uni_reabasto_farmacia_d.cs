using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_reabastos_farmacia_d")]
    public class uni_reabasto_farmacia_d
    {
        [Key()]
        public int id { get; set; }

        [StringLength(3)]
        public string gpo { get; set; }

        [StringLength(3)]
        public string gen { get; set; }

        [StringLength(4)]
        public string esp { get; set; }

        [StringLength(2)]
        public string dif { get; set; }

        public double cant_sol { get; set; }

        public double cant_rec { get; set; }

        public int num_renglon { get; set; }

        [ForeignKey("fk_cabecera")]
        public uni_reabasto_farmacia_m cabecera { get; set; }

        public int fk_cabecera { get; set; }

    }
}
