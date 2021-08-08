using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildProperties.CrossCutting.ApiModel;
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
    public class OwnerController : ControllerBase
    {
        private readonly IOwer ownerBO;
        private readonly ILogger<OwnerController> logger;

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
                logger.LogInformation("[Error]: OwnerController - {mess}", e);
                return null;
            }
        }
    }
}
