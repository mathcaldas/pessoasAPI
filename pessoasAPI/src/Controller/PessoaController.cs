using Microsoft.AspNetCore.Mvc;
using pessoasAPI.src.Model;

namespace pessoasAPI.src.Controller

{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private static readonly List<Pessoa> pessoas = [];

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> GetAll()
        {
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post([FromBody] Pessoa pessoa)
        {
            pessoa.Id = pessoas.Count > 0 ? pessoas.Max(p => p.Id) + 1 : 1;
            pessoas.Add(pessoa);
            return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
        }
    }
}