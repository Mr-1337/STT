using System;
using System.Collections.Generic;
using System.Text;
using SDL2;

namespace STT.Graphics
{
    class Window
    {

        private IntPtr window;

        private string title;
        public string Title
        {
            get => title;
            set
            {
                SDL.SDL_SetWindowTitle(window, title = value);
            }
        }

        public Window()
        {
            window = SDL.SDL_CreateWindow("spooky", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 1024, 720, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            Title = "Beans 2";
            Renderer.Construct(window);
        }
    }
}
