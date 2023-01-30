using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class Matier
    {
        [Key]
        public string nameId { get; set; }

        public string volumHoraireH { get; set; } = string.Empty;

        public string volumHoraireHs { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        //
        public string FillierId { get; set; }    // NameId

        public Fillier? Fillier { get; set; }
    }
}
