using CrossCutting.Automapper.Base;
using Domain.Commands.Subscribe;
using Domain.Entities;
using System;
using System.Reflection;

namespace Domain
{
    public class DomainMappingProfileRegistrator : BaseMappingProfile
    {
        public override Assembly Assembly => typeof(DomainModule).Assembly;

        public DomainMappingProfileRegistrator()
        {
            // register command-to-entity maps
            CreateMap<SubscribeCommand, Subscription>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                ;
        }
    }
}
