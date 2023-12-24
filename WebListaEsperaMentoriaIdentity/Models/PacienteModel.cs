using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WebListaEsperaMentoriaIdentity.Enums;

namespace WebListaEsperaMentoriaIdentity.Models
{
    public class PacienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome precisa ser preenchido")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo email precisa ser preenchido")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo telefone precisa ser preenchido")]
        public string Telefone { get; set; } = string.Empty;



        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now.ToLocalTime();


        public string? Observacao { get; set; }


        [Required(ErrorMessage = "O campo Status precisa ser selecionado")]
        public StatusEnum Status { get; set; }


        public bool Finalizado { get; set; } = false;

        public Guid UsuarioId { get; set; }

        public virtual IdentityUser? Usuario { get; set; } 

    }
}
