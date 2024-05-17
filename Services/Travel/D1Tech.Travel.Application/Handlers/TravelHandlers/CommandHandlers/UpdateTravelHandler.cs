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
    public class UpdateTravelHandler(IWriteRepository<Travels> repository, IWriteRepository<TravelDetails> detailRepository, IMapper mapper) : IRequestHandler<UpdateTravelCommand, Response<bool>>
    {
        private readonly IWriteRepository<Travels> _repository = repository;
        private readonly IWriteRepository<TravelDetails> _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<bool>> Handle(UpdateTravelCommand request, CancellationToken cancellationToken)
        {
            var getTravel = await D1TechTravelAPIs.GetTravelById<TravelResponse>(request.Id);

            if (getTravel == null)
                return Response<bool>.Fail("Travel cannot found!", 409);

            var travel = _mapper.Map<Travels>(getTravel);
            var travelDetail = _mapper.Map<TravelDetails>(getTravel.TravelDetail);

            travel.Name = request.Name;
            travel.ModifiedBy = request.ModifiedBy;
            travel.ModifiedDate = DateTime.Now;

            var isUpdated = await _repository.Update(travel) >= 1;
            if (!isUpdated)
                return Response<bool>.Fail("Travel could not updated", 409);

            travelDetail.Address = request.Address;
            travelDetail.ModifiedBy = request.ModifiedBy;
            travelDetail.Travels = travel;
            travelDetail.TravelsId = travel.Id;
            travelDetail.ModifiedDate = DateTime.Now;

            var isUpdate = await _detailRepository.Update(travelDetail) >= 1;
            if (!isUpdate)
                return Response<bool>.Fail("Travel detail could not updated", 409);

            return Response<bool>.Success(isUpdate, 201);
        }
    }
}
