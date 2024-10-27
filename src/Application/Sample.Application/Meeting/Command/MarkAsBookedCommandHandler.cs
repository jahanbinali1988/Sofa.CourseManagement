namespace Sofa.CourseManagement.Application.Meeting.Command
{
    //public class MarkAsBookedCommandHandler : ICommandHandler<MarkAsBookedCommand>
    //{
    //    private readonly IBookMeetingService _bookMeetingService;
    //    private readonly IMeetingRepository _repository;
    //    private readonly IUnitOfWork _unitOfWork;
    //    public MarkAsBookedCommandHandler(IBookMeetingService bookMeetingService, IMeetingRepository repository, IUnitOfWork unitOfWork)
    //    {
    //        _bookMeetingService = bookMeetingService;
    //        _repository = repository;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task Handle(MarkAsBookedCommand request, CancellationToken cancellationToken)
    //    {
    //        var meeting = await _repository.GetAsync(request.Id, cancellationToken);
    //        if (meeting == null)
    //            throw new EntityNotFoundException($"Unable to find meeting with given id '{request.Id}'");

    //        await meeting.UpdateAsBooked(_bookMeetingService, request.Id);
    //        await _repository.UpdateAsync(meeting, cancellationToken);
    //        await _unitOfWork.CommitAsync(cancellationToken);
    //    }

    //}
}
