using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Generators
{
    class SawGenerator : Generator
    {

        private double Frequency { get; set; }

        public override double GetSample(double time)
        {
            double total = 0f;
            for (int i = 0; i < Keys.Length; i++)
            {
                if (Keys[i] == 1)
                {
                    Frequency = 220 * Math.Pow(2, (i - 9) / 12.0);
                    double period = 1f / Frequency;
                    double amplitude = 2 * (time % period) / period - 1.0;
                    total += 0.05f * amplitude;
                }
            }
            return total;
        }
    }
}
