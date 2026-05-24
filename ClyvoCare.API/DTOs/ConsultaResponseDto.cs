namespace ClyvoCare.API.DTOs
{
    public class ConsultaResponseDto
    {
        public int IdConsulta { get; set; }

        public DateTime? DataConsulta { get; set; }

        public string NomePet { get; set; }

        public string NomeTutor { get; set; }
    }
}