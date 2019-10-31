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

            for (int i = 0; i < 37; i++)
            {
                if (Keys[(int)Input.KeyConstants[i]] == 1)
                {
                    int k = 0;
                    if (i >= 17)
                        k = -5;
                    Frequency = 220f * Math.Pow(2, (i + k - 9) / 12f);
                    total += 0.05f * Math.Sin(Phase + Math.PI * 2 * Frequency * FreqMult * time);
                }
            }

            return total;
        }
    }
}
