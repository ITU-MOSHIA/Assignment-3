using System;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number you want to convert:");
            int userInt = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(NumToWords(userInt));
        }

        static string NumToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumToWords(Math.Abs(number));

            string words = "";

            // Thousands place
            if ((number / 1000) > 0)
            {
                words += NumToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            // Hundreds place
            if ((number / 100) > 0)
            {
                words += NumToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            // Tens and units place
            if (number > 0)
            {
                if (words != "")
                    words += "";

                // Arrays for single-digit numbers and tens multiples
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    // If the number is 20 or more, use the tens array
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            // Trim any extra spaces and return the final words
            return words.Trim();
        }
    }
}