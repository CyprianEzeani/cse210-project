using System;

using System.Collections.Generic;

using System.Linq;

class Program {
    static void Main(string[] args) {
        List<double> numbers = new List<double>();

        // Ask the user for a series of numbers and add them to the List
        double input = 1.0;
        while (input != 0) {
            Console.Write("Enter a number (0 to stop): ");
            input = Convert.ToDouble(Console.ReadLine());
            if (input != 0) {
                numbers.Add(input);
            }
        }

        //  Compute the sum of the numbers in the list
        double sum = numbers.Sum();

        // Compute the average of the numbers in the list
        double average = numbers.Average();

        // Find the maximum value in the list
        double max = numbers.Max();

        // Find the positive number closest to zero in the list
        double closestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().OrderBy(n => Math.Abs(n)).First();

        // Sort the numbers in the list and display the sorted list
        numbers.Sort();
        Console.Write("Sorted number: ");
        foreach (double number in numbers) {
            Console.Write(numbers + " ");
        }
        Console.WriteLine();

        // output the results
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Max: " + max);
        Console.WriteLine("Positive number closest to zero: " + closestPositive);
    }

}