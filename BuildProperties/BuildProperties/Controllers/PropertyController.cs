using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildProperties.APIModel;
using BuildProperties.CrossCutting.ApiModel;
using BuildProperties.CrossCutting.Enumerators;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildProperties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProperty propertyBO;
        private readonly IPropertyTrace propTraceBO;
        private readonly IPropertyImage propertyImgBO;
        private readonly ILogger<PropertyController> logger;

        public PropertyController(RealEstateContext context, Logger<PropertyController> log)
        {
            logger = log;
            propertyBO = new PropertyBO(context);
            propTraceBO = new PropertyTraceBO(context);
            propertyImgBO = new PropertyImageBO(context);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] PropertyAM data)
        {
            try
            {
                propertyBO.Create(data);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = ApiMessage.SUCCESFULLY, TraceId = Guid.NewGuid().ToString() });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerCreate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetProperty(long id)
        {
            try
            {
                var prop = propertyBO.Get(id);

                return StatusCode(StatusCodes.Status200OK, new JsonResponse { Status = StatusCodes.Status200OK, Title = "", TraceId = Guid.NewGuid().ToString(), Result = prop });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerGet : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetProperties()
        {
            try
            {
                var props = propertyBO.Get();

                return StatusCode(StatusCodes.Status200OK, new JsonResponse { Status = StatusCodes.Status200OK, Title = "", TraceId = Guid.NewGuid().ToString(), Result = props });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerGet : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] PropertyAM data)
        {
            try
            {
                propertyBO.Update(data);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = ApiMessage.UPDATED, TraceId = Guid.NewGuid().ToString() });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerCreate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddImage([FromBody] PropertyAM data)
        {
            try
            {
                // foreach () { }
                // propertyImgBO.Update(data);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = ApiMessage.UPDATED, TraceId = Guid.NewGuid().ToString() });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerCreate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SellProperty([FromBody] PropertyAM data)
        {
            try
            {
                propTraceBO.Create(data.PropertyTrace.First());

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = ApiMessage.SOLD, TraceId = Guid.NewGuid().ToString() });

            }
            catch (Exception e)
            {
                logger.LogInformation("[Error] - PropertyControllerCreate : {mess}", e);

                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = ApiMessage.INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

    }
}
