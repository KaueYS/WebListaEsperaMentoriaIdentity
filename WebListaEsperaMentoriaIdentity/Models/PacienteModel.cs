using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace WebListaEsperaMentoriaIdentity.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }



        public string Nome { get; set; }



        public string Email { get; set; }



        public string Telefone { get; set; }


        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; }


        public string? Observacao { get; set; }


        public bool Finalizado { get; set; } = false;


        
        public Guid UsuarioId { get; set; }

       
        public virtual IdentityUser Usuario{ get; set; }

    }
}
