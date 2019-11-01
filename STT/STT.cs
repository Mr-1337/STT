using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using SDL2;
using STT.Generators;
using STT.Graphics;

namespace STT
{
    class STT
    {
        private Window window;
        private bool running;

        private SDL.SDL_AudioSpec desired;
        private uint device;

        private List<Generator> gens;
        private int activeGen;
        private PianoRoll PianoRoll { get; set; }
        private UdpClient Client { get; set; }
        private ConcurrentQueue<byte[]> PacketQueue { get; set; }

        private double time = 0;
        private double packetTime = 0;

        private void Callback(IntPtr userdata, IntPtr stream, int len)
        {
            byte[] data = new byte[len];

            for (int i = 0; i < len / 4; i++)
            {
                float sample = 0;
                sample += (float)gens[activeGen].GetSample(time);
                //Console.WriteLine(BitConverter.ToSingle(data, i * 4 > 2000 ? i * 4 - 2000 : i * 4));
                var temp = BitConverter.GetBytes(sample);// + (2f * BitConverter.ToSingle(data, i > 100 ? i-100 : i)));
                data[4 * i + 0] = temp[0];
                data[4 * i + 1] = temp[1];
                data[4 * i + 2] = temp[2];
                data[4 * i + 3] = temp[3];
                time += 1f / 44100;
            }

            Marshal.Copy(data, 0, stream, len);
        }

        public STT()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
            window = new Window();
            running = true;
            desired.freq = 44100;
            desired.samples = 4096;
            desired.channels = 1;
            desired.format = SDL.AUDIO_F32;
            desired.callback = Callback;
            device = SDL.SDL_OpenAudioDevice(null, 0, ref desired, out var obtained, (int)SDL.SDL_AUDIO_ALLOW_ANY_CHANGE);
            SDL.SDL_PauseAudioDevice(device, 0);
            activeGen = 0;
            gens = new List<Generator>();
            gens.Add(new SawGenerator());
            gens.Add(new SquareGenerator());
            gens.Add(new Organ());
            gens.Add(new SineGenerator());
            PianoRoll = new PianoRoll();

            PacketQueue = new ConcurrentQueue<byte[]>();

            Client = new UdpClient(25565);
            Console.WriteLine("Enter the other IP address:");
            string ip = Console.ReadLine();

            Client.Connect(ip, 25565);

            Client.BeginReceive(new AsyncCallback(onRecv), Client);
        }

        public void Run()
        {
            double delta = 1.0 / 60.0;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (running)
            {
                timer.Restart();
                processEvents();
                update(delta);
                draw(delta);
                delta = timer.ElapsedMilliseconds / 1000.0;
            }
        }

        private void processEvents()
        {
            while (SDL.SDL_PollEvent(out SDL.SDL_Event e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        running = false;
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        if (e.key.keysym.scancode== SDL.SDL_Scancode.SDL_SCANCODE_SPACE && e.key.repeat==0)
                        {
                            activeGen++;
                            activeGen %= gens.Count;
                        }
                        break;
                }
            }
        }

        byte[] input = new byte[64];
        byte[] localInput = new byte[64];
        byte[] remoteInput = new byte[64];

        private void update(double delta)
        {
            var keys = SDL.SDL_GetKeyboardState(out int num);
            byte[] rawInput = new byte[num];
            Marshal.Copy(keys, rawInput, 0, num);
            for (int i = 0; i < Input.KeyConstants.Length; i++)
            {
                int k = (i >= 17) ? -5 : 0;
                if (rawInput[(int)Input.KeyConstants[i]] == 1)
                    localInput[i + k] = 1;
                else
                {
                    localInput[i + k] = 0;
                }
            }

            foreach (var packet in PacketQueue)
            {
                PacketQueue.TryDequeue(out byte[] p);
                for (int i = 0; i < p.Length; i++)
                {
                        remoteInput[i] = p[i];
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)(remoteInput[i] | localInput[i]);
            }

            gens[activeGen].Keys = input;
            PianoRoll.Keys = input;

            if (time > 30)
                time = 0;
            packetTime += delta;
            //Console.WriteLine(delta);
            if (packetTime > 0.1)
            {
                Console.Write("Sent");
                packetTime = 0;
                Client.Send(localInput, input.Length);
            }
            //((Organ)activeGen).Phaser = 0.005f * MathF.Sin(MathF.PI * 2f * 0.5f * time);
        }

        private void onRecv(IAsyncResult result)
        {
            UdpClient state = result.AsyncState as UdpClient;
            IPEndPoint endPoint = new IPEndPoint(0, 25565);
            PacketQueue.Enqueue(state.EndReceive(result, ref endPoint));
            state.BeginReceive(new AsyncCallback(onRecv), state);
        }
        private void draw(double delta)
        {
            Renderer.Instance.SetDrawColor(23, 23, 23, 255);
            Renderer.Instance.Clear();
            PianoRoll.Draw();
            Renderer.Instance.Present();
        }
    }
}
