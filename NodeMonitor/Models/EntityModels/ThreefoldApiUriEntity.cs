using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLib.Models.EntityModels
{
    [Table("nodemon_ThreefoldApiUriList")]
    public class ThreefoldApiUriEntity
    {
        [Key]
        [Required]
        public int ThreefoldApiUriEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Uri { get; set; }
        [Required]
        public string Typ { get; set; }
        [Required]
        public bool List { get; set; }
    }
}