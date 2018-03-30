using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_prescripciones_d")]
    public class uni_prescripcion_d
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

        public double dosis { get; set; }

        public int frecuencia { get; set; }

        public string observaciones { get; set; }

        [ForeignKey("fk_cabecera")]
        public virtual uni_prescripcion_m cabecera { get; set; }

        public int fk_cabecera { get; set; }
       

    }
}
