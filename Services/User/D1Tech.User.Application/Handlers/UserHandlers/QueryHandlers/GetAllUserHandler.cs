using AutoMapper;
using D1Tech.User.Application.Queries.UserQueries;
using D1Tech.User.Application.Repositories;
using D1Tech.User.Application.Responses;
using D1Tech.User.Application.Shared;
using D1Tech.User.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Handlers.UserHandlers.QueryHandlers
{
    public class GetAllUserHandler(IReadRepository<Users> repository, IMapper mapper) : IRequestHandler<GetAllUserQuery, Response<List<UserResponse>>>
    {
        private readonly IReadRepository<Users> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<List<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var getAllUser = await _repository.GetAll();

            var response = _mapper.Map<List<UserResponse>>(getAllUser);

            return Response<List<UserResponse>>.Success(response, 200);
        }
    }
}
