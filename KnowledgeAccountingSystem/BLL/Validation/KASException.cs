using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    /// <summary>
    /// Represents error occuring during Knowledge Accounting System application execution.
    /// </summary>
    public class KASException : Exception
    {
        public KASException(string massage): base(massage) { }
    }
}
