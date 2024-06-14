using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMqMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private static string message;
        [HttpPost]
        public IActionResult CreateMesage()
        {

            var _factory = new ConnectionFactory() { HostName = "localhost", Port = 5674 };

            var createConnect = _factory.CreateConnection();

            var chanel = createConnect.CreateModel();

            chanel.QueueDeclare("Kuyruk1", false, false, false, arguments: null);

            var messageContent = "Merhaba Bu bir Rabbit Mq kuyruk mesajıdır";

            var btyeMessageContent = Encoding.UTF8.GetBytes(messageContent);

            chanel.BasicPublish(exchange: "", routingKey: "Kuyruk1", basicProperties: null, body: btyeMessageContent);

            return Ok("Mesaj Kuyruğa gönderildi");
        }
        [HttpGet]
        public IActionResult ReadMessage()
        {
            var _factory = new ConnectionFactory() { HostName = "localhost", Port = 5674 };

            var createConnect = _factory.CreateConnection();

            var chanel = createConnect.CreateModel();

            var consumer = new EventingBasicConsumer(chanel);

            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);


            };
            chanel.BasicConsume(queue: "Kuyruk1", autoAck: false, consumer: consumer);
            if (string.IsNullOrEmpty(message))
                return NoContent();
            else
                return Ok(message);
        }
    }
}
