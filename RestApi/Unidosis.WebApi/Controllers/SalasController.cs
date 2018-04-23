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
    public class SalasController : ApiController
    {
        UCCatalogos ucCatalogos = new UCCatalogos(new UnidosisContext());

        public HttpResponseMessage Get()
        {
            IIdentity identidad = Thread.CurrentPrincipal.Identity;
            var salas = ucCatalogos.getSalas();
            if (salas == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Existe Info");
            return Request.CreateResponse(HttpStatusCode.OK, salas);
        }

        public HttpResponseMessage Get(int id)
        {
            uni_salaDTO sala = ucCatalogos.getSalaById(id);
            if (sala == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro la sala");
            return Request.CreateResponse(HttpStatusCode.OK, sala);
        }

        public HttpResponseMessage Get(int id,bool disponibles)
        {
            List<uni_camaDTO> camas = ucCatalogos.getCamasById(id,disponibles);
            if (camas == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro la sala");
            return Request.CreateResponse(HttpStatusCode.OK, camas);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]uni_salaDTO _Sala)
        {

            if (_Sala == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado una sala valida");

            uni_salaDTO Sala;
            try
            {
                Sala = ucCatalogos.setSala(_Sala);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Sala);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]uni_salaDTO sala)
        {
            try
            {
                uni_salaDTO original = ucCatalogos.updateSala(sala);
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
