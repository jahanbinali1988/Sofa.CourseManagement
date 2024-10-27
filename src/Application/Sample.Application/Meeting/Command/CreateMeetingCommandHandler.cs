//using Mapster;
//using System.Threading;
//using System.Threading.Tasks;
//using Sofa.CourseManagement.Application.Contract.Meeting;
//using Sofa.CourseManagement.SharedKernel.SeedWork;
//using Sofa.CourseManagement.SharedKernel.Application;
//using Sofa.CourseManagement.Domain.Meetings;
//using Sofa.CourseManagement.Application.Contract.Meeting.Command;

//namespace Sofa.CourseManagement.Application.Meeting.Command
//{
//    internal class CreateMeetingCommandHandler : ICommandHandler<CreateMeetingCommand, MeetingResponseDto>
//    {
//        private readonly IMeetingRepository _repository;
//        private readonly IUnitOfWork _unitOfWork;
//        public CreateMeetingCommandHandler(IMeetingRepository repository, IUnitOfWork unitOfWork)
//        {
//            _repository = repository;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<MeetingResponseDto> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
//        {
//            var meeting = await MeetingEntity.CreateAsync(request.HostMsisdn, request.StartDate, request.EndDate, null);

//            await _repository.AddAsync(meeting, cancellationToken);
//            await _unitOfWork.CommitAsync(cancellationToken);
//            _repository.DetachEntity(meeting);

//            return meeting.Adapt<MeetingResponseDto>();
//        }
//    }
//}
