using ModeloEntidad.DAL;
using ModeloEntidad.Entidades.Catalogos;
using ModeloEntidad.Entidades.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidadControl.Catalogos.DTOs;
using UnidadControl.Movimientos.DTOs;

namespace UnidadControl
{
    public class UCBase
    {
        public UnidosisContext context;

        public UCBase(UnidosisContext context)
        {
            this.context = context;
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<uni_cama, uni_camaDTO>();
                cfg.CreateMap<uni_camaDTO, uni_cama>();
                cfg.CreateMap<uni_enfermera, uni_enfermeraDTO>();
                cfg.CreateMap<uni_enfermeraDTO, uni_enfermera>();
                cfg.CreateMap<uni_paciente, uni_pacienteDTO>();
                cfg.CreateMap<uni_pacienteDTO, uni_paciente>();
                cfg.CreateMap<uni_sala, uni_salaDTO>();
                cfg.CreateMap<uni_salaDTO, uni_sala>();
                cfg.CreateMap<uni_asignacion_cama, uni_asignacion_camaDTO>();
                cfg.CreateMap<uni_asignacion_camaDTO, uni_asignacion_cama>();
                cfg.CreateMap<uni_tratante, uni_tratanteDTO>();
                cfg.CreateMap<uni_tratanteDTO, uni_tratante>();
                cfg.CreateMap<uni_ingreso, uni_ingresoDTO>();
                cfg.CreateMap<uni_ingresoDTO, uni_ingreso>();
            });
        }

        public UCBase()
        {
            this.context = new UnidosisContext();
        }
    }
}
