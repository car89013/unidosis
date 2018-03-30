using AutoMapper;
using ModeloEntidad.DAL;
using ModeloEntidad.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidadControl.Catalogos.DTOs;

namespace UnidadControl.Catalogos
{
    public class UCCatalogos : UCBase
    {
        public UCCatalogos(UnidosisContext context)
            : base(context)
        {
        }

        #region "Paciente"

        public List<uni_pacienteDTO> getPacientes()
        {
            List<uni_pacienteDTO> resultado = new List<uni_pacienteDTO>();
            resultado = AutoMapper.Mapper.Map<List<uni_pacienteDTO>>(context.uni_pacientes.OrderBy(f => f.Afiliacion).ToList());
            return resultado;
        }

        public uni_pacienteDTO getPacienteById(string id)
        {
            uni_pacienteDTO resultado = new uni_pacienteDTO();
            resultado = AutoMapper.Mapper.Map <uni_pacienteDTO>(context.uni_pacientes.FirstOrDefault(f => f.Afiliacion == id));
            return resultado;
        }

        public uni_pacienteDTO setPaciente(uni_pacienteDTO _PacienteDTO)
        {
            try
            {
                var paciente = Mapper.Map<uni_paciente>(_PacienteDTO);
                context.uni_pacientes.Add(paciente);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_pacienteDTO>(paciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_pacienteDTO updatePaciente(uni_pacienteDTO _PacienteDTO)
        {
            var newPaciente = Mapper.Map<uni_paciente>(_PacienteDTO);
            var oldPaciente = context.uni_pacientes.FirstOrDefault(f => f.Afiliacion == newPaciente.Afiliacion);

            oldPaciente.fecha_nacimiento = newPaciente.fecha_nacimiento;
            oldPaciente.Materno = newPaciente.Materno;
            oldPaciente.Nombre = newPaciente.Nombre;
            oldPaciente.Paterno = newPaciente.Paterno;
            context.SaveChanges();
            return _PacienteDTO;
        }


        #endregion

    }
}
