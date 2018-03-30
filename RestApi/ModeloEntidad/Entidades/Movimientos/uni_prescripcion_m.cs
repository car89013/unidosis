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
    [Table("uni_prescripciones_m")]
    public class uni_prescripcion_m
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("fk_tratante")]
        virtual public uni_tratante tratante { get; set; }

        public int fk_tratante { get; set; }

        /// <summary>
        /// Número de Receta
        /// </summary>
        public string num_receta { get; set; }

        public DateTime fecha_hora { get; set; }

        [ForeignKey("fk_ingreso")]
        virtual public uni_ingreso ingreso { get; set; }

        public int fk_ingreso { get; set; }

        virtual public List<uni_prescripcion_d> detalle { get; set; }
    }
}
