using D1Tech.User.Application.Queries.UserQueries;
using D1Tech.User.Application.Repositories;
using D1Tech.User.Application.Responses;
using D1Tech.User.Application.Shared;
using D1Tech.User.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.User.Application.Handlers.UserHandlers.QueryHandlers
{
    public class LoginHandler(IReadRepository<Users> repository) : IRequestHandler<LoginQuery, Response<LoginResponse>>
    {
        private readonly IReadRepository<Users> _repository = repository;
        private readonly string _secretKey = "vfcpypixkwhwekvyfpfqzjtfrsmqiuag";
        public async Task<Response<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _repository.Find(x => x.Status && x.Email == request.Email && x.Password == request.Password);

            if (getUser == null)
                return Response<LoginResponse>.Fail("Please check login information", 409);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponse response = new()
            {
                Token = tokenHandler.WriteToken(token)
            };

            return Response<LoginResponse>.Success(response, 200);
        }
    }
}
