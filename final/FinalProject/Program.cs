using System;
using System.Collections.Generic;

// Enum representing task priorities
enum Priority
{
    Low,
    Medium,
    High
}

// Base class representing a Task
class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority TaskPriority { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime Deadline { get; set; } // Deadline for the task
    public Project TaskProject { get; set; } // Reference to the project the task belongs to

    public Task(string title, string description, Priority priority, DateTime deadline)
    {
        Title = title;
        Description = description;
        TaskPriority = priority;
        Deadline = deadline;
    }

    public virtual void DisplayTaskInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Priority: {TaskPriority}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
        Console.WriteLine($"Deadline: {Deadline.ToShortDateString()}");
        if (TaskProject != null)
        {
            Console.WriteLine($"Project: {TaskProject.Name}");
        }
    }
}

// Derived class representing a ProjectTask
class ProjectTask : Task
{
    public ProjectTask(string title, string description, Priority priority, Project project, DateTime deadline)
        : base(title, description, priority, deadline)
    {
        TaskProject = project;
    }
}

// Class representing a Project
class Project
{
    public string Name { get; set; }
    public List<Task> Tasks { get; } = new List<Task>();

    public Project(string name)
    {
        Name = name;
    }

    public void AddTaskToProject(Task task)
    {
        task.TaskProject = this;
        Tasks.Add(task);
    }
}

// Base class representing a Notification
abstract class Notification
{
    protected string Recipient { get; }

    public Notification(string recipient)
    {
        Recipient = recipient;
    }

    public abstract void SendNotification();
}

// Derived class representing an Email Notification
class EmailNotification : Notification
{
    public EmailNotification(string recipient) : base(recipient) { }

    public override void SendNotification()
    {
        Console.WriteLine($"Sending email notification to {Recipient}.");
        // Additional email notification logic can be added here
    }
}

// Derived class representing an SMS Notification
class SMSNotification : Notification
{
    public SMSNotification(string recipient) : base(recipient) { }

    public override void SendNotification()
    {
        Console.WriteLine($"Sending SMS notification to {Recipient}.");
        // Additional SMS notification logic can be added here
    }
}

// Class representing a Reminder
class Reminder
{
    public string Message { get; set; }
    public Notification Notification { get; set; }

    public Reminder(string message, Notification notification)
    {
        Message = message;
        Notification = notification;
    }

    public void SendNotification()
    {
        Notification.SendNotification();
    }
}

// Class representing a TaskManager
class TaskManager
{
    private List<Task> tasks;
    private List<Reminder> reminders;

    public TaskManager()
    {
        tasks = new List<Task>();
        reminders = new List<Reminder>();
    }


    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void AddReminder(Reminder reminder)
    {
        reminders.Add(reminder);
        reminder.SendNotification(); // Send the notification when adding a reminder
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

    public void DisplayRemainingTasksWithDeadlines()
    {
        Console.WriteLine("Remaining Incomplete Tasks with Deadlines:");
        foreach (var task in tasks)
        {
            if (!task.IsCompleted)
            {
                Console.WriteLine($"- {task.Title}, Deadline: {task.Deadline.ToShortDateString()}");
            }
        }
    }

    public void DisplayReminders()
    {
        Console.WriteLine("Reminders:");
        foreach (var reminder in reminders)
        {
            Console.WriteLine($"{reminder.Message}");
        }
    }

      public void MarkTaskAsCompleted(Task task, string userEmail)
    {
        task.IsCompleted = true;
        Console.WriteLine($"Task '{task.Title}' marked as completed.");

        // Find the nearest incomplete task and add a reminder
        Task nearestIncompleteTask = FindNearestIncompleteTask();
        if (nearestIncompleteTask != null)
        {
            EmailNotification emailNotification = new EmailNotification(userEmail);
            AddReminder(new Reminder($"Upcoming deadline for task '{nearestIncompleteTask.Title}' on {nearestIncompleteTask.Deadline.ToShortDateString()}", emailNotification));
        }
    }

    private Task FindNearestIncompleteTask()
    {
        DateTime currentDate = DateTime.Now;
        Task nearestTask = null;
        TimeSpan nearestTimeDifference = TimeSpan.MaxValue;

        foreach (var task in tasks)
        {
            if (!task.IsCompleted && task.Deadline > currentDate)
            {
                TimeSpan timeDifference = task.Deadline - currentDate;
                if (timeDifference < nearestTimeDifference)
                {
                    nearestTimeDifference = timeDifference;
                    nearestTask = task;
                }
            }
        }

        return nearestTask;
    }

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

        Console.Write("Enter your email address: ");
        string userEmail = Console.ReadLine();

        User user = new User(userName);
        TaskManager taskManager = new TaskManager();

        // Adding tasks for demonstration
        Project projectA = new Project("Project A");
        taskManager.AddTask(new Task("Write report", "Finish the quarterly report", Priority.High, DateTime.Parse("2023-12-31")));
        taskManager.AddTask(new ProjectTask("Develop feature", "Implement new feature", Priority.Medium, projectA, DateTime.Parse("2023-12-15")));
        taskManager.AddTask(new Task("Test application", "Run tests on the new feature", Priority.Medium, DateTime.Parse("2023-12-20")));
        taskManager.AddTask(new ProjectTask("Design UI", "Create user interface design", Priority.High, projectA, DateTime.Parse("2023-12-13")));

        Console.WriteLine("\nTasks in the Task Manager:");
        taskManager.DisplayAllTasks();

        Console.WriteLine("\nEnter the title of the task you completed:");
        string completedTaskTitle = Console.ReadLine();

        Task completedTask = taskManager.FindTask(completedTaskTitle);

        if (completedTask != null)
        {
            taskManager.MarkTaskAsCompleted(completedTask, userEmail);
        }
        else
        {
            Console.WriteLine("Task not found in the task manager.");
        }

        // Display remaining tasks with deadlines
        taskManager.DisplayRemainingTasksWithDeadlines();

        // Display reminders
        taskManager.DisplayReminders();
    }
}
