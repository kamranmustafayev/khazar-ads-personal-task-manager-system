namespace MidtermProj_PTMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(bool complete = false)
        {
            while (!complete)
            {
                Console.WriteLine("\n1. Add Task\r\n2. View All Tasks\r\n3. View Tasks by Priority\r\n4. View Tasks by Category\r\n5. Mark Task as Completed\r\n6. Undo Last Task Completion\r\n7. Delete Task\r\n8. Search Task by Name\r\n9. Process Next Task (Task Scheduling)\r\n10. Exit");
                Console.Write("\nChoice: ");
                bool isSuccessful = Int32.TryParse(Console.ReadLine(), out int result);
                if (isSuccessful)
                {
                    switch (result)
                    {
                        case 1: TaskManager.CreateNewTask(); break;
                        case 2: TaskManager.ViewAllTasks(); break;
                        case 3: TaskManager.ViewAllTasksByPriority(); break;
                        case 4: TaskManager.ViewAllTasksByCategory(); break;
                        case 5: TaskManager.CompleteTask(); break;
                        case 6: TaskManager.UndoTaskCompletion(); break;
                        case 7: TaskManager.DeleteTask(); break;
                        case 8: TaskManager.SearchTask(); break;
                        case 9: TaskManager.ProcessNextTask(); break;
                        case 10: complete = true;  break;
                        default: break;
                    }
                }
            }
        }

        
    }
}
