using System;
using MediatR;

namespace GMS.Business.Handlers.Base;

public class BaseUpdateCommand<T>: IRequest<T> where T : class
{
    public Guid Id { get; set; }
}
