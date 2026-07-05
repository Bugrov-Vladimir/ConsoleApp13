using System;
using System.Collections.Generic;


namespace CSharpEssentials
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
    public class School
    {
        public string Name;
        public List<Student> Students;
        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"Пока в школе {Name} нет учеников");
            }
            else
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10}", "Номер", "Имя", "Фамилия", "Возраст");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10}", $"{i + 1}", Students[i].FirstName, Students[i].LastName, Students[i].Age);
                }
            }
        }

        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.FirstName} успешно добавлен в школу {Name}");
        }
        public void DeleteStudent(int index)
        {
            if (index >= 0 && index < Students.Count)

            {
                Console.WriteLine($"Студент {Students[index].FirstName}, находящийся под индексом {index + 1} был удалён из школы {Name}.");
                Students.RemoveAt(index);
            }
            else

            {
                Console.WriteLine($"В школе {Name} нет ученика с таким индексом.");
            }
        }
    }
    class Program
    {
        public static object FirstName { get; private set; }
        public static object Name { get; private set; }

        static void Main()
        {
            Console.WriteLine("Здравствуйте, введите название школы");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешно создана");
            while (true)
            {
                Console.WriteLine($"Хотите посмотреть список учеников школы {school.Name}? Введите да или нет");
                string userAnswer = GetAnswer();

                if (userAnswer == "да")
                {
                    school.PrintStudents();
                }
                Console.WriteLine($"Хотите добавить нового ученика школы  {school.Name}? Введите да или нет");
                userAnswer = GetAnswer();
                if (userAnswer == "да")
                {
                    Console.WriteLine($"Введите имя ученика");
                    string firstName = Console.ReadLine();
                    Console.WriteLine($"Введите фамилию ученика");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введите возраст ученика");
                    int age = int.Parse(Console.ReadLine());
                    Student student = new Student(firstName, lastName, age);
                    school.AddNewStudent(student);
                }
                Console.WriteLine($"Хотите удалить ученика из школы  {school.Name}? Введите да или нет");
                userAnswer = GetAnswer();
                if (userAnswer == "да")
                {

                    Console.WriteLine("Введите индекс ученика, которого хотите удалить. нумерация, начинается с 1.");

                    int index = int.Parse(Console.ReadLine());

                    int index1 = index - 1;// для нумерации, начиная с 1

                    school.DeleteStudent(index1);

                }
            }

        }

        public static string GetAnswer()
        {
            return Console.ReadLine().ToLower();
        }
    }
}