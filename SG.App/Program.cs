// See https://aka.ms/new-console-template for more information

using SG.BLL.Contracts;
using SG.BLL.MartianRobot;

Dictionary<int, IPlayable> games = new Dictionary<int, IPlayable>
{
    { 1, new MartianRobot(5,5, 0, 0, 'N') }
};

while (true)
{
    Console.WriteLine("Select a game to play:");
    Console.WriteLine("1. Martian Robots");
    Console.WriteLine("0. Exit");

    Console.Write("Enter your choice: ");
    if (int.TryParse(Console.ReadLine(), out int choice) && games.ContainsKey(choice))
    {
        Console.Clear();
        games[choice].Play();
    }
    else if (choice == 0)
    {
        Console.WriteLine("Exiting...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid selection. Please try again.");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
