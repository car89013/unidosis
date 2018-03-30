using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_tratantes")]
    public class uni_tratante
    {
        /// <summary>
        /// Identificador del medico tratante.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Número de adscripción del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string num_adscripcion { get; set; }

        /// <summary>
        /// Nombre del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string Materno { get; set; }

        /// <summary>
        /// Cédula profesional del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string cedula_prof { get; set; }

        /// <summary>
        /// Especialidad del médico tratante.
        /// </summary>
        [StringLength(50)]
        public string especialidad { get; set; }
    }
}
