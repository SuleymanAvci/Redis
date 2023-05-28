

using StackExchange.Redis;

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:1444");

ISubscriber subscriber = redis.GetSubscriber();

//subscriber.SubscribeAsync("mychannel" , (channel,message) =>
subscriber.SubscribeAsync("mychannel.*", (channel,message) =>
{
    Console.WriteLine(message);
});
Console.ReadLine();