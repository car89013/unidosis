using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadControl.Catalogos.DTOs
{
    public class uni_tratanteDTO
    {
        /// <summary>
        /// Identificador del medico tratante.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Número de adscripción del médico tratante.
        /// </summary>
        public string num_adscripcion { get; set; }

        /// <summary>
        /// Nombre del médico tratante.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del médico tratante.
        /// </summary>
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del médico tratante.
        /// </summary>
        public string Materno { get; set; }

        /// <summary>
        /// Cédula profesional del médico tratante.
        /// </summary>
        public string cedula_prof { get; set; }

        /// <summary>
        /// Especialidad del médico tratante.
        /// </summary>
        public string especialidad { get; set; }

    }
}
