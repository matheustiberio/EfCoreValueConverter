using Api.Database;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ExampleController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var examples = _context.Examples.ToList();

            return Ok(examples);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Example body)
        {
            var newExample = new ExampleEntity
            {
                SensitiveInfo = body.SensitiveInfo,
            };

            _context.Examples.Add(newExample);
            _context.SaveChanges();

            return Ok(newExample);
        }
    }

    public class Example
    {
        public string SensitiveInfo { get; set; }
    }
}
