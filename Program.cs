using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            string appName = "Tal Gætter";
            string appVersion = "1.1.0";
            string appAuthor = "Kasper Rosenkrands";

            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("{0}: Version {1} af {2}", appName, appVersion, appAuthor);

            Console.ResetColor();

            Console.WriteLine("Hvad er dit navn?");

            string inputName = Console.ReadLine();

            Console.WriteLine("Hej {0}, lad os spille et spil!", inputName);

            var triesStorage = new List<int>();

            while (true)
            {
                int numberOfTries = 0;

                Random random = new Random();

                int correctNumber = random.Next(1, 11);

                int guess = 0;

                Console.WriteLine("Gæt på et tal mellem 1 og 10");

                while (guess != correctNumber)
                {

                    numberOfTries += 1;

                    string input = Console.ReadLine();

                    //guess = Int32.Parse(input);

                    if (!int.TryParse(input, out guess))
                    {

                        PrintColorMessage(ConsoleColor.Yellow, "Det tal kender jeg ikke, prøv et andet");

                        continue;
                    }

                    if (guess != correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Det var ikke det tal jeg tænkte på, prøv igen");
                    }
                }

                PrintColorMessage(ConsoleColor.Cyan, "Du gættede rigtigt!");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Du brugte {0} forsøg", numberOfTries);

                Console.ResetColor();

                triesStorage.Add(numberOfTries);

                Console.WriteLine("Vil du spille en gang mere? [J eller N]");

                string answer = Console.ReadLine().ToUpper();

                if(answer == "J"){

                    continue;

                } else if(answer == "N") {
                    
                    Console.WriteLine("Du har spillet {0} spil", triesStorage.Count);

                    int sum = 0;

                    foreach(int game in triesStorage){
                        sum += game;
                    }

                    double average = (double)sum / triesStorage.Count;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Dit gennemsnitlige antal gæt var {0}", average);

                    Console.ResetColor();

                    Console.WriteLine("Tryk enter når du er færdig med at læse");

                    string enter = Console.ReadLine();

                    return;
                
                } else {
                    
                    return;
                
                }
            }
        }

        static void PrintColorMessage(ConsoleColor color, string message){
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }

    }
}
