using AutoMapper;
using ModeloEntidad.DAL;
using ModeloEntidad.Entidades.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidadControl.Movimientos.DTOs;

namespace UnidadControl.Movimientos
{
    public class UCMovimientos : UCBase
    {
        public UCMovimientos(UnidosisContext context)
            : base(context)
        {
        }

        #region Ingresos

        public List<uni_ingresoDTO> getIngresos()
        {
            List<uni_ingresoDTO> resultado = null;
            var query = from q in context.uni_ingresos
                        select q;
            if (query.ToList().Count > 0)
            {
                var x = query.ToList();
                resultado = AutoMapper.Mapper.Map<List<uni_ingresoDTO>>(query.ToList());
            }
            return resultado;
        }

        public uni_ingresoDTO getIngresoById(int id)
        {
            uni_ingresoDTO resultado = null;
            var query = from q in context.uni_ingresos
                        where q.id == id
                        select q;
            if (query.ToList().Count > 0)
                resultado = AutoMapper.Mapper.Map<uni_ingresoDTO>(query.FirstOrDefault());
            return resultado;
        }
        
        public uni_ingresoDTO getIngresoByBrazalete(string numBrazalete)
        {
            uni_ingresoDTO resultado = null;
            var query = from q in context.uni_ingresos
                        where q.num_brazalete == numBrazalete
                        select q;
            if (query.ToList().Count > 0)
                resultado = AutoMapper.Mapper.Map<uni_ingresoDTO>(query.FirstOrDefault());
            return resultado;
        }

        public uni_ingresoDTO setIngreso(uni_ingresoDTO _ingresoDTO)
        {
            try
            {
                var ingreso = Mapper.Map<uni_ingreso>(_ingresoDTO);
                context.uni_ingresos.Add(ingreso);
                context.SaveChanges();
                return AutoMapper.Mapper.Map<uni_ingresoDTO>(ingreso);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public uni_ingresoDTO updateIngreso(uni_ingresoDTO _ingresoDTO)
        {
            var newIngreso = Mapper.Map<uni_ingreso>(_ingresoDTO);
            var oldIngreso = context.uni_ingresos.FirstOrDefault(f => f.num_brazalete == newIngreso.num_brazalete);

            oldIngreso.fecha_egreso = newIngreso.fecha_egreso;
            context.SaveChanges();
            return _ingresoDTO;
        }

        #endregion

    }
}
