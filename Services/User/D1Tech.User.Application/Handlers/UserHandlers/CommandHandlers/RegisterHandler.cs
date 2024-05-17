using D1Tech.User.Application.Commands.UserCommands;
using D1Tech.User.Application.Repositories;
using D1Tech.User.Application.Shared;
using D1Tech.User.Domain.Entities;
using MediatR;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Handlers.UserHandlers.CommandHandlers
{
    public class RegisterHandler(IWriteRepository<Users> repository) : IRequestHandler<RegisterCommand, Response<bool>>
    {
        private readonly IWriteRepository<Users> _repository = repository;
        public async Task<Response<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            Users user = new()
            {
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Email = request.Email,
                Password = request.Password
            };

            var isCreated = await _repository.Create(user) >= 1;
            if (!isCreated)
                return Response<bool>.Fail("User could not be created!", 409);

            return Response<bool>.Success(isCreated, 201);
        }
    }
}
