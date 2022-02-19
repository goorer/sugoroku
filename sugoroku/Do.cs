using System;
using System.Collections.Generic;
using System.Threading;

namespace consoleSugoroku.prg
{
    public class Do
    {
        private static List<Player> players;

        public static void InputPlayer()
        {
            players = new List<Player>();

            Console.WriteLine("プレイヤー名を入力してください。");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("入力を終了するには[*]を入力してください。");
            Console.ResetColor();
            NewLine();

            while (true)
            {
                Console.WriteLine("プレイヤー名");
                Console.Write(":");
                string name = Console.ReadLine();
                if (name == "*") break;
                players.Add(new Player(name));
            }
            NewLine();
            Console.WriteLine("入力終了");
            Wait(2000);
            Console.Clear();
        }

        public static void PlayGame()
        {
            bool end = false;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("ゲームを開始するには[Enter]を押してください");
            Console.ResetColor();
            PlessKey(true);

            while (true)
            {
                foreach(Player player in players)
                {
                    Console.WriteLine("{0}の番", player.GetName());
                    NewLine();
                    Console.WriteLine("サイコロを振る [Enter]");
                    PlessKey();
                    NewLine();
                    int moveCell = RollDice();
                    Wait(200);
                    Console.WriteLine("{0}マス進む",moveCell);
                    NewLine();
                    player.SetCurrentCell(moveCell);

                    if (player.GetFinished())
                    {
                        Console.WriteLine("{0}", Common.d_Event[player.GetCurrentCell()]);
                        players.Remove(player);
                    }
                    else
                    {
                        if (Common.d_Event.ContainsKey(player.GetCurrentCell()))
                        {
                            Console.WriteLine("{0}", Common.d_Event[player.GetCurrentCell()]);
                        }
                        else
                        {
                            Console.WriteLine("肝臓を休めよう。。");
                        }
                    }
                    NewLine();

                    if (players.Count == 0)
                    {
                        end = true;
                        break;
                    }

                    Console.WriteLine("次の人に回す[Enter]");
                    PlessKey(true);
                }

                if (end) break;
            }

            Console.WriteLine("終了！");
        }

        private static int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        private static void PlessKey(bool clear = false)
        {
            while (true)
            {
                var key = Console.ReadKey();

                if(key.Key == ConsoleKey.Enter) break;
            }

            if(clear) Console.Clear();
        }

        private static void NewLine()
        {
            Console.WriteLine();
        }

        private static void Wait(int msc)
        {
            Thread.Sleep(msc);
        }
    }
}
