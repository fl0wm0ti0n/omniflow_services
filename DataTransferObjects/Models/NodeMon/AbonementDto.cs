using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.NodeMon
{
    public class AbonementDto
    {
        [MaxLength(50)]
        public int AbonementEntityEntityId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public int UserFk { get; set; }
        [MaxLength(20)]
        public string Target { get; set; }
        [MaxLength(20)]
        public string Source { get; set; }
        [MaxLength(20)]
        public int AbonementTargetTypEntityId { get; set; }
        public AbonementTargetTypDto AbonementTargetTyp { get; set; }
        public ICollection<AbonementsToSourcesDto> AbonementsToSources { get; set; }
    }

    public class AbonementTargetTypDto
    {
        [MaxLength(50)]
        public int AbonementTargetTypEntityId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Typ { get; set; }
        public ICollection<AbonementDto> Abonements { get; set; }
    }
    public class AbonementSourceTypDto
    {
        [MaxLength(50)]
        public int AbonementSourceTypEntityId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Typ { get; set; }
        public ICollection<AbonementsToSourcesDto> AbonementsToSources { get; set; }

    }

    public class AbonementsToSourcesDto
    {
        [MaxLength(50)]
        public int AbonementsSourcesEntityId { get; set; }
        [MaxLength(50)]
        public int AbonementSourceTypEntityId { get; set; }
        public AbonementSourceTypDto AbonementSourceTyp { get; set; }
        [MaxLength(50)]
        public int AbonementEntityId { get; set; }
    }
}