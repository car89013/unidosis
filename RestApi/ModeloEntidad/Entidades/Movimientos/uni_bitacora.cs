using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_bitacoras")]
    public class uni_bitacora
    {
        [Key]
        public int id { get; set; }

        public uni_ingreso ingreso { get; set; }

        public DateTime fechaMovimiento { get; set; }

        [StringLength(8)]
        public string usuario { get; set; }

        public int tratanteId { get; set; }

        public int enfermeraId { get; set; }

        public int prescripcionIdM { get; set; }

        public int prescripcionIdD { get; set; }

        [StringLength(3)]
        public string gpo { get; set; }

        [StringLength(3)]
        public string gen { get; set; }

        [StringLength(4)]
        public string esp { get; set; }

        [StringLength(2)]
        public string dif { get; set; }

        public string descricpion { get; set; }

        public double dosis { get; set; }

        public int frecuencia { get; set; }

        public string observaciones { get; set; }

    }
}
