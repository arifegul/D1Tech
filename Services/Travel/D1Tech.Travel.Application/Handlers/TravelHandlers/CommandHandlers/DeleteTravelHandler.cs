using AutoMapper;
using D1Tech.Travel.Application.Commands.TravelCommands;
using D1Tech.Travel.Application.Repositories;
using D1Tech.Travel.Application.Responses;
using D1Tech.Travel.Application.Shared;
using D1Tech.Travel.Domain.Entities;
using D1Tech.Travel.Infrastructure.APIs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Application.Handlers.TravelHandlers.CommandHandlers
{
    public class DeleteTravelHandler(IWriteRepository<Travels> repository, IWriteRepository<TravelDetails> detailRepository, IMapper mapper) : IRequestHandler<DeleteTravelCommand, Response<bool>>
    {
        private readonly IWriteRepository<Travels> _repository = repository;
        private readonly IWriteRepository<TravelDetails> _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<bool>> Handle(DeleteTravelCommand request, CancellationToken cancellationToken)
        {
            var getTravel = await D1TechTravelAPIs.GetTravelById<TravelResponse>(request.Id);

            if (getTravel == null)
                return Response<bool>.Fail("Travel cannot found!", 409);

            var travel = _mapper.Map<Travels>(getTravel);
            var travelDetail = _mapper.Map<TravelDetails>(getTravel.TravelDetail);

            var isDelete = await _detailRepository.Delete(travelDetail) >= 1;
            if (!isDelete)
                return Response<bool>.Fail("Travel detail could not deleted", 409);

            var isDeleted = await _repository.Delete(travel) >= 1;
            if (!isDeleted)
                return Response<bool>.Fail("Travel could not deleted", 409);


            return Response<bool>.Success(isDeleted, 201);
        }
    }
}
