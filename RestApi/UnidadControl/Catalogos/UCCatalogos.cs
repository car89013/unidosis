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

        #region "Medico"

        public List<uni_tratanteDTO> getMedicos()
        {
            List<uni_tratanteDTO> resultado = new List<uni_tratanteDTO>();
            resultado = AutoMapper.Mapper.Map<List<uni_tratanteDTO>>(context.uni_tratantes.OrderBy(f => f.num_adscripcion).ToList());
            return resultado;
        }

        public uni_tratanteDTO getMedicoById(string num_Adscripcion)
        {
            uni_tratanteDTO resultado = new uni_tratanteDTO();
            resultado = AutoMapper.Mapper.Map<uni_tratanteDTO>(context.uni_tratantes.FirstOrDefault(f => f.num_adscripcion == num_Adscripcion));
            return resultado;
        }

        public uni_tratanteDTO setMedico(uni_tratanteDTO _MedicoDTO)
        {
            try
            {
                var medico = Mapper.Map<uni_tratante>(_MedicoDTO);
                context.uni_tratantes.Add(medico);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_tratanteDTO>(medico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_tratanteDTO updateMedico(uni_tratanteDTO _MedicoDTO)
        {
            var newMedico = Mapper.Map<uni_tratante>(_MedicoDTO);
            var oldMedico = context.uni_tratantes.FirstOrDefault(f => f.id == newMedico.id);

            oldMedico.cedula_prof = newMedico.cedula_prof;
            oldMedico.especialidad = newMedico.especialidad;
            oldMedico.Materno = newMedico.Materno;
            oldMedico.Nombre = newMedico.Nombre;
            oldMedico.Paterno = newMedico.Paterno;
            context.SaveChanges();
            return _MedicoDTO;
        }


        #endregion


    }
}
