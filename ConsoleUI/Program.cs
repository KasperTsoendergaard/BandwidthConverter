using System;
using HelperLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataInputModel dataInputs = new DataInputModel
            {
                FileSizeInMegaBytes = 172800,
                Bandwidth = 1000
            };

            decimal requiredBandwidthCapacity = HelperMethods.BandwidthCapacityRequirement(dataInputs.FileSizeInMegaBytes);

            HelperMethods.TimeToUpload(dataInputs.FileSizeInMegaBytes, dataInputs.Bandwidth);

            HelperMethods.CapacityInPercentageBasedOnAvailableBandwidth(requiredBandwidthCapacity, dataInputs.Bandwidth);

            //Test for GitHub

            //TODO: Byte Conversion e.g. MB to GB or Mbps to Gbps
            //TODO: convert to web app
            
        }
    }
}
