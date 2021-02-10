using System;
using HelperLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataInputModel dataInputs = new DataInputModel
            //{
            //    FileSizeInMegaBytes = 172800,
            //    Bandwidth = 1000
            //};

            //FOR running the EXE file:
            Console.Write("Enter file size in MB: ");
            var fileSize = Console.ReadLine();
            int fileSizeInMegaBytes = Convert.ToInt32(fileSize);

            Console.Write("Enter available Bandwidth capacity: ");
            var bandwidthString = Console.ReadLine();
            int bandwidth = Convert.ToInt32(bandwidthString);

            decimal requiredBandwidthCapacity = HelperMethods.BandwidthCapacityRequirement(fileSizeInMegaBytes);

            HelperMethods.TimeToUpload(fileSizeInMegaBytes, bandwidth);

            HelperMethods.CapacityInPercentageBasedOnAvailableBandwidth(requiredBandwidthCapacity, bandwidth);



            //Using the interface contract - DataInputModel:
            //decimal requiredBandwidthCapacity = HelperMethods.BandwidthCapacityRequirement(dataInputs.fileSizeInMegaBytes);
            //HelperMethods.TimeToUpload(dataInputs.fileSizeInMegaBytes, dataInputs.Bandwidth)
            //HelperMethods.CapacityInPercentageBasedOnAvailableBandwidth(requiredBandwidthCapacity, dataInputs.Bandwidth);


            //TODO: Byte Conversion e.g. MB to GB or Mbps to Gbps
            //TODO: convert to web app

        }
    }
}
