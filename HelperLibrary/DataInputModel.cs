using System;
using System.Collections.Generic;
using System.Text;

namespace HelperLibrary
{
    public class DataInputModel : IDataInputModel
    {
        public int FileSizeInMegaBytes { get; set; }
        public int Bandwidth { get; set; }
    }
}
