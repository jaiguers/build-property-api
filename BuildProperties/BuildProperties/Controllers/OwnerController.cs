using BuildProperties.APIModel;
using BuildProperties.CrossCutting.ApiModel;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BuildProperties.Controllers
{
    /// <summary>
    /// API controller to create owner
    /// Autor: Jair Guerrero
    /// Fecha: 2021-08-10
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwer ownerBO;
        private readonly ILogger<OwnerController> logger;
        private readonly static string SUCCESFULLY = "Creado correctamente";
        private readonly static string UPDATED = "Actualizado correctamente";
        private readonly static string INTERNAL_ERROR = "Internal server error";

        public OwnerController(RealEstateContext context, ILogger<OwnerController> log)
        {
            logger = log;
            ownerBO = new OwnerBO(context);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<OwnerAM> GetOwners(long id)
        {
            try
            {
                return ownerBO.Get(j => j.IdOwner == id);
            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - OwnerControllerGetOwners : {mess}", e);
                return null;
            }
        }

        /// <summary>
        /// Create register in BD 
        /// Autor: Jair Guerrero
        /// Fecha: 2021-08-10
        /// </summary>
        /// <param name="data">Owner data</param>
        /// <returns>Json</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] OwnerAM owner)
        {
            try
            {
                ownerBO.Create(owner);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = SUCCESFULLY, TraceId = Guid.NewGuid().ToString() });
            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - OwnerControllerCreate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        /// <summary>
        /// Update register in BD 
        /// Autor: Jair Guerrero
        /// Fecha: 2021-08-10
        /// </summary>
        /// <param name="data">Owner data</param>
        /// <returns>Json</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] OwnerAM owner)
        {
            try
            {
                ownerBO.Update(owner);

                return StatusCode(StatusCodes.Status200OK, new JsonResponse { Status = StatusCodes.Status200OK, Title = UPDATED, TraceId = Guid.NewGuid().ToString() });
            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - OwnerControllerUpdate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }
    }
}
