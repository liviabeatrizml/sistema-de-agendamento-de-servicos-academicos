/// <summary>
/// DTO que contém a resposta de login de um usuário, incluindo o token de autenticação.
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// ID do usuário autenticado.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Token JWT gerado após a autenticação.
    /// </summary>
    public string Token { get; set; }
}
