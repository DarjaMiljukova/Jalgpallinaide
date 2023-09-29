using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jalgpallinaide;
namespace Jalgpallinaide
{

    public class Program
    {
        //muuda värv
        static void ChangeConsoleColor(ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;

        }
        public static void Main()
        {
            // loomine team ja stadium
            Team esimeneTeam = new Team("Esimene Team");
            Team teineTeam = new Team("Teine Team");
            Stadium stadium = new Stadium(60, 40);
            Game game = new Game(esimeneTeam, teineTeam, stadium);

            // loomine mängija
            for (int i = 1; i <= 22; i++)
            {
                Player player = new Player($"Player {i}");
                if (i <= 11)
                {
                    esimeneTeam.AddPlayer(player);
                }
                else
                {
                    teineTeam.AddPlayer(player);
                }
            }

            game.Start();
            Console.Title = "Jalgpalli näide";
            Console.WindowWidth = stadium.Width + 4;  
            Console.WindowHeight = stadium.Height + 5; 

            while (true)
            {
                game.Move();
                DrawField(stadium.Width, stadium.Height, esimeneTeam.Players, teineTeam.Players, game.Ball);
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0); 
            }
        }

        private static void DrawField(int width, int height, List<Player> homePlayers, List<Player> awayPlayers, Ball ball)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1); 
                Console.Write("!"); // border
                for (int x = 0; x < width; x++)
                {
                    if (IsPlayerAtPosition(x, y, homePlayers))
                    {
                        ChangeConsoleColor(ConsoleColor.Blue);
                        Console.Write("E"); // mängija esimeneTeam
                    }
                    else if (IsPlayerAtPosition(x, y, awayPlayers))
                    {
                        Console.ResetColor();
                        ChangeConsoleColor(ConsoleColor.Red);
                        Console.Write("T"); // mängija teineTeam
                    }
                    else if (IsBallAtPosition(x, y, ball))
                    {
                        Console.ResetColor();
                        ChangeConsoleColor(ConsoleColor.White);
                        Console.Write("O"); // мяч
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" "); // пустая ячейка поля
                    }
                }
                Console.ResetColor();
                ChangeConsoleColor(ConsoleColor.Yellow);
                Console.Write("!"); // правая вертикальная рамка
            }
        }

        // проверяет есть ли игрок в указанных координатах x y на игровом поле
        private static bool IsPlayerAtPosition(int x, int y, List<Player> players)
        {
            // проходим по списку игроков в команде.
            foreach (var player in players)
            {
                // Округляем координаты игрока до целых чисел.
                int playerX = (int)Math.Round(player.X);
                int playerY = (int)Math.Round(player.Y);

                // сравниваем координаты игрока с указанными x y
                if (playerX == x && playerY == y)
                {
                    return true; // возвращаем true если игрок находится в указанных координатах
                }
            }

            return false; // если ни один игрок не находится в указанных координатах возвращаем false
        }

        // проверяет, есть ли мяч в указанных координатах x y на игровом поле
        private static bool IsBallAtPosition(int x, int y, Ball ball)
        {
            // Округляем координаты мяча до целых чисел.
            int ballX = (int)Math.Round(ball.X);
            int ballY = (int)Math.Round(ball.Y);

            // сравниваем координаты мяча с указанными x y
            return ballX == x && ballY == y; // возвращаем true если мяч находится в указанных координатах иначе false
        }
    }
}