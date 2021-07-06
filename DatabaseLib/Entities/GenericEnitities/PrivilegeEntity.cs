using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLib.Entities.GenericEntities
{

    [Table("generic_Privileges")]
    public class PrivilegeEntity
    {
        [Key]
        [Required]
        public int PrivilegeEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FunctionEntity> FunctionEntity { get; set; }
        public ICollection<UserEntity> UserEntity { get; set; }
    }

    [Table("generic_Functions")]
    public class FunctionEntity
    {
        [Key]
        [Required]
        public int FunctionEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        public int PrivilegeEntityId { get; set; }
        public PrivilegeEntity PrivilegeEntity { get; set; }
    }
}