using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tervetuloa kolikonheittopeliin");
        Console.WriteLine("Kirjoita 'exit' lopettaaksesi pelin.");

        while (true)
        {
            Console.WriteLine("\nValitse Heads tai Tails (kirjoita 'Heads' tai 'Tails'):");
            string userChoice = Console.ReadLine()?.Trim().ToLower();

            if (userChoice == "exit")
            {
                Console.WriteLine("Kiitos peleistä! Näkemiin!");
                break;
            }

            if (userChoice != "heads" && userChoice != "tails")
            {
                Console.WriteLine("Epäkelpo vastaus. Valitse joko 'Heads', 'Tails', tai 'exit' lopettaaksesi.");
                continue;
            }

            var random = new Random();
            int randomNumber = random.Next(2);
            string coinResult = randomNumber == 0 ? "heads" : "tails";

            Console.WriteLine($"Kolikko pyörii... Se on {coinResult.ToUpper()}!");

            if (userChoice == coinResult)
            {
                Console.WriteLine("Onnittelut! Voitit pelin!");
            }
            else
            {
                Console.WriteLine("Sori, hävisit. Parempi onni ens kerralla!");
            }
        }
    }
}
