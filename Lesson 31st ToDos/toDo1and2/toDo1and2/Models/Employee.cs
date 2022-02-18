namespace toDo1and2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
    }
}