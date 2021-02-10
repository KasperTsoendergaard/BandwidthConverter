using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class HelperMethods
    {
        internal static void CapacityInPercentageBasedOnAvailableBandwidth(decimal requiredBandwidthCapacity, int bandwidth)
        {
            int percentage = 100;

            decimal capacityInPercentageBasedOnAvailableBandwidth = (requiredBandwidthCapacity / bandwidth) * percentage;
            decimal truncatedPercentage = TruncateDigits(capacityInPercentageBasedOnAvailableBandwidth);
            
            Console.WriteLine();
            Console.WriteLine($"The required capacity of { requiredBandwidthCapacity } Mbps is { truncatedPercentage } % of the total available bandwidth of {bandwidth} Mbps ");
        }
        
        internal static decimal BandwidthCapacityRequirement(int fileSizeInMegaBytes)
        {
            decimal fileSizeInBits = (decimal)fileSizeInMegaBytes * 8;
            int secondsInOneMinutes = 60;
            int minutes = 60;
            int hours = 24;
            int totalSecondsInOneDay = minutes * hours * secondsInOneMinutes;

            decimal requiredBandwidthCapacity = fileSizeInBits / totalSecondsInOneDay;

            decimal truncatedMbps = TruncateDigits(requiredBandwidthCapacity);

            Console.WriteLine();
            Console.WriteLine($"We assume the file is transferred throughout a period of 1 day or { totalSecondsInOneDay } seconds (no batches). ");
            Console.WriteLine($"The required bandwidth capacity for the file size of {fileSizeInMegaBytes} MB is then {truncatedMbps} Mbps");

            return truncatedMbps;
        }

        internal static void TimeToUpload(int fileSizeInMegaBytes, int bandwidth)
        {
            // https://helpdesk.egnyte.com/hc/en-us/articles/201637064-How-Long-Will-it-Take-to-Upload-Backup-or-Download-my-Files-#:~:text=You%20can%20calculate%20the%20approximate,Total%20Upload%20time%20in%20minutes.

            int fileSizeInBites = fileSizeInMegaBytes * 8;
            int secondsInOneMinute = 60;

            double timeToUploadInMinutes = ((double)fileSizeInBites / (double)bandwidth) / secondsInOneMinute; // 800 / 10 / 60  --- 1,3333

            TimeSpan timeSpanUploadTime = TimeSpan.FromMinutes(timeToUploadInMinutes);
            int days = timeSpanUploadTime.Days;
            int hours = timeSpanUploadTime.Hours;
            int minutes = timeSpanUploadTime.Minutes;
            int seconds = timeSpanUploadTime.Seconds;

            Console.WriteLine();
            if (days > 0)
            {
                Console.WriteLine($"The download/upload time needed for a {fileSizeInMegaBytes} MB file is {days} days {hours} hours {minutes} minutes and {seconds} seconds ");
            }
            else if (hours > 0)
            {
                Console.WriteLine($"The download/upload time for a {fileSizeInMegaBytes} MB file is {hours} hours {minutes} minutes and {seconds} seconds ");
            }
            else if (minutes > 0)
            {
                Console.WriteLine($"The download/upload time for a {fileSizeInMegaBytes} MB file is {minutes} minutes and {seconds} seconds ");
            }
            else if (seconds > 0)
            {
                Console.WriteLine($"The download/upload time for a {fileSizeInMegaBytes} MB file is {seconds} seconds ");
            }
            else
            {
                Console.WriteLine("Invalid time or file size");
            }
        }

        private static decimal TruncateDigits(decimal valueToTruncate)
        {
            decimal truncatedValue = Math.Truncate(valueToTruncate * 100) / 100; //To limit digits to (X)X.XX

            return truncatedValue;
        }
    }
}
