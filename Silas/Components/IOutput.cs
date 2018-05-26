using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Silas.Components
{
    public interface IOutput
    {
        Stream Stream { get; set; }
    }
}
