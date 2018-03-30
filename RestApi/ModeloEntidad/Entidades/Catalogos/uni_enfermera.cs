using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_enfermeras")]
    public class uni_enfermera
    {
        /// <summary>
        /// Identificador del enfermer@.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Número de adscripción del enfermer@.
        /// </summary>
        [StringLength(50)]
        public string num_adscripcion { get; set; }

        /// <summary>
        /// Nombre del enfermer@.
        /// </summary>
        [StringLength(50)]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del enfermer@.
        /// </summary>
        [StringLength(50)]
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del enfermer@.
        /// </summary>
        [StringLength(50)]
        public string Materno { get; set; }

        /// <summary>
        /// Cédula profesional del enfermer@.
        /// </summary>
        [StringLength(50)]
        public string cedula_prof { get; set; }

    }
}
