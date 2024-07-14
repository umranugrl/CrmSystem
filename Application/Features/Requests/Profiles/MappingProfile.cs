using Application.Features.Requests.Commands.Add;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries.GetById;
using AutoMapper;
using crmSystem.Domain.DTOs;
using crmSystem.Domain.Entities;

namespace Application.Features.Requests.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, AddRequestCommand>().ReverseMap();
            CreateMap<Request, AddRequestResponse>().ReverseMap();

            CreateMap<Request, DeleteRequestCommand>().ReverseMap();
            CreateMap<Request, DeleteRequestResponse>().ReverseMap();

            CreateMap<Request, UpdateRequestCommand>().ReverseMap();
            CreateMap<Request, UpdateRequestResponse>().ReverseMap();

            CreateMap<Request, RequestDto>();

            CreateMap<Request, GetRequestByIdQuery>().ReverseMap();
            CreateMap<Request, GetRequestByIdResponse>().ReverseMap();
        }
    }
}