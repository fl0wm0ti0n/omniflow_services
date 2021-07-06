using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DatabaseLib.Entities.NodeMonEntities;

namespace DatabaseLib.Entities.GenericEntities
{

    [Table("generic_Users")]
    public class UserEntity
    {
        [Key]
        [Required]
        public int UserEntityId { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public UserLocationEntity LocationEntity { get; set; }
        public ICollection<UserDeviceEntity> UserDeviceEntity { get; set; }
        public ICollection<FarmerEntity> FarmerEntity { get; set; }
        public ICollection<SchedulesToUsersEntity> SchedulesToUsersEntity { get; set; }
        [InverseProperty("Creator")]
        public ICollection<SchedulesEntity> SchedulesEntity { get; set; }
        public int PrivilegesEntityId { get; set; }
        public PrivilegeEntity PrivilegesEntity { get; set; }
    }

    [Table("generic_UserLocation")]
    public class UserLocationEntity
    {
        [Key]
        [Required]
        public int UserLocationEntityId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
    }

    [Table("generic_UserDevices")]
    public class UserDeviceEntity
    {
        [Key]
        [Required]
        public int UserDeviceEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public int DeviceTypEntityId { get; set; }
        public DeviceTypEntity DeviceTypEntity { get; set; }
        public string Address { get; set; }
        public string Value { get; set; }
        public string Secrets { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
    }

    [Table("generic_DeviceTypes")]
    public class DeviceTypEntity
    {
        [Key]
        [Required]
        public int DeviceTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<UserDeviceEntity> UserDeviceEntity { get; set; }
    }
}