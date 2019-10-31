using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Generators
{
    /// <summary>
    /// The base class for all tone generators
    /// </summary>
    abstract class Generator
    {
        public virtual byte[] Keys { get; set; }

        public abstract double GetSample(double time);

        public Generator()
        {
            Keys = new byte[512];
        }

    }
}
