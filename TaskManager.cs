using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class TaskManager {

    private const string FilePath = "tasks.json";
    private List<Task> tasks;

    public TaskManager()
    {
        LoadTasks();
    }

    private void LoadTasks()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }
        else
        {
            tasks = new List<Task>();
        }
    }

    private void SaveTasks(){
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(FilePath, json);
    }

    public void AddTask(string description){
        int newId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;
        var newTask = new Task(newId, description);
        tasks.Add(newTask);
        SaveTasks();
        Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }

    public void ListTasks(string status = null)
    {
        var filteredTasks = tasks;
        if (status != null)
        {
            filteredTasks = tasks.FindAll(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }
        
        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
        }
    }
}