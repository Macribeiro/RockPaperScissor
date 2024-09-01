using System.Collections.Generic;
using System;
using System.IO;
public class Player
{
    public string name;
    public int attempt = 1;
    public string keep = "yes";

    public void winMessage()
    {
        Console.Write("\n\n--------------YOU WIN!--------------\n\n");
    }
    public void loseMessage()
    {
        Console.Write("\n\n--------------YOU LOSE!--------------\n\n");
    }

    public void tieMessage()
    {
        attempt++;
        Console.Write("--------------Tie!--------------");
    }

    public void attempts()
    {
        Console.Write("Attempt: " + attempt.ToString());
    }
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

        while (player.keep.Equals("yes", StringComparison.OrdinalIgnoreCase))

        {
            Console.WriteLine("\n-------------Caption-------------");
            Console.WriteLine("1 - Rock\n2 - Paper\n3 - Scissor\n");

            Random rnd = new Random();
            int computerChoice = rnd.Next(1, 4);
            Console.Write("Choose a number: ");
            int playerChoice = Int32.Parse(Console.ReadLine());

            string cpuChoiceSymbol = symbolMap[computerChoice];
            string playerChoiceSymbol = symbolMap[playerChoice];

            Console.WriteLine("you chose: " + playerChoice + " - " + playerChoiceSymbol.ToString());

            switch (computerChoice)
            {
                case 1:
                    switch (playerChoice)
                    {
                        case 2:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.winMessage();
                            Console.WriteLine("Attempt: " + player.attempt);
                            break;
                        case 3:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.loseMessage();
                            Console.WriteLine("Attempts: " + player.attempt);
                            player.attempt++;
                            break;
                        default:
                            player.tieMessage();
                            break;
                    }
                    break;
                case 2:
                    switch (playerChoice)
                    {
                        case 3:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.winMessage();
                            Console.WriteLine("Attempt: " + player.attempt);
                            break;
                        case 1:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.loseMessage();
                            Console.WriteLine("Attempt: " + player.attempt);
                            player.attempt++;
                            break;
                        default:
                            player.tieMessage();
                            break;
                    }
                    break;
                case 3:
                    switch (playerChoice)
                    {
                        case 1:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.winMessage();
                            Console.WriteLine("Attempt: " + player.attempt);
                            break;
                        case 2:
                            Console.WriteLine("You chose " + playerChoiceSymbol + ". The PC chose: " + cpuChoiceSymbol);
                            player.loseMessage();
                            Console.WriteLine("Attempt: " + player.attempt);
                            break;
                        default:
                            player.tieMessage();
                            break;
                    }
                    break;
            }
            Console.WriteLine("\n\n---------------------------------------\n\n");
            Console.Write("\nDo you want to play? (yes || no): ");
            player.keep = Console.ReadLine();
        }

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "gameInfo.txt");
        var infos = "------------------------------ROCK, PAPER, SCISSOR GAME------------------------------\n\n\n\n\n\n\n\n\n\nPlayer " + player.name + ". Attempts: " + player.attempt;
        File.WriteAllText(filePath, infos);
    }
}
