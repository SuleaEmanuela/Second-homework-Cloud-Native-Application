using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacService.Protos;
using ZodiacService.DataAccess;

namespace ZodiacService.Services
{
    public class CustomerZodiacService : Zodiac.ZodiacBase
    {
        private readonly ZodiacOperations zodiacOperations=new ZodiacOperations();
        private readonly ILogger<CustomerZodiacService> _logger;

        public CustomerZodiacService(ILogger<CustomerZodiacService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(CustomerDate request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, "GetZodiacSign function has been called.");

            var zodiacSignName = zodiacOperations.GetZodiacSign(request);

            var response = zodiacSignName;
            
            return Task.FromResult(response);
        }


    }
}
