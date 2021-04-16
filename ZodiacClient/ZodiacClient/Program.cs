﻿using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System.Threading.Tasks;
using System.Net.Http;

namespace ZodiacClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            //new GrpcChannelOptions { HttpHandler = httpHandler }
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Zodiac.ZodiacClient(channel);
            // var response = await client.GetZodiacSignAsync(
               //  new CustomerDate { Date="10/10/2000"});
            // Console.WriteLine(response.SignName);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
