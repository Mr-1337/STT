using SDL2;
using System;
using System.Collections.Generic;
using System.Text;

namespace STT.Graphics
{
    class Renderer
    {
        private IntPtr renderer;
        private static Renderer instance;

        public static void Construct(IntPtr window)
        {
            Instance = new Renderer(window);
        }

        private Renderer(IntPtr window)
        {
            renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        }

        public static Renderer Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                else
                    throw new Exception("Renderer Instance not");
            }
            private set
            {
                instance = value;
            }
        }

        public void Clear()
        {
            SDL.SDL_RenderClear(renderer);
        }

        public void Present()
        {
            SDL.SDL_RenderPresent(renderer);
        }

        public void SetDrawColor(byte r, byte g, byte b, byte a)
        {
            SDL.SDL_SetRenderDrawColor(renderer, r, g, b, a);
        }

        public void DrawRect(SDL.SDL_Rect rect)
        {
            SDL.SDL_RenderDrawRect(renderer, ref rect);
        }

        public void DrawRects(SDL.SDL_Rect[] rects)
        {
            SDL.SDL_RenderDrawRects(renderer, rects, rects.Length);
        }

        public void FillRect(SDL.SDL_Rect rect)
        {
            SDL.SDL_RenderFillRect(renderer, ref rect);
        }

        public void FillRects(SDL.SDL_Rect[] rects)
        {
            SDL.SDL_RenderFillRects(renderer, rects, rects.Length);
        }

    }
}
