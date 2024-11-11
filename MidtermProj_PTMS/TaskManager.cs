using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MidtermProj_PTMS
{
    public static class TaskManager
    {
        public static List<Task> Tasks { get; set; } = new List<Task>();
        public static List<Task> CompletedTasks { get; set; } = new List<Task>();

        public static void AddTask(Task newTask)
        {
            Tasks.Add(newTask);
        }

        public static void CreateNewTask()
        {
            Console.WriteLine("\nCreate new task. (Send empty value to return)");
            Console.Write("Task name: ");
            string? taskName = Console.ReadLine();
            int priority = -1;
            int category = -1;
            if (String.IsNullOrEmpty(taskName))
            {

            }
            else
            {
                var check = TaskManager.Tasks.Any(x => x.Name == taskName);
                if (check)
                {
                    CreateNewTask();
                }
                else
                {
                    while (priority == -1)
                    {
                        priority = CreateNewTaskPriority();
                    }

                    while (category == -1)
                    {
                        category = CreateNewTaskCategory();
                    }
                    Task newTask = new()
                    {
                        Name = taskName,
                        Priority = priority,
                        Category = category
                    };
                    TaskManager.AddTask(newTask);
                    Console.WriteLine("\nTask added successfully");
                }
            }
        }

        static int CreateNewTaskPriority()
        {
            Console.Write("\nPriority: ");
            bool isSuccessful = Int32.TryParse(Console.ReadLine(), out int result);
            if (isSuccessful)
            {
                if (result >= 0) return result;
                else return -1;
            }
            else return -1;
        }

        static int CreateNewTaskCategory()
        {
            Console.WriteLine("Category:\r\n1. Work\r\n2. Personal\r\n3. Study");
            Console.Write("\nChoice: ");
            bool isSuccessful = Int32.TryParse(Console.ReadLine(), out int result);
            if (isSuccessful)
            {
                if (result > 0 && result < 4) return result;
                else return -1;
            }
            else return -1;
        }

        public static void ViewAllTasks()
        {
            Console.WriteLine("All tasks: \r\n");
            if (TaskManager.Tasks.Count > 0)
            {
                foreach (Task task in TaskManager.Tasks)
                {
                    Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                }
            }
            else
            {
                Console.WriteLine("Task list is empty!\n");
            }
        }

        public static void ViewAllTasksByPriority()
        {
            Console.WriteLine("All tasks by priority: \r\n");
            if (TaskManager.Tasks.Count > 0)
            {
                List<Task> formattedTasks = TaskManager.Tasks.OrderByDescending(task => task.Priority).ToList();
                formattedTasks.RemoveAll(x => CompletedTasks.Contains(x));
                foreach (Task task in formattedTasks)
                {
                    Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                }
            }
            else
            {
                Console.WriteLine("Task list is empty!\n");
            }
        }

        public static void ViewAllTasksByCategory()
        {
            Console.WriteLine("All tasks by category: \r\n");
            if (TaskManager.Tasks.Count > 0)
            {
                Console.WriteLine("[WORK]\n");
                List<Task> formattedTasks = TaskManager.Tasks.Where(x => x.Category == 1).ToList();
                if (formattedTasks.Count > 0)
                {
                    foreach (Task task in formattedTasks)
                    {
                        Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                    }
                }
                else
                {
                    Console.WriteLine("NO TASK");
                }
                Console.WriteLine("\n[PERSONAL]\n");

                formattedTasks = TaskManager.Tasks.Where(x => x.Category == 2).ToList();
                if (formattedTasks.Count > 0)
                {
                    foreach (Task task in formattedTasks)
                    {
                        Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                    }
                }
                else
                {
                    Console.WriteLine("NO TASK");
                }

                Console.WriteLine("\n[STUDY]\n");

                formattedTasks = TaskManager.Tasks.Where(x => x.Category == 3).ToList();
                if (formattedTasks.Count > 0)
                {
                    foreach (Task task in formattedTasks)
                    {
                        Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                    }
                }
                else
                {
                    Console.WriteLine("NO TASK");
                }
            }
            else
            {
                Console.WriteLine("Task list is empty!\n");
            }
        }

        public static void CompleteTask()
        {
            Console.WriteLine("\nComplete task. (Send empty value to return)");
            Console.Write("Task name: ");
            string? taskName = Console.ReadLine();
            if (String.IsNullOrEmpty(taskName))
            {

            }
            else
            {
                var task = TaskManager.Tasks.FirstOrDefault(x => x.Name == taskName);
                if (task != null)
                {
                    TaskManager.CompletedTasks.Add(task);
                    Console.WriteLine("Marked as complete successfully!");
                }
                else
                {
                    Console.WriteLine($"There are no task named {taskName}!");
                }
            }
            
        }

        public static void UndoTaskCompletion()
        {
            if (TaskManager.CompletedTasks.Count > 0)
            {
                TaskManager.CompletedTasks.RemoveAt(CompletedTasks.Count - 1);
                Console.WriteLine("Completion undo successfully!");
            }
            else
            {
                Console.WriteLine("There are no completed task in the system");
            }
        }

        public static void DeleteTask()
        {
            Console.WriteLine("\nDelete task. (Send empty value to return)");
            Console.Write("Task name: ");
            string? taskName = Console.ReadLine();
            if (String.IsNullOrEmpty(taskName))
            {

            }
            else
            {
                var task = TaskManager.Tasks.FirstOrDefault(x => x.Name == taskName);
                if (task != null)
                {
                    TaskManager.Tasks.Remove(task);
                    if (TaskManager.CompletedTasks.Contains(task))
                    {
                        TaskManager.CompletedTasks.Remove(task);
                    }
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine($"There are no task named {taskName}!");
                }
            }
        }

        public static void SearchTask()
        {
            Console.WriteLine("\nSearch task. (Send empty value to return)");
            Console.Write("Task name: ");
            string? taskName = Console.ReadLine();
            if (String.IsNullOrEmpty(taskName))
            {

            }
            else
            {
                var task = TaskManager.Tasks.FirstOrDefault(x => x.Name == taskName);
                if (task != null)
                {
                    Console.WriteLine($"- Name: {task.Name} | Priority: {task.Priority} | Category: {task.GetCategoryName(task.Category)}");
                }
                else
                {
                    Console.WriteLine($"There are no task named {taskName}!");
                }
            }
        }

        public static void ProcessNextTask()
        {
            Console.WriteLine("Your current uncompleted task: \r\n");
            List<Task> formattedTasks = new();
            formattedTasks.AddRange(TaskManager.Tasks);
            formattedTasks.RemoveAll(x => TaskManager.CompletedTasks.Contains(x));
            Task? currentTask = formattedTasks.FirstOrDefault();
            if (currentTask != null)
            {
                Console.WriteLine($"- Name: {currentTask.Name} | Priority: {currentTask.Priority} | Category: {currentTask.GetCategoryName(currentTask.Category)}");
            }
            else
            {
                Console.WriteLine("Task list is empty!\n");
            }
        }

    }
}
