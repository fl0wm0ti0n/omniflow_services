using System;
using System.Collections.Generic;

namespace DataTransferObjects.Models.NodeMon
{
    public class PrivilegeDto
    {
        public int PrivilegeDtoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FunctionDto> FunctionDto { get; set; }
        public ICollection<UserDto> UserDto { get; set; }
    }

    public class FunctionDto
    {
        public int FunctionDtoId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int PrivilegeDtoId { get; set; }
        public PrivilegeDto PrivilegeDto { get; set; }
    }
}