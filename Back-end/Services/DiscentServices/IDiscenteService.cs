using System.Threading.Tasks;
using Back_end.Models;

public interface IDiscenteService
{
    /// <summary>
    /// Registra um novo discente no sistema.
    /// </summary>
    /// <param name="registrarDiscente">Objeto que contém as informações necessárias para registrar um discente.</param>
    /// <returns>Um objeto Discente representando o discente registrado.</returns>
    Task<Discente> RegistrarDiscenteAsync(RegistrarDiscente registrarDiscente);
    
    Task<LoginResponseDto> LoginDiscenteAsync(LoginDiscente loginDiscente);
    Task<bool> EmailJaCadastradoAsync(string email);
    Task<Profissional> RegistrarProfissionalAsync(RegistrarProfissional registrarProfissional);
    Task<LoginResponseDto> LoginProfissionalAsync(LoginProfissional loginProfissional);
    Task<bool> AtualizarPerfilAsync(AtualizarPerfilDto atualizarPerfil);
    Task<bool> AlterarSenhaAsync(AlterarSenhaDto alterarSenha);
    Task<DiscenteDto> ObterDiscentePorIdAsync(int id);
}
