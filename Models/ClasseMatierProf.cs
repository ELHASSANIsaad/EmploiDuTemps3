using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class ClasseMatierProf
    {
        [Key]
        public string nameId { get; set; }

        public string classe { get; set; } = string.Empty;

        public string matier { get; set; } = string.Empty;

        public string prof { get; set; } = string.Empty;


    }
}
