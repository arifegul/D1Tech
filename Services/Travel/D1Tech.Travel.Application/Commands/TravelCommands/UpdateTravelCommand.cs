using D1Tech.Travel.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Commands.TravelCommands
{
    public record UpdateTravelCommand(
            int Id,
            string Name,
            string Address,
            string ModifiedBy
        )
        : IRequest<Response<bool>>;
}
