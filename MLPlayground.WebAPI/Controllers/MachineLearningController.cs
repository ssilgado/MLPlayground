using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MLPlayground.Services.Contracts;

namespace MLPlayground.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MachineLearningController : ControllerBase
    {
        private readonly IImageLoadService _imageLoadService;

        public MachineLearningController(IImageLoadService imageLoadService)
        {
            _imageLoadService = imageLoadService;
        }

        [HttpPost]
        [ActionName("LoadImages")]
        public async Task<IActionResult> LoadImagesLocally()
        {
            var result = await _imageLoadService.LoadImages();

            if(result) return Ok();
            return Problem();
        }
    }
}