using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ZodiacSingsClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacSign.ZodiacSignClient(channel);

            var clientRequest = new CustomerDate() {Date="10/01/2000"};

            var response = await client.GetZodiacSignAsync(clientRequest);
            Console.WriteLine(response.ZodiacSignName);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
