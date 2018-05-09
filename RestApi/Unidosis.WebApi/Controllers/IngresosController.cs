using ModeloEntidad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using UnidadControl.Movimientos;
using UnidadControl.Movimientos.DTOs;

namespace Unidosis.WebApi.Controllers
{
    public class IngresosController : ApiController
    {
        UCMovimientos ucMovimientos = new UCMovimientos(new UnidosisContext());

        public HttpResponseMessage Get()
        {
            IIdentity identidad = Thread.CurrentPrincipal.Identity;
            var ingresos = ucMovimientos.getIngresos();
            if (ingresos == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Existe Info");
            return Request.CreateResponse(HttpStatusCode.OK, ingresos);
        }

        public HttpResponseMessage Get(int id)
        {
            uni_ingresoDTO ingreso = ucMovimientos.getIngresoById(id);
            if (ingreso == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el ingreso");
            return Request.CreateResponse(HttpStatusCode.OK, ingreso);
        }

        public HttpResponseMessage Get(string numbrazalete)
        {
            uni_ingresoDTO ingreso = ucMovimientos.getIngresoByBrazalete(numbrazalete);
            if (ingreso == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el ingreso");
            return Request.CreateResponse(HttpStatusCode.OK, ingreso);
        }

        public HttpResponseMessage Get(int idSala,bool activos)
        {
            List<uni_ingresoDTO> ingresos = ucMovimientos.getIngresosBySala(idSala,activos);
            if (ingresos == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el ingreso");
            return Request.CreateResponse(HttpStatusCode.OK, ingresos);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]uni_ingresoDTO _Ingreso)
        {

            if (_Ingreso == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado un medico valido");

            uni_ingresoDTO Ingreso;
            try
            {
                Ingreso = ucMovimientos.setIngreso(_Ingreso);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado un medico valido");
            }

            return Request.CreateResponse(HttpStatusCode.OK, Ingreso);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]uni_ingresoDTO ingreso)
        {
            try
            {
                uni_ingresoDTO original = ucMovimientos.updateIngreso(ingreso);
                return Request.CreateResponse(HttpStatusCode.OK, original);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
