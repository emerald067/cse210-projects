using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Create a list to store the numbers
        List<int> numbers = new List<int>();
        int usernumber = -1;
        Console.WriteLine("Enter a list of number, type 0 when finished. ");
        while (usernumber != 0)
        {
            //Get the number from the user:
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            usernumber = int.Parse(input);

            //Append the number to the list if it is not 0
            if (usernumber != 0)
            {
                numbers.Add(usernumber);
            }
        }
        //Calculate the sum and average of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");

        //Find the largest number in the list
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        //Find the smallest number in the list
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        Console.WriteLine($"The smallest number is: {smallestPositive}");

        //sort the list
        numbers.Sort();
        Console.Write("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number} ");
        }

    }
}