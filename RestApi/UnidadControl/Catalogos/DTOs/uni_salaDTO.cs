using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadControl.Catalogos.DTOs
{
    public class uni_salaDTO
    {
        /// <summary>
        /// Identificador de la sala o cuarto.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Descripción de la sala o cuarto.
        /// </summary>
        public string desc_sala { get; set; }

        /// <summary>
        /// Lista de camas asignadas a la sala o cuarto.
        /// </summary>
        virtual public List<uni_asignacion_camaDTO> camas { get; set; }

        public int numeroCamas
        {
            get
            {
                if (camas != null)
                    return camas.Count();
                else
                    return 0;
            }
        }

    }
}
