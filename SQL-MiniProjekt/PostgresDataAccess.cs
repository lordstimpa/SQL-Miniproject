using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_MiniProjekt
{
    // Following methods below make connections to the database
    public class PostgresDataAccess
    {
        // CONNECTION STRING
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // Method that retrieves information about PROJECTS
        internal static List<ProjectModel> LoadProject()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {         
                try
                {
                    var output = cnn.Query<ProjectModel>("SELECT * FROM sda_project", new DynamicParameters());
                    return output.ToList();
                }
                catch (PostgresException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
        }

        // Method that retrieves information about PERSONS
        internal static List<PersonModel> LoadPerson()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<PersonModel>("SELECT * FROM sda_person", new DynamicParameters());
                    return output.ToList();
                }
                catch (PostgresException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
        }

        // Method that retrieves INNER JOINS project_name with project_person table
        internal static List<ProjectPersonModel> LoadProjectPerson()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<ProjectPersonModel>("SELECT sda_project_person.*, sda_project.project_name FROM sda_project_person INNER JOIN sda_project ON sda_project_person.project_id = sda_project.id", new DynamicParameters());
                    return output.ToList();
                }
                catch (PostgresException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
        }

        // Method that inserts a new PROJECT
        internal static void AddProject(string project_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Query<ProjectModel>($"INSERT INTO sda_project (project_name) VALUES ('{project_name}')", new DynamicParameters());
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Method that inserts a new PERSON
        internal static void AddPerson(string person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Query<PersonModel>($"INSERT INTO public.sda_person (person_name) VALUES ('{person_name}')", new DynamicParameters());
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Method that inserts HOURS WORKED
        internal static void AddHours(ProjectPersonModel ProjectPerson)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {              
                try
                {
                    cnn.Query<PersonModel>("INSERT INTO public.sda_project_person (hours, project_id, person_id) VALUES (@hours, @project_id, @person_id)", ProjectPerson);
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Method that updates a PERSON
        internal static void EditPerson(PersonModel Person)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Query<PersonModel>("UPDATE sda_person SET person_name = @person_name WHERE id = @id", Person);
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Method that updates a PROJECT
        internal static void EditProject(ProjectModel Project)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Query<ProjectModel>("UPDATE sda_project SET project_name = @project_name WHERE id = @id", Project);
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Method that updates HOURS worked
        internal static void EditHours(ProjectPersonModel ProjectPerson)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Query<ProjectPersonModel>("UPDATE sda_project_person SET hours = @hours WHERE id = @id", ProjectPerson);
                }
                catch (PostgresException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
