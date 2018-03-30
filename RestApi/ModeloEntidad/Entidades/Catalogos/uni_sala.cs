using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_salas")]
    public class uni_sala
    {
        public uni_sala()
        {
            this.camas = new List<uni_asignacion_cama>();
        }

        /// <summary>
        /// Identificador de la sala o cuarto.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Descripción de la sala o cuarto.
        /// </summary>
        [StringLength(80)]
        public string desc_sala { get; set; }

        /// <summary>
        /// Lista de camas asignadas a la sala o cuarto.
        /// </summary>
        virtual public List<uni_asignacion_cama> camas { get; set; }

    }
}
