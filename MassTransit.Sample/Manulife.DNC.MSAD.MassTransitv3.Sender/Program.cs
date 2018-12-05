using MassTransit;
using GreenPipes;
using System;
using Manulife.DNC.MSAD.MassTransitv3.Messages;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.MassTransitv3.Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Masstransit Request Side";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.80.71/EDCVHOST"), hst =>
                {
                    hst.Username("admin");
                    hst.Password("edison");
                });
                // Retry : 重试
                cfg.UseRetry(ret =>
                {
                    ret.Interval(3, 10); // 消费失败后重试3次，每次间隔10s
                });
                // RateLimit : 限流
                cfg.UseRateLimit(1000, TimeSpan.FromMinutes(1)); // 1分钟以内最多1000次调用访问
                // CircuitBreaker : 熔断
                cfg.UseCircuitBreaker(cb =>
                {
                    cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                    cb.TripThreshold = 15; // 当失败的比例至少达到15%才会启动熔断
                    cb.ActiveThreshold = 10; // 当失败次数至少达到10次才会启动熔断
                    cb.ResetInterval = TimeSpan.FromMinutes(5);
                }); // 当在1分钟内消费失败率达到15%或调用了10次还是失败时，暂停5分钟的服务访问
            });

            bus.Start();

            SendMessage(bus);

            bus.Stop();
        }

        private static void SendMessage(IBusControl bus)
        {
            var mqAddress = new Uri($"rabbitmq://192.168.80.71/EDCVHOST/Qka.MassTransitTestv3");
            var client = bus.CreateRequestClient<IRequestMessage, IResponseMessage>(mqAddress, 
                TimeSpan.FromHours(10)); // 创建请求客户端，10s之内木有回馈则认为是超时(Timeout)

            do
            {
                Console.WriteLine("Press q to exit if you want.");
                string value = Console.ReadLine();
                if (value.ToLower().Equals("q"))
                {
                    break;
                }

                Task.Run(async () =>
                {
                    var request = new RequestMessage()
                    {
                        MessageId = 10001,
                        Content = value,
                        RequestId = 10001
                    };

                    var response = await client.Request(request);

                    Console.WriteLine($"Request => MessageId={request.MessageId}, Content={request.Content}");
                    Console.WriteLine($"Response => MessageCode={response.MessageCode}, Content={response.Content}");
                }).Wait();
            } while (true);
        }
    }
}
