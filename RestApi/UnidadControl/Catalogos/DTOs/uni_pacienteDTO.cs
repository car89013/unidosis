using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadControl.Catalogos.DTOs
{
    public class uni_pacienteDTO
    {
        /// <summary>
        /// Número de afilición del paciente.
        /// </summary>
        public string Afiliacion { get; set; }

        /// <summary>
        /// Nombre del paciente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del paciente.
        /// </summary>
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del paciente.
        /// </summary>
        public string Materno { get; set; }

        /// <summary>
        /// Fecha de nacimiento del paciente.
        /// </summary>
        public DateTime fecha_nacimiento { get; set; }
    }
}
