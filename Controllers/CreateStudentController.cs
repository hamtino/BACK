using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateStudentController : ControllerBase
    {
        //variables para credenciales sql server
        public string DataSource = "<your_server>.database.windows.net";
        public string UserID = "<your_username>";
        public string Password = "<your_password>";
        public string InitialCatalog = "<your_database>";

        [HttpPost]
        public string Post(Student students)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.UserID = UserID;
            builder.Password = Password;
            builder.InitialCatalog = InitialCatalog;

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

        [HttpGet]
        public List<Student> Get()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.UserID = UserID;
            builder.Password = Password;
            builder.InitialCatalog = InitialCatalog;
            List<Student> ListStudents = new List<Student>();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql = @"SELECT [ID]
                                   ,[NOMBRE]
                                   ,[EDAD]
                                   ,[DOCUMENTO]
                                   ,[TIPO_LICENCIA] FROM [dbo].[ESTUDIANTES]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListStudents.Add(new Student
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    age = reader.GetInt32(2),
                                    document = reader.GetInt64(3),
                                    licence = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
                return ListStudents;
            }
            catch (SqlException e)
            {
                return ListStudents;
            }
        }
        [HttpDelete]
        public string Delete(int ID)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.UserID = UserID;
            builder.Password = Password;
            builder.InitialCatalog = InitialCatalog;
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql = @"DELETE FROM [dbo].[ESTUDIANTES]
                                WHERE ID = " + ID;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                            }
                        }
                    }
                }
                return "Se elimino correctamente";
            }
            catch (SqlException e)
            {
                return "error " + e.Message;
            }
        }
    }
}
