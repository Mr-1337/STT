using System;
using System.Threading;
using SDL2;
using STT.Graphics;

/*
 * Hey now, you're an all star
 * Get your game on, go, play
 * Hey now, you're a rock star
 * Get your show on, get, paid
 */
namespace STT
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Can't we settle this over a pint?!");

            STT program = new STT();
            program.Run();
        }
    }
}
