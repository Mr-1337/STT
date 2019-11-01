using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Generators
{
    class SineGenerator : Generator
    {

        public double Frequency { get; set; } = 440f;
        public double FreqMult { get; set; } = 1.0f;
        public double Phase { get; set; } = 0f;

        public override double GetSample(double time)
        {
            double total = 0f;

            for (int i = 0; i < Keys.Length; i++)
            {
                if (Keys[i] == 1)
                {
                    Frequency = 220f * Math.Pow(2, (i - 9) / 12f);
                    total += 0.05f * Math.Sin(Phase + Math.PI * 2 * Frequency * FreqMult * time);
                }
            }

            return total;
        }
    }
}
