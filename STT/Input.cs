using System;
using System.Collections.Generic;
using System.Text;
using SDL2;

namespace STT
{
    class Input
    {



        public Input()
        {

        }

        public static SDL.SDL_Scancode []KeyConstants = new[]
        {
            SDL.SDL_Scancode.SDL_SCANCODE_Z, SDL.SDL_Scancode.SDL_SCANCODE_S, SDL.SDL_Scancode.SDL_SCANCODE_X, SDL.SDL_Scancode.SDL_SCANCODE_D, SDL.SDL_Scancode.SDL_SCANCODE_C, SDL.SDL_Scancode.SDL_SCANCODE_V, SDL.SDL_Scancode.SDL_SCANCODE_G, SDL.SDL_Scancode.SDL_SCANCODE_B, SDL.SDL_Scancode.SDL_SCANCODE_H,
            SDL.SDL_Scancode.SDL_SCANCODE_N, SDL.SDL_Scancode.SDL_SCANCODE_J, SDL.SDL_Scancode.SDL_SCANCODE_M, SDL.SDL_Scancode.SDL_SCANCODE_COMMA, SDL.SDL_Scancode.SDL_SCANCODE_L, SDL.SDL_Scancode.SDL_SCANCODE_PERIOD, SDL.SDL_Scancode.SDL_SCANCODE_SEMICOLON, SDL.SDL_Scancode.SDL_SCANCODE_SLASH,
            SDL.SDL_Scancode.SDL_SCANCODE_Q, SDL.SDL_Scancode.SDL_SCANCODE_2, SDL.SDL_Scancode.SDL_SCANCODE_W, SDL.SDL_Scancode.SDL_SCANCODE_3, SDL.SDL_Scancode.SDL_SCANCODE_E, SDL.SDL_Scancode.SDL_SCANCODE_R, SDL.SDL_Scancode.SDL_SCANCODE_5, SDL.SDL_Scancode.SDL_SCANCODE_T, SDL.SDL_Scancode.SDL_SCANCODE_6,
            SDL.SDL_Scancode.SDL_SCANCODE_Y, SDL.SDL_Scancode.SDL_SCANCODE_7, SDL.SDL_Scancode.SDL_SCANCODE_U, SDL.SDL_Scancode.SDL_SCANCODE_I, SDL.SDL_Scancode.SDL_SCANCODE_9, SDL.SDL_Scancode.SDL_SCANCODE_O, SDL.SDL_Scancode.SDL_SCANCODE_0, SDL.SDL_Scancode.SDL_SCANCODE_P, SDL.SDL_Scancode.SDL_SCANCODE_LEFTBRACKET, SDL.SDL_Scancode.SDL_SCANCODE_EQUALS, SDL.SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET
        };
    }
}
