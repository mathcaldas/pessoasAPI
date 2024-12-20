using Microsoft.AspNetCore.Mvc;
using pessoasAPI.src.Model;

namespace pessoasAPI.src.Controller

{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private static readonly List<Endereco> enderecos = [];

        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> GetAll()
        {
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            var endereco = enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            return Ok(endereco);
        }

        [HttpPost]
        public ActionResult<Endereco> Post([FromBody] Endereco endereco)
        {
            endereco.Id = enderecos.Count > 0 ? enderecos.Max(e => e.Id) + 1 : 1;
            enderecos.Add(endereco);
            return CreatedAtAction(nameof(Get), new { id = endereco.Id }, endereco);
        }
    }
}