using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Catalogos
{
    [Table("uni_pacientes")]
    public class uni_paciente
    {
        /// <summary>
        /// Número de afilición del paciente.
        /// </summary>
        [Key]
        [StringLength(50)]
        public string Afiliacion { get; set; }

        /// <summary>
        /// Nombre del paciente.
        /// </summary>
        [StringLength(50)]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del paciente.
        /// </summary>
        [StringLength(50)]
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del paciente.
        /// </summary>
        [StringLength(50)]
        public string Materno { get; set; }

        /// <summary>
        /// Fecha de nacimiento del paciente.
        /// </summary>
        public DateTime fecha_nacimiento { get; set; }
    }
}
