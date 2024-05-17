using AutoMapper;
using D1Tech.Travel.Application.Queries.TravelQueries;
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

namespace D1Tech.Travel.Application.Handlers.TravelHandlers.QueryHandlers
{
    public class GetAllTravelHandler(IReadRepository<Travels> repository, IReadRepository<TravelDetails> detailRepository, IMapper mapper) : IRequestHandler<GetAllTravelQuery, Response<List<TravelResponse>>>
    {
        private readonly IReadRepository<Travels> _repository = repository;
        private readonly IReadRepository<TravelDetails> _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<TravelResponse>>> Handle(GetAllTravelQuery request, CancellationToken cancellationToken)
        {
            var getAllTravel = await _repository.GetAll();

            List<TravelResponse> response = [];
            foreach (var item in getAllTravel)
            {
                var getTravelDetail = await _detailRepository.Find(x => x.Status && x.TravelsId == item.Id);

                var travellMap = _mapper.Map<TravelResponse>(item);
                var travelDetailMap = _mapper.Map<TravelDetailResponse>(getTravelDetail);
                travellMap.TravelDetail = travelDetailMap;

                response.Add(travellMap);
            }

            return Response<List<TravelResponse>>.Success(response, 200);
        }
    }
}
