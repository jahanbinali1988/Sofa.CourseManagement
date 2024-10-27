namespace Sofa.CourseManagement.Application.Meeting.Command
{
    //public class MarkAsReservedCommandHandler : ICommandHandler<MarkAsReservedCommand>
    //{
    //    private readonly IReserveMeetingService _reserveMeetingService;
    //    private readonly IMeetingRepository _repository;
    //    private readonly IUnitOfWork _unitOfWork;
    //    public MarkAsReservedCommandHandler(IReserveMeetingService reserveMeetingService, IMeetingRepository repository, IUnitOfWork unitOfWork)
    //    {
    //        _reserveMeetingService = reserveMeetingService;
    //        _repository = repository;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task Handle(MarkAsReservedCommand request, CancellationToken cancellationToken)
    //    {
    //        var meeting = await _repository.GetAsync(request.Id, cancellationToken);
    //        if (meeting == null)
    //            throw new EntityNotFoundException($"Unable to find meeting with given id '{request.Id}'");

    //        await meeting.UpdateAsReserved(_reserveMeetingService, request.Id);
    //        await _repository.UpdateAsync(meeting, cancellationToken);
    //        await _unitOfWork.CommitAsync(cancellationToken);
    //    }
    //}
}
