using ModeloEntidad.Entidades.Movimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_asignacion_camas")]
    public class uni_asignacion_cama
    {
        [Key(), Column(Order = 1)]
        public int id { get; set; }

        [ForeignKey("fk_sala")]
        virtual public uni_sala sala { get; set; }
        public int fk_sala { get; set; }

        [ForeignKey("fk_cama")]
        virtual public uni_cama cama { get; set; }

        public int fk_cama { get; set; }

        [ForeignKey("fk_ingreso")]
        virtual public uni_ingreso ingreso { get; set; }

        public int fk_ingreso { get; set; }
    }
}
