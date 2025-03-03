using Application.CQRS.Tables.DTOs;
using AutoMapper;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Tables.Handlers;

public class GetTableById
{

   public record struct Query:IRequest<ResponseModel<GetTableByIdDto
       >>
    {
        public int Id;
    }

    public sealed class Handler(IUnitOfWork unitOfWork,IMapper
         mapper) : IRequestHandler<Query, ResponseModel<GetTableByIdDto>>
{
        private readonly IMapper _mapper=mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<ResponseModel<GetTableByIdDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            
            var table =await _unitOfWork.TableRepository.GetTableById (request.Id);   

            var responseModel = _mapper.Map<GetTableByIdDto>(table);

            return new ResponseModel<GetTableByIdDto>
            {
                Data
            = responseModel,
                IsSuccess = true
            };
        }
    }
}
