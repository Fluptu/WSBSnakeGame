using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    private static void Main()
    {
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;

        int screenwidth = Console.WindowWidth - 10;
        int screenheight = Console.WindowHeight - 5;
        Random randomnummer = new();
        Pixel hoofd = new Pixel();
        hoofd.xPos = screenwidth / 2;
        hoofd.yPos = screenheight / 2;
        hoofd.schermKleur = ConsoleColor.Red;

        string movement = "RIGHT";
        int score = 0;
        List<int> teljePositie = new List<int>();
        List<int> telje = new List<int>();

        DateTime tijd = DateTime.Now;
        string obstacle = "*";
        int obstacleXpos = randomnummer.Next(1, screenwidth);
        int obstacleYpos = randomnummer.Next(1, screenheight);

        while (true)
        {
            Console.Clear();
            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");


            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }

            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }

            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nScore: " + score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("H");
            for (int i = 0; i < telje.Count; i += 2)
            {
                Console.SetCursorPosition(telje[i], telje[i + 1]);
                Console.Write("■");
            }


            //Draw Snake
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");

            ConsoleKeyInfo info = Console.ReadKey();
            //Game Logic
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    movement = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    movement = "DOWN";
                    break;
                case ConsoleKey.LeftArrow:
                    movement = "LEFT";
                    break;
                case ConsoleKey.RightArrow:
                    movement = "RIGHT";
                    break;
            }

            if (movement == "UP")
            {
                hoofd.yPos--;
            }

            if (movement == "DOWN")
            {
                hoofd.yPos++;
            }

            if (movement == "LEFT")
            {
                hoofd.xPos--;
            }

            if (movement == "RIGHT")
            {
                hoofd.xPos++;
            }

            //Hindernis treffen
            if (hoofd.xPos == obstacleXpos && hoofd.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = randomnummer.Next(1, screenwidth);
                obstacleYpos = randomnummer.Next(1, screenheight);
            }

            teljePositie.Insert(0, hoofd.xPos);
            teljePositie.Insert(1, hoofd.yPos);
            teljePositie.RemoveAt(teljePositie.Count - 1);
            teljePositie.RemoveAt(teljePositie.Count - 1);

            //Kollision mit Wände oder mit sich selbst
            if (hoofd.xPos == 0 || hoofd.xPos == screenwidth - 1 || hoofd.yPos == 0 || hoofd.yPos == screenheight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
                Console.WriteLine("Dein Score ist: " + score);
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);
                Environment.Exit(0);
            }
            for (int i = 0; i < teljePositie.Count; i++)
            {
                if (hoofd.xPos == teljePositie[i] && hoofd.yPos == teljePositie[i + 1] && i != 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(screenwidth / 5, (screenheight / 2) + 1);
                    Console.WriteLine("Dein Score ist: " + score);
                    Console.SetCursorPosition(screenwidth / 5, (screenheight / 2) + 2);
                    Environment.Exit(0);
                }
            }
            Thread.Sleep(50);
        }
    }
}

public class Pixel
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string? karacter { get; set; }
}

public class Obstakel
{
    public int Xpos { get; set; }
    public int Ypos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string? karacter { get; set; }
}