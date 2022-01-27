using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementPortal
{
    internal class OngoingCourse
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    static internal class OngoingCourseManager
    {
        static internal List<OngoingCourse> GetAll()
        {
            var list = new List<OngoingCourse>();


            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select * from tableOngoingCourses";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var course = new OngoingCourse()
                    {
                        StudentId = dr.GetInt32(0),
                        TeacherId = dr.GetInt32(1),
                        CourseId = dr.GetInt32(2)
                    };


                    if (!(dr.IsDBNull(3)))
                        course.StartDate = dr.GetDateTime(3);

                    if (!(dr.IsDBNull(4)))
                        course.EndDate = dr.GetDateTime(4);

                    list.Add(course);
                }
            }

            return list;
        }
    }
}
