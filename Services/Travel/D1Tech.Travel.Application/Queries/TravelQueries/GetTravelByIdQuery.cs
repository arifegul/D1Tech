using D1Tech.Travel.Application.Responses;
using D1Tech.Travel.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Queries.TravelQueries
{
    public record GetTravelByIdQuery(
            int Id
        )
        : IRequest<Response<TravelResponse>>;
}
