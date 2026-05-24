using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClyvoCare.API.Entities
{
    [Table("TB_CONSULTAS")]
    public class Consulta
    {
        [Key]
        [Column("ID_CONSULTA")]
        public int IdConsulta { get; set; }

        [Column("DATA_CONSULTA")]
        public DateTime? DataConsulta { get; set; }

        [ForeignKey("Pet")]
        [Column("ID_PET")]
        public int IdPet { get; set; }

        public Pet Pet { get; set; }
    }
}