using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_end.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar os serviços disponíveis na API do sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ServicoController"/> com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados utilizado para acessar os serviços.</param>
        public ServicoController(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastra um novo serviço no sistema.
        /// </summary>
        /// <param name="servicoDto">Objeto contendo as informações do serviço a ser cadastrado.</param>
        /// <returns>Retorna o serviço cadastrado com o seu respectivo ID.</returns>
        /// <remarks>
        /// Essa rota permite que novos serviços sejam registrados no sistema. 
        /// O serviço deve conter informações básicas, como tipo, descrição e tipo de atendimento.
        /// </remarks>
        [HttpPost("cadastrar")]
        public async Task<ActionResult<ServicoDisponivel>> CadastrarServico(ServicoDto servicoDto)
        {
            var novoServico = new ServicoDisponivel
            {
                Tipo = servicoDto.Tipo,
                Descricao = servicoDto.Descricao,
                TipoAtendimento = servicoDto.TipoAtendimento
            };

            _context.ServicoDisponivel.Add(novoServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServico), new { id = novoServico.IdServico }, novoServico);
        }

        /// <summary>
        /// Obtém os detalhes de um serviço específico pelo ID.
        /// </summary>
        /// <param name="id">ID do serviço a ser buscado.</param>
        /// <returns>Retorna os detalhes do serviço encontrado ou uma mensagem de erro se não for encontrado.</returns>
        /// <remarks>
        /// Essa rota permite que seja feita a consulta de um serviço específico com base no seu ID.
        /// Se o serviço não for encontrado, retorna um erro 404.
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoDisponivel>> GetServico(int id)
        {
            var servico = await _context.ServicoDisponivel.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        /// <summary>
        /// Lista todos os serviços disponíveis no sistema.
        /// </summary>
        /// <returns>Retorna uma lista de todos os serviços cadastrados.</returns>
        /// <remarks>
        /// Essa rota permite obter uma lista completa de todos os serviços registrados no sistema.
        /// Útil para exibir uma visão geral dos serviços oferecidos.
        /// </remarks>
        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<ServicoDisponivel>>> ListarServicos()
        {
            return await _context.ServicoDisponivel.ToListAsync();
        }
    }
}
