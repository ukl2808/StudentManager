class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public List<Student> GetStudentsByYear(int year)
    {
        return students.Where(student => student.Year == year).ToList();
    }

    public Student GetOldestStudent()
    {
        return students.OrderByDescending(student => student.Age).FirstOrDefault();
    }
}
