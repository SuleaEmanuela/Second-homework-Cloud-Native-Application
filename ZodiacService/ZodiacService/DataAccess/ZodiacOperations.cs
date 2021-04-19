using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZodiacService.Protos;

namespace ZodiacService.DataAccess
{
    public class ZodiacOperations
    {
        private readonly string filePath = "./Resources/ZodiacSigns.txt";

        public ZodiacSign GetZodiacSign(CustomerDate date)
        {
            string[] formattedDate = date.Date.Split('/');
            string day = formattedDate[1];
            string month = formattedDate[0];
            var zodiacSign = new ZodiacSign();
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                while ((line=sr.ReadLine()) != null)
                {

                    string[] words = line.Split(' ');
                    string startDateSign = words[1];
                    string[] formattedStartDate = startDateSign.Split('/');
                    string startMonth = formattedStartDate[0];
                    string startDay = formattedStartDate[1];
                    string endDateSign = words[2];
                    string[] formattedEndDate = endDateSign.Split('/');
                    string endMonth = formattedEndDate[0];
                    string endDay = formattedEndDate[1];
                    if (month.Contains(startMonth) || month.Contains(endMonth))
                    {
                        if ((Convert.ToInt32(day)) > Convert.ToInt32(startDay))
                            zodiacSign.SignName = words[0];
                            //System.Console.WriteLine(words[0]);

                    }
                    if (month.Contains(endMonth))
                    {
                        if ((Convert.ToInt32(day)) < Convert.ToInt32(endDay))
                            zodiacSign.SignName = words[0];
                        //System.Console.WriteLine(words[0]);
                    }

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return zodiacSign;
        }

        public void ValidateDate(CustomerDate date)
        {
            DateTime result;
            string[] formats = { "M/d/yyyy", "MM/dd/yyyy" };
            bool dateValide2 = DateTime.TryParseExact(date.Date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
           // Console.WriteLine(dateValide2);
        }
    }
}
