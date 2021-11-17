using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wookie
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            int count = 0;
            int UserTry;
            int apl;
            int flag = 0;

            Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 10000);
            Console.WriteLine("Добро пожаловать в игру \"Wookie\"");
            Console.WriteLine("Правила игры:");
            Console.WriteLine("Загадывается число от 12 до 120. Игроки по очереди выбирают число от 1 до 4 включительно.");
            Console.WriteLine("Если загаданное число равняется нулю, то походвший игрок оказывается победителем");
            Console.WriteLine();

            do
            {
                string currentPlayer = "";

                string comp = "Компьютер";
                Console.Write("Введите имя игрока: ");
                string user1 = Console.ReadLine();

                Console.Write("Введите Имя игрока: ");
                string user2 = Console.ReadLine();

                Console.Write("\nВведите минимальное число Игрока от 1 до 30 :");
                int startus = Convert.ToInt32(Console.ReadLine());
                while (startus >= 30 || startus <= 0)
                {
                    Console.WriteLine("Введенное вами число неверно, попробуйте еще раз");
                    startus = Convert.ToInt32(Console.ReadLine());
                    continue;
                }


                Console.Write($"\nВведите максимальное число Игрока от {startus + 10} до 50:");
                int endus = Convert.ToInt32(Console.ReadLine());
                while (endus >= 50 || endus <= startus + 10)
                {
                    Console.WriteLine("Введенное вами число неверно, попробуйте еще раз");
                    endus = Convert.ToInt32(Console.ReadLine());
                    continue;
                }


                Console.Write($"\nВведите минимальное 'обшее число' от {120} до {endus * 30}:");
                int start = Convert.ToInt32(Console.ReadLine());
                while (start >= endus * 30 || start <= 120)
                {
                    Console.WriteLine("Введенное вами число неверно, попробуйте еще раз");
                    start = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                Console.Write($"\nВведите максимальное 'общее число' от {startus * 20} до {endus * 50}:");
                int end = Convert.ToInt32(Console.ReadLine());
                while (end >= endus * 50 || end <= startus * 10)
                {
                    Console.WriteLine("Введенное вами число неверно, попробуйте еще раз");
                    end = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                int GameNumber = ran.Next(start, end);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ваше число: {GameNumber}.");
                Console.ForegroundColor = ConsoleColor.Green;

                while (GameNumber != 0)
                {
                    for (; ; )
                    {
                        Console.WriteLine($"Игровое число: {GameNumber}");
                        switch (flag)
                        {
                            case 0:
                                currentPlayer = comp;
                                break;
                            case 1:
                                currentPlayer = user1;
                                break;
                            case 2:
                                currentPlayer = user2;
                                break;
                        }

                        Console.WriteLine($"Ходит: {currentPlayer}");

                        if (flag == 0)
                        {
                            UserTry = ran.Next(startus, endus);
                            Console.WriteLine($"Ход {currentPlayer}: {UserTry}");

                        }
                        else UserTry = int.Parse(Console.ReadLine());


                        GameNumber -= UserTry;
                        count++;
                        flag++;
                        if (flag > 2) flag = 0;

                        if (UserTry < startus || endus < UserTry)
                        {
                            Console.WriteLine("Введенное вами число неверно, попробуйте еще раз");
                            UserTry = Convert.ToInt32(Console.ReadLine());
                        }

                        if (GameNumber - UserTry == 0)
                        {
                            Console.WriteLine($"ПОбедил: ");
                            switch (flag)
                            {
                                case 0:
                                    currentPlayer = comp;
                                    break;
                                case 1:
                                    currentPlayer = user1;
                                    break;
                                case 2:
                                    currentPlayer = user2;
                                    break;
                            }
                        }

                        else if (GameNumber - UserTry < 0)
                        {
                            Console.WriteLine("Результат не может быть меньше 0. Введите другое число ");
                            continue;
                        }

                        Console.WriteLine($"Осталось: " + GameNumber);
                    }
                }
                Console.WriteLine("Нажимте 1, чтобы сыграть еще раз");
                int.TryParse(Console.ReadLine(), out apl);
            } while (apl == 1);
        }
    }
}

          