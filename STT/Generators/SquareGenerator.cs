﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Generators
{
    class SquareGenerator : Generator
    {

        private double Frequency { get; set; }

        public SquareGenerator()
        {

        }

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
                    Frequency = 220 * Math.Pow(2, (i + k - 9) / 12.0);
                    double period = 1f / Frequency;
                    float sign = ((time % period) / period) < 0.5 ? -1 : 1;
                    total += 0.05f * sign;
                }
            }
            return total;
        }
    }
}
