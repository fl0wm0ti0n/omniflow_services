using System;
using System.Collections.Generic;

namespace DataTransferObjects.Models.NodeMon
{
    public class UserDto
    {
        public int UserDtoId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public UserLocationDto LocationDtoId { get; set; }
        public ICollection<UserDeviceDto> UserDeviceDtoId { get; set; }
        public ICollection<FarmerDto> FarmerDto { get; set; }
        public int SchedulesDtoId { get; set; }
        public SchedulesDto SchedulesDto { get; set; }
        public int PrivilegesDtoId { get; set; }
        public PrivilegeDto PrivilegesDto { get; set; }
    }

    public class UserLocationDto
    {
        public int UserLocationDtoId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
    }

    public class UserDeviceDto
    {
        public int UserDeviceDtoId { get; set; }
        public string Name { get; set; }
        public DeviceTypDto DeviceTypDto { get; set; }
        public string Address { get; set; }
        public string Value { get; set; }
        public string Secrets { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int UserDtoId { get; set; }
        public UserDto UserDto { get; set; }
    }

    public class DeviceTypDto
    {
        public int DeviceTypDtoId { get; set; }
        public string Name { get; set; }
    }
}