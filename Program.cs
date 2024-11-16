using System;
using System.Collections.Generic;
using ConsoleTables;

class Program
{
    static void Main()
    {
        List<string> tasks = new List<string>();
        string input;
        do
        {
            Console.Clear();
            DisplayHeader();

            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option (1-4): ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    RemoveTask(tasks);
                    break;
                case "3":
                    ViewTasks(tasks);
                    break;
                case "4":
                    Console.WriteLine("\nExiting the To-Do App. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option, please try again.");
                    break;
            }

            if (input != "4")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

        } while (input != "4");
    }

    static void DisplayHeader()
    {
        // Displaying header with some colors
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("          To-Do List App");
        Console.WriteLine("===================================");
        Console.ResetColor();
    }

    static void AddTask(List<string> tasks)
    {
        Console.Write("Enter task to add: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine($"\nTask '{task}' added successfully.");
    }

    static void RemoveTask(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks to remove.");
            return;
        }

        Console.WriteLine("\nTasks to remove:");
        ViewTasks(tasks);
        Console.Write("Enter the task number to remove: ");
        int taskIndex;
        
        if (int.TryParse(Console.ReadLine(), out taskIndex) && taskIndex > 0 && taskIndex <= tasks.Count)
        {
            string taskToRemove = tasks[taskIndex - 1];
            tasks.RemoveAt(taskIndex - 1);
            Console.WriteLine($"\nTask '{taskToRemove}' removed successfully.");
        }
        else
        {
            Console.WriteLine("\nInvalid task number.");
        }
    }

    static void ViewTasks(List<string> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks available.");
            return;
        }

         ConsoleTables for better formatting
        var table = new ConsoleTable("Task No.", "Task");

        for (int i = 0; i < tasks.Count; i++)
        {
            table.AddRow(i + 1, tasks[i]);
        }

        table.Write(Format.Alternative);
    }
}
