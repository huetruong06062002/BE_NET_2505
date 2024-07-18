using System;
using System.Collections.Generic;
using System.Linq;

namespace BE_NET_2505
{
    // Bài 1: Generic Stack Class
    public class MyStack<T>
    {
        private List<T> elements = new List<T>();

        public void Push(T item)
        {
            elements.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The stack is empty.");
            T item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The stack is empty.");
            return elements[elements.Count - 1];
        }

        public bool IsEmpty()
        {
            return elements.Count == 0;
        }
    }

    // Bài 2: Student Class
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
    }

    public class Bai26
    {
        public void TestMyStack()
        {
            // Testing MyStack with different data types
            MyStack<int> intStack = new MyStack<int>();

            Console.WriteLine("Enter integers to push to the stack (type 'exit' to stop):");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

                if (int.TryParse(input, out int value))
                {
                    intStack.Push(value);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }

            Console.WriteLine("Popping from stack...");
            while (!intStack.IsEmpty())
            {
                Console.WriteLine(intStack.Pop());
            }

            Console.WriteLine("Stack is empty: " + intStack.IsEmpty());
        }

        public void ManageStudents()
        {
            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();

            Console.WriteLine("Enter student details (type 'exit' to stop):");
            while (true)
            {
                Console.Write("Enter student ID: ");
                string idInput = Console.ReadLine();
                if (idInput.ToLower() == "exit")
                    break;

                if (!int.TryParse(idInput, out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter an integer.");
                    continue;
                }

                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter student grade: ");
                string gradeInput = Console.ReadLine();
                if (!double.TryParse(gradeInput, out double grade))
                {
                    Console.WriteLine("Invalid grade. Please enter a numeric value.");
                    continue;
                }

                studentDictionary[id] = new Student { ID = id, Name = name, Grade = grade };
            }

            if (studentDictionary.Count > 0)
            {
                // Finding the student with the highest grade
                var highestGradeStudent = studentDictionary.Values.OrderByDescending(s => s.Grade).FirstOrDefault();
                Console.WriteLine($"Student with highest grade: {highestGradeStudent.Name} - {highestGradeStudent.Grade}");

                // Getting list of students with grade greater than a given value
                Console.Write("Enter the grade threshold: ");
                double threshold = double.Parse(Console.ReadLine());
                var highGradeStudents = studentDictionary.Values.Where(s => s.Grade > threshold).Select(s => s.Name).ToList();
                Console.WriteLine("Students with grade greater than " + threshold + ": " + string.Join(", ", highGradeStudents));

                // Counting number of students with grade average or above (assuming average is 70)
                double averageGrade = 70;
                int countAverageOrAbove = studentDictionary.Values.Count(s => s.Grade >= averageGrade);
                Console.WriteLine($"Number of students with grade average or above: {countAverageOrAbove}");
            }
            else
            {
                Console.WriteLine("No students were entered.");
            }
        }
    }
}
