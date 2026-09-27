using System;
using System.Linq;
class LevelOne

{
    public static void Main(string[] args)
    {
        var numbers = new[] { 1, 5, 8, 10, 13, 20 };
        var greaterThanFive = numbers.Where(number => number > 5)
                                     .OrderByDescending(number => number);

        Console.WriteLine("Numbers greater than 5 in descending order:");
        foreach (var number in greaterThanFive)
        {
            Console.WriteLine(number);
        }
        
        var allNumbersPositive = numbers.All(number => number > 0);

        var divisibleBySeven = numbers.Any(number => number % 7 == 0);

        Console.WriteLine($"All numbers are positive: {allNumbersPositive}");

        Console.WriteLine($"There is a number divisible by 7: {divisibleBySeven}");
        
    }
}