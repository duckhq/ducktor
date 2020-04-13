using Debugger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Debugger.Api
{
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly BuildService _service;

        public ApiController(BuildService service)
        {
            _service = service;
        }

        [HttpGet("builds")]
        public IActionResult Get()
        {
            return Ok(_service.GetBuilds());
        }
    }
}
