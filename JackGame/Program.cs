
using System;
using System.Threading;
namespace MyApp
{

    internal class Program
    {

        static int[] Cards = new int[5];
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Deck();
            bool stop = false;
            int total = Cards[0] + Cards[1];
            int dealerTotal = 0;
            int milliseconds = 3000;
            Console.WriteLine("Welcome to TERMINAL-JACK!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("-----------");
            Console.WriteLine("Your cards are " + Cards[0] + " and " + Cards[1]);
            while (total < 21 && stop == false)
            {
                string choice = HorC();
                if (choice == "call")
                {
                    Console.WriteLine("Your total is " + total);
                    Console.WriteLine("----------------");
                    Console.WriteLine("The dealer will now draw cards");
                    Thread.Sleep(milliseconds);
                    while (dealerTotal <= total)
                    {
                        int dealerCard = rng.Next(1, 14);
                        if (dealerCard > 10)
                        {
                            dealerCard = 10;
                        }
                        dealerTotal += dealerCard;
                    }
                    if (dealerTotal > total && dealerTotal <= 21)
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine(dealerTotal);
                        Console.WriteLine("GAME OVER! Dealer is closer.");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Press any key to continue.");
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine(dealerTotal);
                        Console.WriteLine("YOU WIN! Dealer busts.");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Press any key to continue.");
                        stop = true;
                    }
                }
                else    //HIT
                {
                    if (total == Cards[0] + Cards[1])
                    {
                        Console.WriteLine(Cards[2]);
                        total += Cards[2];
                    }
                    else if (total == Cards[0] + Cards[1] + Cards[2])
                    {
                        Console.WriteLine(Cards[3]);
                        total += Cards[3];
                    }
                    else if (total == Cards[0] + Cards[1] + Cards[2] + Cards[3])
                    {
                        Console.WriteLine(Cards[4]);
                        total += Cards[4];
                        stop = true;
                        if (total <= 21)
                        {
                            Console.WriteLine("YOU WIN! You managed to draw five cards without busting!");
                            Console.WriteLine("---------------");
                            Console.WriteLine("Press any key to Continue");
                        }
                    }
                }
            }
            if (total == 21)
            {
                Console.WriteLine("YOU WIN! You got a total of exactly 21!");
                Console.WriteLine("---------------");
                Console.WriteLine("Press any key to continue.");
            }
            if (total > 21)
            {
                Console.WriteLine("GAME OVER! You busted.");
                Console.WriteLine("---------------");
                Console.WriteLine("Press any key to continue");
            }
            Console.ReadKey();
        }
        static string HorC()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("HIT or CALL?");
            string choice = Console.ReadLine().ToLower();
            while (choice != "hit" && choice != "call")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("try again.");
                choice = Console.ReadLine().ToLower();
            }
            return choice;
        }
        static void Deck()
        {
            for(int i = 0; i < 5; i++)
            {
                Cards[i] = rng.Next(1, 14);
                if (Cards[i] > 10)
                {
                    Cards[i] = 10;
                }
            }
        }
    }
}