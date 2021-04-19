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

        public static void validateCharPlacement(CustomerDate date)
        {
            DateTime result;
            char[] dateByCharaters = date.Date.ToCharArray();
            string[] formats = { "M/d/yyyy", "MM/dd/yyyy" };
            if (DateTime.TryParseExact(date.Date, formats[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out result) == true)
            {
                if (dateByCharaters[1] == '/' && dateByCharaters[3] == '/')
                {
                    Console.WriteLine("Pos:" + dateByCharaters[1] + " " + dateByCharaters[3]);
                }
            }
            if (DateTime.TryParseExact(date.Date, formats[1], CultureInfo.InvariantCulture, DateTimeStyles.None, out result) == true)
            {
                if (dateByCharaters[2] == '/' && dateByCharaters[5] == '/')
                {
                    Console.WriteLine("Pos:" + dateByCharaters[2] + " " + dateByCharaters[5]);
                }
            }

        }

        public void ValidateDate(CustomerDate date)
        {
            string[] formattedDate = date.Date.Split('/');
            string day = formattedDate[1];
            string month = formattedDate[0];
            string year = formattedDate[2];
            DateTime result;
            string[] formats = { "M/d/yyyy", "MM/dd/yyyy" };
            bool dateFormatValide = DateTime.TryParseExact(date.Date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            bool leapYear = DateTime.IsLeapYear(Convert.ToInt32(year));
            //Console.WriteLine(dateValide);
        }
    }
}
