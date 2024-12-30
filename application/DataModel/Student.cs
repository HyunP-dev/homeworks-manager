namespace application.DataModel
{
    public class Student
    {
        public required string Name { get; set; }
        public int Number { get; set; }

        public Student(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Student {{ Name: {Name}, Number: {Number} }}";
        }
    }
}
