using System.Collections.Generic;
using AutoMapper;
using ERPServer.DTO.PrivilegeManagement;
using ERPServer.Models.PrivilegeManagement;

namespace ERPServer.DTO
{
    public class PrivilegeAutoMapperProfileConfiguration : Profile
    {
        public PrivilegeAutoMapperProfileConfiguration()
        {
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(source => source.Department))
            .IncludeMembers(source => source.UserRoleRelation);
            //.ForMember(dest => dest.Roles, opt => opt.MapFrom(source => source.UserRoleRelation));

            CreateMap<List<UserRoleRelation>, UserDTO>();
            //.ForMember(dest => dest.Roles, opt => opt.MapFrom(source => source));
            //CreateMap<UserRoleRelation, RoleDTO>();
            //.IncludeMembers(s=>s.Role);

            //CreateMap<Role, RoleDTO>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}