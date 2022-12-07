using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CDCNfinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NugetController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            string content = CDCNNugetfinal.CDCNNugetfinal.GetInfo();
            return Ok(content);
        }

        [HttpGet("Detail")]
        public IActionResult GetDetail()
        {
            string content = CDCNNugetfinal.CDCNNugetfinal.GetDetail();
            return Ok(content);
        }
    }
}