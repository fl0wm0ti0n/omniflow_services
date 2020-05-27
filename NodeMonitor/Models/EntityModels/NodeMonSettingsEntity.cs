using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLib.Models.EntityModels
{
    [Table("nodemon_Settings")]
    public class NodeMonSettingsEntity
    {
        [Key]
        [Required]
        public int NodeMonSettingsEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string System { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Value { get; set; }
    }
}