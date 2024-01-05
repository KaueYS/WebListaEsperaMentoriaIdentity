namespace WebListaEsperaMentoriaIdentity.Models
{
    public class EspecialidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<ProfissionalModel>? Profissional { get; set;}

    }
}
