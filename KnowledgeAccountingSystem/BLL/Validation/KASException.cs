using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public class KASException : Exception
    {
        public KASException(string massage): base(massage) { }
    }
}
