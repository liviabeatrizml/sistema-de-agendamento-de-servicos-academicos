/// <summary>
/// DTO que representa um serviço disponível, contendo informações sobre seu tipo, descrição e tipo de atendimento.
/// </summary>
public class ServicoDto
{
    /// <summary>
    /// Tipo do serviço, como consulta, terapia, entre outros.
    /// </summary>
    public string Tipo { get; set; }

    /// <summary>
    /// Descrição detalhada do serviço oferecido.
    /// </summary>
    public string Descricao { get; set; }

    /// <summary>
    /// Tipo de atendimento do serviço, como presencial ou remoto.
    /// </summary>
    public string TipoAtendimento { get; set; }
}
