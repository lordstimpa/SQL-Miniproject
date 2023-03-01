namespace SQLMiniProjekt;
class Program
{
    static void Main(string[] args)
    {
        RunProgram();
    }

    static void RunProgram()
    {
        bool repeat = true;

        do
        {
            Console.Clear();
            Console.WriteLine("\n Welcome to the SQL - Miniproject");
            Console.WriteLine("\n Kindly enter an option shown below: ");
            Console.WriteLine(" 1. Display History");
            Console.WriteLine(" 2. Register time worked");
            Console.WriteLine(" 3. Register Person");
            Console.WriteLine(" 4. Register Project");
            Console.WriteLine(" 5. Exit");

            Console.Write("\n --->");
            string input = Console.ReadLine();

            bool success = int.TryParse(input, out int inputInt);

            if (success && inputInt > 0 && inputInt < 6)
            {
                switch (inputInt)
                {
                    case 1:
                        DisplayHistory();
                        break;

                    case 2:
                        RegisterTime();
                        break;

                    case 3:
                        RegisterPerson();
                        break;

                    case 4:
                        RegisterProject();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("\n Thank you for using this application.");
                        Console.WriteLine("\n Press any key to continue.");
                        Console.ReadLine();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n Error has accured, please try again.");
                        Console.WriteLine("\n Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine(" Invalid input.\n Please enter an option from the menu.");
            }

        } while (repeat);
    }

    static void DisplayHistory()
    {

    }
    
    static void RegisterTime()
    {

    }

    static void RegisterPerson()
    {

    }

    static void RegisterProject()
    {

    }
}