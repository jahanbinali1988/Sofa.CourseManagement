﻿namespace Sofa.CourseManagement.SharedKernel.ServiceBus
{
	public class RabbitMQSetting
	{
		public string? HostName { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
        public int? Port { get; set; }
    }
	public static class RabbitMQQueues
	{
		public const string PrimaryQueue = "primaryQueue";
	}
}
