using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.DTO;
using Library.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var libraries = new List<LibraryDTO>();

            return (IActionResult) libraries;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return (IActionResult)(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}