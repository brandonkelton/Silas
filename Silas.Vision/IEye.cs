using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Sight
{
    public interface IEye : IDisposable
    {
        event EventHandler DataAvailable;
    }
}
