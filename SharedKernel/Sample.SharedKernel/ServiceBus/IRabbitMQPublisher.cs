using System.Threading.Tasks;

namespace Sofa.CourseManagement.SharedKernel.ServiceBus
{
	public interface IRabbitMQPublisher<T>
	{
		Task PublishMessageAsync(T message, string queueName);
	}
}
