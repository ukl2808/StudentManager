class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }

    public Student(string name, string surname, int age, int year)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Name} {Surname}, Age: {Age}, Year: {Year}";
    }
}
