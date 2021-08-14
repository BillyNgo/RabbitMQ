using System;
using System.Text;
using RabbitMQ;
using RabbitMQ.Client;

namespace RabbitMQ.Demo.Producer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("BasicQueue", false, false, false, null);
                    while (true)
                    {
                        var message = Console.ReadLine();
                        var body = Encoding.UTF8.GetBytes($"Billy: {message}");
                        channel.BasicPublish("", "BasicQueue", null, body);
                    }
                }
            }
        }
    }
}
