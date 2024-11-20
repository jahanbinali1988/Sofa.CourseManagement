﻿using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.InstituteUsers;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.DomainEventConsumers
{
	public class DeleteInstituteUserDomainEventConsumer : DomainEventHandler<DeleteInstituteUserDomainEvent>
	{
		public DeleteInstituteUserDomainEventConsumer(ILogger<DeleteInstituteUserDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(DeleteInstituteUserDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
