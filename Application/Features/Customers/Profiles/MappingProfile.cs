using Application.Features.Customers.Commands.Add;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetById;
using AutoMapper;
using crmSystem.Domain.DTOs;
using crmSystem.Domain.Entities;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, AddCustomerCommand>().ReverseMap();
            CreateMap<Customer, AddCustomerResponse>().ReverseMap();

            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerResponse>().ReverseMap();

            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerResponse>().ReverseMap();

            CreateMap<Customer, CustomerDto>();

            CreateMap<Customer, GetCustomerByIdQuery>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdResponse>().ReverseMap();
        }
    }
}