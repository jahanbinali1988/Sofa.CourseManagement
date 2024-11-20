﻿using Microsoft.Extensions.Logging;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.DomainEventConsumers
{
	public class AddVideoPostDomainEventConsumer : DomainEventHandler<AddVideoPostDomainEvent>
	{
		public AddVideoPostDomainEventConsumer(ILogger<AddVideoPostDomainEventConsumer> logger) : base(logger)
		{
		}

		protected override Task HandleEvent(AddVideoPostDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
