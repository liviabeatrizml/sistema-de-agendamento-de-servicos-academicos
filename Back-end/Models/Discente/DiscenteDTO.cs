/// <summary>
/// DTO que representa os dados de um discente, utilizados em diversas operações.
/// </summary>
public class DiscenteDto
{
    /// <summary>
    /// Nome completo do discente.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Endereço de e-mail do discente.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Senha do discente para autenticação.
    /// </summary>
    public string Senha { get; set; }

    /// <summary>
    /// Número de matrícula do discente.
    /// </summary>
    public int Matricula { get; set; }

    /// <summary>
    /// Número de telefone do discente.
    /// </summary>
    public string Telefone { get; set; }

    /// <summary>
    /// Nome do curso que o discente está matriculado.
    /// </summary>
    public string Curso { get; set; }
}
