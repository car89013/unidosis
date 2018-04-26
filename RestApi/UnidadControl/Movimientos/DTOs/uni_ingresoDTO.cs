using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidadControl.Catalogos.DTOs;

namespace UnidadControl.Movimientos.DTOs
{
    public class uni_ingresoDTO
    {
        /// <summary>
        /// Identificador del ingreso de un paciente.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Paciente al que se esta ingresando.
        /// </summary>
        virtual public uni_pacienteDTO paciente { get; set; }

        /// <summary>
        /// Foreing Key del paciente (Afiliacion)
        /// </summary>
        public string fk_paciente { get; set; }

        public string num_brazalete { get; set; }

        public DateTime fecha_ingreso { get; set; }

        public DateTime fecha_egreso { get; set; }

        //virtual public List<uni_prescripcion_mDTO> prescripciones { get; set; }

        virtual public List<uni_bitacoraDTO> bitacora { get; set; }

        public string motivoIngreso { get; set; }

        virtual public uni_asignacion_camaDTO asignacion { get; set; }

    }
}
