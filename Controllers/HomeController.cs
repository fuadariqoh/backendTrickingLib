using System;
using Microsoft.AspNetCore.Mvc;

namespace TrickingLibrary.Controllers
{


    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }
    }
}
