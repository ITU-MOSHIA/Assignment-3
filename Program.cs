using System;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInt;

            // Keep asking for input until the user enters a valid number
            while (true)
            {
                Console.WriteLine("Enter the number you want to convert:");

                // Try to read and convert user input to an integer
                if (int.TryParse(Console.ReadLine(), out userInt))
                {
                    // Check if the number is within the allowed range
                    if (userInt >= -9999 && userInt <= 9999)
                    {
                        // If it's valid, stop asking
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a number with 4 digits or less.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            // Convert the valid number to words and display the result
            Console.WriteLine(NumToWords(userInt));
        }

        // This function converts a number to words
        static string NumToWords(int number)
        {
            // If the number is 0, return "Zero"
            if (number == 0)
                return "Zero";

            // If the number is negative, add "Minus" and make it positive
            if (number < 0)
                return "Minus " + NumToWords(Math.Abs(number));

            string words = "";

            // Handle thousands place
            if ((number / 1000) > 0)
            {
                words += NumToWords(number / 1000) + " Thousand ";
                number %= 1000; // Remove thousands place
            }

            // Handle hundreds place
            if ((number / 100) > 0)
            {
                words += NumToWords(number / 100) + " Hundred ";
                number %= 100; // Remove hundreds place
            }

            // Handle tens and units places
            if (number > 0)
            {
                if (words != "")
                    words += ""; // No extra space needed

                // Maps for numbers less than 20 and multiples of ten
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                // Numbers less than 20 have unique names
                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    // Use tens map for numbers 20 and above
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10]; // Add hyphen for numbers like "Twenty-One"
                }
            }

            // Remove extra spaces and return the result
            return words.Trim();
        }
    }
}

