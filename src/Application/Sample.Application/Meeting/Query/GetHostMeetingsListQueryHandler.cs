//using Mapster;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Sofa.CourseManagement.Application.Contract.Meeting;
//using Sofa.CourseManagement.Application.Contract.Meeting.Query;
//using Sofa.CourseManagement.SharedKernel.Application;
//using Sofa.CourseManagement.Domain.Meetings;

//namespace Sofa.CourseManagement.Application.Meeting.Query
//{
//    public class GetHostMeetingsListQueryHandler : IQueryHandler<GetHostMeetingsListQuery, Pagination<MeetingResponseDto>>
//    {
//        private readonly IMeetingRepository _repository;
//        public GetHostMeetingsListQueryHandler(IMeetingRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<Pagination<MeetingResponseDto>> Handle(GetHostMeetingsListQuery request, CancellationToken cancellationToken)
//        {
//            var meetings = await _repository.GetListByHostMsisdnAsync(request.HostMsisdn, request.Offset, request.Count, cancellationToken);

//            return meetings.Adapt<Pagination<MeetingResponseDto>>();
//        }
//    }
//}
