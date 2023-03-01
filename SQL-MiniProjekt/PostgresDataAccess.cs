using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_MiniProjekt
{
    public class PostgresDataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

    /*
    public static List<StudentModel> LoadStudents()
    {
        using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
        {
            var output = cnn.Query<StudentModel>("SELECT * FROM sda_student", new DynamicParameters());
            return output.ToList();
        }
    }
    */
}
