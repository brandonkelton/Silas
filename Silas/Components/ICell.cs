using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Components
{
    /// <summary>
    /// Transposition of all inputs
    /// </summary>
    public interface ICell
    {
        List<IInput> Inputs { get; set; }

        IOutput Output { get; set; }
    }
}
