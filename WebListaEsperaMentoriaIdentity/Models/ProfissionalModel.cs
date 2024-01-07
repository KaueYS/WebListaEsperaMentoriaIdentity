using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebListaEsperaMentoriaIdentity.Models
{
    public class ProfissionalModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public EspecialidadeModel? Especialidade { get; set; }
        public int? EspecialidadeId { get; set; }
        
        
        
        
        public List<PacienteModel>? Pacientes { get; set;}

        public static implicit operator ProfissionalModel(List<SelectListItem> v)
        {
            throw new NotImplementedException();
        }
    }
}
