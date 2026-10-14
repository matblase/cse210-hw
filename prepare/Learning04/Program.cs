using System;

namespace Learning04;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment assignment1 = new Assignment("Cori Matute", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        
        MathAssignment assignment2 = new MathAssignment("Mariela Matute", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        
        WritingAssignment assignment3 = new WritingAssignment("Elizabeth Clark", "European History", "The Causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}