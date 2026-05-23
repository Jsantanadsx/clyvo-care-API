using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClyvoCare.API.Entities
{
    [Table("TB_TUTORES")]
    public class Tutor
    {
        [Key]
        [Column("ID_TUTOR")]
        public int IdTutor { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NOME_TUTOR")]
        public string NomeTutor { get; set; }

        [Required]
        [StringLength(14)]
        [Column("CPF_TUTOR")]
        public string CpfTutor { get; set; }

        [Required]
        [StringLength(120)]
        [Column("EMAIL_TUTOR")]
        public string EmailTutor { get; set; }

        [StringLength(20)]
        [Column("TELEFONE_TUTOR")]
        public string TelefoneTutor { get; set; }

        [Column("DATA_NASCIMENTO_TUTOR")]
        public DateTime? DataNascimentoTutor { get; set; }

        [Column("DT_CADASTRO_TUTOR")]t
        public DateTime DtCadastroTutor { get; set; }

        [JsonIgnore]
        public ICollection<Pet> Pets { get; set; }
    }
}