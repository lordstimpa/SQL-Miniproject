using SQL_MiniProjekt;

namespace SQLMiniProjekt;
class Program
{
    static void Main(string[] args)
    {
        RunProgram();
    }

    // Method for displaying the main menu which is used for navigating to
    // all of the different functions that this program consist of.
    // Each specific function is called within this method.
    static void RunProgram()
    {
        bool repeat = true;

        do
        {
            Console.Clear();
            Console.WriteLine("\n ==| Welcome to the SQL - Miniproject |==");
            Console.WriteLine("\n Kindly enter an option shown below: \n");
            Console.WriteLine(" [1] Register");
            Console.WriteLine(" [2] Create");
            Console.WriteLine(" [3] Edit");
            Console.WriteLine(" [E] Exit");
            Console.Write("\n ---> ");
            string input = Console.ReadLine();

            switch (input)
            {
                // Register time worked
                case "1":
                    RegisterInfo();
                    break;

                // Add Person / Project
                case "2":
                    CreateInfo();
                    break;

                // Edit Person / Project / Hours
                case "3":
                    EditInfo();
                    break;

                // EXIT Program
                case "E":
                case "e":
                    Console.Clear();
                    Console.WriteLine("\n Thank you for using this application.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                    repeat = false;
                    break;

                // ERROR catch
                default:
                    Console.Clear();
                    Console.WriteLine(" Invalid input.\n Please enter an option from the menu.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                    break;
            }

        } while (repeat);
    }

    // Method for registering WORKED TIME
    static void RegisterInfo()
    {
        List<PersonModel> Persons = PostgresDataAccess.LoadPerson();
        List<ProjectModel> Projects = PostgresDataAccess.LoadProject();

        Console.Clear();
        Console.WriteLine("\n ==| Register Time Worked |==");
        Console.WriteLine("\n Kindly enter a person shown below:\n");

        for (int i = 0; i < Persons.Count; i++)
        {
            Console.WriteLine($" [{i + 1}] {Persons[i].person_name}");
        }

        Console.Write("\n ---> ");
        string personInput = Console.ReadLine();
        bool success = int.TryParse(personInput, out int personInputInt);

        if (success && personInputInt >= 1 && personInputInt <= Persons.Count())
        {
            Console.Clear();
            Console.WriteLine($"\n ==| Register Time Worked for {Persons[personInputInt - 1].person_name} |==");
            Console.WriteLine("\n Kindly enter a project shown below:\n");

            for (int i = 0;i < Projects.Count; i++)
            {
                Console.WriteLine($" [{i + 1}] {Projects[i].project_name}");
            }

            Console.Write("\n ---> ");
            string projectInput = Console.ReadLine();
            bool success2 = int.TryParse(projectInput, out int projectInputInt);
            
            if (success2 && projectInputInt >= 1 && projectInputInt <= Projects.Count())
            {
                Console.Clear();
                Console.WriteLine($"\n ==| Register Time Worked for {Persons[personInputInt - 1].person_name} |==");
                Console.WriteLine("\n Kindly enter the time worked in HOURS: ");
                Console.Write("\n ---> ");
                string timeInput = Console.ReadLine();
                bool success3 = int.TryParse(timeInput, out int timeInputInt);

                if (success3 && timeInputInt > 0)
                {
                    ProjectPersonModel model = new ProjectPersonModel()
                    {
                        hours = timeInputInt,
                        project_id = Projects[projectInputInt - 1].id,
                        person_id = Persons[personInputInt - 1].id
                    };                 

                    PostgresDataAccess.AddHours(model);
                    Console.Clear();
                    Console.WriteLine("\n Hours worked has been registered to the database successfully.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                }
                else
                {
                    // ERROR catch
                    Console.Clear();
                    Console.WriteLine("\n Invalid input.\n Please enter time worked in hours.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                // ERROR catch
                Console.Clear();
                Console.WriteLine("\n Invalid input.\n Please enter an option from the menu.");
                Console.Write("\n Press any key to continue.");
                Console.ReadLine();
            }
        }
        else
        {
            // ERROR catch
            Console.Clear();
            Console.WriteLine("\n Invalid input.\n Please enter an option from the menu.");
            Console.Write("\n Press any key to continue.");
            Console.ReadLine();
        }
    }

    // Method for creating/adding new PROJECTS or PEOPLE to the database
    static void CreateInfo()
    {
        bool repeat = true;
        do
        {
            Console.Clear();
            Console.WriteLine("\n ==| Submenu for adding information |==");
            Console.WriteLine("\n Enter an option below:\n");
            Console.WriteLine(" [1] Add person");
            Console.WriteLine(" [2] Add project");
            Console.WriteLine(" [E] Exit");
            Console.Write("\n ---> ");
            string input = Console.ReadLine();

            switch (input)
            {
                // Contains information which is displayed to the user
                // on how to add a NEW PERSON to the database.
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n ==| Add a new person |==");
                    Console.WriteLine("\n Enter the name of the person you want to add.");
                    Console.Write("\n ---> ");
                    string personName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(personName))
                    {
                        // ERROR catch
                        Console.WriteLine("\n Input not valid. Please try again.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        // Calls upon the method which connects to the database
                        PostgresDataAccess.AddPerson(personName);
                        Console.WriteLine($"\n {personName} has been added to the database successfully.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                        repeat = false;
                    }
                    break;

                // Contains information that is displayed to the user
                // on how to add a NEW PROJECT to the database.
                case "2":
                    Console.Clear();
                    Console.WriteLine("\n ==| Add a new project |==");
                    Console.WriteLine("\n Enter the name of the project you want to add.");
                    Console.Write("\n ---> ");
                    string projectName = Console.ReadLine();    
                    
                    if (string.IsNullOrWhiteSpace(projectName))
                    {
                        // ERROR catch
                        Console.WriteLine("\n Input not valid. Please try again.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        // Call upon the method which connects to the database
                        PostgresDataAccess.AddProject(projectName);                  
                        Console.WriteLine($"\n {projectName} has been added to the database successfully.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                        repeat = false;
                    }
                    break;

                // EXIT submenu
                case "E":
                case "e":
                    repeat = false;
                    break;

                // ERROR catch
                default:
                    Console.Clear();
                    Console.WriteLine(" Invalid input.\n Please enter an option from the submenu.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                    break;
            }

        } while (repeat);
    }

    // Method for editing existing information about projects/people
    // and on the time that has been spent on projects.
    static void EditInfo()
    {
        List<PersonModel> Persons = PostgresDataAccess.LoadPerson();
        List<ProjectModel> Projects = PostgresDataAccess.LoadProject();
        List<ProjectPersonModel> ProjectPersons = PostgresDataAccess.LoadProjectPerson();
        bool repeat = true;

        do
        {
            Console.Clear();
            Console.WriteLine("\n ==| Edit Information |==");
            Console.WriteLine("\n Enter what you wish to edit:\n");
            Console.WriteLine(" [1] Person");
            Console.WriteLine(" [2] Project");
            Console.WriteLine(" [3] Hours");
            Console.WriteLine(" [E] Exit");
            Console.Write("\n ---> ");
            string input = Console.ReadLine();

            switch (input)
            {
                // EDIT person name
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n ==| Edit Person |==");
                    Console.WriteLine("\n Enter person to edit:\n");

                    for (int i = 0; i < Persons.Count(); i++)
                    {
                        Console.WriteLine($" [{i+1}] {Persons[i].person_name}");
                    }          

                    Console.Write("\n ---> ");
                    string personInput = Console.ReadLine();
                    bool success = int.TryParse(personInput, out int personInputInt);

                    if (success && personInputInt >= 1 && personInputInt <= Persons.Count())
                    {
                        Console.Write("\n Enter a new person name: ");
                        string newPersonName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newPersonName))
                        {
                            // ERROR catch
                            Console.WriteLine("\n Input not valid. Please try again.");
                            Console.Write("\n Press any key to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Calls upon the method which connects to the database
                            Persons[personInputInt - 1].person_name = newPersonName;
                            PostgresDataAccess.EditPerson(Persons[personInputInt - 1]);
                            Console.WriteLine($"\n {newPersonName} has been updated successfully.");
                            Console.Write("\n Press any key to continue.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        // ERROR catch
                        Console.Clear();
                        Console.WriteLine("\n Invalid input.\n Please enter an option from the menu.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                    }
                    break;

                // EDIT project name
                case "2":
                    Console.Clear();
                    Console.WriteLine("\n ==| Edit Project |==");
                    Console.WriteLine("\n Enter project to edit:\n");

                    for (int i = 0; i < Projects.Count(); i++)
                    {
                        Console.WriteLine($" [{i + 1}] {Projects[i].project_name}");
                    }

                    Console.Write("\n ---> ");
                    string projectInput = Console.ReadLine();
                    bool success2 = int.TryParse(projectInput, out int projectInputInt);

                    if (success2 && projectInputInt >= 1 && projectInputInt <= Persons.Count())
                    {
                        Console.Write("\n Enter a new project name: ");
                        string newProjectName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newProjectName))
                        {
                            // ERROR catch
                            Console.WriteLine("\n Input not valid. Please try again.");
                            Console.Write("\n Press any key to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Calls upon the method which connects to the database
                            Projects[projectInputInt -1].project_name = newProjectName;
                            PostgresDataAccess.EditProject(Projects[projectInputInt - 1]);
                            Console.WriteLine($"\n {newProjectName} has been updated successfully.");
                            Console.Write("\n Press any key to continue.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        // ERROR catch
                        Console.Clear();
                        Console.WriteLine("\n Invalid input.\n Please enter an option from the menu.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                    }
                    break;

                // EDIT worked hours 
                case "3":
                    Console.Clear();
                    Console.WriteLine("\n ==| Edit Hours Worked |==");
                    Console.WriteLine("\n Enter person to edit registered time:\n");

                    for (int i = 0; i < Persons.Count(); i++)
                    {
                        Console.WriteLine($" [{i + 1}] {Persons[i].person_name}");
                    }

                    Console.Write("\n ---> ");
                    string personInput2 = Console.ReadLine();
                    bool success3 = int.TryParse(personInput2, out int personInputInt2);

                    if (success3 && personInputInt2 >= 1 && personInputInt2 <= Persons.Count())
                    {
                        int i = 1;
                        List<ProjectPersonModel> timeList = new List<ProjectPersonModel>();

                        Console.Clear();
                        Console.WriteLine("\n ==| Edit Hours Worked |==");
                        Console.WriteLine("\n Enter a registration number to edit:\n");

                        foreach (ProjectPersonModel projectPerson in ProjectPersons)
                        {
                            if (projectPerson.person_id == Persons[personInputInt2 - 1].id)
                            {
                                timeList.Add(projectPerson);
                                Console.WriteLine($" [{i++}] Registration | Worked hours: {projectPerson.hours}");
                            }
                        }

                        if (timeList.Count == 0)
                        {
                            // ERROR catch
                            Console.Clear();
                            Console.WriteLine($"\n {Persons[personInputInt2 - 1].person_name} has not registered any worked time.");
                            Console.Write("\n Press any key to continue.");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.Write("\n ---> ");
                            string rowInput = Console.ReadLine();
                            bool success4 = int.TryParse(rowInput, out int rowInputInt);

                            if (success4 && rowInputInt >= 1 && rowInputInt <= timeList.Count())
                            {
                                Console.Write("\n Enter new hours worked: ");
                                string newHoursWorked = Console.ReadLine();
                                bool success5 = int.TryParse(newHoursWorked, out int newHoursWorkedInt);

                                if (success5 && newHoursWorkedInt >= 1 && newHoursWorkedInt <= 24)
                                {
                                    // Calls upon the method which connects to the database
                                    timeList[rowInputInt - 1].hours = newHoursWorkedInt;
                                    PostgresDataAccess.EditHours(timeList[rowInputInt - 1]);
                                    Console.WriteLine($"\n {Persons[personInputInt2 - 1].person_name} hours has been updated successfully.");
                                    Console.Write("\n Press any key to continue.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    // ERROR catch
                                    Console.WriteLine("\n Hours cannot be less than 1 or exceed 24 hours.");
                                    Console.Write("\n Press any key to continue.");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                // ERROR catch
                                Console.Clear();
                                Console.WriteLine("\n Invalid input.\n Please enter an option from the submenu.");
                                Console.Write("\n Press any key to continue.");
                                Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        // ERROR catch
                        Console.Clear();
                        Console.WriteLine("\n Invalid input.\n Please enter an option from the submenu.");
                        Console.Write("\n Press any key to continue.");
                        Console.ReadLine();
                    }
                    break;

                // EXIT submenu
                case "E":
                case "e":
                    repeat = false;
                    break;

                // ERROR catch
                default:
                    Console.Clear();
                    Console.WriteLine(" Invalid input.\n Please enter an option from the submenu.");
                    Console.Write("\n Press any key to continue.");
                    Console.ReadLine();
                    break;
            } 

        } while (repeat);
    }
}