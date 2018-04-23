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
    public class EnfermerasController : ApiController
    {
        UCCatalogos ucCatalogos = new UCCatalogos(new UnidosisContext());

        public HttpResponseMessage Get()
        {
            IIdentity identidad = Thread.CurrentPrincipal.Identity;
            var enfermeras = ucCatalogos.getEnfermeras();
            if (enfermeras == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Existe Info");
            return Request.CreateResponse(HttpStatusCode.OK, enfermeras);
        }

        public HttpResponseMessage Get(string id)
        {
            uni_enfermeraDTO enfermera = ucCatalogos.getEnfermeraById(id);
            if (enfermera == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro la enfermera");
            return Request.CreateResponse(HttpStatusCode.OK, enfermera);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]uni_enfermeraDTO _Enfermera)
        {

            if (_Enfermera == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se ha especificado una enfermera valida");

            uni_enfermeraDTO Enfermera;
            try
            {
                Enfermera = ucCatalogos.setEnfermera(_Enfermera);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Enfermera);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]uni_enfermeraDTO enfermera)
        {
            try
            {
                uni_enfermeraDTO original = ucCatalogos.updateEnfermera(enfermera);
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
