using System;
using System.ComponentModel.Design;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(String[] args)
        {
            Program.Run();
        }

        private static void Run()
        {
            Program program = new Program();
            program.Menu();
        }

        private void Menu()
        {
            Console.WriteLine("-- Gæt tallet --");
            Console.WriteLine();
            Console.Write("Indtast det højest mulige tal: ");
            int max = Getint();
            Console.WriteLine("Det højeste tal er: " + max);
            Console.WriteLine();

            Console.WriteLine("Vælg en fremgangsmåde");
            Console.WriteLine("1 - Brute force metoden");
            Console.WriteLine("2 - Binary search metoden");
            Console.Write("Dit valg: ");

            int mode = SelectMethod();

            if (mode == 1)
                BruteForce(max);
            if (mode == 2)
                BinarySearch(max);
            else
            {
                Console.WriteLine("VÆLG 1 ELLLER 2 !!!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void BinarySearch(int max)
        {
            int value = GenereateNumber(max);
            int mode = 0;
            int guess;
            List<int> list = new List<int>();

            
            while (true)
            {
                if (mode != 1 || mode != 2)
                {
                    Console.WriteLine("Vælg 1 for mindre end. Vælg 2 for større end");
                    mode = Getint();
                }
                if (mode == 1)
                {
                    Console.WriteLine("Er tallet lavere end: ");
                    Console.Write("Dit gæt: ");
                    guess = Getint();
                    list.Add(guess);
                    if (guess == value)
                    {
                        Console.WriteLine("DU GÆTTEDE RIGTIGT");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                    if (value < guess)
                        Console.WriteLine("ja");
                    else
                        Console.WriteLine("nej");

                    Console.WriteLine("Du har gættet på følgende tal: ");
                    foreach (int i in list)
                        Console.Write(i + ", ");
                    Console.WriteLine();
                }
                if (mode == 2)
                {
                    Console.WriteLine("Er tallet større end: ");
                    Console.Write("Dit gæt: ");
                    guess = Getint();
                    list.Add(guess);
                    if (guess == 1)
                    {
                        Console.WriteLine("DU GÆTTEDE RIGTIGT");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                    if (value > guess)
                        Console.WriteLine("ja");
                    else
                        Console.WriteLine("nej");

                    Console.WriteLine("Du har gættet på følgende tal: ");
                    foreach (int i in list)
                        Console.Write(i + ", ");
                    Console.WriteLine();
                }
                mode = 0;
            }
        }

        private int GenereateNumber(int max)
        {
            Random random = new Random();

            return random.Next(max);
        }

        private void BruteForce(int max)
        {
            List<int> list = new List<int>();
            int value = GenereateNumber(max);
            
            bool WIN = false;
            do
            {
                Console.Write("Gæt tallet: ");
                int guess = Getint();
                list.Add(guess);
                if (guess == value)
                    WIN = true;

                if (WIN)
                {
                    Console.WriteLine("DU GÆTTEDE RIGTIGT");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Du gættede forkert. Prøv igen...");

                    Console.WriteLine("Du har gættet på følgende tal: ");
                    foreach (int i in list)
                        Console.Write(i + ", ");
                    Console.WriteLine();
                }

            } while (!WIN);
        }

        private int Getint()
        {
            int result = 0;

            while (!(int.TryParse(Console.ReadLine(), out result)))
            {
                Console.WriteLine("Indtast et tal!!");
            }
            return result;
        }
 
        private int SelectMethod()
        {
            int result = 0;
            while( !(result == 1 || result == 2))
            {
                Console.WriteLine("Vælg 1 eller 2");
                while (!(int.TryParse(Console.ReadLine(), out result)))
                {
                    Console.WriteLine("Indtast et tal!!");
                }
            }
            return result;
        }
    }
}