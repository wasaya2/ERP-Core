using AutoMapper;
using eTrackerCore.Entities;
using eTrackerInfrastructure.ViewModels.Validations;
using Microsoft.AspNetCore.Identity;

namespace eTrackerInfrastructure.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, IdentityUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.UserName));
        }
    }
}
