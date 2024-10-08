using System;

class Program
{
    static void Main(string[] args)
    {
        var taskManager = new TaskManager();
        
        if (args.Length == 0)
        {
            Console.WriteLine("No command provided.");
            return;
        }

        string command = args[0];

        switch (command)
        {
            case "add":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please provide a task description.");
                }
                else
                {
                    string description = string.Join(" ", args, 1, args.Length - 1);
                    taskManager.AddTask(description);
                }
                break;
            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
