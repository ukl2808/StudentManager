StudentManager studentManager = new StudentManager();
studentManager.AddStudent(new Student("John", "Doe", 20, 2));
studentManager.AddStudent(new Student("Jane", "Smith", 22, 3));
studentManager.AddStudent(new Student("Michael", "Johnson", 19, 1));
studentManager.AddStudent(new Student("Emily", "Williams", 21, 3));
studentManager.AddStudent(new Student("David", "Brown", 20, 2));

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Remove Student");
    Console.WriteLine("3. Get Students by Year");
    Console.WriteLine("4. Get Oldest Student");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");

    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input. Please enter a valid option.");
        continue;
    }

    switch (choice)
    {
        case 1:
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();

            int age;
            if (!GetIntInput("Enter Age: ", out age))
            {
                Console.WriteLine("Invalid input for Age. Student not added.");
                continue;
            }

            int year;
            if (!GetIntInput("Enter Year: ", out year))
            {
                Console.WriteLine("Invalid input for Year. Student not added.");
                continue;
            }

            Student student = new Student(name, surname, age, year);
            studentManager.AddStudent(student);
            Console.WriteLine("Student added.");
            break;

        case 2:
            Console.WriteLine("Enter the student's name to remove:");
            string nameToRemove = Console.ReadLine();

            Student studentToRemove = studentManager.GetStudentsByYear(0).FirstOrDefault(s => s.Name == nameToRemove);
            if (studentToRemove != null)
            {
                studentManager.RemoveStudent(studentToRemove);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            break;

        case 3:
            int yearToGet;
            if (!GetIntInput("Enter Year to get students from: ", out yearToGet))
            {
                Console.WriteLine("Invalid input for Year.");
                continue;
            }

            var studentsByYear = studentManager.GetStudentsByYear(yearToGet);
            Console.WriteLine($"Students from Year {yearToGet}:");
            foreach (var s in studentsByYear)
            {
                Console.WriteLine(s);
            }
            break;

        case 4:
            Student oldestStudent = studentManager.GetOldestStudent();
            if (oldestStudent != null)
            {
                Console.WriteLine("Oldest Student:");
                Console.WriteLine(oldestStudent);
            }
            else
            {
                Console.WriteLine("No students found.");
            }
            break;

        case 5:
            Console.WriteLine("Program completed.");
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

    static bool GetIntInput(string message, out int value)
{
    Console.Write(message);
    return int.TryParse(Console.ReadLine(), out value);
}