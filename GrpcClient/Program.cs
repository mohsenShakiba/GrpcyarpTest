using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // this does not work as it goes through the yarp proxy
            var channel = GrpcChannel.ForAddress("http://localhost:8000");
            
            // but this works as it connects directly to the grpc service
            // var channel = GrpcChannel.ForAddress("http://localhost:6000");
            
            var client = new Greeter.GreeterClient(channel);

            var helloRequest = new HelloRequest {Name = "Client"};
            
            var response = await client.SayHelloAsync(helloRequest);

            Console.WriteLine($"Response from greeter service is {response.Message}");
        }
    }
}