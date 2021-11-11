using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly Random _random = new Random(); 

        [HttpGet]
        public int GetNumbers()
        {
            return _random.Next(0, 100);
        }

    }
}
