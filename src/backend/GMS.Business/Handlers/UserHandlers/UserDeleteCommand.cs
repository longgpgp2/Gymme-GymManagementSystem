using System;
using MediatR;

namespace GMS.Business.Handlers.UserHandlers;

public class UserDeleteCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public UserDeleteCommand(Guid id)
    {
        Id = id;
    }
}
