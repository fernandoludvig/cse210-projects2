using System;
using System.Collections.Generic;

// Base class representing a Task
class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority TaskPriority { get; set; }
    public bool IsCompleted { get; set; } = false;

    public Task(string title, string description, Priority priority)
    {
        Title = title;
        Description = description;
        TaskPriority = priority;
    }

    public virtual void DisplayTaskInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Priority: {TaskPriority}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
    }
}

// Enum representing task priorities
enum Priority
{
    Low,
    Medium,
    High
}

// Derived class representing a ProjectTask
class ProjectTask : Task
{
    public string ProjectName { get; set; }

    public ProjectTask(string title, string description, Priority priority, string projectName)
        : base(title, description, priority)
    {
        ProjectName = projectName;
    }

    public override void DisplayTaskInfo()
    {
        base.DisplayTaskInfo();
        Console.WriteLine($"Project: {ProjectName}");
    }
}

// Class representing a TaskManager
class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void DisplayAllTasks()
    {
        Console.WriteLine("All Tasks:");
        foreach (var task in tasks)
        {
            task.DisplayTaskInfo();
            Console.WriteLine();
        }
    }

    public void MarkTaskAsCompleted(Task task)
    {
        task.IsCompleted = true;
        Console.WriteLine($"Task '{task.Title}' marked as completed.");
    }

    // Method to find a task by title
    public Task FindTask(string title)
    {
        return tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}

// Class representing a User
class User
{
    public string UserName { get; private set; }

    public User(string userName)
    {
        UserName = userName;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Task Manager!");

        Console.Write("Enter your username: ");
        string userName = Console.ReadLine();

        User user = new User(userName);
        TaskManager taskManager = new TaskManager();

        // Adding tasks for demonstration
        taskManager.AddTask(new Task("Write report", "Finish the quarterly report", Priority.High));
        taskManager.AddTask(new ProjectTask("Develop feature", "Implement new feature", Priority.Medium, "Project A"));

        Console.WriteLine("\nTasks in the Task Manager:");
        taskManager.DisplayAllTasks();

        Console.WriteLine("\nEnter the title of the task you completed:");
        string completedTaskTitle = Console.ReadLine();

        Task completedTask = taskManager.FindTask(completedTaskTitle);

        if (completedTask != null)
        {
            taskManager.MarkTaskAsCompleted(completedTask);
        }
        else
        {
            Console.WriteLine("Task not found in the task manager.");
        }
    }
}
