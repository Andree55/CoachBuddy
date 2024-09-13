using AutoMapper;
using CoachBuddy.Domain.Interfaces;
using MediatR;


namespace CoachBuddy.Application.ClientTraining.Queries.GetClientTrainings
{
    public class GetClientTrainingsQueryHandler : IRequestHandler<GetClientTrainingsQuery, IEnumerable<ClientTrainingDto>>
    {
        private readonly IClientTrainingRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientTrainingsQueryHandler(IClientTrainingRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientTrainingDto>> Handle(GetClientTrainingsQuery request, CancellationToken cancellationToken)
        {
            var result = await _clientRepository.GetAllByEncodedName(request.EncodedName);

            var dtos= _mapper.Map<IEnumerable<ClientTrainingDto>>(result);

            return dtos;
        }
    }
}
