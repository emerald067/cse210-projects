using System;

class Program
{
    static void Main(string[] args)
    {
        //get the gradepercentage from the user.
        Console.Write("Please enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letter = "";
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // get the last digit.
        int lastDigit = gradePercentage % 10;
        string sign = "";
        if (gradePercentage >= 7)
        {
            sign = "+";
        }
        else if (gradePercentage <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // handle exceptions (A+, F+ and F-)
        if (gradePercentage >= 90)
        {
            sign = "";
        }
        else if (gradePercentage <= 50)
        {
            sign = "";
        }
        
        // display the grade

        Console.WriteLine($"Your grade is: {letter}{sign}. ");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have not passed the course. Better luck next time!");
        }
    }
}