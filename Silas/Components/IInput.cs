using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Silas.Components
{
    public interface IInput
    {
        Stream Stream { get; set; }

        decimal Intensity { get; set; }
    }
}
