using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLib.Entities
{
    [Table("nodemon_Settings")]
    public class SettingsEntity
    {
        [Key]
        [Required]
        public int SettingsEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ServiceTyp { get; set; }
        [Required]
        public string ServiceId { get; set; }
        [Required]
        public string System { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Value { get; set; }
    }
}