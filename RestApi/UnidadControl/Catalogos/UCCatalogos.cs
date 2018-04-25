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
            resultado = AutoMapper.Mapper.Map<uni_pacienteDTO>(context.uni_pacientes.FirstOrDefault(f => f.Afiliacion == id));
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
                var med = (from m in context.uni_tratantes
                           where m.num_adscripcion == _MedicoDTO.num_adscripcion
                           select m).FirstOrDefault();
                if (med != null)
                    throw new Exception("Este médico ya se encuentra capturado en el sistema");
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

        #region "Enfermer@"

        public List<uni_enfermeraDTO> getEnfermeras()
        {
            List<uni_enfermeraDTO> resultado = new List<uni_enfermeraDTO>();
            resultado = AutoMapper.Mapper.Map<List<uni_enfermeraDTO>>(context.uni_enfermeras.OrderBy(f => f.num_adscripcion).ToList());
            return resultado;
        }

        public uni_enfermeraDTO getEnfermeraById(string num_Adscripcion)
        {
            uni_enfermeraDTO resultado = new uni_enfermeraDTO();
            resultado = AutoMapper.Mapper.Map<uni_enfermeraDTO>(context.uni_enfermeras.FirstOrDefault(f => f.num_adscripcion == num_Adscripcion));
            return resultado;
        }

        public uni_enfermeraDTO setEnfermera(uni_enfermeraDTO _EnfermeraDTO)
        {
            try
            {
                var enf = (from m in context.uni_enfermeras
                           where m.num_adscripcion == _EnfermeraDTO.num_adscripcion
                           select m).FirstOrDefault();
                if (enf != null)
                    throw new Exception("Esta enfermera ya se encuentra capturado en el sistema");
                var enfermera = Mapper.Map<uni_enfermera>(_EnfermeraDTO);
                context.uni_enfermeras.Add(enfermera);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_enfermeraDTO>(enfermera);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_enfermeraDTO updateEnfermera(uni_enfermeraDTO _EnfermeraDTO)
        {
            var newEnfermera = Mapper.Map<uni_enfermera>(_EnfermeraDTO);
            var oldEnfermera = context.uni_enfermeras.FirstOrDefault(f => f.id == newEnfermera.id);

            oldEnfermera.cedula_prof = newEnfermera.cedula_prof;
            oldEnfermera.Materno = newEnfermera.Materno;
            oldEnfermera.Nombre = newEnfermera.Nombre;
            oldEnfermera.Paterno = newEnfermera.Paterno;
            context.SaveChanges();
            return _EnfermeraDTO;
        }


        #endregion

        #region "Camas"

        public List<uni_camaDTO> getCamas()
        {
            List<uni_camaDTO> resultado = new List<uni_camaDTO>();
            resultado = AutoMapper.Mapper.Map<List<uni_camaDTO>>(context.uni_camas.OrderBy(f => f.id).ToList());
            return resultado;
        }

        public uni_camaDTO getCamaById(int id)
        {
            uni_camaDTO resultado = new uni_camaDTO();
            resultado = AutoMapper.Mapper.Map<uni_camaDTO>(context.uni_camas.FirstOrDefault(f => f.id == id));
            return resultado;
        }

        public uni_camaDTO setCama(uni_camaDTO _CamaDTO)
        {
            try
            {
                var cama = (from m in context.uni_camas
                            where m.id == _CamaDTO.id
                            select m).FirstOrDefault();
                if (cama != null)
                    throw new Exception("Esta enfermera ya se encuentra capturado en el sistema");
                var c = Mapper.Map<uni_cama>(_CamaDTO);
                context.uni_camas.Add(c);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_camaDTO>(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_camaDTO updateCama(uni_camaDTO _CamaDTO)
        {
            var newCama = Mapper.Map<uni_camaDTO>(_CamaDTO);
            var oldCama = context.uni_camas.FirstOrDefault(f => f.id == newCama.id);

            oldCama.desc_cama = newCama.desc_cama;
            context.SaveChanges();
            return _CamaDTO;
        }


        #endregion

        #region "Salas"

        public List<uni_salaDTO> getSalas()
        {
            List<uni_salaDTO> resultado = new List<uni_salaDTO>();
            resultado = AutoMapper.Mapper.Map<List<uni_salaDTO>>(context.uni_salas.OrderBy(f => f.id).ToList());
            return resultado;
        }

        public uni_salaDTO getSalaById(int id)
        {
            uni_salaDTO resultado = new uni_salaDTO();
            resultado = AutoMapper.Mapper.Map<uni_salaDTO>(context.uni_salas.FirstOrDefault(f => f.id == id));
            return resultado;
        }

        public List<uni_camaDTO> getCamasById(int id, bool disponibles)
        {
            List<uni_cama> resultado = new List<uni_cama>();
            if (id == 0)
            {
                if (disponibles)
                    return getCamas();
                else
                    return Mapper.Map<List<uni_camaDTO>>(resultado);
            }
            else
            {
                var query = (from x in context.uni_salas
                             where x.id == id
                             select x.camas).FirstOrDefault();
                foreach (var item in query)
                    resultado.Add(item.cama);
                if (disponibles)
                {
                    var camas = (from c in context.uni_camas
                                 select c).ToList();
                    var listaCamasNoAsignados = camas.Where((n) => !(resultado.Contains(n))).ToList();
                    return Mapper.Map<List<uni_camaDTO>>(listaCamasNoAsignados);
                }
                else
                    return Mapper.Map<List<uni_camaDTO>>(resultado);
            }
        }

        public uni_salaDTO setSala(uni_salaDTO _SalaDTO)
        {
            try
            {
                var sala = (from m in context.uni_salas
                            where m.id == _SalaDTO.id
                            select m).FirstOrDefault();
                if (sala != null)
                    throw new Exception("Esta sala ya se encuentra capturado en el sistema");
                var s = Mapper.Map<uni_sala>(_SalaDTO);
                context.uni_salas.Add(s);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_salaDTO>(s);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_salaDTO updateSala(uni_salaDTO _SalaDTO)
        {
            var newSala = Mapper.Map<uni_salaDTO>(_SalaDTO);
            var oldSala = context.uni_salas.FirstOrDefault(f => f.id == newSala.id);

            oldSala.desc_sala = newSala.desc_sala;
            context.SaveChanges();
            return _SalaDTO;
        }


        #endregion

    }
}
