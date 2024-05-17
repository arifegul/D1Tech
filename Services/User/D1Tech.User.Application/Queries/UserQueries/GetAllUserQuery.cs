using D1Tech.User.Application.Responses;
using D1Tech.User.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Queries.UserQueries
{
    public class GetAllUserQuery : IRequest<Response<List<UserResponse>>>
    {
    }
}
