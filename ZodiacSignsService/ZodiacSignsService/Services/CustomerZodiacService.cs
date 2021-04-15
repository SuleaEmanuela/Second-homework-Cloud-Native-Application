using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacSignsService.Protos;

namespace ZodiacSignsService.Services
{
    public class CustomerZodiacService : ZodiacSign.ZodiacSignBase
    {

        public override Task<CustomerZodiacSign> GetZodiacSign(CustomerDate request, ServerCallContext context)
        {
            CustomerZodiacSign output = new CustomerZodiacSign();
            //validation 1
            DateTime result;
            string[] formats = { "M/d/yyyy", "MM/dd/yyyy" };
            bool dateValide = DateTime.TryParseExact(request.date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            if(dateValide==true)
            {
                output.zodiacSignName = "Aries";
            }
            return Task.FromResult(output);
        }
    }
}
