using SDL2;
using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Graphics
{
    class PianoRoll
    {

        private List<Key> KeyGraphics { get; set; }
        private List<Key> BlackKeys { get; set; }
        private List<Key> WhiteKeys { get; set; }
        private int KeyWidth { get; set; } = 30;
        private int KeyHeight { get; set; } = 160;
        private int PianoX { get; set; } = 200;
        private int PianoY { get; set; } = 100;

        public byte[] Keys { get; set; }

        public PianoRoll()
        {

            KeyGraphics = new List<Key>(48);
            WhiteKeys = new List<Key>(48);
            BlackKeys = new List<Key>(48);
            Keys = new byte[64];
            lastX = PianoX;
            genOctave();
            genOctave();
            genOctave();
            //genOctave();
        }

        private int lastX;

        private void addKey(Key key)
        {
            SDL.SDL_Rect r = new SDL.SDL_Rect();
            if (key is WhiteKey)
            {
                r.x = lastX;
                r.w = (int)(KeyWidth * key.ScaleX);
                r.h = (int)(KeyHeight * key.ScaleY);
                r.y = PianoY;
                lastX += r.w;
                WhiteKeys.Add(key);
            }
            else
            {
                r.w = (int)(KeyWidth * key.ScaleX);
                r.h = (int)(KeyHeight * key.ScaleY);
                r.y = PianoY;
                r.x = lastX - (r.w/2);
                BlackKeys.Add(key);
            }
            key.Rect = r;
            KeyGraphics.Add(key);
        }

        private void genOctave()
        {
            addKey(new WhiteKey());
                addKey(new BlackKey());
            addKey(new WhiteKey());
                addKey(new BlackKey());
            addKey(new WhiteKey());
            addKey(new WhiteKey());
                addKey(new BlackKey());
            addKey(new WhiteKey());
                addKey(new BlackKey());
            addKey(new WhiteKey());
                addKey(new BlackKey());
            addKey(new WhiteKey());
        }



        public void Draw()
        {

            for (int i = 0; i < Keys.Length; i++)
            {
                Renderer.Instance.SetDrawColor(255, 255, 255, 255);
                if (Keys[i] == 1)
                {
                    if (i < KeyGraphics.Count)
                    KeyGraphics[i].Pressed = true;
                }
                else if (i < KeyGraphics.Count)
                    KeyGraphics[i].Pressed = false;
            }

            foreach (var k in WhiteKeys)
            {
                var v = k.Color;
                if (k.Pressed)
                    v /= 2;
                Renderer.Instance.SetDrawColor(v, v, v, 255);
                Renderer.Instance.FillRect(k.Rect);
                Renderer.Instance.SetDrawColor(0, 0, 0, 255);
                Renderer.Instance.DrawRect(k.Rect);
            }
            foreach (var k in BlackKeys)
            {
                var v = k.Color;
                if (k.Pressed)
                    v /= 2;
                Renderer.Instance.SetDrawColor(v, v, v, 255);
                Renderer.Instance.FillRect(k.Rect);
                Renderer.Instance.SetDrawColor(0, 0, 0, 255);
                Renderer.Instance.DrawRect(k.Rect);
            }
        }
    }
}
