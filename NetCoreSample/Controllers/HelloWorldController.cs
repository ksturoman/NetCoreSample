using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NetCoreSample.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok($"Hello world! The time is {DateTime.Now}");
    }
}
