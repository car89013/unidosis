using ModeloEntidad.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloEntidad.Entidades.Movimientos
{
    [Table("uni_ingresos")]
    public class uni_ingreso
    {
        public uni_ingreso()
        {
            this.prescripciones = new List<uni_prescripcion_m>();
        }

        /// <summary>
        /// Identificador del ingreso de un paciente.
        /// </summary>
        [Key()]
        public int id { get; set; }

        /// <summary>
        /// Paciente al que se esta ingresando.
        /// </summary>
        [ForeignKey("fk_paciente")]
        virtual public uni_paciente paciente { get; set; }

        /// <summary>
        /// Foreing Key del paciente (Afiliacion)
        /// </summary>
        public string fk_paciente { get; set; }

        //[ForeignKey("fk_asignacion_cama")]
        //virtual public uni_asignacion_cama cama { get; set; }

        //public int fk_asignacion_cama { get; set; }

        public string num_brazalete { get; set; }

        public DateTime fecha_ingreso { get; set; }

        public DateTime fecha_egreso { get; set; }

        virtual public List<uni_prescripcion_m> prescripciones { get; set; }
    }
}
