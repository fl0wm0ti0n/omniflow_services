using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLib.Entities.GenericEntities
{
    [Table("generic_Abonement")]
    public class AbonementEntity
    {
        [Key]
        [Required]
        public int AbonementEntityEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserFk { get; set; }
        [Required]
        public string Target { get; set; }
        [Required]
        public string Source { get; set; }
        public int AbonementTargetTypEntityId { get; set; }
        public AbonementTargetTypEntity AbonementTargetTyp { get; set; }
        public ICollection<AbonementsToSourcesEntity> AbonementsToSources { get; set; }
    }

    [Table("generic_AbonementTyp")]
    public class AbonementTargetTypEntity
    {
        [Key]
        [Required]
        public int AbonementTargetTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Typ { get; set; }
        public ICollection<AbonementEntity> Abonements { get; set; }
    }

    [Table("generic_AbonementSourceTyp")]
    public class AbonementSourceTypEntity
    {
        [Key]
        [Required]
        public int AbonementSourceTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Typ { get; set; }
        public ICollection<AbonementsToSourcesEntity> AbonementsToSources { get; set; }

    }

    [Table("generic_AbonementsToSources")]
    public class AbonementsToSourcesEntity
    {
        [Key]
        [Required]
        public int AbonementsSourcesEntityId { get; set; }
        public int AbonementSourceTypEntityId { get; set; }
        public AbonementSourceTypEntity AbonementSourceTyp { get; set; }
        public int AbonementEntityId { get; set; }
        public AbonementEntity AbonementEntity { get; set; }
    }
}