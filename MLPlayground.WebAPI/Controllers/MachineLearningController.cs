using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MLPlayground.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MachineLearningController : ControllerBase
    {
        [HttpGet]
        [ActionName("TestAction")]
        public string Get()
        {
            return "Test";
        }
    }
}