using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementPortal
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string CanTeach1 { get; set; }
        public string CanTeach2 { get; set; }
        public string CanTeach3 { get; set; }
    }

    internal static class TeacherManager
    {

        const string connectionString = @"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True";


        internal static void Add()
        {

        }

        internal static List<Teacher> GetTeachers()
        {
            var list = new List<Teacher>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select * from tableTeacher";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var teacher = new Teacher()
                    {
                        Id = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        Surname = dr.GetString(2),
                        BirthDate = dr.GetDateTime(3),
                        CanTeach1 = dr.GetString(4),
                        CanTeach2 = dr.GetString(5),
                        CanTeach3 = dr.GetString(6)
                    };

                    list.Add(teacher);
                }
            }

            return list;
        }

        internal static void Update()
        {

        }
        internal static void Delete()
        {

        }
    }
}