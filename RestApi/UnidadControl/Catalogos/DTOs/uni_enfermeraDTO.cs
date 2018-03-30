using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadControl.Catalogos.DTOs
{
    public class uni_enfermeraDTO
    {
        /// <summary>
        /// Identificador del enfermer@.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Número de adscripción del enfermer@.
        /// </summary>
        public string num_adscripcion { get; set; }

        /// <summary>
        /// Nombre del enfermer@.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del enfermer@.
        /// </summary>
        public string Paterno { get; set; }

        /// <summary>
        /// Apellido materno del enfermer@.
        /// </summary>
        public string Materno { get; set; }

        /// <summary>
        /// Cédula profesional del enfermer@.
        /// </summary>
        public string cedula_prof { get; set; }

    }
}
