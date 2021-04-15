using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace ZodiacClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Zodiac.ZodiacClient(channel);
            var request = new CustomerDate();
            request.Date = "10/10/2000";
            var response = await client.GetZodiacSignAsync(request);
            Console.WriteLine(response);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
