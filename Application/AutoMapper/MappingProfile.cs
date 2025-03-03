using Application.CQRS.Customers.Commands.Responses;
using Application.CQRS.Customers.Queries.Responses;
using Application.CQRS.Products.Queries.Responses;
using Application.CQRS.Tables.DTOs;
using Application.CQRS.Users.DTOs;
using AutoMapper;
using Domain.Entities;
using Application.CQRS.Tables.Handlers;
using Application.CQRS.Users.Handlers;
namespace Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User,GetByIdDto>().ReverseMap();
        CreateMap<UpdateDto, User>().ReverseMap();

        CreateMap<Register.Command, User>();
        CreateMap<User,RegisterDto>().ReverseMap(); 



        CreateMap<Customer,GetAllCustomersResponse>().ReverseMap();
        CreateMap<AddCustomerResponse,Customer>().ReverseMap();
        CreateMap<GetAllProductsResponse,Product>().ReverseMap();
        CreateMap<AddTable.Command, Table>().ReverseMap();
        CreateMap<GetTableByIdDto,Table>().ReverseMap();    


    }
}