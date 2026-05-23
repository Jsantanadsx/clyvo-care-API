using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClyvoCare.API.Entities
{
    [Table("TB_PETS")]
    public class Pet
    {
        [Key]
        [Column("ID_PET")]
        public int IdPet { get; set; }

        [Required]
        [StringLength(80)]
        [Column("NOME_PET")]
        public string NomePet { get; set; }

        [Required]
        [StringLength(40)]
        [Column("ESPECIE")]
        public string Especie { get; set; }

        [StringLength(60)]
        [Column("RACA")]
        public string Raca { get; set; }

        [Required]
        [Column("SEXO")]
        public string Sexo { get; set; }

        [StringLength(40)]
        [Column("COR")]
        public string Cor { get; set; }

        [Column("PESO")]
        public decimal? Peso { get; set; }

        [Column("DATA_NASCIMENTO_PET")]
        public DateTime? DataNascimentoPet { get; set; }

        [StringLength(40)]
        [Column("STATUS_SAUDE")]
        public string StatusSaude { get; set; }

        [ForeignKey("Tutor")]
        [Column("ID_TUTOR")]
        public int IdTutor { get; set; }

        public Tutor Tutor { get; set; }
    }
}