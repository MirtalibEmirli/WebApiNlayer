using Application.CQRS.Tables.DTOs;
using AutoMapper;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Tables.Handlers;

public class AddTable
{

    public record struct Command : IRequest<ResponseModel<AddTableDto>>
    {
        public Command(string num, int cap)
        {
            TableNumber = num;
            Capacity = cap;
        }
        public string TableNumber { get; set; }

        public int Capacity { get; set; }
    }


    public sealed class Handler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<Command, ResponseModel<AddTableDto>>
    {
        private readonly IMapper _mapper = mapper;

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<ResponseModel<AddTableDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(request);

            table.CreatedBy = 1;
       await     _unitOfWork.TableRepository.CreateTable(table);
            return new ResponseModel<AddTableDto>
            {
                Data = new AddTableDto { Id = table.Id  },
                IsSuccess = true,
            };
        }
    }
}

