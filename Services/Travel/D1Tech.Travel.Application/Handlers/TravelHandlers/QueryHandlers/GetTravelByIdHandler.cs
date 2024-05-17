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
    public class GetTravelByIdHandler(IReadRepository<Travels> repository, IReadRepository<TravelDetails> detailRepository, IMapper mapper) : IRequestHandler<GetTravelByIdQuery, Response<TravelResponse>>
    {
        private readonly IReadRepository<Travels> _repository = repository;
        private readonly IReadRepository<TravelDetails> _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<TravelResponse>> Handle(GetTravelByIdQuery request, CancellationToken cancellationToken)
        {
            var getTravel = await _repository.Find(x => x.Status && x.Id == request.Id);
            var getTravelDetail = await _detailRepository.Find(x => x.Status && x.TravelsId == request.Id);

            var travellMap = _mapper.Map<TravelResponse>(getTravel);
            var travelDetailMap = _mapper.Map<TravelDetailResponse>(getTravelDetail);

            travellMap.TravelDetail = travelDetailMap;

            return Response<TravelResponse>.Success(travellMap, 200);
        }
    }
}
