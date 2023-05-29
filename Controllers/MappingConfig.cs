using System;
using AutoMapper;
using Controller.Models;
using Controller.Models.DTO;
using Nexus.Models;
using Nexus.Models.DTO;

namespace Nexus
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<PayStub, PayStubDTO>().ReverseMap();

            CreateMap<VacationTime, VacationTimeDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

