using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Sofa.CourseManagement.SharedKernel.ServiceBus
{
	public class RabbitMQPublisher<T> : IRabbitMQPublisher<T>
	{
		private readonly RabbitMQSetting _rabbitMqSetting;

		public RabbitMQPublisher(IOptions<RabbitMQSetting> rabbitMqSetting)
		{
			_rabbitMqSetting = rabbitMqSetting.Value;
		}

		public async Task PublishMessageAsync(T message, string queueName)
		{

			var factory = new ConnectionFactory
			{
				HostName = _rabbitMqSetting.HostName,
				Port = _rabbitMqSetting.Port!.Value,
				UserName = _rabbitMqSetting.UserName,
				Password = _rabbitMqSetting.Password,
				Endpoint = new AmqpTcpEndpoint(_rabbitMqSetting.HostName)
				
			};

			using var connection = await factory.CreateConnectionAsync();
			using var channel = await connection.CreateChannelAsync();
			await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

			var messageJson = JsonConvert.SerializeObject(message);
			var body = Encoding.UTF8.GetBytes(messageJson);

			await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);
		}
	}
}
