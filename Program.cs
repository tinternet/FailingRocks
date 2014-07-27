using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Falling_Rocks
{

    class Program
    {
        struct Position
        {
            public int Col, Row;
            public Position(int x, int y)
            {
                this.Col = x;
                this.Row = y;
            }
        }

        static Random randomNumber = new Random(DateTime.Now.Millisecond);

        private static List<Position> RocksArray()
        {
            List<Position> rocks = new List<Position>();
            for (int i = 0; i < randomNumber.Next(2, 7); i++)
            {
                rocks.Add(new Position(
                    randomNumber.Next(1, Console.WindowWidth - 1),
                    randomNumber.Next(1, Console.WindowHeight - 13)));
            }
            return rocks;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            DateTime startingTime = DateTime.Now;
            double sleepTime = 50;

            
            Position dwarf = new Position(39, 24);
            Console.SetCursorPosition(dwarf.Col, dwarf.Row);
           
            Console.Write("0");
            Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
            Console.Write(")");
            Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
            Console.Write("(");

            List<Position> plusRocks = RocksArray();
            PrintRocks(plusRocks, "+");
            List<Position> upperRocks = RocksArray();
            PrintRocks(upperRocks, "^");
            List<Position> maimunRocks = RocksArray();
            PrintRocks(maimunRocks, "@");
            List<Position> multyRocks = RocksArray();
            PrintRocks(multyRocks, "*");
            List<Position> andRocks = RocksArray();
            PrintRocks(andRocks, "&");
            List<Position> procentRocks = RocksArray();
            PrintRocks(procentRocks, "%");
            List<Position> moneyRocks = RocksArray();
            PrintRocks(moneyRocks, "$");
            List<Position> sharpRocks = RocksArray();
            PrintRocks(sharpRocks, "#");
            List<Position> minusRocks = RocksArray();
            PrintRocks(minusRocks, "-");
            List<Position> exclamationRocks = RocksArray();
            PrintRocks(exclamationRocks, "!");
            List<Position> dotRocks = RocksArray();
            PrintRocks(dotRocks, ".");
            List<Position> dotSlashRocks = RocksArray();
            PrintRocks(dotSlashRocks, ";");

            int speedMeter = 1;
            Console.ReadKey();

            while (true)
            {
                // Read user key
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    MoveDwarf(ref dwarf, pressedKey);
                }
                if (speedMeter % 3 == 0)
                {
                    MoveRocks(ref plusRocks, "+");
                    if (CheckCollision(ref plusRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }

                    MoveRocks(ref upperRocks, "^");
                    if (CheckCollision(ref upperRocks, dwarf, startingTime, "^"))
                    {
                        return;
                    }

                    MoveRocks(ref maimunRocks, "@");
                    if (CheckCollision(ref maimunRocks, dwarf, startingTime, "@"))
                    {
                        return;
                    }

                    MoveRocks(ref multyRocks, "*");
                    if (CheckCollision(ref multyRocks, dwarf, startingTime, "*"))
                    {
                        return;
                    }

                    MoveRocks(ref andRocks, "&");
                    if (CheckCollision(ref andRocks, dwarf, startingTime, "&"))
                    {
                        return;
                    }

                    MoveRocks(ref procentRocks, "%");
                    if (CheckCollision(ref procentRocks, dwarf, startingTime, "%"))
                    {
                        return;
                    }

                    MoveRocks(ref moneyRocks, "$");
                    if (CheckCollision(ref moneyRocks, dwarf, startingTime, "$"))
                    {
                        return;
                    }

                    MoveRocks(ref sharpRocks, "#");
                    if (CheckCollision(ref sharpRocks, dwarf, startingTime, "#"))
                    {
                        return;
                    }

                    MoveRocks(ref minusRocks, "-");
                    if (CheckCollision(ref minusRocks, dwarf, startingTime, "-"))
                    {
                        return;
                    }

                    MoveRocks(ref exclamationRocks, "!");
                    if (CheckCollision(ref exclamationRocks, dwarf, startingTime, "!"))
                    {
                        return;
                    }

                    MoveRocks(ref dotRocks, ".");
                    if (CheckCollision(ref dotRocks, dwarf, startingTime, "."))
                    {
                        return;
                    }

                    MoveRocks(ref dotSlashRocks, ";");
                    if (CheckCollision(ref dotSlashRocks, dwarf, startingTime, ";"))
                    {
                        return;
                    }
                }

                speedMeter++;
                Thread.Sleep((int)sleepTime);
                sleepTime -= 0.02;
            }
        }

        private static void PrintRocks(List<Position> rocks, string rock)
        {
            for (int i = 0; i < rocks.Count; i++)
            {
                Console.SetCursorPosition(rocks[i].Col, rocks[i].Row);
                Console.Write(rock);
            }
        }

        private static void MoveRocks(ref List<Position> rocks, string rock)
        {
            List<Position> newRocks = new List<Position>();
            foreach (var currentRock in rocks)
            {
                Console.SetCursorPosition(currentRock.Col, currentRock.Row);

                Console.Write(" ");
                Console.SetCursorPosition(currentRock.Col, (currentRock.Row + 1));
                newRocks.Add(new Position(currentRock.Col, currentRock.Row + 1));
                Console.Write(rock);
            }
            rocks = newRocks;
        }

        private static void MoveDwarf(ref Position dwarf, ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (dwarf.Col != (Console.WindowWidth - 3))
                {
                    Console.SetCursorPosition(dwarf.Col, dwarf.Row);

                    Console.Write(" ");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);

                    Console.Write(" ");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);

                    Console.Write(" ");
                    Console.SetCursorPosition((dwarf.Col += 1), dwarf.Row);

                    Console.Write("0");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
                    Console.Write(")");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
                    Console.Write("(");
                }
                else
                {
                    Console.SetCursorPosition(dwarf.Col, (dwarf.Row - 1));

                    Console.Write(" ");
                    Console.SetCursorPosition(dwarf.Col, dwarf.Row);

                    Console.Write("0");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
                    Console.Write(")");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
                    Console.Write("(");
                }
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (dwarf.Col != (Console.WindowWidth - 79))
                {
                    Console.SetCursorPosition(dwarf.Col, dwarf.Row);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    Console.SetCursorPosition((dwarf.Col -= 1), dwarf.Row);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("0");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
                    Console.Write(")");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
                    Console.Write("(");
                }
                else
                {
                    Console.SetCursorPosition(dwarf.Col, dwarf.Row);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("0");
                    Console.SetCursorPosition(dwarf.Col + 1, dwarf.Row);
                    Console.Write(")");
                    Console.SetCursorPosition(dwarf.Col - 1, dwarf.Row);
                    Console.Write("(");
                }
            }
        }

        private static bool CheckCollision(ref List<Position> rocks, Position dwarf, DateTime startingTime, string rockSymbol)
        {
            List<Position> newRocks = new List<Position>();

            foreach (var rock in rocks)
            {
                if (rock.Row > (Console.WindowHeight - 2))
                {
                    if (dwarf.Col == rock.Col || (dwarf.Col - 1) == rock.Col || (dwarf.Col + 1) == rock.Col)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Game Over! Your time : " + (DateTime.Now - startingTime) + " seconds");
                        Console.ReadLine();
                        return true;
                    }
                    else
                    {
                        Console.SetCursorPosition(rock.Col, rock.Row);
                        Console.Write(" ");
                        Position newRock = new Position(randomNumber.Next(1, Console.WindowWidth - 1), randomNumber.Next(1, Console.WindowHeight - 13));
                        newRocks.Add(newRock);
                        Console.SetCursorPosition(newRock.Col, (newRock.Row));
                        Console.Write(rockSymbol);
                    }
                }
                else
                {
                    newRocks.Add(rock);
                }
            }
            rocks = newRocks;
            return false;
        }
    }
}