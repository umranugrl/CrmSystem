using Application.Features.Interactions.Commands.Add;
using Application.Features.Interactions.Commands.Delete;
using Application.Features.Interactions.Commands.Update;
using Application.Features.Interactions.Queries.GetById;
using AutoMapper;
using crmSystem.Domain.DTOs;
using crmSystem.Domain.Entities;

namespace Application.Features.Interactions.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Interaction, AddInteractionCommand>().ReverseMap();
            CreateMap<Interaction, AddInteractionResponse>().ReverseMap();

            CreateMap<Interaction, DeleteInteractionCommand>().ReverseMap();
            CreateMap<Interaction, DeleteInteractionResponse>().ReverseMap();

            CreateMap<Interaction, UpdateInteractionCommand>().ReverseMap();
            CreateMap<Interaction, UpdateInteractionResponse>().ReverseMap();

            CreateMap<Interaction, InteractionDto>();

            CreateMap<Interaction, GetInteractionByIdQuery>().ReverseMap();
            CreateMap<Interaction, GetInteractionByIdResponse>().ReverseMap();
        }
    }
}
