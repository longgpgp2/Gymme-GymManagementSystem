using System;
using GMS.Models.ViewModels.UserViews;
using MediatR;

namespace GMS.Business.Handlers.UserHandlers;

public class UserGetByIdQuery : IRequest<UserViewModel>
{
    public Guid Id { get; set; }



}
