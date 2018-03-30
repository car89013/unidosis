using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_reabasto_servicios")]
    public class uni_reabasto_servicio
    {
        [Key()]
        public int id { get; set; }

        public DateTime fecha_hora_sol { get; set; }

        public DateTime fecha_hora_rec { get; set; }

        public int  num_bolsas_sol { get; set; }

        public int num_bolsas_rec { get; set; }

        [StringLength(50)]
        public string centro_costo { get; set; }

        [StringLength(10)]
        public string num_pedido { get; set; }

        public virtual List<uni_aplicacion_m> aplicaciones { get; set; }         
   }
}
