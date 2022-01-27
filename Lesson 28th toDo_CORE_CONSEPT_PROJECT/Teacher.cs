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
        public string Profession { get; set; }
    }

    internal static class TeacherManager
    {
        internal static void Add()
        {

        }

        internal static List<Teacher> GetTeachers()
        {
            var list = new List<Teacher>();

            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
                        Profession = dr.GetString(4)
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