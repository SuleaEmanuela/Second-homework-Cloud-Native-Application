using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacService.Protos;

namespace ZodiacService.Services
{
    public class CustomerZodiacService : Zodiac.ZodiacBase
    {
        private readonly ILogger<CustomerZodiacService> _logger;

        public CustomerZodiacService(ILogger<CustomerZodiacService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(CustomerDate request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, "GetZodiacSign called");
            //ZodiacSign response = new ZodiacSign() { SignName="Aries"};
            return Task.FromResult(new ZodiacSign
            {
                SignName = "Aries" + request.Date
            });
            //return Task.FromResult(response);
        }


    }
}
