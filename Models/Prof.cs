using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploiDuTemps.Models
{
    public class Prof
    {

        [Key]
        public string cinId { get; set; }

        public string userName { get; set; } = string.Empty;

        public string nom { get; set; } = string.Empty;

        public string prenom { get; set; } = string.Empty;

        public string informtion { get; set; } = string.Empty;

        public string hasEmploi { get; set; } = string.Empty;  // default no

        //

    }
}
