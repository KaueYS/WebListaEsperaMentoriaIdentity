namespace WebListaEsperaMentoriaIdentity.Models
{
    public class ProfissionalModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public EspecialidadeModel? Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
        
        
        
        
        public List<PacienteModel>? Pacientes { get; set;}
    }
}
