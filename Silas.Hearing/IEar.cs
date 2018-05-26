using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Hearing
{
    public interface IEar : IDisposable
    {
        event EventHandler DataAvailable;
    }
}
