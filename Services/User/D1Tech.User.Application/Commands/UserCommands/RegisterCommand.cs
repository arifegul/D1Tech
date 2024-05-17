using D1Tech.User.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Commands.UserCommands
{
    public record RegisterCommand
        (
            string Email,
            string Password,
            string CreatedBy
        )
        : IRequest<Response<bool>>;
}
