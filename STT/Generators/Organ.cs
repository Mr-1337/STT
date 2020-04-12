using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Generators
{
    class Organ : Generator 
    {

        SineGenerator gen = new SineGenerator();
        readonly double power;
        readonly double volume;

        public double Phaser { get; set; } = 0;
        public Organ()
        {
            power = Math.Pow(2f, -5.0 / 12);
            volume = 1;
        }

        public override double GetSample(double time)
        {
            double amplitude = 0f;

            time += Phaser;

            gen.Keys = Keys;

            amplitude += volume * gen.GetSample(time);

            gen.Phase = 0.935;
            gen.FreqMult = 8;
            amplitude += volume * gen.GetSample(time);

            gen.Phase = 0.22;
            gen.FreqMult = 4;
            amplitude += volume * gen.GetSample(time);

            gen.Phase = 0.5;
            gen.FreqMult = 2;
            amplitude += volume * gen.GetSample(time);

            gen.Phase = 0.1;
            gen.FreqMult = 0.25;
            amplitude += volume * gen.GetSample(time);

            gen.Phase = 0;
            gen.FreqMult = 0.5;
            amplitude += volume * gen.GetSample(time);

            gen.FreqMult = power;
            amplitude += volume * gen.GetSample(time);

            gen.FreqMult = 1;
            amplitude += volume * gen.GetSample(time);

            amplitude = 0.08f * Math.Sign(amplitude) * (1 - (Math.Exp(-1 * Math.Abs(amplitude) * 500)));

            return amplitude;
        }
}
}
