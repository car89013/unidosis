using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_aplicaciones_d")]
    public class uni_aplicacion_d
    {
        [Key]
        public int id { get; set; }

        [StringLength(3)]
        public string gpo { get; set; }

        [StringLength(3)]
        public string gen { get; set; }

        [StringLength(4)]
        public string esp { get; set; }

        [StringLength(2)]
        public string dif { get; set; }

        public string descricpion { get; set; }

        public int cant { get; set; }

        [ForeignKey("fk_cabecera")]
        public virtual uni_aplicacion_m cabecera { get; set; }

        public int fk_cabecera { get; set; }

    }
}
