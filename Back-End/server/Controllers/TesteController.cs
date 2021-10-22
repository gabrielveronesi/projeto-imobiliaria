using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace server.Controllers
{
    [ApiController]
    [Route("teste")]
    public class TesteController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TesteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("ativo")]
        public ActionResult<string> Get()
        {
            return "Api está funcionando";
        }

        [HttpGet("retorna-cs")]
        public string TesteRetornoConectionString()
        {
            var a = _configuration.GetSection("conexao").Value;
            //var b = _configuration.GetValue<string>("MySettings:DbConnection");
            
            return a;
        }
    }
}

