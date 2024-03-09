/** 
 *  Student Grade Calculator
 *  
 *  This program allows users to calculate the final grades of students based on their preliminary, midterm, and final term scores. 
 *  It also determines if a student has passed or failed based on their average grade.
 *  
 *  Author: PP-Namias
 *  
 *  Licensed under the MIT License
 *  
 *  Activity#2: 
 *  Create a C# program that will search at least 3 students' records, 
 *  if found it will compute the final grades of the students 
 *  by entering the PRELIM, MIDTERM & FINAL TERM and the Final Grades is the 
 *  average of the 3 grades you have entered, and then by the determining 
 *  the average of the students if the average is less than 75 it will display the word "FAILED" 
 *  but if the average is more than 75 it will display "PASSED".
 */


using System;

class Program
{
    static string[] studentNames = new string[100];
    static double[,] studentGrades = new double[100, 3];
    static int numberOfStudents = 0;

    static void Main(string[] args)
    {

        Console.WriteLine("   _____ _             _            _      _____               _         _____      _            _       _             ");
        Console.WriteLine("  / ____| |           | |          | |    / ____|             | |       / ____|    | |          | |     | |            ");
        Console.WriteLine(" | (___ | |_ _   _  __| | ___ _ __ | |_  | |  __ _ __ __ _  __| | ___  | |     __ _| | ___ _   _| | __ _| |_ ___  _ __ ");
        Console.WriteLine("  \\___ \\| __| | | |/ _` |/ _ \\ '_ \\| __| | | |_ | '__/ _` |/ _` |/ _ \\ | |    / _` | |/ __| | | | |/ _` | __/ _ \\| '__|");
        Console.WriteLine("  ____) | |_| |_| | (_| |  __/ | | | |_  | |__| | | | (_| | (_| |  __/ | |___| (_| | | (__| |_| | | (_| | || (_) | |   ");
        Console.WriteLine(" |_____/ \\__|\\__,_|\\__,_|\\___|_| |_|\\__| \\_____|_|  \\__,_|\\__,_|\\___|  \\_____|\\__,_|_|\\___|\\__,_|_|\\__,_|\\__\\___/|_|  ");

        while (true)
        {


            Console.WriteLine(" ");

            Console.WriteLine("[ 1 ] Enter student grades");
            Console.WriteLine("[ 2 ] Search for student records");
            Console.WriteLine("[ 3 ] Exit");
            Console.WriteLine(" ");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterStudentGrades();
                    break;
                case 2:
                    SearchForStudentRecords();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void EnterStudentGrades()
    {
        Console.WriteLine(" ");

        Console.WriteLine("Enter Student Names and Grades:");

        Console.Write("Student Name: ");
        string name = Console.ReadLine();
        studentNames[numberOfStudents] = name;

        Console.Write("Prelim Grade: ");
        double prelimGrade = double.Parse(Console.ReadLine());
        studentGrades[numberOfStudents, 0] = prelimGrade;

        Console.Write("Midterm Grade: ");
        double midtermGrade = double.Parse(Console.ReadLine());
        studentGrades[numberOfStudents, 1] = midtermGrade;

        Console.Write("Final Term Grade: ");
        double finalGrade = double.Parse(Console.ReadLine());
        studentGrades[numberOfStudents, 2] = finalGrade;

        double averageGrade = (prelimGrade + midtermGrade + finalGrade) / 3;
        Console.WriteLine($"Average Grade: {averageGrade}");

        string result = (averageGrade >= 75) ? "PASSED" : "FAILED";
        Console.WriteLine($"Result: {result}");

        numberOfStudents++;
    }

    static void SearchForStudentRecords()
    {
        if (numberOfStudents == 0)
        {
            Console.WriteLine("No student records found.");
            return;
        }

        Console.WriteLine(" ");

        Console.WriteLine("List of Student Records:");
        Console.WriteLine("Student Number\tStudent Name");
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"{i + 1}\t\t{studentNames[i]}");
        }

        Console.WriteLine(" ");

        Console.Write("Enter the student number to search or 0 to exit: ");
        int searchChoice = int.Parse(Console.ReadLine());

        if (searchChoice == 0)
            return;

        if (searchChoice > 0 && searchChoice <= numberOfStudents)
        {
            int studentIndex = searchChoice - 1;
            Console.WriteLine($"Student Name: {studentNames[studentIndex]}");
            Console.WriteLine($"Prelim Grade: {studentGrades[studentIndex, 0]}");
            Console.WriteLine($"Midterm Grade: {studentGrades[studentIndex, 1]}");
            Console.WriteLine($"Final Term Grade: {studentGrades[studentIndex, 2]}");

            double averageGrade = (studentGrades[studentIndex, 0] + studentGrades[studentIndex, 1] + studentGrades[studentIndex, 2]) / 3;
            Console.WriteLine($"Average Grade: {averageGrade}");

            string result = (averageGrade >= 75) ? "PASSED" : "FAILED";
            Console.WriteLine($"Result: {result}");
        }
        else
        {
            Console.WriteLine("Invalid student number.");
        }
    }
}
