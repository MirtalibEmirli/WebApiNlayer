using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Handlers;

public class Delete
{

    record struct Command:IRequest<ResponseModel<Unit>>

    {
        public int Id { get; set; }
    }

    public sealed class Handler : IRequestHandler<Command, ResponseModel<Unit>>{

        Task<ResponseModel<Unit>> IRequestHandler<Command, ResponseModel<Unit>>.Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
