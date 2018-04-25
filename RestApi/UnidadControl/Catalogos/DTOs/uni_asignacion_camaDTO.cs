using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidadControl.Movimientos.DTOs;

namespace UnidadControl.Catalogos.DTOs
{
    public class uni_asignacion_camaDTO
    {
        public int id { get; set; }

        virtual public uni_salaDTO sala { get; set; }

        public int fk_sala { get; set; }

        virtual public uni_camaDTO cama { get; set; }

        public int fk_cama { get; set; }

        virtual public uni_ingresoDTO ingreso { get; set; }

        public int fk_ingreso { get; set; }

    }
}
