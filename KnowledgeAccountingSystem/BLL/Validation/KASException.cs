using System;

namespace BLL.Validation
{
    /// <summary>
    /// Represents error occuring during Knowledge Accounting System application execution.
    /// </summary>
    [Serializable]
    public class KASException : Exception
    {
        public KASException() { }

        public KASException(string massage) : base(massage) { }

        public KASException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
