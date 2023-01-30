using System.ComponentModel.DataAnnotations;

namespace EmploiDuTemps.Models
{
    public class Fillier
    {

        [Key]
        public string NameId { get; set; }

        public string designation { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        // 

        //public string InspectionTypeId { get; set; }

        //public InspectionType? InspectionType { get; set; }
    }
}
