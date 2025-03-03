using Application.CQRS.Users.DTOs;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Handlers;

public class Update
{
    public record struct Command : IRequest<ResponseModel<UpdateDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }


    public sealed class Handler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<Command, ResponseModel<UpdateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<ResponseModel<UpdateDto>> Handle
            (Command request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (currentUser == null) throw new BadRequestException("User doesnt exist with provided Id");
            currentUser.Name = request.Name;
            currentUser.Email = request.Email;
            currentUser.SurName = request.SurName;
            currentUser.Phone = request.Phone;
            _unitOfWork.UserRepository.UpdateUser(currentUser);
            await _unitOfWork.SaveChanges();

            var responseModel = mapper.Map<UpdateDto>(currentUser);
            return new ResponseModel<UpdateDto>
            {
                Data = responseModel,
                IsSuccess = true,
            };
        }
    }

}
