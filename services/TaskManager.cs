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

    public void UpdateTask(int id, string newDescription){
        var task = tasks.Find(x => x.Id == id);
        if (task != null)
        {
            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            SaveTasks();
            Console.WriteLine($"Task {id} updated.");
        }
        else
        {
            Console.WriteLine($"Task {id} not found.");
        }
    }

    public void DeleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks();
            Console.WriteLine($"Task {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Task {id} not found.");
        }
    }

    public void MarkInProgress(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Status = "in-progress";
            task.UpdatedAt = DateTime.Now;
            SaveTasks();
            Console.WriteLine($"Task {id} marked as in-progress.");
        }
        else
        {
            Console.WriteLine($"Task {id} not found.");
        }
    }

    public void MarkDone(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Status = "done";
            task.UpdatedAt = DateTime.Now;
            SaveTasks();
            Console.WriteLine($"Task {id} marked as done.");
        }
        else
        {
            Console.WriteLine($"Task {id} not found.");
        }
    }

    

    public void ListTasks(string status = null)
    {
        var filteredTasks = tasks;
        if (status != null)
        {
            filteredTasks = tasks.FindAll(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

            if (filteredTasks.Count() == 0)
            {
                Console.WriteLine($"Tasks with status {status} not found");
            }
        }
        
        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
        }
    }
}