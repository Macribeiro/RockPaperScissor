using System.Collections.Generic;
using System;
using System.IO;
public class Player
{
    public string name;
    public int attempt = 1;
    public string keep = "no";
}

public class Computer
{
    static void Main()
    {
        Dictionary<int, string> symbolMap = new Dictionary<int, string>
        {
            { 1, "Rock" },
            { 2, "Paper" },
            { 3, "Scissor" }
        };

        Player player = new Player();
        Console.WriteLine("What is your name?\n");
        Console.Write("Your Name: ");
        player.name = Console.ReadLine();

        Console.WriteLine("\n\nPlayer " + player.name);

        Console.Write("\nDo you want to play? (yes or no) ");
        player.keep = Console.ReadLine();

        while (player.keep.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("\n-------------Caption-------------");
            Console.WriteLine("1 - Rock\n2 - Paper\n3 - Scissor\n");

            Random rnd = new Random();
            int computerChoice = rnd.Next(1, 4);
            Console.Write("Choose a number: ");
            int playerChoice = Int32.Parse(Console.ReadLine());

            if (playerChoice >= 4)
            {
                Console.WriteLine("Number Invalid! Try Again");
                break;
            }

            string cpuChoiceSymbol = symbolMap[computerChoice];
            string palyerChoiceSymbol = symbolMap[playerChoice];

            if (computerChoice == 1 && playerChoice == 3)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\nYou Lose!\n");
                player.attempt++;
                Console.WriteLine("Attempts: " + player.attempt);
            }
            else if (computerChoice == 3 && playerChoice == 1)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\n--------------YOU WIN!--------------\"");
                Console.WriteLine("Attempts: " + player.attempt);
                break;
            }

            if (computerChoice == 2 && playerChoice == 1)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\nYou Lose!");
                Console.WriteLine("Attempts: " + player.attempt);
                player.attempt++;
            }
            else if (computerChoice == 1 && playerChoice == 2)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\n--------------YOU WIN!--------------\"");
                Console.WriteLine("Attempts: " + player.attempt);
                break;
            }

            if (computerChoice == 3 && playerChoice == 2)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\nYou Lose!");
                Console.WriteLine("Attempts: " + player.attempt);
                player.attempt++;
            }
            else if (computerChoice == 2 && playerChoice == 3)
            {
                Console.WriteLine("You chose " + palyerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol + "\n\n--------------YOU WIN!--------------");
                Console.WriteLine("Attempts: " + player.attempt);
                break;
            }

            if (computerChoice == playerChoice || playerChoice == computerChoice)
            {
                Console.WriteLine("Tie!");
                player.attempt++;
            }

            Console.Write("Do you want to keep playing? (yes or no) ");
            player.keep = Console.ReadLine();
        }

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "gameInfo.txt");
        var infos = "------------------------------ROCK, PAPER, SCISSOR GAME------------------------------\n\n\n\n\n\n\n\n\n\nPlayer " + player.name + ". Attempts: " + player.attempt;
        File.WriteAllText(filePath, infos);
    }
}