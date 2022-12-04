using System;
using Microsoft.AspNetCore.Mvc;

namespace CDCNfinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentryController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            int c = -1;

            int a = 31;
            int b = 0;
            c = div(a, b);
            return Ok(c);
        }


        int div(int a, int b)
        {
            return a / b;
        }
    }
}