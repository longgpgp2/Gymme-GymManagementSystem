using System;
using MediatR;
using GMS.Models.ViewModels.UserViews;

namespace GMS.Business.Handlers.UserHandlers;

public class UserGetAllQuery : IRequest<IEnumerable<UserViewModel>>
{
}
