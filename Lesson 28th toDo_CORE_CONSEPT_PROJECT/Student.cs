using Microsoft.Data.SqlClient;

namespace CourseManagementPortal
{

        internal class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime ModificationTime { get; set; }
            
        }

        internal class StudentManager
        {
            internal void Add()
            {
                
                Student student = new Student();
                GetStudents().Add(student);
            }

            internal static List<Student> GetStudents()
            {
                var list = new List<Student>();

                using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();

                    cmd.CommandText = @"select * from tableStudent";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var student = new Student()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Surname = dr.GetString(2),
                            BirthDate = dr.GetDateTime(3),
                            CreationTime = dr.GetDateTime(4)
                        };


                        if (!(dr.IsDBNull(5)))
                            student.ModificationTime = dr.GetDateTime(5);

                        list.Add(student);
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

