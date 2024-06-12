using GestaoProjeto.Domain.Interfaces.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProjetoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioPersistence _funcionarioPersistence;
        private readonly IFuncaoPersistence _funcaoPersistence;

        public FuncionarioController(IFuncionarioPersistence funcionarioPersistence, IFuncaoPersistence funcaoPersistence)
        {
            _funcionarioPersistence = funcionarioPersistence;
            _funcaoPersistence = funcaoPersistence;
        }

        [HttpGet("GetAllFunc")]
        public async Task<IActionResult> GetAll()
        {
            var query = await _funcionarioPersistence.GetAll(null, null);
            return Ok(query); // Você pode retornar uma lista de itens ou qualquer outra coisa aqui
        }

        [HttpGet("GetAllFuncao")]
        public async Task<IActionResult> GetAll2()
        {
            var query = await _funcaoPersistence.GetFuncoesComFuncionarios();
            return Ok(query); // Você pode retornar uma lista de itens ou qualquer outra coisa aqui
        }

    }
}
