using AutoMapper;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeMapperProfile: Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<Employee, EmployeeEditModel>()
                .ForMember(
                    target => target.ConfirmEmail,
                    option => option.MapFrom(entity => entity.Email)
                );
            
            CreateMap<EmployeeEditModel, Employee>();

        }
    }
}
