using Microsoft.Data.SqlClient;

namespace CourseManagementPortal
{
        internal class Course
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Duration { get; set; } //in month
            public double Price { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime ModificationTime { get; set; }
        }


        internal static class CourseManager
        {
            internal static void Add()
            {
               
            }

            internal static List<Course> GetCourses()
            {
                var list = new List<Course>();

                using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
                {


                    connection.Open();

                    var cmd = connection.CreateCommand();

                    cmd.CommandText = @"select * from tableCourse";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var course = new Course()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Duration = dr.GetInt32(2),
                            Price = (double)dr.GetDecimal(3),
                            CreationTime = dr.GetDateTime(4),
                        };

                        if (!(dr.IsDBNull(5)))
                            course.ModificationTime = dr.GetDateTime(5);

                        list.Add(course);
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
