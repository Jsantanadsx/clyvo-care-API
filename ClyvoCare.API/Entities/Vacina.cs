using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClyvoCare.API.Entities
{
    [Table("TB_VACINAS")]
    public class Vacina
    {
        [Key]
        [Column("ID_VACINA")]
        public int IdVacina { get; set; }

        [Column("NOME_VACINA")]
        public string NomeVacina { get; set; }

        [Column("DATA_APLICACAO")]
        public DateTime? DataAplicacao { get; set; }

        [Column("PROXIMA_DOSE")]
        public DateTime? ProximaDose { get; set; }

        [ForeignKey("Pet")]
        [Column("ID_PET")]
        public int IdPet { get; set; }

        public Pet Pet { get; set; }
    }
}