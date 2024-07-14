using Application.Features.Opportunities.Commands.Add;
using Application.Features.Opportunities.Commands.Delete;
using Application.Features.Opportunities.Commands.Update;
using Application.Features.Opportunities.Queries.GetById;
using AutoMapper;
using crmSystem.Domain.DTOs;
using crmSystem.Domain.Entities;

namespace Application.Features.Opportunities.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Opportunity, AddOpportunityCommand>().ReverseMap();
            CreateMap<Opportunity, AddOpportunityResponse>().ReverseMap();

            CreateMap<Opportunity, DeleteOpportunityCommand>().ReverseMap();
            CreateMap<Opportunity, DeleteOpportunityResponse>().ReverseMap();

            CreateMap<Opportunity, UpdateOpportunityCommand>().ReverseMap();
            CreateMap<Opportunity, UpdateOpportunityResponse>().ReverseMap();

            CreateMap<Opportunity, OpportunityDto>();

            CreateMap<Opportunity, GetOpportunityByIdQuery>().ReverseMap();
            CreateMap<Opportunity, GetOpportunityByIdResponse>().ReverseMap();
        }
    }
}
