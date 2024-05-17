using AutoMapper;
using D1Tech.Travel.Application.Commands.TravelCommands;
using D1Tech.Travel.Application.Repositories;
using D1Tech.Travel.Application.Responses;
using D1Tech.Travel.Application.Shared;
using D1Tech.Travel.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Handlers.TravelHandlers.CommandHandlers
{
    public class CreateTravelHandler(IWriteRepository<Travels> repository, IWriteRepository<TravelDetails> detailRepository) : IRequestHandler<CreateTravelCommand, Response<bool>>
    {
        private readonly IWriteRepository<Travels> _repository = repository;
        private readonly IWriteRepository<TravelDetails> _detailRepository = detailRepository;

        public async Task<Response<bool>> Handle(CreateTravelCommand request, CancellationToken cancellationToken)
        {
            Travels travels = new()
            {
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Name = request.Name,
                UserId = request.UserId
            };

            var isCreated = await _repository.Create(travels) >= 1;
            if (!isCreated)
                return Response<bool>.Fail("Travel could not be created!", 409);

            TravelDetails travelDetails = new()
            {
                Address = request.Address,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                TravelsId = travels.Id,
            };

            var isCreate = await _detailRepository.Create(travelDetails) >= 1;
            if (!isCreate)
                return Response<bool>.Fail("Travel details could not be created!", 409);

            return Response<bool>.Success(isCreate, 201);
        }
    }
}
