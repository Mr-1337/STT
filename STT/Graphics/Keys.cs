using SDL2;
using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Graphics
{
    abstract class Key
    {
        public virtual SDL.SDL_Rect Rect { get; set; }
        public abstract byte Color { get; }
        public bool Pressed { get; set; } = false;
        public abstract float ScaleX { get; }
        public abstract float ScaleY { get; }
    }

    class WhiteKey : Key
    {
        public override byte Color => 255;
        public override float ScaleX => 1f;
        public override float ScaleY => 1f;
    }

    class BlackKey : Key
    {
        public override byte Color => 42;
        public override float ScaleX => 0.5f;
        public override float ScaleY => 0.6f;
    }
}
