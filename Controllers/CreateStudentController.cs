using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;


namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateStudentController : ControllerBase
    {
        [HttpPost]
        public string Post(Student students)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "<your_server>.database.windows.net";
            builder.UserID = "<your_username>";
            builder.Password = "<your_password>";
            builder.InitialCatalog = "<your_database>";
            try { 
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql = @"INSERT INTO [dbo].[ESTUDIANTES]
                                   ([NOMBRE]
                                   ,[EDAD]
                                   ,[DOCUMENTO]
                                   ,[TIPO_LICENCIA])
                                     VALUES
                                   ('" + students.name + "',"
                                   + students.age + ","
                                   + students.document + ","
                                   + "'" +students.licence + "')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
                return "Se agrego " + students.name + " correctamente";
            }
            catch (SqlException e)
            {
                return "error " + e.Message;
            }
        }
    }
}
