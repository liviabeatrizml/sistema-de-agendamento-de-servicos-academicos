using Back_end.Data;
using Back_end.Dtos;
using Back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Services
{
    /// <summary>
    /// Responsável por gerenciar as operações relacionadas a agendamento de serviço no sistema
    /// </summary>
    public class AgendamentoService : IAgendamentoService
    {
        /// <summary>
        /// Atributo privado que representa o contexto do banco de dados
        /// </summary>
        /// <param name="context">Construtor que recebe o banco de dados</param>
        private readonly ApiDbContext _context;

        /// <summary>
        /// Construtor da classe AgendamentoService.
        /// </summary>
        /// <param name="context">Contexto do banco de dados a ser utilizado pelo serviço.</param>
        public AgendamentoService(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permite que o discente solicite um novo agendamento com base no horário disponível
        /// para o profissional e serviço especificado.
        /// </summary>
        /// <param name="dto">Objeto DTO contendo as informações necessárias para o agendamento.</param>
        /// <returns>Um novo agendamento ou null se o horário não estiver disponível.</returns>
        public async Task<Agendamento> SolicitarAgendamentoAsync(SolicitarAgendamentoDto dto)
        {
            // Verifica se o horário está disponível
            var horarioDisponivel = await _context.HorarioDisponivel
                .FirstOrDefaultAsync(h => h.IdHorario == dto.HorarioId && h.ProfissionalId == dto.ProfissionalId);

            if (horarioDisponivel == null)
            {
                return null; // Horário indisponível
            }

            // Cria um novo agendamento
            var novoAgendamento = new Agendamento
            {
                Data = dto.Data,
                DiscenteId = dto.DiscenteId,
                HorarioId = dto.HorarioId,
                ProfissionalId = dto.ProfissionalId,
                ServicoId = dto.ServicoId
            };

            _context.Agendamento.Add(novoAgendamento);
            await _context.SaveChangesAsync();

            return novoAgendamento;
        }

        /// <summary>
        /// Cancela o agendamento com base no ID fornecido.
        /// </summary>
        /// <param name="agendamentoId">ID do agendamento a ser cancelado.</param>
        /// <returns>Retorna um booleano indicando se o cancelamento foi bem-sucedido.</returns>
        public async Task<bool> CancelarAgendamentoAsync(int agendamentoId)
        {
            var agendamento = await _context.Agendamento.FindAsync(agendamentoId);
            if (agendamento == null)
            {
                return false; // Agendamento não encontrado
            }

            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Lista os agendamentos disponíveis para um discente específico.
        /// </summary>
        /// <param name="discenteId">ID do discente para filtrar os agendamentos.</param>
        /// <returns>Retorna uma lista de agendamentos associados ao discente.</returns>
        public async Task<List<Agendamento>> ListarAgendamentosPorDiscenteAsync(int discenteId)
        {
            return await _context.Agendamento
                .Where(a => a.DiscenteId == discenteId)
                .ToListAsync();
        }

        /// <summary>
        /// Lista os horários disponíveis para um profissional específico.
        /// </summary>
        /// <param name="profissionalId">ID do profissional para filtrar os horários.</param>
        /// <returns>Retorna uma lista de horários disponíveis para o profissional.</returns>
        public async Task<List<HorarioDisponivel>> ListarHorariosDisponiveisAsync(int profissionalId)
        {
            return await _context.HorarioDisponivel
                .Where(h => h.ProfissionalId == profissionalId)
                .ToListAsync();
        }
    }
}
