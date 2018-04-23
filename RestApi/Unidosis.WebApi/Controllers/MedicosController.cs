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
    public class MedicosController : ApiController
    {
        UCCatalogos ucCatalogos = new UCCatalogos(new UnidosisContext());

        public HttpResponseMessage Get()
        {
            IIdentity identidad = Thread.CurrentPrincipal.Identity;
            var medicos = ucCatalogos.getMedicos();
            if (medicos == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Existe Info");
            return Request.CreateResponse(HttpStatusCode.OK, medicos);
        }

        public HttpResponseMessage Get(string id)
        {
            uni_tratanteDTO medico = ucCatalogos.getMedicoById(id);
            if (medico == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el medico");
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]uni_tratanteDTO _Medico)
        {

            if (_Medico == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado un medico valido");

            uni_tratanteDTO Medico;
            try
            {
                Medico = ucCatalogos.setMedico(_Medico);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Medico);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]uni_tratanteDTO medico)
        {
            try
            {
                uni_tratanteDTO original = ucCatalogos.updateMedico(medico);
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
