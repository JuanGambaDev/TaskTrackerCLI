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
        var newTask = new Task();
        newTask.Description = description;
        tasks.Add(newTask);
        SaveTasks();
        Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }
}