using StackExchange.Redis;

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:1444");

ISubscriber subscriber = redis.GetSubscriber();

while (true)
{
    Console.WriteLine("Mesaj : ");
    string message = Console.ReadLine();
    //await subscriber.PublishAsync("mychannel", message);
    await subscriber.PublishAsync("mychannel.*", message);
}