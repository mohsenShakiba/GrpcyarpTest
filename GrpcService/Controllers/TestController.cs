using Microsoft.AspNetCore.Mvc;

namespace GrpcService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController: ControllerBase
    {
        [Route("sample")]
        public string Test()
        {
            return "Ok";
        }
    }
}