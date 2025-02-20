using Application.CQRS.Customers.Commands.Responses;
using Application.CQRS.Customers.Queries.Responses;
using Application.CQRS.Users.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User,GetByIdDto>().ReverseMap();  
        CreateMap<Customer,GetAllCustomersResponse>().ReverseMap();
        CreateMap<AddCustomerResponse,Customer>().ReverseMap();
    }
}