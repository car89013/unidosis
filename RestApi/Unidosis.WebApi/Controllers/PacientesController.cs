using ModeloEntidad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using UnidadControl.Catalogos;
using UnidadControl.Catalogos.DTOs;

namespace Unidosis.WebApi.Controllers
{
    public class PacientesController : ApiController
    {
        UCCatalogos ucCatalogos = new UCCatalogos(new UnidosisContext());

        public HttpResponseMessage Get()
        {
            IIdentity identidad = Thread.CurrentPrincipal.Identity;
            var pacientes = ucCatalogos.getPacientes();
            if (pacientes == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Existe Info");
            return Request.CreateResponse(HttpStatusCode.OK, pacientes);
        }

        public HttpResponseMessage Get(string id)
        {
            uni_pacienteDTO paciente = ucCatalogos.getPacienteById(id);
            if (paciente == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el paciente");
            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]uni_pacienteDTO _Paciente)
        {

            if (_Paciente == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado un paciente valido");

            uni_pacienteDTO Paciente;
            try
            {
                Paciente = ucCatalogos.setPaciente(_Paciente);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Paciente);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]uni_pacienteDTO paciente)
        {
            try
            {
                uni_pacienteDTO original = ucCatalogos.updatePaciente(paciente);
                return Request.CreateResponse(HttpStatusCode.OK, original);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}


    }
}
