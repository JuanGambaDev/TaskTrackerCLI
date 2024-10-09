using System;
using System.Xml.Serialization;

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

            case "list":
                string status = args.Length > 1 ? args[1] : null;
                taskManager.ListTasks(status);
                break;

            case "update":
                if (args.Length < 3 || !int.TryParse(args[1], out int updateId))
                {
                    Console.WriteLine("Please provide a valid task ID and new description.");
                }
                else
                {
                    string newDescription = string.Join(" ", args, 2, args.Length - 2);
                    taskManager.UpdateTask(updateId, newDescription);
                }
                break;

            case "delete":
                if (args.Length < 2 || !int.TryParse(args[1], out int deleteId))
                {
                    Console.WriteLine("Please provide a valid task ID and new description.");
                }
                else
                {
                    string newDescription = string.Join(" ", args, 2, args.Length - 2);
                    taskManager.DeleteTask(deleteId);
                }
                break;

            case "mark-in-progress":
                if (args.Length < 2 || !int.TryParse(args[1], out int inProgressId))
                {
                    Console.WriteLine("Please provide a valid task ID.");
                }
                else
                {
                    taskManager.MarkInProgress(inProgressId);
                }
                break;

            case "mark-done":
                if (args.Length < 2 || !int.TryParse(args[1], out int doneId))
                {
                    Console.WriteLine("Please provide a valid task ID.");
                }
                else
                {
                    taskManager.MarkDone(doneId);
                }
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
