using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadControl.Movimientos.DTOs
{
    public class uni_bitacoraDTO
    {
        public int id { get; set; }

        public DateTime fechaMovimiento { get; set; }

        public string usuario { get; set; }

        public int tratanteId { get; set; }

        public int enfermeraId { get; set; }

        public int prescripcionIdM { get; set; }

        public int prescripcionIdD { get; set; }

        public string gpo { get; set; }

        public string gen { get; set; }

        public string esp { get; set; }

        public string dif { get; set; }

        public string descricpion { get; set; }

        public double dosis { get; set; }

        public int frecuencia { get; set; }

        public string observaciones { get; set; }

    }
}
