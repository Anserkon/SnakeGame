using System;
using System.Collections.Generic;
using Cn = System.Console;
namespace SnakeTheGame
{
    internal class Program{static void Main(){
            Cn.Title = "snakegame"; 
            Random rnd = new Random();
            char snakesymbol = 'D', applesymbol = 'Q';
            int vectorx = 1, vectory = 0;
            ConsoleKey key;
            int[][] snake = new int[][] {new int[] { 5, 5 }};
            var keys = new Dictionary<ConsoleKey, (int, int)>
            {
                {ConsoleKey.UpArrow, ( 0 , -1 )},
                {ConsoleKey.DownArrow, ( 0 , 1 )},
                {ConsoleKey.LeftArrow, ( -1 , 0 )},
                {ConsoleKey.RightArrow, ( 1 , 0 )},
            };
            int[] apple = { 3, 3 };
            int time = 150;
            int[] shead = { 0, 0 };
            bool exit = false;
            Cn.CursorVisible = false; Cn.BackgroundColor = ConsoleColor.Green;
            while (!exit)
            {
                Cn.WindowHeight = 15;
                Cn.WindowWidth = 40;
                Cn.BufferHeight = Cn.WindowHeight;
                Cn.BufferWidth = Cn.WindowWidth;
                System.Threading.Thread.Sleep( time );
                if (Cn.KeyAvailable) {
                    key = Cn.ReadKey(true).Key;
                    try {vectorx = keys[key].Item1; vectory = keys[key].Item2; } catch ( Exception ){}
                }
                Cn.ForegroundColor = ConsoleColor.Black; Cn.Clear(); Cn.WriteLine(snake.Length);
                for (int i = snake.Length - 1; i >= 0; i--)
                {
                    Cn.SetCursorPosition(snake[i][0], snake[i][1]);
                    Cn.Write(snakesymbol);
                    if (i == 0){
                        snake[i][0] += vectorx;
                        snake[i][1] += vectory;
                        if (snake[i][0] > Cn.BufferWidth-1){snake[i][0] = 0;}
                        if (snake[i][0] < 0){snake[i][0] = Cn.BufferWidth-1;}
                        if (snake[i][1] > Cn.BufferHeight-1){snake[i][1] = 0;}
                        if (snake[i][1] < 0){snake[i][1] = Cn.BufferHeight-1;}}
                    else{
                        snake[i][0] = snake[i - 1][0];
                        snake[i][1] = snake[i - 1][1];}
                }
                Cn.ForegroundColor = ConsoleColor.DarkRed;
                Cn.SetCursorPosition(apple[0], apple[1]);
                Cn.WriteLine(applesymbol);
                shead[0] = snake[0][0];
                shead[1] = snake[0][1];
                for (int i = 1; i < snake.Length; i++)
                {
                    if (shead[0] == snake[i][0] && shead[1] == snake[i][1])
                        {Cn.ForegroundColor = ConsoleColor.DarkRed;Cn.SetCursorPosition(shead[0], shead[1]);Cn.Write(snakesymbol);
                        Cn.SetCursorPosition(0, 0);Cn.Write("Game over, count is "+snake.Length);exit = true;}}
                if (shead[0] == apple[0] && shead[1] == apple[1])
                {
                    Array.Resize(ref snake, snake.Length + 1);
                    snake[snake.Length - 1] = new int[] { 0, 0 };
                    apple[0] = rnd.Next(Cn.BufferWidth-1);
                    apple[1] = rnd.Next(Cn.BufferHeight-1);
                }
                Cn.CursorLeft = 0;
                Cn.CursorTop = 0;
            }
            Cn.ReadLine();
        }
    }
}
