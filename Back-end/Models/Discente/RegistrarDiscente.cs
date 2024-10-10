using System.ComponentModel.DataAnnotations;

namespace Back_end.Models
{
    /// <summary>
    /// Modelo que representa os dados necessários para registrar um discente.
    /// </summary>
    public class RegistrarDiscente
    {
        /// <summary>
        /// Nome completo do discente.
        /// </summary>
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço de e-mail do discente.
        /// Deve ser um formato de e-mail válido.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Senha do discente para autenticação.
        /// Deve ter entre 6 e 99 caracteres.
        /// </summary>
        [Required]
        [StringLength(99, MinimumLength = 6)]
        public string Senha { get; set; }

        /// <summary>
        /// Número de matrícula do discente.
        /// </summary>
        [Required]
        public int Matricula { get; set; }

        /// <summary>
        /// Número de telefone do discente.
        /// </summary>
        [Required]
        public string Telefone { get; set; }

        /// <summary>
        /// Curso que o discente está matriculado.
        /// </summary>
        [StringLength(100)]
        public string Curso { get; set; }
    }
}
