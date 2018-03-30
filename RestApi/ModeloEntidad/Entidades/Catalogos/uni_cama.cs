using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_camas")]
    public class uni_cama
    {
        /// <summary>
        /// Identificador de la cama.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Descripción de la cama.
        /// </summary>
        [StringLength(50)]
        public string desc_cama { get; set; }

        //[ForeignKey("fk_sala")]
        //virtual public uni_sala sala { get; set; }

        //public int fk_sala { get; set; }
    }
}
